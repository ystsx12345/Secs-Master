using Secs_Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt.Models;
using ConvertFormt.Anaylise;
using System.Threading;
using System.Diagnostics;

namespace ConvertFormt.Server
{
   public class Secs
    {

        public AppServer appServer;  // 被动连接


        private  SecsQueue buffer = null;
        private  Dictionary<string, SecsMessage> ResponsedList;
        private  List<SecsMessage>  SendList;
        private object lockObject = new object();
        private Time.T6 Tim6;
        private Time.T7 Tim7;
        private Time.T8 Tim8;
        private MachineStatus machineStatus;
        public  event Action<SecsStatus> ScesStatusChanged;
        public event Action<MachineStatus> MachineStatusChanged;

        /// <summary>
        /// 接受到请求类消息
        /// </summary>
        public event Action<SecsMessage,Secs> ScesReciveRequestEvent;
        /// <summary>
        /// 接受到响应类消息
        /// </summary>
        public event Action<SecsMessage, Secs> ScesReciveResponedEvent;

        public SecsStatus Status { get; set; }


        #region 定时器属性

        public int T3Value { get; set; } = 30;

        public int T5Value { get; set; } = 40;

        public int T6Value { get; set; } = 50;

        public int T7Value { get; set; } = 50;

        public int T8Value { get; set; } = 20;

        #endregion

        #region 设备状态属性
        public MachineStatus MachineStatus 
        {
            get{ return machineStatus; }
            set { machineStatus = value; MachineStatusChanged?.BeginInvoke(machineStatus, null, null); }
        }


        #endregion

        #region 日志记录
        public  bool EnableLog { get; set; } = false;

        #endregion

        public Secs()
        {
            ResponsedList = new Dictionary<string, SecsMessage>();
            SendList = new List<SecsMessage>();
            Status = SecsStatus.NotInit;
            ScesStatusChanged?.Invoke(Status);
        }

        public void Init(string ip,int port,bool passive)
        {
            appServer = new AppServer(ip, port);
           
            Tim6 = new Time.T6();
            Tim7 = new Time.T7();
            Tim8 = new Time.T8();
            Tim6.TimeOutEvent += Tim6_TimeOutEvent;
            Tim7.TimeOutEvent += Tim7_TimeOutEvent;
            Tim8.TimeOutEvent += Tim8_TimeOutEvent;
            if (!appServer.Start())
            {
               
                Log.LogError($"LISTEN {ip },{port} FAILED ");

            }
            else
            {
                buffer = new ConvertFormt.Anaylise.SecsQueue(1024, appServer);
                buffer.ReciveMessageEvent += Buffer_ReciveMessageEvent;
                buffer.SelectRspEvent += Buffer_SelectRspEvent;
                buffer.SelectReqEvent += Buffer_SelectReqEvent;
                buffer.DeselectReqEvent += Buffer_DeselectReqEvent;
                buffer.LinkTestReqEvent += Buffer_LinkTestReqEvent;
                buffer.StartTim8 += Buffer_StartTim8;
                buffer.StopTim8 += Buffer_StopTim8;
                
                appServer.ReciveData += AppServer_ReciveData;
                appServer.SessionConnected += AppServer_SessionConnected;
                appServer.SessionClosed += AppServer_SessionClosed;
                Status = SecsStatus.NotConnected;
                ScesStatusChanged?.Invoke(Status);
                Log.LogInfo($"LISTEN {ip },{port} SUCCESS ");
            }
        }


        #region 系统请求应答事件
        private void Buffer_LinkTestReqEvent(SecsHeader header)
        {
            SecsBodyCommon com = new SecsBodyCommon();
            byte[]  data = com.CreateOperator(SecsType.LinkTestRsp, header.SystemBytes);
            appServer.Send(data);
            Log.LogSendBytes(Format.byteToHexStr(data));
          
        }

        private void Buffer_DeselectReqEvent(SecsHeader header)
        {
            SecsBodyCommon com = new SecsBodyCommon();
            byte[] data = com.CreateOperator(SecsType.DeSelectRsp, header.SystemBytes);
            appServer.Send(data);
            Log.LogSendBytes(Format.byteToHexStr(data));
        }

