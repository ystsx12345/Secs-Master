using ConvertFormt;
using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.EQP
{
    public class S2F42 : IResponse
    {
        public S2F42()
        {
            Key = "S2F41";
        }

        public override SecsMessage GetResponed(SecsMessage message, Secs status)
        {
            SecsBody resBody = new SecsBody(SecsDataType.L);
            SecsBody paramter = new SecsBody(SecsDataType.L);
            if (message.Body.subScesBody.Count()==2)
            {               
                string cmd = message.Body.subScesBody[0].Messge.ToString();

                if (EQP_SECS_Data.ControlMode!=CtrolMode.OnLineRemote)
                {
                    resBody.Add(new SecsBody(SecsDataType.B, 2));
                }
                else if (DataItem.DataList.RCMDList.ContainsKey(cmd))  // 存在远程命令
                {

                    resBody.Add(new SecsBody(SecsDataType.B, 0));
                    if (message.Body.subScesBody[1].subScesBody!=null) // 命令带参数
                    {
                        
                        DataItem.DataList.RCMDList[cmd].RCMDParamter = new Dictionary<string, string>();
                        foreach (var item in message.Body.subScesBody[1].subScesBody)  
                        {
                            SecsBody cpBody = new SecsBody(SecsDataType.L);
                            cpBody.Add(new SecsBody(SecsDataType.ASCII, item.subScesBody[0].Messge));
                            if(item.subScesBody.Count==2)  // 参数+ 参数值
                            {
                                string cpName = item.subScesBody[0].Messge.ToString();
                                string cpVal = item.subScesBody[1].Messge.ToString();
                                if (DataItem.DataList.RCMDList[cmd].CPNAME_VAL_List.ContainsKey(cpName))  // 参数存在
                                {
                                    if (DataItem.DataList.RCMDList[cmd].CPNAME_VAL_List[cpName].Contains(cpVal)) // 参数值存在
                                    {
                                        DataItem.DataList.RCMDList[cmd].RCMDParamter.Add(cpName, cpVal);
                                        cpBody.Add(new SecsBody(SecsDataType.B, 0));
                                    }
                                    else  // 值不存在
                                    {
                                        cpBody.Add(new SecsBody(SecsDataType.B, 1));
                                    }
                                }
                                else  // 参数不存在
                                {
                                    cpBody.Add(new SecsBody(SecsDataType.B, 1));
                                }
                            }
                            else  // 参数格式不正确
                            {
                                cpBody.Add(new SecsBody(SecsDataType.B, 1));
                            }
                            paramter.Add(cpBody);
                        }
                       
                        // 所有参数相同才能给出事件
                        if(DataItem.DataList.RCMDList[cmd].RCMDParamter.Count== message.Body.subScesBody[1].subScesBody.Count)
                        {
                            DataItem.DataList.RCMDList[cmd].Action();
                        }                       
                    }
                    else  // 命令不带参数
                    {
                        DataItem.DataList.RCMDList[cmd].Action();
                       // resBody.Add(new SecsBody(SecsDataType.B,0));
                    }
                }
                else // 不包含命令
                {
                    resBody.Add(new SecsBody(SecsDataType.B, 1));
                }
            }
            else  // 格式不正确
            {
                resBody.Add(new SecsBody(SecsDataType.B, 1));
            }
            resBody.Add(paramter);
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(2, 42, message.Header.SystemBytes, resBody);


        }

        public SecsMessage ResultMsg(SecsMessage message,byte HCACK)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody hcack = new SecsBody(SecsDataType.B, HCACK);
            SecsBody paramterList = new SecsBody(SecsDataType.L);
            body.Add(hcack);
            body.Add(paramterList);
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(2, 42, message.Header.SystemBytes, body);
        }


        public SecsMessage ResultMsg(SecsMessage message,byte HCACK,byte CPACK)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody hcack = new SecsBody(SecsDataType.B, HCACK);
            SecsBody paramterList = new SecsBody(SecsDataType.L);
            if (message.Body.subScesBody.Count==2)
            {
                if (message.Body.subScesBody[1].subScesBody.Count>0)
                {
                    if (message.Body.subScesBody[1].subScesBody[0].subScesBody.Count==2)
                    {
                        string cpnameValue = message.Body.subScesBody[1].subScesBody[0].subScesBody[0].Messge.ToString();
                        SecsBody paramter = new SecsBody(SecsDataType.L);
                        SecsBody cpname = new SecsBody(SecsDataType.ASCII, cpnameValue);
                        SecsBody cpack = new SecsBody(SecsDataType.B, CPACK);
                        paramter.Add(cpname);
                        paramter.Add(cpack);
                        paramterList.Add(paramter);
                    }
                }
            }
                             
            body.Add(hcack);
            body.Add(paramterList);
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(2, 42, message.Header.SystemBytes, body);
        }
  
    }
}
