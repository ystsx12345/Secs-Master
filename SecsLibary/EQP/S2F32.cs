using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecsLibary.Common;

namespace SecsLibary.EQP
{
    public class S2F32 : IResponse
    {
        public S2F32()
        {
            Key = "S2F31";
        
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            // 12 or 16 bytes of time
            // YYMMDDhhmmss
            // YYYYMMDDhhmmsscc


            // DateTime dt = Convert.ToDateTime(message.Body.Messge);
            if (message.Body.BodyCount == 16)
            {
                try
                {
                    ushort YYYY = ushort.Parse(message.Body.Messge.ToString().Substring(0, 4));
                    ushort MM = ushort.Parse(message.Body.Messge.ToString().Substring(4, 2));
                    ushort DD = ushort.Parse(message.Body.Messge.ToString().Substring(6, 2));
                    ushort hh = ushort.Parse(message.Body.Messge.ToString().Substring(8, 2));
                    ushort mm = ushort.Parse(message.Body.Messge.ToString().Substring(10, 2));
                    ushort ss = ushort.Parse(message.Body.Messge.ToString().Substring(12, 2));
                    ushort cc = ushort.Parse(message.Body.Messge.ToString().Substring(14, 2));
                    SetSystemDateTime.SetLocalTimeByStr(YYYY, MM, DD, hh, mm, ss, cc);
                   return ResultMsg(message, 0);
                }
                catch (Exception)
                {
                  return  ResultMsg(message, 1);
                    
                }
              
            }
            if (message.Body.BodyCount==12)
            {
                try
                {
                    ushort YYYY = ushort.Parse(message.Body.Messge.ToString().Substring(0, 2));
                    ushort MM = ushort.Parse(message.Body.Messge.ToString().Substring(2, 2));
                    ushort DD = ushort.Parse(message.Body.Messge.ToString().Substring(4, 2));
                    ushort hh = ushort.Parse(message.Body.Messge.ToString().Substring(6, 2));
                    ushort mm = ushort.Parse(message.Body.Messge.ToString().Substring(8, 2));
                    ushort ss = ushort.Parse(message.Body.Messge.ToString().Substring(10, 2));
                    SetSystemDateTime.SetLocalTimeByStr(YYYY, MM, DD, hh, mm, ss, 00);
                    return ResultMsg(message, 0);
                }
                catch (Exception)
                {

                    return ResultMsg(message, 1);
                }

            }

          return ResultMsg(message, 1);

        }

        public SecsMessage ResultMsg(SecsMessage message,int Error)
        {         
            SecsBody body = new SecsBody(SecsDataType.B, Error);
            SecsBodyCommon common = new SecsBodyCommon();
            return common.CreateScesMessage(2, 32, message.Header.SystemBytes, body);
        }
    }
}
