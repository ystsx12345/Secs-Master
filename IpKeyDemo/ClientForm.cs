using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpKeyDemo
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            client = new Secs_Socket.AppSession(txtIP.Text, int.Parse(txtPort.Text));
            client.ReciveDataFilter += Client_ReciveDataFilter; ;
        }

        private void Client_ReciveDataFilter(byte[] obj)
        {
            AppendLog($"{Encoding.ASCII.GetString(obj)}");
        }

        Secs_Socket.AppSession client = null;
        private void btnConnect_Click(object sender, EventArgs e)
        {
         
            var res =client.Start();
            if (!res)
            {
                MessageBox.Show("连接失败");
            }
        }

        private void Client_ReciveServerEvent(byte[] obj)
        {
            AppendLog($"{Encoding.ASCII.GetString(obj)}");
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            client.Stop();
        }

        private void AppendLog(string msg)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() =>
                {
                    richTextBox1.AppendText(msg);
                }
                ));
            }
            else
            {
                richTextBox1.AppendText(msg);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
           var res =  client.Send(Encoding.ASCII.GetBytes(txtMsg.Text),out string msg);
            if (!res)
            {
                MessageBox.Show(msg);
            }

        }

        private void chkReConnect_CheckedChanged(object sender, EventArgs e)
        {
           
                client.AutoReConnect = chkReConnect.Checked;
            
        }
    }
}
