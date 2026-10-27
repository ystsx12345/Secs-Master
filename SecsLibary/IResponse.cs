using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt;
using ConvertFormt.Server;


namespace SecsLibary
{
    /// <summary>
    /// 定义响应消息基类  
    /// </summary>
   public abstract class IResponse
    {
        public string Key { get; set; }


        /// <summary>
        /// 针对需要回复类消息的  响应抽像类
        /// </summary>
        /// <param name="message">接受到消息实体</param>
        /// <param name="status">当前设备状态 remote local offline</param>
        /// <returns>需要发送的实体</returns>

        public abstract SecsMessage GetResponed(SecsMessage message, Secs status);
      




    }
}
