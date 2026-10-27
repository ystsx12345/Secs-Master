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
    /// <summary>
    /// secs report
    /// </summary>
    [Serializable]
     public class RPTID
    {

        private List<string> list = null;

        public string ID { get; set; }

        public string Name { get; set; }

        public List<string> VIDList 
        {
            get 
            {
                if (list == null) list = new List<string>();
                return list;
            }
            set { list = value; }
        }


        public ConvertFormt.SecsMessage GetSecsMessage()
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody rptid = new SecsBody(SecsDataType.ASCII, ID);           
            SecsBody vidList = new SecsBody(SecsDataType.L);
            if (VIDList.Count > 0)
            {
                foreach (var item in VIDList)
                {
                    if(DataList.VIDList.ContainsKey(item))
                    {
                        SecsBody vid = new SecsBody(SecsDataType.ASCII, DataList.VIDList[item].VALUES);
                        vidList.Add(vid);
                    }                   
                }              
            }
            body.Add(rptid);
            body.Add(vidList);
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(6, 11, body);
        }

        public override string ToString()
        {
            return $"ID:{ID},Link Reprot Count:{VIDList.Count}";
        }


        /// <summary>
        /// 返回xml的节点
        /// </summary>
        /// <returns></returns>
        public XElement GetElement()
        {
            
            XElement element = new XElement(this.GetType().Name);
            XAttribute rptidID = new XAttribute("ID", ID);  // id 属性
            element.Add(rptidID);
            XAttribute rptidName = new XAttribute("Name", Name);  // id 属性
            element.Add(rptidName);
            foreach (var vid in VIDList)
            {
                XElement VID = new XElement("VID");
                XAttribute vidID = new XAttribute("ID", vid);
                VID.Add(vidID);
                element.Add(VID);
            }          
            return element;
        }

        /// <summary>
        /// 设置xml的节点到实体
        /// </summary>
        /// <param name="element"></param>
        public void SetElement(XElement element)
        {
            if (element == null) return;
            XAttribute attributeID = element.Attribute("ID");
            if (attributeID != null) ID = attributeID.Value;
            XAttribute attributeName = element.Attribute("Name");
            if (attributeName != null) Name = attributeName.Value;
            //  VIDList.Clear();
            foreach (var vid in element.Elements("VID"))
            {
                XAttribute vidID = vid.Attribute("ID");
                if(vidID!=null) VIDList.Add(vidID.Value);

            }
        }

    }
}
