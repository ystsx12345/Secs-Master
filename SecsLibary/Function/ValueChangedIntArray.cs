using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.Function
{
   public class ValueChangedIntArray
    {
        private int[] lastValue;

        public bool GetChanged(int[] values)
        {
            if (lastValue==null)
            {
                lastValue = new int[values.Length];
                ChangedEvent?.Invoke(values);
                return true;
            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if(values[i]!=lastValue[i])
                    {
                        ChangedEvent?.Invoke(values);
                        return true;
                    }
                }
                return false;
            }           
        }

        public event Action<int[]> ChangedEvent;
    }
}
