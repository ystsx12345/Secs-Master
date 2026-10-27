using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S1F18 : IResponse
    {
        public S1F18()
        {
            Key = "S1F17";
         
        }
        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBody body = new SecsBody(SecsDataType.B, "0");
            SecsBodyCommon common = new SecsBodyCommon();
            EQP_SECS_Data.ControlMode = CtrolMode.OnLineLocal;
            return common.CreateScesMessage(1, 18, message.Header.SystemBytes, body);
        }
    }
}
