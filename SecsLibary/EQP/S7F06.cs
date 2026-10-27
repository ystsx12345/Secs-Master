using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S7F06 : IResponse
    {
        
        

        public S7F06()
        {
            Key = "S7F5";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {

            if (DataItem.DataList.PPIDList.ContainsKey(message.Body.Messge.ToString()))
            {

                SecsBody body = new SecsBody(SecsDataType.L);
                SecsBody ppid = new SecsBody(SecsDataType.ASCII, message.Body.Messge);
                body.Add(ppid);
                SecsBody ppbody = new SecsBody(SecsDataType.L);
                foreach (var item in DataItem.DataList.PPIDList[message.Body.Messge.ToString()].PPBodyList)
                {
                    
                    ppbody.Add(item.GetSecsBody());
                }
                body.Add(ppbody);
                SecsBodyCommon comom = new SecsBodyCommon();
                return comom.CreateScesMessage(7, 6, message.Header.SystemBytes, body);


            }
            else
            {
                SecsBody body = new SecsBody(SecsDataType.L);
                SecsBodyCommon comom = new SecsBodyCommon();
                return comom.CreateScesMessage(7, 6, message.Header.SystemBytes, body);
            }
        }
        
      
    }
}
