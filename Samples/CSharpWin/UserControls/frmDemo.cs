using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpWin.UserControls
{
    public partial class frmDemo : UserControl
    {
        public frmDemo()
        {
            InitializeComponent();
        }

        private void btnShowMsgClick(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked on me", "Message");
        }
    }
}
