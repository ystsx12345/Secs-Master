using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecsLibary
{
    public partial class ActiveSendView : Form
    {
        List<EQP_ACTIVE.ActiveStream> ListCmd = new List<EQP_ACTIVE.ActiveStream>();
        public event Action<ConvertFormt.SecsMessage> SendActiveMessage;
        public ActiveSendView()
        {
            InitializeComponent();
            ListCmd.Add(new EQP_ACTIVE.ActiveStream() { KeyName = "S5F1", Comment = "S5F1(Active Send Alarm)" });
            ListCmd.Add(new EQP_ACTIVE.ActiveStream() { KeyName = "S6F11", Comment = "S6F11(Active Send Event)" });
            cmbStream.DisplayMember = "Comment";
            cmbStream.ValueMember = "KeyName";
            cmbStream.DataSource = ListCmd;
        }

        private void ActiveSendView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbData.DisplayMember = "Value";
            cmbData.ValueMember = "Key";
            EQP_ACTIVE.ActiveStream select = cmbStream.SelectedItem as EQP_ACTIVE.ActiveStream;
            switch (select.KeyName)
            {
                case "S5F1":                   
                    cmbData.DataSource = new BindingSource(DataItem.DataList.ALARMList, null);                              
                    break;
                case "S6F11":
                    cmbData.DataSource = new BindingSource(DataItem.DataList.CEIDList, null);
                    break;
                default:
                    break;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string stream = cmbStream.SelectedValue.ToString();
            string data = cmbData.SelectedValue.ToString();
            ConvertFormt.SecsMessage message = null;
            switch (stream)
            {
                case "S5F1":
                    if(DataItem.DataList.ALARMList.ContainsKey(data))
                    {
                        if (DataItem.DataList.ALARMList[data].Enable == false) return;
                        message = DataItem.DataList.ALARMList[data].GetSecsMessage();
                        
                    }
                    else
                    {
                        MessageBox.Show("Select Data Error");
                        return;
                    }
                    break;
                case "S6F11":
                    if (DataItem.DataList.CEIDList.ContainsKey(data))
                    {
                        if (DataItem.DataList.CEIDList[data].Enable == false) return;
                        message = DataItem.DataList.CEIDList[data].GetSecsMessage();
                    }
                    else
                    {
                        MessageBox.Show("Select Data Error");
                        return;
                    }
                    break;

                default:
                    break;
            }
           if(message!=null) SendActiveMessage?.Invoke(message);

        }
    }
}
