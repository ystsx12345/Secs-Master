using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace Secs_Socket
{
   public class AppSession
    {

        public string RemoteIP { get; set; }

        public int RemotePort { get; set; }

        public bool AutoReConnect { get; set; }  // 发送时自动重连

        public int ReConnectCount { get; set; } = 3;  // 自动重连次数

        public int ReConnectDelay { get; set; } = 1000;

        public byte[] EndByte { get; set; } = new byte[2] { 0x0D, 0x0A };

        public event Action<byte[]> ReciveServerEvent;

        /// <summary>
        /// 增加一个过滤事件
        /// </summary>
        public event Action<byte[]> ReciveDataFilter;

        private Socket clientSocket;
        private IPEndPoint endPoint;
        private byte[] buffer = new byte[1024 * 5];
        private readonly object lockObject = new object();
        private List<byte> reciveBuffer = new List<byte>();

        public AppSession(string ip,int port)
        {
            RemoteIP = ip;
            RemotePort = port;
            endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        }

        public bool Start()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);             
                clientSocket.Connect(endPoint);
                if (clientSocket.Connected)
                {
                    clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReciveData, clientSocket);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
          
        }

        private void ReciveData(IAsyncResult ar)
        {
            lock (lockObject)
            {
                try
                {
                    if (clientSocket!=null && clientSocket.Connected )
                    {
                        int count = clientSocket.EndReceive(ar);
                        if (count > 0)
                        {
                            byte[] data = new byte[count];
                            Array.Copy(buffer, data, data.Length);
                            DataBuffer(data);
                          
                            buffer = new byte[1024 * 5];
                            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReciveData, clientSocket);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if(ex.Message.Contains("远程主机强迫关闭了一个现有的连接"))
                    {
                        Stop();
                    }                   
                }                         
            }

        }

        private void DataBuffer(byte[] data)
        {
            if (ReciveDataFilter!=null)
            {
                reciveBuffer.AddRange(data);
                if (reciveBuffer.Count < EndByte.Length)
                {
                    return;
                }
                for (int i = 0; i < EndByte.Length; i++)
                {
                    // 0x0D   0x0A   =2     0             1
                    //  receiveBuffer =100  100-2+0 = 98  100-2+1 =99
                    if (EndByte[i] != reciveBuffer[reciveBuffer.Count - EndByte.Length + i])
                    {
                        return;
                    }
                }
                byte[] reciveByte = reciveBuffer.ToArray();
                reciveBuffer.Clear();
                ReciveDataFilter?.BeginInvoke(reciveByte,null,null);
            }
            else
            {
                ReciveServerEvent?.BeginInvoke(data, null, null);
            }
        }



        public void Stop()
        {
            if(clientSocket!=null)
            {
                clientSocket.Close();
                clientSocket = null;
            }
          
        }


        /// <summary>
        /// 发送并支持重连 发送最好放到异步线程中
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Send(byte[] data,out string msg)
        {
            int index = 0;
            if (clientSocket == null)
            {
                if(AutoReConnect)
                {
                    do
                    {
                        var res = Start();
                        index++;
                        if (res)
                        {
                            break;
                        }
                        else
                        {
                            Stop();
                            if (index == ReConnectCount - 1)
                            {
                                // 需要分情况
                                msg = $"服务器失败{RemoteIP}:{RemotePort},并且重连依然失败";
                                return false;
                            }
                        }
                        System.Threading.Thread.Sleep(ReConnectDelay);
                    } while (index < ReConnectCount) ;
                }        
                else
                {
                    msg = $"连接服务器失败{RemoteIP}:{RemotePort}";
                    return false;
                }
            }

            try
            {
                clientSocket.Send(data);
                msg = "Success";
                return true;
            }
            catch (Exception ex)
            {

                msg = ex.ToString();
                return false;
            }
         
        }
      

    }
}
