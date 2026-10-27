using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary
{
   public abstract class ISend
    {
        public abstract bool SendActive<T>(T obj,ref SecsMessage objRef);
    }
}
