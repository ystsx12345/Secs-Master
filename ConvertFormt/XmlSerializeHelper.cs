using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ConvertFormt
{
   public class XmlSerializeHelper
    {

        /// <summary>
        /// 序列化实体类到文件中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public static void XmlSerializerToFile<T>(T obj,string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path,FileMode.Create))
                {
                    Type t = obj.GetType();
                    XmlSerializer serialer = new XmlSerializer(t);
                    serialer.Serialize(fs, obj);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 反序列化实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T XmlDeserialerFromFile<T>(string path) where T:class
        {
            try
            {
                using (FileStream fs = new FileStream(path,FileMode.Open))
                {
                    XmlSerializer serialer = new XmlSerializer(typeof(T));
                    return serialer.Deserialize(fs) as T;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
