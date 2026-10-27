using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecsLibary.Views
{
    public partial class TIDView : Form
    {
        public TIDView(string message)
        {
            InitializeComponent();
            textBox1.Text = message;
        }
    }
}
