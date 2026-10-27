using ConvertFormt;
using ConvertFormt.Server;
using SecsLibary;
using SecsLibary.DataItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SecsLibary
{
    public partial class SECSView : Form
    {
        private Secs secs;
        private SecsConfig secsConfig;
        private int controlModeEventID;
        public event Action<string> SECS_LOT_SELECT;
        public event Action<bool,string>  SECS_PROCESS_DOWN;
        public event Action<List<string>> SECS_PROCESS_DELETE;
        public delegate List<SecsLibary.DataItem.PPBody> GetRecipeParamterDelegate(string recipeName);
        public GetRecipeParamterDelegate ParamterDelegate;
      
        public SECSView()
        {
            InitializeComponent();
            secs = new Secs();
            secsConfig = new SecsConfig();
            secs.ScesStatusChanged += Sces_ScesStatusChanged;
            secs.ScesReciveRequestEvent += Sces_ScesRequestEvent;
            secs.MachineStatusChanged += Sces_MachineStatusChanged;
            Log.SetLogBytes(richSECSILog);
            Log.SetLogSML(richSECSIILog);
            Log.EnableByteLog = true;
            sendView.SendActiveMessage += SendView_SendActiveMessage;
            this.Load += SECSView_Load;
            SecsLibary.EQP_SECS_Data.Idle = true;
            this.FormClosing += SECSView_FormClosing;
            EQP_SECS_Data.ControlModeChangedEvent += EQP_SECS_Data_ControlModeChangedEvent;
           
            //  LoadConfig();
          //  GetRecipeParamterDelegate 
        }

       

        private void SECSView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void SECSView_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

       
        private void LoadConfig()
        {
            if (File.Exists("Secs.json"))
            {
                secsConfig = (SecsConfig)SecsLibary.Common.JsonHelper.DeSerialize<SecsConfig>("Secs.json");
                txtIP.Text = secsConfig.IP;
                txtPort.Text = secsConfig.Port.ToString();
                chkAutoEnable.Checked = secsConfig.AutoEnable;
                controlModeEventID = secsConfig.ControlModeEventID;
                if (secsConfig.Listen)
                {
                    btnEnable.Enabled = false;
                }
                switch (secsConfig.ControlState)
                {
                    case 1:
                        radOffline.Checked = true;
                        break;
                    case 4:
                        radLocal.Checked = true;
                        break;
                    case 5:
                        radRemote.Checked = true;
                        break;
                    default:
                        break;
                }
             
            }
            // VID 数据集合
          //  UpdatePPIDList();
            if (secsConfig.AutoEnable)
            {
                InitSecs();
            }
        }

        /// <summary>
        /// SECS 配置保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            secsConfig.IP = txtIP.Text;
            secsConfig.Port = int.Parse(txtPort.Text);
            secsConfig.AutoEnable = chkAutoEnable.Checked;
            secsConfig.ControlState = (int)EQP_SECS_Data.ControlMode;
            secsConfig.ControlModeEventID= controlModeEventID;
            SecsLibary.Common.JsonHelper.Serialize("Secs.json",secsConfig);
            MessageBox.Show("Save Secs Config Success");
        }


        /// <summary>
        /// 设备状态改变
        /// </summary>
        /// <param name="obj"></param>
        private void Sces_MachineStatusChanged(MachineStatus obj)
        {
            Log.LogInfo($"machine Status {Enum.GetName(obj.GetType(), obj)}");
        }

        /// <summary>
        /// 主机发送请求回复
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void Sces_ScesRequestEvent(SecsMessage obj, Secs arg2)
        {

            if (obj.Header.Function % 2 ==1)
            {
                secs.Send(SecsLibary.EQPManger.Mange(obj, arg2));
            }
            else
            {
                Console.WriteLine("");
            }
            
        }

        /// <summary>
        /// SECS状态改变
        /// </summary>
        /// <param name="obj"></param>
        private void Sces_ScesStatusChanged(SecsStatus obj)
        {
            if (obj == SecsStatus.Selected)
            {
                EQP_SECS_Data.SecsEnable = true;
            }
            else
            {
                EQP_SECS_Data.SecsEnable = false;
            }
        }


        /// <summary>
        /// Enable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnable_Click(object sender, EventArgs e)
        {
            InitSecs();
        }

        /// <summary>
        /// Disable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisable_Click(object sender, EventArgs e)
        {
            secs.Stop();
            btnEnable.Enabled = true;
        }

        /// <summary>
        /// local / remote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (radLocal.Checked) EQP_SECS_Data.ControlMode = CtrolMode.OnLineLocal;
                  
        }
        // remote
        private void radRemote_CheckedChanged(object sender, EventArgs e)
        {
            if (radRemote.Checked) EQP_SECS_Data.ControlMode = CtrolMode.OnLineRemote;
        }

        private void radOffline_CheckedChanged(object sender, EventArgs e)
        {
            if(radOffline.Checked) EQP_SECS_Data.ControlMode = CtrolMode.OfflineLine;
        }

        private void EQP_SECS_Data_ControlModeChangedEvent(CtrolMode obj)
        {
            switch (obj)
            {
                case CtrolMode.None:
                    break;
                case CtrolMode.OfflineLine:
                    radOffline.Invoke(new Action(() =>
                    {
                        radOffline.Checked = true;
                    }
                    ));
                 
                    break;
                case CtrolMode.OnLineLocal:
                    radLocal.Invoke(new Action(() =>
                    {
                        radLocal.Checked = true;
                    }
                    ));
                  
                    break;
                case CtrolMode.OnLineRemote:
                    radRemote.Invoke(new Action(() =>
                    {
                        radRemote.Checked = true;
                    }
                   ));
                   
                    break;
                default:
                    break;
            }
            SendCEID(controlModeEventID.ToString());
        }

        /// <summary>
        /// 初始化SECS
        /// </summary>
        internal void InitSecs()
        {
            if (!IPAddress.TryParse(txtIP.Text,out IPAddress address))
            {
                MessageBox.Show("IP Address Format Error");
                return;
            }
            if (!int.TryParse(txtPort.Text,out int port))
            {
                MessageBox.Show("Port Foramt Error");
                return;
            }
            secs.Init(txtIP.Text, int.Parse(txtPort.Text), true);
            EQP_SECS_Data.Secs = secs;
            this.btnEnable.Enabled = false;
            secsConfig.Listen = true;
           
            EQP_SECS_Data.Company = "simtech";
            EQP_SECS_Data.Version = "v1.0.01";
            DataList.DeSerialization("secs.xml");
            // 可以建立一个容器 使用容器的方式将时间全部封装到容器中
            // DataList.RCMDList->远程命令容器
            // DataList.EventList-> 主机发送需要执行时间
            // EventList 需要提前配置 这样可以将内容提前加入到EventList的集合中
            // 触发时间
            // 主程序可直接使用EventList的内容
            SecsLibary.EQP.S7F04.PROCESS_DOWN_EVENT += S7F04_PROCESS_DOWN_EVENT;
            SecsLibary.EQP.S10F04.TIDDisplayEvent += S10F04_TIDDisplayEvent;
            SecsLibary.EQP.S7F18.PROCESS_DELETE_EVENT += S7F18_PROCESS_DELETE_EVENT;
          
        }

      

        private void S10F04_TIDDisplayEvent(string obj)
        {
            Views.TIDView view = new Views.TIDView(obj);
            view.ShowDialog();
        }         

        private void S7F18_PROCESS_DELETE_EVENT(List<string> obj)
        {
            SECS_PROCESS_DELETE?.Invoke(obj);
        }

        /// <summary>
        /// 主机发送Process
        /// </summary>
        /// <param name="obj"></param>
        private void S7F04_PROCESS_DOWN_EVENT(bool isCreate,string obj)
        {
            SECS_PROCESS_DOWN?.Invoke(isCreate,obj);
        }

        /// <summary>
        /// 主机发送Lot开始 需要下载参数到设备
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="paramter"></param>
        private void EQPStatus_PPSELECT_EVENT(string cmd,string paramter)
        {
            // MessageBox.Show($"Cmd:{cmd},Paramter:{paramter}");
            SECS_LOT_SELECT?.Invoke(paramter);
        }
    

      
        #region 日志操作
        private void btnClearLog1_Click(object sender, EventArgs e)
        {
            richSECSILog.Clear();
          
        }

        private void btnClearLog2_Click(object sender, EventArgs e)
        {
            richSECSIILog.Clear();
        }


        private void btnSaveSECSII_Click(object sender, EventArgs e)
        {
            SaveLog(richSECSIILog);
        }

        private void btnSaveSECSI_Click(object sender, EventArgs e)
        {
            SaveLog(richSECSILog);
        }

        ActiveSendView sendView = new ActiveSendView();
        private void btnActiveSend_Click(object sender, EventArgs e)
        {
            sendView.Show();
            sendView.Activate();
        }

        private void SendView_SendActiveMessage(SecsMessage obj)
        {
            secs.Send(obj);
        }


        private void SaveLog(RichTextBox rich)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save log";
            save.Filter = "txt|*.txt";
            var res = save.ShowDialog();
            if (res == DialogResult.OK)
            {

                using (FileStream fs = new FileStream(save.FileName, FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(rich.Text);
                    sw.Flush();
                    sw.Close();
                }
                MessageBox.Show("Save SECS Log Success");
            }

        }

        #endregion

        #region 主动发送
        public bool SendCEID(string id)
        {
            if (DataList.CEIDList.ContainsKey(id))
            {
                if (!DataList.CEIDList[id].Enable)
                {
                    return false;
                }
                SecsMessage message =  DataList.CEIDList[id].GetSecsMessage();
                secs.Send(message);
                return true;
            }
            return false;
        }

        public bool SendAlarm(string id)
        {
            if (DataList.ALARMList.ContainsKey(id))
            {
                if (!DataList.ALARMList[id].Enable)
                {
                    return false;
                }
                SecsMessage message = DataList.ALARMList[id].GetSecsMessage();
                secs.Send(message);
                return true;
            }
            return false;
        }

        public bool SendAlarm(ALARM alarm)
        {
            if (alarm == null) return false;
            if (DataList.ALARMList.ContainsKey(alarm.ALID))
            {
                if (!DataList.ALARMList[alarm.ALID].Enable)
                {
                    return false;
                }
                SecsMessage message = alarm.GetSecsMessage();
                secs.Send(message);
                return true;
            }
            return false;
        }

        public string SendVID(string vid)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody vidBody = new SecsBody(SecsDataType.U4, vid);
            body.Add(vidBody);
            SecsBodyCommon comom = new SecsBodyCommon();
            SecsMessage message = comom.CreateScesMessage(1, 3, body);
            secs.Send(message);
            return null;

            
        }

        public string[] SendVID(string[] vids)
        {
            if (vids == null) return null;
            SecsBody body = new SecsBody(SecsDataType.L);
            foreach (var item in vids)
            {
                SecsBody vidBody = new SecsBody(SecsDataType.U4, item);
                body.Add(vidBody);
            }         
            SecsBodyCommon comom = new SecsBodyCommon();
            SecsMessage message = comom.CreateScesMessage(1, 3, body);
            secs.Send(message);
            return null;
        }


        #endregion

        #region 文件操作
        private void saveToFile_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save Data List";
            save.Filter = "xml|*.xml";
            var res = save.ShowDialog();
            if (res == DialogResult.OK)
            {
                DataList.Serialization(save.FileName);
                MessageBox.Show("Save SECS Data Success");
            }


        }

        private void loadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open Secs data";
            open.Filter = "xml|*.xml";
            var res = open.ShowDialog();
            if (res == DialogResult.OK)
            {
                DataList.DeSerialization(open.FileName);
                MessageBox.Show("Open SECS Data Success");
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            SendVID("1000");
        }

       
    }
}
