using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
   public class S7F18:IResponse
    {
        public S7F18()
        {
            Key = "S7F17";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            List<string> ppidList = new List<string>();
            if (message.Body.Type == SecsDataType.L && message.Body.BodyCount==0)  // 删除全部
            {
                foreach (var ppid in DataItem.DataList.PPIDList)
                {
                    ppidList.Add(ppid.Key);
                }
            }
            else  // 删除指定
            {
                foreach (var item in message.Body.subScesBody)
                {
                    if (DataItem.DataList.PPIDList.ContainsKey(item.Messge.ToString()))
                    {
                        ppidList.Add(item.Messge.ToString());
                    }
                    else
                    {
                        return ResultMsg(message, 4);
                    }
                }
            }
            // 执行删除操作
            foreach (var ppid in ppidList)
            {
                if(DataItem.DataList.PPIDList.ContainsKey(ppid))
                {
                    DataItem.DataList.PPIDList.Remove(ppid);
                }
            }
            PROCESS_DELETE_EVENT?.BeginInvoke(ppidList, null, null);
            return ResultMsg(message, 0);
        }

        public SecsMessage ResultMsg(SecsMessage message,byte Errorcode)
        {
            SecsBodyCommon com = new SecsBodyCommon();
            SecsBody body = new SecsBody(SecsDataType.B,Errorcode);
            return com.CreateScesMessage(7, 18, message.Header.SystemBytes, body);
        }

        /// <summary>
        /// 删除对应的Recipe文件 此处可能有坑  只删除PartConfig.xml文件内容
        /// </summary>
        public static event Action<List<string>> PROCESS_DELETE_EVENT;
    }
}
