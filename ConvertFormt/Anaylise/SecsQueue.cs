using Secs_Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConvertFormt.Anaylise
{

    /// <summary>
    /// 管理接受消息的序列
    /// </summary>
   public class SecsQueue
    {

        byte[] buffer = null;
        private object lockObject = new object();
        private AppServer server = null;
        private event Action<byte[]> ReciveBodyEvent;
        private bool Tim8Run = false;

        public event Action StartTim8;
        public event Action StopTim8;

        public event Action ResetBuffer;
       
        /// <summary>
        /// 接受到一条完整消息的事件
        /// </summary>
        public event Action<SecsMessage> ReciveMessageEvent;

        public event Action SelectRspEvent;
        public event Action<SecsHeader> SelectReqEvent;
        public event Action<SecsHeader> LinkTestReqEvent;
        public event Action<SecsHeader> DeselectReqEvent;
        private int Length = 0;
        private int InitSize;
      
        /// <summary>
        /// 构造接受消息
        /// </summary>
        /// <param name="size">缓存默认长度</param>
        /// <param name="app">服务器</param>
        public SecsQueue(int size,AppServer app)
        {
            server = app;
            buffer = new byte[size];
            InitSize = size;
            ReciveBodyEvent += ScesQueue_ReciveBodyEvent;
            ResetBuffer += ScesQueue_ResetBuffer;
            Task.Run(() =>
            ScesMsgRecive()
            );
        }

        /// <summary>
        ///  清楚缓存数据
        /// </summary>
        private void ScesQueue_ResetBuffer()
        {
            buffer = new byte[InitSize];
        }

        public void ClearBuffer()
        {
            buffer = new byte[InitSize];
        }



        /// <summary>
        /// 新消息有自动加
        /// </summary>
        /// <param name="rec"></param>
        public void Add(byte[] rec)
        {
            Monitor.Enter(lockObject);
            if (Length+ rec.Length> buffer.Length)
            {
                byte[] temp = new byte[Length];
                Array.Copy(buffer, 0, temp, 0, Length);  // 缓存原数据
                buffer = new byte[Length + rec.Length*2];
                Array.Copy(temp, 0, buffer, 0, temp.Length); // Copy 原数据
                Array.Copy(rec, 0, buffer, Length, rec.Length);  // Copy 新数据
                Length += rec.Length;
            }
            else
            {
                Array.Copy(rec, 0, buffer, Length, rec.Length);
                Length += rec.Length;
            }
            Monitor.Exit(lockObject);
        }

        // T8 经常超时

        private void ScesMsgRecive()
        {
            while (true)
            {
                if (!server.serverStart) break;
                if (Length > 4)
                {
                    try
                    {
                        
                        StartTim8?.Invoke();
                        byte[] lengthBytes = buffer.Take(4).ToArray();
                        int length = Common.bytesToInt2(lengthBytes, 0);
                        if (length < 10)  //  数据长度0 清除所有已接受到数据
                        {
                            buffer = new byte[InitSize];
                        }
                        // 启动T8检查接受数据时间
                        else if (Length >= length + 4)
                        {
                            StopTim8?.Invoke();
                            byte[] rec = buffer.Take(length + 4).ToArray();
                            // 数组向前移动
                            Monitor.Enter(lockObject);
                            byte[] temp = new byte[Length - rec.Length];
                            Array.Copy(buffer, 0, temp, 0, temp.Length);  // Copy 源数据
                            buffer = new byte[buffer.Length];
                            Array.Copy(temp, 0, buffer, 0, temp.Length);
                            Length = temp.Length;
                            Monitor.Exit(lockObject);
                            ReciveBodyEvent?.BeginInvoke(rec, null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        Monitor.Exit(lockObject);
                    }
              


                }
           
            }
      
        }


        /// <summary>
        /// 接受缓存区判断一条完成消息 异步方法
        /// </summary>
        /// <param name="obj"></param>
        private void ScesQueue_ReciveBodyEvent(byte[] obj)
        {
            byte[] lengthBytes = new byte[4];
            Array.Copy(obj, 0, lengthBytes, 0, 4);

            // 分析头
            SecsHeader header = new SecsHeader();
            header.ByteLength = Common.bytesToInt2(lengthBytes, 0);
            header.UpSessionID = obj[4];
            header.LowerSessionID = obj[5];
            header.Stream = obj[6];
            header.Function = obj[7];
            header.PType = obj[8];
            header.SType = obj[9];
            Array.Copy(obj, 10, header.SystemBytes, 0, 4);
            // 分析内容
          
            SecsType  Type = (SecsType)header.SType;
            SecsBodyCommon com = new SecsBodyCommon();
            SecsMessage message = new SecsMessage();
          //  Log.LogReciveBytes(Format.byteToHexStr(obj));
            switch (Type)
            {
                case SecsType.SelectReq:
                    SelectReqEvent?.Invoke(header);
           
                    break;
                case SecsType.SelectRsp:
                    SelectRspEvent?.Invoke();
                    break;
                case SecsType.DeSelectReq:
                    DeselectReqEvent?.Invoke(header);
            
                    break;
                case SecsType.DeSelectRsp:
                  
                    break;
                case SecsType.LinkTestReq:
                    LinkTestReqEvent?.Invoke(header);
             
                    break;
                case SecsType.LinkTestRsp:
                  
                    break;
                case SecsType.SeperateReq:
                   
                    break;
                case SecsType.RejectReq:
                  
                    break;
                case SecsType.Message:
                    byte[] bodysBytes = new byte[header.ByteLength - 10];
                    SecsBody body = new SecsBody();
                    Array.Copy(obj, 14, bodysBytes, 0, bodysBytes.Length);
                    body.SetBody(bodysBytes);                  
                    message.Header = header;
                    message.Body = body;
                    ReciveMessageEvent?.Invoke(message);
                    break;
                default:
                    break;
            }
          


        }





       

    }
}
