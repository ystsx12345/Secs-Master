using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S2F34 : IResponse
    {
        public S2F34()
        {
            Key = "S2F33";
        }
        public string DATAID { get; set; }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            if (message.Body.subScesBody.Count==2)
            {
                DATAID =  message.Body.subScesBody[0].Messge.ToString();
                
                if (message.Body.subScesBody[1].Type == SecsDataType.L && message.Body.subScesBody[1].BodyLength==0) 
                {
                    // 删除所有报告与关联
                    for (int rptIdIndex = 0; rptIdIndex < DataItem.DataList.RPTIDList.Count; rptIdIndex++)
                    {
                        string rptidKey = DataItem.DataList.RPTIDList.ElementAt(rptIdIndex).Key; // 报告ID
                        foreach (var ceidItem in DataItem.DataList.CEIDList)
                        {                           
                            if (ceidItem.Value.RPTIDList.Contains(rptidKey))
                            {
                                ceidItem.Value.RPTIDList.Remove(rptidKey);
                            }
                        }
                       
                    }
                    DataItem.DataList.RPTIDList.Clear();
                    return ResultMsg(message, 0);
                }
                else
                {
                    if (message.Body.subScesBody[1].subScesBody.Count > 0)
                    {
                        foreach (var rptID in message.Body.subScesBody[1].subScesBody)  // 遍历RPTID
                        {
                            if (rptID.subScesBody.Count == 2)
                            {
                                string rptIDKey = rptID.subScesBody[0].Messge.ToString();  // 定义报告ID
                                if (rptID.subScesBody[1].Type != SecsDataType.L)  // 格式不正确
                                {
                                    return ResultMsg(message, 2);
                                }
                                if (rptID.subScesBody[1].BodyLength == 0)  // 需要删除报告与关联
                                {
                                    if (DataItem.DataList.RPTIDList.ContainsKey(rptIDKey))
                                    {
                                        foreach (var ceidItem in DataItem.DataList.CEIDList)  // 遍历事件
                                        {
                                            if (ceidItem.Value.RPTIDList.Contains(rptIDKey))
                                            {
                                                ceidItem.Value.RPTIDList.Remove(rptIDKey);
                                            }
                                        }
                                        DataItem.DataList.RPTIDList.Remove(rptIDKey);
                                    }
                                    return ResultMsg(message, 0);
                                }
                                DataItem.RPTID NRPTID = new DataItem.RPTID();
                                NRPTID.ID = rptIDKey;
                                NRPTID.Name = "Host-"+rptIDKey;
                                foreach (var vID in rptID.subScesBody[1].subScesBody)  // 遍历变量
                                {
                                    if (DataItem.DataList.VIDList.ContainsKey(vID.Messge.ToString()))  // 是否包含变量
                                    {
                                        NRPTID.VIDList.Add(vID.Messge.ToString());
                                    }
                                    else
                                    {
                                        return ResultMsg(message, 4);
                                    }
                                }
                                // 添加
                                if (!DataItem.DataList.RPTIDList.ContainsKey(rptIDKey))  // 报告是否已经存在
                                {
                                    DataItem.DataList.RPTIDList.Add(rptIDKey, NRPTID);

                                }
                                else
                                {
                                    return ResultMsg(message, 3);
                                }
                            }
                            else
                            {
                                return ResultMsg(message, 2);
                            }
                        }
                        return ResultMsg(message, 0);
                    }
                    else
                    {
                        return ResultMsg(message, 2);
                    }


                }
            }
            else
            {
                return ResultMsg(message, 5);
            }
        }

        public SecsMessage ResultMsg(SecsMessage message,int ErrorCode)
        {
            SecsBody body = new SecsBody(SecsDataType.B, ErrorCode);
            SecsBodyCommon common = new SecsBodyCommon();
            return common.CreateScesMessage(2, 34, message.Header.SystemBytes, body);       
        }
    }
}
