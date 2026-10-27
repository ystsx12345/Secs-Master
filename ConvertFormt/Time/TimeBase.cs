using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt.Time
{
    public abstract class TimeBase
    {

        /// <summary>
        /// 启动定时器 s
        /// </summary>
        public abstract void Start(int time,SecsMessage message);


        /// <summary>
        /// 终止定时器
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// 超时事件
        /// </summary>
        public abstract event Action<SecsMessage> TimeOutEvent;
 
    }
}
