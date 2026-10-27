using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.Function
{
   public class ValueChangeBool
    {
        bool lastValue = false;
        int index = 0;
      

        public bool GetChanged(bool value)
        {
            if(index==0)
            {
                ChangedEvent?.Invoke(value);
                index = 1;
                lastValue = value;
                return true;
            }
            else
            {
                if (value != lastValue)
                {
                    ChangedEvent?.Invoke(value);
                    lastValue = value;
                    return true;
                }
                else
                {
                    lastValue = value;
                    return false;
                }
            }
        }

        public event Action<bool> ChangedEvent;


    }
}
