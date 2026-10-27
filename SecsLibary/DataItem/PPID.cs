using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecsLibary.DataItem
{

    /* 软件加载获取文件刷新PPID
     * 添加 删除 修改文件刷新依次
     * 下载参数时更新到本地文件
     */ 

    /// <summary>
    /// Secs process
    /// </summary>
    [Serializable]
    public class PPID
    {
        private List<PPBody> list = null;

        public string ID { get; set; }
      

        public List<PPBody> PPBodyList
        {
            get
            { 
                if (list == null) list = new List<PPBody>();
                return list;
            }
            set { list = value; }
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
            foreach (var ppBody in PPBodyList)
            {              
                XElement PPBody=  ppBody.GetElement();
                element.Add(PPBody);
            }
            return element;
        }


        public void SetElement(XElement element)
        {
            if (element == null) return;
            XAttribute attributeID = element.Attribute("ID");
            if (attributeID != null) ID = attributeID.Value;
          //  PPBodyList.Clear();
            foreach (var ppbody in element.Elements("PPBody"))
            {
                PPBody subPpbody = new PPBody();
                subPpbody.SetElement(ppbody);
                PPBodyList.Add(subPpbody);

            }

        }
    }
}
