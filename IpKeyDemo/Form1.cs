using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Secs_Socket.AppSocket;
using Secs_Socket;

namespace IpKeyDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void btnServer_Click(object sender, EventArgs e)
        {
            ServerForm form = new ServerForm();
            form.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            ClientForm frm = new ClientForm();
            frm.Show();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            ActiveVIew view = new ActiveVIew();
            view.Show();
        }
    }
}
