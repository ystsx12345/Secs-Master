using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt.DataItem
{
    /// <summary>
    /// 只能是基础类型 boolen uint int ushort short string binary
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class VID<T>
    {

        public string  ID { get; set; }

        public string  Name { get; set; }

        public T Value { get; set; }

    }
}
