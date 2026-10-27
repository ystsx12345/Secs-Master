using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S2F38 : IResponse
    {
        public S2F38()
        {
            Key = "S2F37";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            if (message.Body.subScesBody.Count==2)
            {
                bool enable = false;
                if (Convert.ToByte(message.Body.subScesBody[0].Messge) ==0x01 )
                {
                    enable = true;
                }
                else
                {
                    enable = false;
                }
               
                if (message.Body.subScesBody[1].BodyCount > 0)  // 指定CEID  Enable
                {
                    List<string> CeidList = new List<string>();
                    foreach (var item in message.Body.subScesBody[1].subScesBody)
                    {
                        if (DataItem.DataList.CEIDList.ContainsKey(item.Messge.ToString()))
                        {
                            CeidList.Add(item.Messge.ToString());
                        }
                        else
                        {
                            return ResultMsg(message, 1);  // 至少有一个CEID不存在
                        }
                    }
                    foreach (var item in CeidList)
                    {
                        DataItem.DataList.CEIDList[item].Enable = enable;
                    }
                    return ResultMsg(message, 0);
                }
                else  // 全部CEID
                {
                    foreach (var item in DataItem.DataList.CEIDList)
                    {
                        item.Value.Enable = enable;
                    }
                    return ResultMsg(message, 0);
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
            return common.CreateScesMessage(2, 38, body);
        }
    }
}
