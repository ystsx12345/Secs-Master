using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary
{
   public class SList<T>:List<T>
    {
        public event Action CollectionChanged;
        public new  void Add(T t)
        {
            base.Add(t);
            CollectionChanged?.Invoke();
        }

        public new void Remove(T t)
        {
            base.Remove(t);
            CollectionChanged?.Invoke();
        }

    }
}
