using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            view.Hide();
        }

        SecsLibary.SECSView view = new SecsLibary.SECSView();
        private void btnSeceView_Click(object sender, EventArgs e)
        {
            view.Show();
       
          //  SecsLibary.DataItem.DataList.RCMDList["RESUME"].RCMD_EVENT += Form1_RCMD_EVENT;
           
        }

        private void Form1_RCMD_EVENT(Dictionary<string, string> obj)
        {
            throw new NotImplementedException();
        }
    }
}
