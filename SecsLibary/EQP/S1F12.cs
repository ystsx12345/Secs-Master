using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt.Server;

namespace SecsLibary.EQP
{
    // Status Variable NameList Reply  (SVNRR)
    public class S1F12 : IResponse
    {
        public S1F12()
        {
            Key = "S1F11";
           
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            foreach (var item in DataItem.DataList.VIDList)
            {
                SecsBody subBody = new SecsBody(SecsDataType.L);
                SecsBody subBody1 = new SecsBody(SecsDataType.ASCII,item.Value.ID);
                SecsBody subBody2 = new SecsBody(SecsDataType.ASCII, item.Value.SVName);
                SecsBody subBody3 = new SecsBody(SecsDataType.ASCII, item.Value.UNITS);
                subBody.Add(subBody1);
                subBody.Add(subBody2);
                subBody.Add(subBody3);
                body.Add(subBody);
            }
            SecsBodyCommon common = new SecsBodyCommon();
            return common.CreateScesMessage(1, 12, message.Header.SystemBytes, body);

        }
    }
}
