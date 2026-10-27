using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecsLibary.EQP;
using SecsLibary.Host;
using ConvertFormt;
using System.Reflection;
using ConvertFormt.Server;

namespace SecsLibary
{
   public class EQPManger
    {

        public static Dictionary<string, IResponse> ResponseList = new Dictionary<string, IResponse>();

        /// <summary>
        /// 自动回复管理方法
        /// </summary>
        /// <param name="message">需要回复消息内容</param>
        /// <param name="sces">消息内容</param>
        /// <returns></returns>
        public static SecsMessage Mange(SecsMessage message,Secs sces)
        {
            if (message.Header.ToString() != "S1F1" && message.Header.ToString()!="S1F13")
            {
                if(EQP_SECS_Data.ControlMode == CtrolMode.OfflineLine)
                {
                    SecsBodyCommon com = new SecsBodyCommon();
                    SecsBody body = new SecsBody(SecsDataType.B, 0);
                    return com.CreateScesMessage(byte.Parse(((int)message.Header.Stream- 128).ToString()), 0, message.Header.SystemBytes,body);
                }
            }       
            #region 枚举方法
         
            IResponse reponsed = null;
  
            switch (message.Header.ToString())
                {
                    case "S1F1":
                        reponsed = new S1F02();
                        break;
                    case "S1F3":
                        reponsed = new S1F04();
                        break;
                    case "S1F11":
                        reponsed = new S1F12();
                        break;
                    case "S1F13":
                        reponsed = new S1F14();
                        break;
                    case "S1F15":
                        reponsed = new S1F16();
                        break;
                    case "S1F17":
                        reponsed = new S1F18();
                        break;
                    case "S2F13":
                        reponsed = new S2F14();
                        break;
                    case "S2F17":
                        reponsed = new S2F18();
                        break;
                    case "S2F31":
                        reponsed = new S2F32();
                        break;
                    case "S2F33":
                        reponsed = new S2F34();
                        break;
                    case "S2F35":
                        reponsed = new S2F36();
                        break;
                    case "S2F37":
                        reponsed = new S2F38();
                        break;
                    case "S2F41":
                        reponsed = new S2F42();
                        break;
                    case "S5F3":
                        reponsed = new S5F04();
                        break;
                    case "S5F5":
                        reponsed = new S5F06();
                        break;
                    case "S5F7":
                        reponsed = new S5F08();
                        break;
                    case "S7F1":
                        reponsed = new S7F02();
                        break;
                    case "S7F3":
                        reponsed = new S7F04();
                        break;
                    case "S7F5":
                        reponsed = new S7F06();
                        break;
                    case "S7F17":
                        reponsed = new S7F18();
                        break;
                    case "S7F19":
                        reponsed = new S7F20();
                        break;
                    case "S10F3":
                        reponsed = new S10F04();
                        break;
                    case "S1F2":
                        break;

                    default:
                        break;

                }           
            return  reponsed.GetResponed(message, sces);
            
            #endregion

        }


        /// <summary>
        /// 添加自动回复列表
        /// </summary>
        /// <param name="key">键 Snfm</param>
        /// <param name="response">响应类</param>
        public static void AddResponse(IResponse response)
        {
            if (response == null) return;
            if (!ResponseList.ContainsKey(response.Key))
            {
                ResponseList.Add(response.Key, response);
            }
        }


        


        
    }
}
