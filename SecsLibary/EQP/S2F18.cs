using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt.Server;

namespace SecsLibary.EQP
{
    public class S2F18 : IResponse
    {
        public S2F18()
        {
            Key = "S2F17";
        
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBodyCommon com = new SecsBodyCommon();
            SecsBody body = new SecsBody(SecsDataType.ASCII, DateTime.Now.ToString("yyyyMMddHHmmssfs"));
            return com.CreateScesMessage(2, 18, message.Header.SystemBytes, body);
        }
    }
}