        private void Buffer_SelectReqEvent(SecsHeader header)
        {
            SecsBodyCommon com = new SecsBodyCommon();
            byte[] data = com.CreateOperator(SecsType.SelectRsp, header.SystemBytes);
            appServer.Send(data);
            Log.LogSendBytes(Format.byteToHexStr(data));
            Tim6.Stop();
            Tim7.Stop();
            Status = SecsStatus.Selected;
            ScesStatusChanged?.Invoke(Status);

        }
        #endregion

        // 连接断开
        private void AppServer_SessionClosed(Secs_Socket.AppSocket.Session obj)
        {
            Log.LogError($"HSMS DISCONNECTED ");
            Status = SecsStatus.NotConnected;
            ScesStatusChanged?.Invoke(Status);
        }

        // select rsp 响应
        private void Buffer_SelectRspEvent()
        {
            Tim6.Stop();
            Tim7.Stop();
            Status = SecsStatus.Selected;
            ScesStatusChanged?.Invoke(Status);
        }

        //建立连接
        private void AppServer_SessionConnected(Secs_Socket.AppSocket.Session obj)
        {
            Status = SecsStatus.NotSelected;
            ScesStatusChanged?.Invoke(Status);
            Tim7.Start(T7Value);
            // 主动发送select.req
            //ScesBodyCommon common = new ScesBodyCommon();
            //Send(common.CrateScesOperator(ScesType.SelectReq));
            Log.LogInfo($"Actived Success {obj.IP }:{obj.Port}");
        }

        // 接受到消息
        private void AppServer_ReciveData(Secs_Socket.AppSocket.Session obj)
        {
            buffer.Add(obj.ReceiveBytes);
            Log.LogReciveBytes(Format.byteToHexStr(obj.ReceiveBytes));
        }

        // 终止连接
        public void Stop()
        {
            SecsBodyCommon common = new SecsBodyCommon();
            Send(common.CreateScesOperator(SecsType.SeperateReq));
            appServer.Stop();
        }


        /// <summary>
        /// 被动接受到消息事件
        /// </summary>
        /// <param name="obj"></param>
        private void Buffer_ReciveMessageEvent(SecsMessage obj)
        {
            SecsType type = (SecsType)obj.Header.SType;
            if (type!= SecsType.Message)
            {
                return;
            }
            bool request = obj.Header.Function % 2 == 0 ? false : true;  // 请求类消息
            byte Stream  = obj.Header.Function % 2 == 0 ? obj.Header.Stream : (byte)(obj.Header.Stream - 0x80);
            byte Function = obj.Header.Function;
            string key = $"S{Stream}F{Function - (byte)1}";
            Log.LogReciveSML(ScesMessageToSml.ToSml(obj, 22));
           
            if (request)  // 请求类 需要回复
            {
                key = $"S{Stream}F{Function+(byte)1}";
               
                // 不在自动回复列表中 触发自定义回复
                ScesReciveRequestEvent?.BeginInvoke(obj,this, null, null);


              //  Log.LogError($"Responed list not find {key}");
            }
            else   //  回复类不需要回复
            {
                for (int i = 0; i < SendList.Count; i++)
                {
                    byte rspStream = SendList[i].Header.Function % 2 == 0 ? SendList[i].Header.Stream : (byte)(SendList[i].Header.Stream - 0x80);
                    byte rspFunction = SendList[i].Header.Function;
                    string rspkey = $"S{rspStream}F{rspFunction}";
                    if (key == rspkey)
                    {
                        SendList[i].Tim3.Stop();
                        SendList.RemoveAt(i);
                        return;
                    }
                }
                // 接受到响应消息 需要判断是否响应合理
                ScesReciveResponedEvent?.BeginInvoke(obj,this, null, null);
            }
       

        }

