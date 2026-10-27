using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt;

namespace SecsLibary
{
   public class ErrorMessage
    {

        public static SecsMessage IllegalData(byte[] systemBytes)
        {
            SecsBodyCommon com = new SecsBodyCommon();
            SecsBody body = new SecsBody(SecsDataType.B, "0");
            return com.CreateScesMessage(9, 7,systemBytes, body);
        }
    }
}
