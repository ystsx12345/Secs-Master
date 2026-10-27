using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S5F04 : IResponse
    {
        public S5F04()
        {
            Key = "S5F3";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            if (message.Body.subScesBody.Count == 2)
            {
                List<string> AlarmList = new List<string>();
               
                bool enable = false;
                if(Convert.ToByte(message.Body.subScesBody[0].Messge) == 0x80)
                {
                    enable = true;
                }
                else
                {
                    enable = false;
                }

                if (message.Body.subScesBody[1].BodyCount == 0 && message.Body.subScesBody[1].Type == SecsDataType.U4)  // 全部
                {
                    foreach (var item in DataItem.DataList.ALARMList)
                    {
                        item.Value.Enable = enable;
                    }
                    return ResultMsg(message, 0);
                }
                if (message.Body.subScesBody[1].BodyCount > 0 && message.Body.subScesBody[1].Type == SecsDataType.U4)
                {
                    uint[] alarmEnable = message.Body.subScesBody[1].Messge as uint[];
                    foreach (var item in alarmEnable)  // 筛选出需要操作的ID
                    {
                        if (DataItem.DataList.ALARMList.ContainsKey(item.ToString()))
                        {
                            AlarmList.Add(item.ToString());
                        }
                        else
                        {
                            return ResultMsg(message, 1);  // 不存在的退出
                        }

                    }
                    foreach (var alarm in DataItem.DataList.ALARMList)
                    {
                        foreach (var item in AlarmList)
                        {
                            if (alarm.Key == item)
                            {
                                alarm.Value.Enable = enable;
                            }
                        }
                    }
                    return ResultMsg(message, 0);
                }
                return ResultMsg(message, 2);
            }
            else
            {
                return ResultMsg(message, 2);
            }
        }

        public SecsMessage ResultMsg(SecsMessage message, int ErrorCode)
        {
            SecsBody body = new SecsBody(SecsDataType.B, ErrorCode);
            SecsBodyCommon common = new SecsBodyCommon();
            return common.CreateScesMessage(5, 4,message.Header.SystemBytes, body);
        }
    }
}
