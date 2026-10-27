using ConvertFormt;
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
   public class ALARM
    {
        /// <summary>
        /// 设置报警或者清除报警
        /// </summary>
        public string ALCD { get; set; } = "128";

        /// <summary>
        /// 报警编号
        /// </summary>
        public string ALID { get; set; }

        
        /// <summary>
        /// 报警内容
        /// </summary>
        public string ALTX { get; set; }

        /// <summary>
        /// 允许报警发送
        /// </summary>
        public bool Enable { get; set; } = true;


        public ConvertFormt.SecsMessage GetSecsMessage()
        {
       
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody alcd = new SecsBody(SecsDataType.B, ALCD);
            SecsBody alid = new SecsBody(SecsDataType.U4, ALID);
            SecsBody altx = new SecsBody(SecsDataType.ASCII, ALTX);
            body.Add(alcd);
            body.Add(alid);
            body.Add(altx);
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(5, 1, body);
        }

        public override string ToString()
        {
            return $"Text:{ALTX},ID:{ALID},Set/Clear:{ALCD}";
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
                  
                    if(prop.PropertyType.Name =="Boolean")
                    {
                        prop.SetValue(this, Convert.ToBoolean(attribute.Value));
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
