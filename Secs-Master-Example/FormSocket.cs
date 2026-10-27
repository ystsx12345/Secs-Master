using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Secs_Socket;
using ConvertFormt;
using ConvertFormt.Server;

namespace Secs_Master_Example
{
    public partial class FormSocket : Form
    {

    
        private Secs sces;
        public FormSocket()
        {
            InitializeComponent();
            radPassive.Checked = true;
            sces = new Secs();
            sces.ScesStatusChanged += Sces_ScesStatusChanged;
            sces.ScesReciveRequestEvent += Sces_ScesRequestEvent;
            sces.MachineStatusChanged += Sces_MachineStatusChanged;
            Log.SetLogBytes(richLog);
            Log.SetLogSML(richLog2);

        }

        private void Sces_MachineStatusChanged(MachineStatus obj)
        {
            Log.LogInfo($"machine Status {Enum.GetName(obj.GetType(),obj)}");
        }

        /// <summary>
        /// 请求回复事件
        /// </summary>
        /// <param name="obj"></param>
        private void Sces_ScesRequestEvent(SecsMessage obj,Secs sces)
        {
           sces.Send(SecsLibary.EQPManger.Mange(obj, sces));
        }

        /// <summary>
        /// 模式状态改变
        /// </summary>
        /// <param name="obj"></param>
        private void Sces_ScesStatusChanged(SecsStatus obj)
        {
            if (label3.InvokeRequired)
            {
                label3.Invoke(new Action(() =>

                label3.Text = Enum.GetName(obj.GetType(), obj)
                )) ;
            }
            else
            {
                label3.Text = Enum.GetName(obj.GetType(), obj);
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {

            #region 固定回复

         /*

            SecsBodyCommon com = new SecsBodyCommon();
            //Select.rsp
            // S1F14
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody body1 = new SecsBody(SecsDataType.B, "0");
            SecsBody body2 = new SecsBody(SecsDataType.L);
            body.Add(body1);
            body.Add(body2);
            sces.Add(com.CreateScesMessage(1, 14, body));

            SecsBody body10 = new SecsBody(SecsDataType.L);
            SecsBody body11 = new SecsBody(SecsDataType.B, "0");
            body10.Add(body11);
            SecsBody body12 = new SecsBody(SecsDataType.L);

            SecsBody body13 = new SecsBody(SecsDataType.L);
            SecsBody body14 = new SecsBody(SecsDataType.ASCII,"0");
            SecsBody body15 = new SecsBody(SecsDataType.BOOlEAN,"1");
            body13.Add(body14);
            body13.Add(body15);
            body12.Add(body13);
            body10.Add(body12);
            sces.Add(com.CreateScesMessage(2, 42, body10));
            // S1F18
            SecsBody bodyS1F18 = new SecsBody(SecsDataType.B, "1");
            sces.Add(com.CreateScesMessage(1,18,bodyS1F18));
            // S1F2  在线请求回复
            SecsBody bodyS1F2 = new SecsBody(SecsDataType.L);
            SecsBody bodyMDLN = new SecsBody(SecsDataType.ASCII, "SIMTECH");
            SecsBody bodySoftRev = new SecsBody(SecsDataType.ASCII, "V1.2.45");
            bodyS1F2.Add(bodyMDLN);
            bodyS1F2.Add(bodySoftRev);
            sces.Add(com.CreateScesMessage(1, 2, bodyS1F2));

            // S2F18
            SecsBody bodyS2F17 = new SecsBody(SecsDataType.ASCII, DateTime.Now.ToString("yyyyMMddHHmmssfs"));
            //    sces.Add(com.CrateScesMessage(2, 18, bodyS2F17));
            // S1F4 回复设备状态
           */
            #endregion

            sces.Init(txtIP.Text, int.Parse(txtPort.Text), true);
            // VID 数据集合
            //SecsLibary.DataItem.DataList.VIDList.Add("1001", new SecsLibary.VID() { ID = "1001", VALUES = "5" });
            //SecsLibary.DataItem.DataList.VIDList.Add("1002", new SecsLibary.VID() { ID = "1002", VALUES = "15" });
            //SecsLibary.DataItem.DataList.VIDList.Add("1003", new SecsLibary.VID() { ID = "1003", VALUES = "25" });
            //SecsLibary.DataItem.DataList.VIDList.Add("1004", new SecsLibary.VID() { ID = "1004", VALUES = "35" });
            //SecsLibary.DataItem.DataList.VIDList.Add("1005", new SecsLibary.VID() { ID = "1005", VALUES = "45" });
            //SecsLibary.DataItem.DataList.PPIDList.Add("45*45", null);
            //SecsLibary.DataItem.DataList.PPIDList.Add("46*46", null);
            //SecsLibary.DataItem.DataList.PPIDList.Add("47*47", null);
            this.btnEnable.Enabled = false;         
        }

        private void Buffer_ReciveMessageEvent(SecsMessage obj)
        {
          // Log.LogReciveSML(ScesMessageToSml.ToSml(obj, 22));
        }



        private void btnDisEnable_Click(object sender, EventArgs e)
        {
          
            this.btnEnable.Enabled = true;
            sces.Stop();
            
        }


        private void btnClearLog_Click(object sender, EventArgs e)
        {
          
            richLog.Clear();
        }

        private void btnClearLog2_Click(object sender, EventArgs e)
        {
            richLog2.Clear();
        }

        // S5F1 发送列表
        private void button6_Click(object sender, EventArgs e)
        {
            SecsBody body = new SecsBody(SecsDataType.L, "1");          
            SecsBody body1 = new SecsBody(SecsDataType.ASCII, "A");
            body.Add(body1);
            SecsBody body2 = new SecsBody(SecsDataType.ASCII, "B");
            body.Add(body2);
            SecsBody body3 = new SecsBody(SecsDataType.L, "C");          
            SecsBody body4 = new SecsBody(SecsDataType.ASCII, "C");
            body3.Add(body4);
            SecsBody body5 = new SecsBody(SecsDataType.ASCII, "C");
            body3.Add(body5);
            SecsBody body6 = new SecsBody(SecsDataType.L, "C");
            SecsBody body7 = new SecsBody(SecsDataType.U2, "12");
            body6.Add(body7);
            SecsBody body8 = new SecsBody(SecsDataType.U4, "65");
            body6.Add(body8);
            SecsBody body9 = new SecsBody(SecsDataType.B, "0");
            body6.Add(body9);
            body3.Add(body6);
            body.Add(body3);
            SecsBodyCommon common = new SecsBodyCommon();
            sces.Send(common.CreateScesMessage(5, 1, body));
       
        }

        private void btnS1F13_Click(object sender, EventArgs e)
        {
            SecsBody body = new SecsBody(SecsDataType.U4, new uint[] { 1,1});
            ////  SecsBody body3 = new SecsBody(SecsDataType.U4, new uint[] {1,1,1,1,1});
            //SecsBody body3 = new SecsBody(SecsDataType.U4, new uint[] { 1,1});
            //body.Add(body3);
            SecsBodyCommon common = new SecsBodyCommon();
            sces.Send(common.CreateScesMessage(1, 13, body));
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            sces.SaveAsXML("Sces.xml");
        }

        // S6F11 发送事件
        private void button1_Click(object sender, EventArgs e)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody ceid = new SecsBody(SecsDataType.ASCII, "3001");
            SecsBody rptidList = new SecsBody(SecsDataType.L);

            SecsBody vid0 = new SecsBody(SecsDataType.ASCII, "1000");
            SecsBody vid1 = new SecsBody(SecsDataType.ASCII, "1001");
            SecsBody vid2 = new SecsBody(SecsDataType.ASCII, "1002");
            SecsBody vid3 = new SecsBody(SecsDataType.ASCII, "1003");
            rptidList.Add(vid0);
            rptidList.Add(vid1);
            rptidList.Add(vid2);
            rptidList.Add(vid3);
            body.Add(ceid);
            body.Add(rptidList);
           
            SecsBodyCommon common = new SecsBodyCommon();
            sces.Send(common.CreateScesMessage(6, 11, body));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBody ppid = new SecsBody(SecsDataType.ASCII, "ADS-0009");
            SecsBody ppBody = new SecsBody(SecsDataType.B, new byte[60] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
             1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
             1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
             1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
             1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
             1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            body.Add(ppid);
            body.Add(ppBody);
            SecsBodyCommon common = new SecsBodyCommon();
            sces.Send(common.CreateScesMessage(7, 6, body));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                SecsBody secs = new SecsBody(SecsDataType.ASCII, "Hello world");

                SecsBodyCommon common = new SecsBodyCommon();
                sces.Send(common.CreateScesMessage(1, 1, secs));
                System.Threading.Thread.Sleep(100);
            }
      
        }
    }
}
