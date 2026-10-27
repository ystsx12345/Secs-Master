using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt.Time
{
    /// <summary>
    ///控制会话超时   发送 select.req 启动   接受到select.rsp 终止
    /// </summary>
    public class T6 
    {
        public  event Action TimeOutEvent;
        private Action TimeRun;
        private bool Istop = false;
        private int TimeCount = 0;
        private int Index = 0;

        public string Name { get; set; }
        public bool IsRunning { get; set; }
        public T6()
        {
            TimeRun += callback;
        }

        public  void Start(int time)
        {
            Index = 0;
            TimeCount = time;
            IsRunning = true;
            TimeRun?.BeginInvoke(null, null);

        }

        public  void Stop()
        {
            Istop = true;
            //IsRunning = false;
        }

        private void callback()
        {
            do
            {
                Index++;
                System.Threading.Thread.Sleep(1000);
             
                if (Index > TimeCount)
                {
                    IsRunning = false;
                   
                    TimeOutEvent?.Invoke();
                    break;
                }
                if (Istop)
                {
                    Index = 0;
                    Istop = false;
                    IsRunning = false;
                    
                    break;
                }
                Debug.WriteLine($"{Name} Run");

            } while (true);
        }
    }
}
