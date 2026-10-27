using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Secs_Socket.AppSocket
{
   public class Session
    {
        private NetworkStream netstream;
     
        private object tcpClientLock = new object();//锁TcpClient;Dispose之后就不允许EndRead，远程连接断开以后，就不允许再调用Dispose
        private bool closed = false;//包括本地主动断开和远程断开

        /// <summary>
        /// 接收到服务器数据
        /// </summary>
        public event Action<Session> ClientReciveData;
        public event Action<Session> NewClient;
        /// <summary>
        /// 服务器主动断开
        /// </summary>
        public event Action<Session> CloseClient;

      
        public Session(TcpClient tcpclient)
        {
            Client = tcpclient;
            BodyByts = new byte[tcpclient.ReceiveBufferSize];//接收数据的缓冲区大小，如果太小一段数据会多次接收完成
           
            netstream = tcpclient.GetStream();//如果远程客户端断开一样可以获得netstream
            BeginRead();
        }


        public string Key { get; set; }

        public string IP { get; set; }

        public int  Port { get; set; }

        public TcpClient Client { get; set; }

        public string Body { get; set; }  // 消息

        public byte[] BodyByts { get; set; }

        public byte[] ReceiveBytes { get; set; }

        public bool Send(byte[] data)
        {
            bool result = false;
            try
            {
                netstream.Write(data, 0, data.Length);
                result = true;
            }
            catch (Exception ex)
            {
               
                throw;
            }
            return result;
        }

        /// <summary>
        /// 服务的接收到客户端连接后最先做的操作之一，客户端接收数据线程起始
        /// </summary>
        /// <returns></returns>
        public bool BeginRead()
        {
            bool result = false;
            try
            {
          //      NewClient?.Invoke(this);
                netstream.BeginRead(BodyByts, 0, BodyByts.Length, EndRead, null);//如果远程客户端断开这句话一样可以执行
                result = true;
            }
            catch
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// 有互斥资源
        /// 接收数据，远程连接断开，远程程序关闭，本地连接断开，都会按顺序调用进来；因为连接关闭后不再调用BeginRead
        /// 服务器listener.stop时不会进入这个函数，客户端照样通讯，服务端只是不能接收新连接而已
        /// </summary>
        /// <param name="ar"></param>
        private void EndRead(IAsyncResult ar)
        {
            lock (tcpClientLock)
            {
                if (!closed)//如果本地主动断开就不会进入
                {
                    try
                    {
                        int count = netstream.EndRead(ar);
                        if (count > 0)
                        {
                            Body = Encoding.Default.GetString(BodyByts, 0, count);
                            ReceiveBytes = new byte[count];
                            Array.Copy(BodyByts, 0, ReceiveBytes, 0, count);
                            ClientReciveData?.Invoke(this);
                            BodyByts = new byte[Client.ReceiveBufferSize];
                            netstream.BeginRead(BodyByts, 0, BodyByts.Length, EndRead, null);
                        }
                        else//远程客户端主动断开
                        {
                            LocalClientClose();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("无法从传输连接中读取数据: 远程主机强迫关闭了一个现有的连接"))
                        {
                            LocalClientClose();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 远程连接断开后（点关闭断开，程序退出断开）本地连接处理
        /// </summary>
        private void LocalClientClose()
        {
            closed = true;
            DisposeEx();
            CloseClient?.Invoke(this);
        }

        /// <summary>
        /// 有互斥资源
        /// 在已连接条件下关闭本地连接和资源释放时调用
        /// </summary>
        public void Dispose()
        {
            lock (tcpClientLock)
            {
                if (!closed)
                {
                    closed = true;
                    DisposeEx();
                    CloseClient?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// 由Dispose和LocalClientClose调用
        /// </summary>
        private void DisposeEx()
        {
            if (netstream != null)
            {
                netstream.Dispose();
                netstream = null;
            }
            if (Client != null)
            {
                Client.Close();
                Client = null;
            }
        }


    }
}
