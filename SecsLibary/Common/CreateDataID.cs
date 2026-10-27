using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.Common
{
    /// <summary>
    /// 生成一个0-65535的数字
    /// </summary>
  public  class CreateDataID
    {
        private static int dataID = 0;

        public static int GetDATAID()
        {
           if (dataID > 32767) dataID = 0;
           return dataID++;
        }
    }
}
