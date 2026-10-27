using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S5F08 : IResponse
    {
        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBodyCommon common = new SecsBodyCommon();
            SecsBody alamList = new SecsBody(SecsDataType.L);
            foreach (var item in DataItem.DataList.ALARMList)
            {
                if (item.Value.Enable == true)
                {
                    alamList.Add(item.Value.GetSecsMessage().Body);
                }
            }
            return common.CreateScesMessage(5, 8, message.Header.SystemBytes, alamList);
        }
    }
}
