using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt.Time
{
    /// <summary>
    /// 回复超时   发送后等待回复超时 从队列中消除发送记录
    /// </summary>
    public class T3 : TimeBase
    {
        public override event Action<SecsMessage> TimeOutEvent;

        private Action TimeRun;
        private bool Istop = false;
        private int TimeCount = 0;
        private int Index = 0;
        private SecsMessage mesage;

        public override void Start(int time,SecsMessage scesMessage)
        {
            TimeCount = time;
            mesage = scesMessage;
            TimeRun += callback;
            TimeRun?.BeginInvoke(null, null);

        }

        private void callback()
        {
            do
            {
                Index++;
                System.Threading.Thread.Sleep(1000);
                if (Index>TimeCount)
                {
                  //  Debug.WriteLine("T3 TimeOut");
                    TimeOutEvent?.Invoke(mesage);
                    break;
                }
                if (Istop)
                {
                    Index = 0;
                    Istop = false;
                  //  Debug.WriteLine("T3 Stop");
                    break;
                }
               // Debug.WriteLine("T3 Run");

            } while (true);
        }

        public override void Stop()
        {
            Istop = true;
        }
    }
}
