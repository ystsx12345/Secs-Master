using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecsLibary.DataItem
{
    /// <summary>
    /// secs 事件
    /// </summary>
   [Serializable]
   public class CEID
    {
        private List<string> list = null;

        /// <summary>
        /// 事件ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 事件的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否允许发送
        /// </summary>
        public bool Enable { get; set; } = true;

        /// <summary>
        /// 事件关联报告列表
        /// </summary>
        public List<string> RPTIDList 
        {
            get
            {
                if (list == null)
                {
                    list = new List<string>();
                }
                return list;
            }
            set { list = value; }
        }

        public ConvertFormt.SecsMessage GetSecsMessage()
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody dataid = new SecsBody(SecsDataType.U4, Common.CreateDataID.GetDATAID());
            SecsBody ceid = new SecsBody(SecsDataType.ASCII, ID);
            SecsBody rptid = new SecsBody(SecsDataType.L);
            if (RPTIDList.Count>0)
            {
                foreach (var item in RPTIDList)
                {
                    if (DataList.RPTIDList.ContainsKey(item))
                    {
                        rptid.Add(DataList.RPTIDList[item].GetSecsMessage().Body);
                    }
                   
                }
            }
            body.Add(dataid);
            body.Add(ceid);
            body.Add(rptid);
            SecsBodyCommon comom = new SecsBodyCommon();
            return comom.CreateScesMessage(6, 11, body);
        }

        public override string ToString()
        {
            return $"ID:{ID},Link Reprot Count:{RPTIDList.Count}";
        }

        /// <summary>
        /// 返回xml的节点
        /// </summary>
        /// <returns></returns>
        public XElement GetElement()
        {
            XElement element = new XElement(this.GetType().Name);
            XAttribute ceidID = new XAttribute("ID", ID);  // id 属性
            element.Add(ceidID);
            XAttribute ceidName = new XAttribute("Name", Name);  // id 属性
            element.Add(ceidName);
            XAttribute ceidEnable = new XAttribute("Enable", Enable);
            element.Add(ceidEnable);
            foreach (var rptid in RPTIDList)
            {
                XElement RPTID = new XElement("RPTID");
                XAttribute rptidID = new XAttribute("ID", rptid);
                RPTID.Add(rptidID);
                element.Add(RPTID);
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
            RPTIDList.Clear();
            foreach (var rptid in element.Elements("RPTID"))
            {
                XAttribute rptidID = rptid.Attribute("ID");
                if(rptidID!=null) RPTIDList.Add(rptidID.Value);

            }

        }
    }
}
