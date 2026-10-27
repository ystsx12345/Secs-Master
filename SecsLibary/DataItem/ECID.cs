using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecsLibary.DataItem
{
    [Serializable]
   public class ECID
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }


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
                XAttribute attribute = element.Attribute(prop.Name);
                if (attribute != null) prop.SetValue(this, attribute.Value);
            }

        }

    }
}
