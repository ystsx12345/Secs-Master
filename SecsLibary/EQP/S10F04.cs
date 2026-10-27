using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S10F04 : IResponse
    {
        public S10F04()
        {
            Key = "S10F3";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            if (message.Body.Type == SecsDataType.L && message.Body.BodyCount==2)
            {

                TIDDisplayEvent?.BeginInvoke(message.Body.subScesBody[1].Messge.ToString(),null,null);
                return ResultMsg(message, 0);
            }
            else
            {
                return ResultMsg(message, 4);
            }
        }

        public SecsMessage ResultMsg(SecsMessage message, int ErrorCode)
        {
            SecsBody body = new SecsBody(SecsDataType.B, ErrorCode);
            SecsBodyCommon common = new SecsBodyCommon();
            return common.CreateScesMessage(10, 4,message.Header.SystemBytes, body);
        }

        public static event Action<string> TIDDisplayEvent;
    }
}
