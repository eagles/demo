using System.Windows.Forms;

namespace ProgressBarEx
{
    public partial class ProgressForm : Form
    {
        /// <summary>
        /// Setup progress message
        /// </summary>
        public string MessageInfo
        {
            set { this.lblInfo.Text = value; }
        }

        /// <summary>
        /// Set the value of progress bar
        /// </summary>
        public int ProcessValue
        {
            set { this.progressBar.Value = value; }
        }

        /// <summary>
        /// Set the style of progress bar
        /// </summary>
        public ProgressBarStyle ProcessStyle
        {
            set { this.progressBar.Style = value; }
        }

        public ProgressForm()
        {
            InitializeComponent();
        }
    }
}
