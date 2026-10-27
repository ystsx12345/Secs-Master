using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S2F14 : IResponse
    {
        public S2F14()
        {
            Key = "S2F13";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)


        {
            if (message.Body.subScesBody==null && message.Body.Type == SecsDataType.L)
            {
                SecsBody body = new SecsBody(SecsDataType.L);
                foreach (var item in DataItem.DataList.ECIDList)
                {
                    SecsBody subbody = new SecsBody(SecsDataType.ASCII, item.Value.Value);
                    body.Add(subbody);
                }
                SecsBodyCommon common = new SecsBodyCommon();
                return common.CreateScesMessage(2, 14, message.Header.SystemBytes, body);
            }
            if (message.Body.subScesBody.Count>0)  // 只上传请求项
            {
                SecsBody Mainbody = new SecsBody(SecsDataType.L);
                foreach (var body in message.Body.subScesBody)
                {
                    foreach (var item in DataItem.DataList.ECIDList)
                    {
                        if (body.Messge.ToString() == item.Key)
                        {
                            SecsBody subbody = new SecsBody(SecsDataType.ASCII, item.Value.Value);
                            Mainbody.Add(subbody);
                        }
                    }
                }
                SecsBodyCommon common = new SecsBodyCommon();
                return common.CreateScesMessage(2, 14, message.Header.SystemBytes, Mainbody);
            }
            return ErrorMsg(message);
            
        }

        public SecsMessage ErrorMsg(SecsMessage message)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBodyCommon common = new SecsBodyCommon();
            return common.CreateScesMessage(2, 14, message.Header.SystemBytes, body);
        }
    }
}
