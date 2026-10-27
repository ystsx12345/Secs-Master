using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt.Server;

namespace SecsLibary.EQP
{
    public class S2F44 : IResponse
    {
        public S2F44()
        {
            Key = "S2F43";
      
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            throw new NotImplementedException();
        }

        public SecsMessage GetResponse(SecsMessage reciveSces)
        {
            throw new NotImplementedException();
        }
    }
}
