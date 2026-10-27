using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S2F36 : IResponse
    {
        public S2F36()
        {
            Key = "S2F35";
        }

        public string DATAID { get; set; }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            if (message.Body.Type == SecsDataType.L)
            {
                if (message.Body.BodyLength == 2)
                {
                    DATAID = message.Body.subScesBody[0].Messge.ToString();
                    if (message.Body.subScesBody[1].Type != SecsDataType.L) //错误
                    {
                        return ResultMsg(message, 2);
                    }
                    if (message.Body.subScesBody[1].BodyLength == 0) //错误
                    {
                        return ResultMsg(message, 2);
                    }


                    foreach (var ceID in message.Body.subScesBody[1].subScesBody)  // 遍历CEID
                    {
                        if (ceID.BodyLength != 2)
                        {
                            return ResultMsg(message, 2);
                        }
                        string ceidKey = ceID.subScesBody[0].Messge.ToString();
                        if (DataItem.DataList.CEIDList.ContainsKey(ceID.subScesBody[0].Messge.ToString()))// 存在CEID
                        {
                            DataItem.CEID NCEID = new DataItem.CEID();
                            NCEID.Enable = false;
                            NCEID.ID = ceidKey;
                            NCEID.Name = "Host-" + ceidKey;
                            if (ceID.subScesBody[1].Type != SecsDataType.L) // 报告不是列表
                            {
                                return ResultMsg(message, 2);
                            }
                            if (ceID.subScesBody[1].BodyLength == 0) // 报告列表为0 需要解除关联
                            {
                                DataItem.DataList.CEIDList[ceidKey].RPTIDList.Clear();
                                return ResultMsg(message, 0);
                            }
                            foreach (var rptid in ceID.subScesBody[1].subScesBody)
                            {
                                if (DataItem.DataList.RPTIDList.ContainsKey(rptid.Messge.ToString()))  // 存在RPTID
                                {
                                    NCEID.RPTIDList.Add(rptid.Messge.ToString());
                                }
                                else // 报告不存在
                                {
                                    return ResultMsg(message, 5);
                                }
                            }


                            DataItem.DataList.CEIDList[ceidKey] = NCEID;
                            return ResultMsg(message, 0);

                        }
                        else  // 不存在CEID
                        {
                            return ResultMsg(message, 4);
                        }
                    }
                    return ResultMsg(message, 0);
                }
                else
                {

                    return ResultMsg(message, 2);
                }

            }
            else
            {
                return ResultMsg(message, 2);
            }

        }

        public SecsMessage ResultMsg(SecsMessage message, int ErrorCode)
        {
            SecsBody body = new SecsBody(SecsDataType.B, ErrorCode);
            SecsBodyCommon common = new SecsBodyCommon();
            return common.CreateScesMessage(2, 36, message.Header.SystemBytes, body);
        }
    }
}
