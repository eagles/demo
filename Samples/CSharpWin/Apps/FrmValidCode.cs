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
    public partial class FrmValidCode : UserControl
    {
        private ValidCode validCode = new ValidCode(4, ValidCode.CodeType.Words);

        public FrmValidCode()
        {
            InitializeComponent();
        }

        private void FrmValidCodeLoad(object sender, EventArgs e)
        {
            LoadValidCode();
        }

        private void picValidCodeClick(object sender, EventArgs e)
        {
            LoadValidCode();
        }

        private void LoadValidCode()
        {
            picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!this.txtValidCode.Text.Equals(validCode.CheckCode))
            {
                MessageBox.Show(" 请输入正确的验证码!", this.Text);
                this.txtValidCode.Focus();
                return;
            }
            else
            {
                MessageBox.Show("验证码通过", this.Text);
                return;
            }
        }
    }
}
