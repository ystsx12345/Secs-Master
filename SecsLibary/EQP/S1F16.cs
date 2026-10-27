using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S1F16 : IResponse
    {
        public S1F16()
        {
            Key = "S1F15";
         
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBody body = new SecsBody(SecsDataType.B,"0");
            SecsBodyCommon common = new SecsBodyCommon();
            EQP_SECS_Data.ControlMode = CtrolMode.OfflineLine;
            return common.CreateScesMessage(1, 16, message.Header.SystemBytes, body);
        }
    }
}