        /// <summary>
        /// 主动上报消息
        /// </summary>
        public void Send(SecsMessage model)
        {
            if (Status == SecsStatus.NotConnected || Status== SecsStatus.NotInit)
            {
                System.Windows.Forms.MessageBox.Show("SEND MESSAGE FAIL,TCP NOT READY");
                return;
            }
            SecsBodyCommon common = new SecsBodyCommon();
            byte[] data = common.CreateSces(model, out string sml);
            appServer.Send(data);
            Monitor.Enter(lockObject);
           
            if (model.IsRquest)  // 消息启动T3 请求类消息
            {
                SendList.Add(model);
                model.Tim3.Start(T3Value, model);
                model.Tim3.TimeOutEvent += Tim3_TimeOutEvent;
            }
            if (model.Header.GetScesType()== SecsType.SelectReq) // SelectReq启动T6
            {               
                Tim6.Start(T6Value);
            }       
            Monitor.Exit(lockObject);
            SecsType type = (SecsType)model.Header.SType;
            if (type== SecsType.Message)
            {
                Log.LogSendSML(sml);
            }       
            Log.LogSendBytes(Format.byteToHexStr(data));
           
          
        }

        private void Buffer_StopTim8()
        {
            Debug.WriteLine($"T8 Stop {index}");
            Tim8.Stop();
    
        }

        int index = 0;
        private void Buffer_StartTim8()
        {
            if (!Tim8.IsRunning)
            {
                Tim8.Start(T8Value);
                index++;
                Debug.WriteLine($"T8 Start {index}");
                
            }
           
        }

        /// <summary>
        /// T8 单条信息等待超时 socket 接受到头长时间未等到数据完成
        /// </summary>
        private void Tim8_TimeOutEvent()
        {
            Log.LogError("T8 WAIT TO READ SOCKET TIMEOUT");
            buffer.ClearBuffer();
        }

        /// <summary>
        /// T7 Not Select等待超时
        /// </summary>
        private void Tim7_TimeOutEvent()
        {
            Log.LogError("T7 WAIT TO SELECTED TIMEOUT");
        }

        /// <summary>
        /// T6 进入Select超时
        /// </summary>
        private void Tim6_TimeOutEvent()
        {
            Log.LogError("T6 WAIT SELECT.RSP TIMEOUT");
        }

        /// <summary>
        /// T3 等待回复超时
        /// </summary>
        private void Tim3_TimeOutEvent(SecsMessage seceMesage)
        {
            SendList.Remove(seceMesage);
          //  Array.Reverse(seceMesage.Header.SystemBytes);
            
            Log.LogError($"T3 WAIT TIMEOUT StreamFunction:S{(seceMesage.Header.Stream-0x80).ToString("X")}F{seceMesage.Header.Function}  SessionID:{BitConverter.ToInt32(seceMesage.Header.SystemBytes, 0)}");
        }


        /// <summary>
        /// 添加消息到响应队列中 
        /// </summary>
        /// <param name="Model">必须是偶数 因为是响应消息</param>
        public void Add(SecsMessage Model)
        {
            byte Stream = Model.Header.Function % 2 == 0 ? Model.Header.Stream : (byte)(Model.Header.Stream - 0x80);
            byte Function = Model.Header.Function;
            string key = $"S{Stream}F{Function}";
            if (ResponsedList.ContainsKey(key))
            {
                ResponsedList[key] = Model;
            }
            else
            {
                ResponsedList.Add(key, Model);
            }


        }

        public void SaveAsXML(string path)
        {
            List<Models.ScesModel> list = new List<ScesModel>();
            foreach (var item in ResponsedList)
            {
                Models.ScesModel model = new ScesModel();
                if (item.Value.Body!=null)
                {
                    model.Mesage = item.Value.Body.ToSML(0);
                }
               
                model.Key = item.Key;
                list.Add(model);
                    
            }
           
            XmlSerializeHelper.XmlSerializerToFile<List<Models.ScesModel>>(list, path);
         
        }

        public void ReadFormXML(string path)
        {
            // List<ScesModel> list  =  XmlSerializeHelper.XmlDeserialerFromFile<List<Models.ScesModel>>(path);
            //foreach (var item in list)
            //{
            //    ResponsedList = new Dictionary<string, SecsMessage>();
            //    ResponsedList.Add(item.Key, item.Mesage);
            //}
        }


      




    }
}
