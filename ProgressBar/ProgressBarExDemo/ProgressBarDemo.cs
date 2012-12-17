using System;
using System.Windows.Forms;
using System.Threading;

namespace ProgressBarEx
{
    public partial class ProgressBarDemo : Form
    {
        public ProgressBarDemo()
        {
            InitializeComponent();
        }

        private void btnShowProgressBar_Click(object sender, EventArgs e)
        {
            ProgressOperator process = new ProgressOperator();
            process.BackgroundWork = this.Do;
            process.BackgroundWorkerCompleted += new EventHandler<BackgroundWorkerEventArgs>(process_BackgroundWorkerCompleted);
            process.Start();
        }

        void process_BackgroundWorkerCompleted(object sender, BackgroundWorkerEventArgs e)
        {
            if (e.BackGroundException == null)
            {
                MessageBox.Show("执行完毕");
            }
            else
            {
                MessageBox.Show("异常:" + e.BackGroundException.Message);
            }
        }

        private void btnShowPerProgressBar_Click(object sender, EventArgs e)
        {
            PercentProgressOperator process = new PercentProgressOperator();
            process.BackgroundWork = this.DoWithProcess;
            process.BackgroundWorkerCompleted += new EventHandler<BackgroundWorkerEventArgs>(process_BackgroundWorkerCompleted);
            process.Start();
        }

        void Do()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
            }
        }

        void DoWithProcess(Action<int> percent)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
                percent(i);
            }
        }
    }
}
