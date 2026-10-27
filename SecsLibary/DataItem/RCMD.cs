using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecsLibary.DataItem
{
    /// <summary>
    /// 远程命令
    /// </summary>
   public class RCMD
    {
       

        private Dictionary<string, List<string>> cpname_val_list;
        private Dictionary<string, string> rcmdParamter;

        /// <summary>
        /// 命令关键字
        /// </summary>
        public string CmdKey { get; set; }


        /// <summary>
        /// 参数与其对应的参数值    // 一个命令可以有多个参数  一个参数也可以有多个值
        /// Key -> 参数名称   Value->参数允许值
        /// </summary>
        public Dictionary<string,List<string>> CPNAME_VAL_List
        {
            get 
            {
                if (cpname_val_list == null)
                {
                    cpname_val_list = new Dictionary<string, List<string>>();
                }
                    
                return cpname_val_list;
            }
            set
            {
                cpname_val_list = value;
            }
        }


        /// <summary>
        /// 远程命令参数列表
        /// </summary>
        public Dictionary<string, string> RCMDParamter
        {
            get 
            {
                if(rcmdParamter==null) rcmdParamter = new Dictionary<string, string>();

                return rcmdParamter;
            }
            set { rcmdParamter = value; }
        }

        /// <summary>
        /// 命令参数
        /// </summary>
        public string CPNAME { get; set; }

        /// <summary>
        /// 命令参数值
        /// </summary>
        public string CPVAL { get; set; }


        public void Action()
        {
            // 参数+参数值的集合
            RCMD_EVENT?.BeginInvoke(RCMDParamter, null, null);
        }

        /// <summary>
        /// 远程命令处理事件
        /// </summary>
        public event Action<Dictionary<string,string>> RCMD_EVENT;



        /// <summary>
        /// 返回xml的节点
        /// </summary>
        /// <returns></returns>
        public XElement GetElement()
        {

            XElement element = new XElement(this.GetType().Name);
            XAttribute rcmdID = new XAttribute("CmdKey", CmdKey);  // id 属性
            element.Add(rcmdID);
            foreach (var name_value in CPNAME_VAL_List)
            {
                XElement cpName = new XElement("CPNAME");
                XAttribute attributeName = new XAttribute("Name", name_value.Key);
                cpName.Add(attributeName);
                foreach (var val in name_value.Value)
                {
                    XElement cpVal = new XElement("CPVAL");
                    cpVal.Value = val;
                    cpName.Add(cpVal);
                }
                element.Add(cpName);
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
            XAttribute attributeID = element.Attribute("CmdKey");
            if (attributeID != null) CmdKey = attributeID.Value;
          //  CPNAME_VAL_List.Clear();
            foreach (var cpName in element.Elements("CPNAME"))
            {
                XAttribute attributeName = cpName.Attribute("Name");              
                if (attributeName != null)
                {
                    List<string> cpValList = new List<string>();
                    foreach (var cpVal in cpName.Elements("CPVAL"))
                    {
                        cpValList.Add(cpVal.Value);
                    }
                    if (CPNAME_VAL_List.ContainsKey(attributeName.Value))
                    {
                        CPNAME_VAL_List[attributeName.Value]= cpValList;
                    }
                    else
                    {
                        CPNAME_VAL_List.Add(attributeName.Value, cpValList);
                    }
                    
                }
               

            }
        }




    }
}
