using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpWin.Apps;

namespace CSharpWin
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Add(new FrmValidCode());
        }
    }
}
