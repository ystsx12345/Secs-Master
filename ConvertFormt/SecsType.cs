using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{
   public enum SecsType
    {
       SelectReq= 0x01,
       SelectRsp = 0x02,
       DeSelectReq= 0x03,
       DeSelectRsp= 0x04,
       LinkTestReq= 0x05,
       LinkTestRsp= 0x06,
       SeperateReq= 0x09,
       RejectReq= 0x07,
       Message= 0x00,
    }
}
