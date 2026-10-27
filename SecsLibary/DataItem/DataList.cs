using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace SecsLibary.DataItem
{
    /// <summary>
    /// 全局的SECS数据包括VID ECID  RPTID  CEID RCMD PPID
    /// 并且提供了保存文件的方法
    /// </summary>
    [Serializable]
    public class DataList
    {

        #region 控制变量
        /// <summary>
        /// 当更新数据时不存在ID是否自动添加
        /// </summary>
        public static bool AddIdWhenUpdate = true;

        #endregion

        #region 数据集合

       

        private static Dictionary<string, VID> vidList;
        private static Dictionary<string, ALARM> alarmList;
        private static Dictionary<string, CEID> ceidList;
        private static Dictionary<string, PPID> ppidList;
        private static Dictionary<string, SVID> svidList;
        private static Dictionary<string, ECID> ecidList;
        private static Dictionary<string, RPTID> rptidList;
        private static Dictionary<string, RCMD> rcmdList;
    

        //   public event Action PPIDListChanged;

        /// <summary>
        /// VID(变量) 列表
        /// </summary>
        public static Dictionary<string, VID> VIDList
        {
            get
            {
                if (vidList == null)
                {
                    vidList = new Dictionary<string, VID>();
                }
                return vidList;
            }
            set
            {
                vidList = value;
            }

        }

        /// <summary>
        /// Alarm(报警) 列表
        /// </summary>
        public static Dictionary<string, ALARM> ALARMList
        {
            get
            {
                if (alarmList == null)
                {
                    alarmList = new Dictionary<string, ALARM>();
                }
                return alarmList;
            }
            set
            {
                alarmList = value;
            }
        }

        /// <summary>
        /// Event(事件) 列表
        /// </summary>
        public static Dictionary<string, CEID> CEIDList
        {
            get
            {
                if (ceidList == null)
                {
                    ceidList = new Dictionary<string, CEID>();
                }
                return ceidList;
            }
            set { ceidList = value; }
        }

        /// <summary>
        /// PPID(配方) 列表
        /// </summary>
        public static Dictionary<string, PPID> PPIDList
        {
            get
            {
                if (ppidList == null) ppidList = new Dictionary<string, PPID>();
                return ppidList;
            }
            set { ppidList = value; }
        }

        /// <summary>
        /// SVID(状态变量) 列表
        /// </summary>
        public static Dictionary<string, SVID> SVIDList
        {
            get
            {
                if (svidList == null) svidList = new Dictionary<string, SVID>();
                return svidList;
            }
            set { svidList = value; }
        }

        /// <summary>
        /// ECID(设备常量) 列表
        /// </summary>
        public static Dictionary<string, ECID> ECIDList
        {
            get
            {
                if (ecidList == null) ecidList = new Dictionary<string, ECID>();
                return ecidList;
            }
            set { ecidList = value; }
        }

        /// <summary>
        /// RPTID(报告常量) 列表
        /// </summary>
        public static Dictionary<string, RPTID> RPTIDList
        {
            get
            {
                if (rptidList == null) rptidList = new Dictionary<string, RPTID>();
                return rptidList;
            }
            set { rptidList = value; }
        }

        /// <summary>
        /// 远程命令
        /// </summary>
        public static Dictionary<string,RCMD> RCMDList
        {
            get
            {
                if (rcmdList == null) rcmdList = new Dictionary<string, RCMD>();
                return rcmdList;
            }
            set { rcmdList = value; }
        }

   

        #endregion

        #region 数据更新

        /// <summary>
        /// 更新常量ECID
        /// </summary>
        /// <param name="ecid"></param>
        /// <returns></returns>
        public static bool ModifyECID(ECID ecid)
        {
            if (ECIDList.ContainsKey(ecid.ID))
            {
                ECIDList[ecid.ID] = ecid;
            }
            else
            {
                if(AddIdWhenUpdate)
                {
                    ECIDList.Add(ecid.ID, ecid);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 更新变量VID
        /// </summary>
        /// <param name="vid"></param>
        /// <returns></returns>
        public static bool ModifyVID(VID vid)
        {
            if (VIDList.ContainsKey(vid.ID))
            {
                VIDList[vid.ID] = vid;
            }
            else
            {
                if (AddIdWhenUpdate)
                {
                    VIDList.Add(vid.ID, vid);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ModifyVID(string id,string value)
        {
            if (VIDList.ContainsKey(id))
            {
                VIDList[id].VALUES = value;
            }
            else
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 更新变量SVID
        /// </summary>
        /// <param name="svid"></param>
        /// <returns></returns>
        public static bool ModifySVID(SVID svid)
        {
            if (SVIDList.ContainsKey(svid.ID))
            {
                SVIDList[svid.ID] = svid;
            }
            else
            {
                if (AddIdWhenUpdate)
                {
                    SVIDList.Add(svid.ID, svid);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 更新报警ALARM
        /// </summary>
        /// <param name="alarm"></param>
        /// <returns></returns>
        public static bool ModifyALARM(ALARM alarm)
        {
            if (ALARMList.ContainsKey(alarm.ALID))
            {
                ALARMList[alarm.ALID] = alarm;
            }
            else
            {
                if (AddIdWhenUpdate)
                {
                    ALARMList.Add(alarm.ALID, alarm);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

       

       
        /// <summary>
        /// 更新报告 RPTID
        /// </summary>
        /// <param name="rptid"></param>
        /// <returns></returns>
        public static bool ModifyRPTID(RPTID rptid)
        {
            if (RPTIDList.ContainsKey(rptid.ID))
            {
                RPTIDList[rptid.ID] = rptid;
            }
            else
            {
                if (AddIdWhenUpdate)
                {
                    RPTIDList.Add(rptid.ID, rptid);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 更新事件CEID
        /// </summary>
        /// <param name="ceid"></param>
        /// <returns></returns>
        public static bool ModifyCEID(CEID ceid)
        {
            if (CEIDList.ContainsKey(ceid.ID))
            {
                CEIDList[ceid.ID] = ceid;
            }
            else
            {
                if (AddIdWhenUpdate)
                {
                    CEIDList.Add(ceid.ID, ceid);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 更新配方PPID
        /// </summary>
        /// <param name="ppid"></param>
        /// <returns></returns>
        public static bool ModifyPPID(PPID ppid)
        {
            if (PPIDList.ContainsKey(ppid.ID))
            {
                PPIDList[ppid.ID] = ppid;
            }
            else
            {
                if (AddIdWhenUpdate)
                {
                    PPIDList.Add(ppid.ID, ppid);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }


        #endregion

        #region 数据加载与保存

        /// <summary>
        /// 序列化数据到文件
        /// </summary>
        /// <param name="file"></param>
        public static void Serialization(string file)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Secs");
            // VID
            XElement VID = new XElement("VID");
            foreach (var vid in VIDList)
            {
                XElement element = vid.Value.GetElement();
                VID.Add(element);
            }
            root.Add(VID);
    
            //ECID
            XElement ECID = new XElement("ECID");
            foreach (var ecid in ECIDList)
            {
                XElement element = ecid.Value.GetElement();
                ECID.Add(element);
            }
            root.Add(ECID);
            //ALARM
            XElement ALARM = new XElement("ALARM");
            foreach (var alarm in ALARMList)
            {
                XElement element = alarm.Value.GetElement();
                ALARM.Add(element);
            }
            root.Add(ALARM);
            //RPTID
            XElement RPTID = new XElement("RPTID");
            foreach (var rptid in RPTIDList)
            {
                XElement element = rptid.Value.GetElement();
                RPTID.Add(element);
            }
            root.Add(RPTID);
            //CEID
            XElement CEID = new XElement("CEID");
            foreach (var ceid in CEIDList)
            {
                XElement element = ceid.Value.GetElement();
                CEID.Add(element);
            }
            root.Add(CEID);
            // RCMD
            XElement RCMD = new XElement("RCMD");
            foreach (var rcmd in RCMDList)
            {
                XElement element = rcmd.Value.GetElement();
                RCMD.Add(element);
            }
            root.Add(RCMD);

            // PPID
            XElement PPID = new XElement("PPID");
            foreach (var ppid in PPIDList)
            {
                XElement element = ppid.Value.GetElement();
                PPID.Add(element);
            }
            root.Add(PPID);

            doc.Add(root);
            doc.Save(file);
        }

        /// <summary>
        /// 反序列化从文件
        /// </summary>
        /// <param name="file"></param>
        public static void DeSerialization(string file)
        {
            XDocument doc = XDocument.Load(file);
            XElement root = doc.Root;
            // VID
            XElement VID = root.Element("VID");
           // VIDList.Clear();
            foreach (var vid in VID.Elements("VID"))
            {
                VID subVid = new VID();
                subVid.SetElement(vid);
                if(VIDList.ContainsKey(subVid.ID))
                {
                    VIDList[subVid.ID] = subVid;
                }
                else
                {
                    VIDList.Add(subVid.ID, subVid);
                }
                
            }

            //ECID
            XElement ECID = root.Element("ECID");
          //  ECIDList.Clear();
            foreach (var ecid in ECID.Elements("ECID"))
            {
                ECID subEcid = new ECID();
                subEcid.SetElement(ecid);
                if (ECIDList.ContainsKey(subEcid.ID))
                {
                    ECIDList[subEcid.ID] = subEcid;
                }
                else
                {
                    ECIDList.Add(subEcid.ID, subEcid);
                }
               
            }
         
            //ALARM
            XElement ALARM = root.Element("ALARM");
          //  ALARMList.Clear();
            foreach (var alarm in ALARM.Elements("ALARM"))
            {
                ALARM subAlarm = new ALARM();
                subAlarm.SetElement(alarm);
                if (ALARMList.ContainsKey(subAlarm.ALID))
                {
                    ALARMList[subAlarm.ALID] = subAlarm;
                }
                else
                {
                    ALARMList.Add(subAlarm.ALID.ToString(), subAlarm);
                }
          
            }
            
            //RPTID
            XElement RPTID = root.Element("RPTID");
          //  RPTIDList.Clear();
            foreach (var rptid in RPTID.Elements("RPTID"))
            {
                RPTID subRptid = new RPTID();
                subRptid.SetElement(rptid);
                if (RPTIDList.ContainsKey(subRptid.ID))
                {
                    RPTIDList[subRptid.ID] = subRptid;
                }
                else
                {
                    RPTIDList.Add(subRptid.ID, subRptid);
                }
               
            }
           
            //CEID
            XElement CEID = root.Element("CEID");
          //  CEIDList.Clear();
            foreach (var ceid in CEID.Elements("CEID"))
            {
                CEID subCeid = new CEID();
                subCeid.SetElement(ceid);
                if (CEIDList.ContainsKey(subCeid.ID))
                {
                    CEIDList[subCeid.ID] = subCeid;
                }
                else
                {
                    CEIDList.Add(subCeid.ID, subCeid);
                }
               
            }
            //RCMD
            XElement RCMD = root.Element("RCMD");
          //  RCMDList.Clear();
            foreach (var rcmd in RCMD.Elements("RCMD"))
            {
                RCMD subRcmd = new RCMD();
                subRcmd.SetElement(rcmd);
                if (RCMDList.ContainsKey(subRcmd.CmdKey))
                {
                    RCMDList[subRcmd.CmdKey] = subRcmd;
                }
                else
                {
                    RCMDList.Add(subRcmd.CmdKey, subRcmd);
                }
               
            }
            
            // PPID
            XElement PPID = root.Element("PPID");
          //  PPIDList.Clear();
            foreach (var ppid in PPID.Elements("PPID"))
            {
                PPID subPPid = new PPID();
                subPPid.SetElement(ppid);
                if (PPIDList.ContainsKey(subPPid.ID))
                {
                    PPIDList[subPPid.ID] = subPPid;
                }
                else
                {
                    PPIDList.Add(subPPid.ID, subPPid);
                }
               
            }

        }

        #endregion
    }
}
