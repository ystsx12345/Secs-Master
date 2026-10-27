using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt.Server;

namespace SecsLibary.EQP
{
    public class S1F14 : IResponse
    {
        public S1F14()
        {
            Key = "S1F13";
          
        }
        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBody body = new SecsBody(SecsDataType.L);

            SecsBody success = new SecsBody(SecsDataType.B, "0");
            body.Add(success);

            SecsBody main = new SecsBody(SecsDataType.L);
            SecsBody mdln = new SecsBody(SecsDataType.ASCII, EQP_SECS_Data.Company);
            SecsBody revisons = new SecsBody(SecsDataType.ASCII, EQP_SECS_Data.Version);
            main.Add(mdln);
            main.Add(revisons);
            body.Add(main);
            if (EQP_SECS_Data.ControlMode == CtrolMode.OfflineLine) EQP_SECS_Data.ControlMode = CtrolMode.OnLineLocal;
            SecsBodyCommon common = new SecsBodyCommon();
            return common.CreateScesMessage(1, 14, message.Header.SystemBytes, body);


        }
    }
}
