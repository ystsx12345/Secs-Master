using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{

    /// <summary>
    /// 主机发送一个Process
    /// </summary>
    public class S7F04 : IResponse
    {
        /// <summary>
        /// 主机发送 Process
        /// </summary>
        public S7F04()
        {
            Key = "S7F3";
          
        }
        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            if (message.Body.subScesBody.Count==2)
            {
                var res =  DataItem.DataList.PPIDList.ContainsKey(message.Body.subScesBody[0].Messge.ToString());
                if (res)// 存在更新
                {
                    SecsBody PPbodyList = message.Body.subScesBody[1];
                    foreach (var item in PPbodyList.subScesBody)
                    {
                        foreach (var ppBody in DataItem.DataList.PPIDList[message.Body.subScesBody[0].Messge.ToString()].PPBodyList)
                        {
                            if (item.BodyCount!=2 || item.Type != SecsDataType.L)
                            {
                                return ResultMsg(message, 2);
                            }
                            if (item.subScesBody[0].Messge.ToString()== ppBody.Name)  // 依据名称更新
                            {
                                ppBody.Value = item.subScesBody[1].Messge.ToString();
                            }
                        }
                    }
                    // 更新本地文件
                    PROCESS_DOWN_EVENT?.BeginInvoke(false,message.Body.subScesBody[0].Messge.ToString(), null, null);
                    return ResultMsg(message, 0);
                                     
                }
                else  // 不存在 需要添加
                {
                    SecsBody PPbodyList = message.Body.subScesBody[1];
                    DataItem.PPID PPid = new DataItem.PPID();
                    PPid.ID = message.Body.subScesBody[0].Messge.ToString();
                    foreach (var item in PPbodyList.subScesBody)
                    {
                        if(item.BodyCount!=2 || item.Type!= SecsDataType.L)
                        {
                            return ResultMsg(message, 2);
                        }
                        PPid.PPBodyList.Add(new DataItem.PPBody()
                        {
                            Name = item.subScesBody[0].Messge.ToString(),
                            Value = item.subScesBody[1].Messge.ToString()
                        });
                    }
                    DataItem.DataList.PPIDList.Add(PPid.ID, PPid);
                    PROCESS_DOWN_EVENT?.BeginInvoke(true,message.Body.subScesBody[0].Messge.ToString(), null, null);
                    return ResultMsg(message,0);
                }                 
            }
            else
            {
                return ResultMsg(message,5);
            }
        }

        public SecsMessage ResultMsg(SecsMessage message,int Error)
        {          
            SecsBody body = new SecsBody(SecsDataType.B, Error);       
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(7, 4, message.Header.SystemBytes, body);
        }

        /// <summary>
        /// host down process 1. new  2. ppid name
        /// </summary>
        public static event Action<bool,string> PROCESS_DOWN_EVENT;
    }
}
