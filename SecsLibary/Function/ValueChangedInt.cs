using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.Function
{
   public class ValueChangedInt
    {
        int lastValue = -1; 

        public bool GetChanged(int value)
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

        public event Action<int> ChangedEvent;



    }
}
