using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpWin.Apps
{
    public partial class FrmDemo : UserControl
    {
        public FrmDemo()
        {
            InitializeComponent();
        }

        private void btnShowMsgClick(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked on me", "Message");
        }
    }
}
