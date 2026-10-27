using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt.Server;

namespace SecsLibary.EQP
{
    public class S9F7 : IResponse
    {
        public S9F7()
        {
          
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBodyCommon com = new SecsBodyCommon();
            SecsBody body = new SecsBody(SecsDataType.B,"0");          
            return  com.CreateScesMessage(9, 7, body);
        }
    }
}
