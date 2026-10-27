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
    public partial class ActiveVIew : Form
    {
        public ActiveVIew()
        {
            InitializeComponent();
        }

        private void btnGetIp_Click(object sender, EventArgs e)
        {
            txtIP.Text = AppSessionHelper.GetLocalIp();
        }

        private void btnActiveMD5_Click(object sender, EventArgs e)
        {
            txtResult.Text = AppSessionHelper.GetMD5Hash(txtIP.Text);
        }
    }
}
