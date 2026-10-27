using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecsLibary
{
    /// <summary>
    /// 变量
    /// </summary>
    [Serializable]
    public class VID
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; } = "";
        /// <summary>
        /// 名称
        /// </summary>
        public string SVName { get; set; } = "";
        /// <summary>
        /// 值
        /// </summary>
        public string VALUES { get; set; } = "0";

        public SecsDataType Type { get; set; } = SecsDataType.ASCII;

        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; } = "pcs";

        /// <summary>
        /// 返回xml的节点
        /// </summary>
        /// <returns></returns>
        public XElement GetElement()
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            XElement element = new XElement(this.GetType().Name);
            foreach (var prop in props)
            {
                XAttribute attribute = new XAttribute(prop.Name, prop.GetValue(this));
                element.Add(attribute);
            }
            return element;
        }


        public void SetElement(XElement element)
        {
            if (element == null) return;
            PropertyInfo[] props = this.GetType().GetProperties();          
            foreach (var prop in props)
            {
                XAttribute attribute =  element.Attribute(prop.Name);
              //  if (attribute != null) prop.SetValue(this, attribute.Value);
                if (attribute != null)
                {
                    if (prop.PropertyType.Name == "SecsDataType")
                    {
                        prop.SetValue(this, Enum.Parse(typeof(SecsDataType), attribute.Value));
                    }
                    else
                    {
                        prop.SetValue(this, attribute.Value);
                    }

                }
            }
           
        }

       
    }
}
