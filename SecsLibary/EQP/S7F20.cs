using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    /// <summary>
    /// 返回PPID 列表
    /// </summary>
    public class S7F20 : IResponse
    {

        public S7F20()
        {
            Key = "S7F19";
        }
        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            foreach (var item in DataItem.DataList.PPIDList)
            {
                SecsBody subBody = new SecsBody(SecsDataType.ASCII,item.Key);
                body.Add(subBody);
            }
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(7, 20, message.Header.SystemBytes, body);
        }
    }
}
