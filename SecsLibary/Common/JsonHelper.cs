using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SecsLibary.Common
{
  public  class JsonHelper
    {
        /// <summary>
        /// 序列化到文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="obj"></param>
        public static void Serialize(string file,object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            using (FileStream fs = new FileStream(file,FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(json);
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// 反序列化从文件中
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static object DeSerialize<T>(string file)
        {
            string result = string.Empty;
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                StreamReader sw = new StreamReader(fs);
                result= sw.ReadToEnd();
            }
           return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
