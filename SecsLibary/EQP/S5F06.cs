using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
  public class S5F06:IResponse
    {
        public S5F06()
        {
            Key = "S5F5";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBodyCommon common = new SecsBodyCommon();
            SecsBody alamList = new SecsBody(SecsDataType.L);
           
            if (message.Body.Type == SecsDataType.U4 && message.Body.BodyCount>0)  // 获取指定
            {
                uint[] AlIDList = message.Body.Messge as uint[];
               
                foreach (var AlarmID in AlIDList)
                {
                    SecsBody subAlarm = new SecsBody(SecsDataType.L);
                    if (DataItem.DataList.ALARMList.ContainsKey(AlarmID.ToString()))
                    {                       
                        subAlarm = DataItem.DataList.ALARMList[AlarmID.ToString()].GetSecsMessage().Body;
                      
                    }
                    else
                    {
                        SecsBody alcd = new SecsBody(SecsDataType.ASCII, "0");
                        SecsBody alid = new SecsBody(SecsDataType.ASCII, "0");
                        SecsBody alTx = new SecsBody(SecsDataType.ASCII, " ");
                        subAlarm.Add(alcd);
                        subAlarm.Add(alid);
                        subAlarm.Add(alTx);
                    }
                    alamList.Add(subAlarm);
                }
              
                return common.CreateScesMessage(5, 6, message.Header.SystemBytes, alamList);
            }
     
            if (message.Body.Type == SecsDataType.U4 && message.Body.BodyCount==0)  // 获取全部
            {              
                foreach (var item in DataItem.DataList.ALARMList)
                {                    
                    alamList.Add(item.Value.GetSecsMessage().Body);
                }               
                return common.CreateScesMessage(5, 6, message.Header.SystemBytes, alamList);
            }           
            return common.CreateScesMessage(5, 6, message.Header.SystemBytes, alamList);
           
        }


    }
}
