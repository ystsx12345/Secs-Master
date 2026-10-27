using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
   public class S7F02 : IResponse
    {
        /// <summary>
        /// Recipe的数量下载
        /// </summary>

        public S7F02()
        {
            Key = "S7F1";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            if (message.Body.Type == SecsDataType.L)
            {
                if (message.Body.subScesBody.Count != 2)
                {
                    return Error(message);
                }
                else
                {
                    string ppidName = message.Body.subScesBody[0].Messge.ToString();
                    if (int.TryParse(message.Body.subScesBody[1].Messge.ToString(), out int Length))
                    {
                        if (Length > 0)
                        {
                            if (DataItem.DataList.VIDList.ContainsKey("1100"))
                            {
                                DataItem.DataList.VIDList["1100"].ID = ppidName;
                                DataItem.DataList.VIDList["1100"].VALUES = Length.ToString();
                            }
                            else
                            {
                                DataItem.DataList.VIDList.Add("1100", new VID() { ID = ppidName, VALUES = Length.ToString() });
                            }
                            SecsBody body = new SecsBody(SecsDataType.B,"0");
                            SecsBodyCommon comom = new SecsBodyCommon();
                            return comom.CreateScesMessage(7, 2, message.Header.SystemBytes, body);
                        }
                        else
                        {
                            return Error(message);
                        }

                    }
                    else
                    {
                        return Error(message);
                    }

                }
            }
            else
            {
                return Error(message);
            }
        } 

        public SecsMessage Error(SecsMessage message)
        {
            SecsBody body = new SecsBody(SecsDataType.B,"1");
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(7, 1, message.Header.SystemBytes, body);
        }
    }
}
