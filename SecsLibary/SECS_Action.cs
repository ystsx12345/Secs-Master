using ConvertFormt;
using SecsLibary.DataItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary
{
    /// <summary>
    /// 全局的SECS主动发送
    /// </summary>
   public class SECS_Action
    {
        #region 主动发送
        public static bool SendCEID(string id)
        {
            if (DataList.CEIDList.ContainsKey(id))
            {
                SecsMessage message = DataList.CEIDList[id].GetSecsMessage();
                EQP_SECS_Data.Secs.Send(message);
                return true;
            }
            return false;
        }

        public bool SendAlarm(string id)
        {
            if (DataList.ALARMList.ContainsKey(id))
            {
                SecsMessage message = DataList.ALARMList[id].GetSecsMessage();
                EQP_SECS_Data.Secs.Send(message);
                return true;
            }
            return false;
        }

        public bool SendAlarm(ALARM alarm)
        {
            if (alarm == null) return false;
            SecsMessage message = alarm.GetSecsMessage();
            EQP_SECS_Data.Secs.Send(message);
            return true;
        }


        #endregion
    }
}
