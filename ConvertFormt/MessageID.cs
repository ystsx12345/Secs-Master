using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{
  public  class MessageID
    {
        public static int Index = 0;
        public static int GetID()
        {
            Index++;
            if (Index>254)
            {
                Index = 0;
            }
            return Index;
        }
    }
}
