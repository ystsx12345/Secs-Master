using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConvertFormt;

namespace SecsLibary.DataItem
{

    /// <summary>
    /// 具体参数
    /// </summary>
    [Serializable]
    public class PPBody
    {
        public string Name { get; set; }

        public SecsDataType Type { get; set; }

        public string Value { get; set; }




        public SecsBody GetSecsBody()
        {

            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody nameBody = new SecsBody(SecsDataType.ASCII, Name);
            SecsBody valueBody = new SecsBody(Type, Value);
            body.Add(nameBody);
            body.Add(valueBody);
            return body;
        }

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
