/* ***********************************************
 * Author :  EASON
 * Email  :  wuyi@outlook.com
 * Function: 
 * history:  created by EASON 12/2/2012 9:17:17 PM
 * ***********************************************/

namespace ProgressBarEx
{
    using System;
    using System.ComponentModel;

    using ProgressBarEx;

    public class ProgressOperator
    {
        private BackgroundWorker _backgroundWorker;
        private ProgressForm _processForm;
        private BackgroundWorkerEventArgs _eventArgs;//异常参数

        /// <summary>
        /// 后台执行的操作
        /// </summary>
        public Action BackgroundWork { get; set; }

        /// <summary>
        /// 设置进度条显示的提示信息
        /// </summary>
        public string MessageInfo
        {
            set { this._processForm.MessageInfo = value; }
        }

        /// <summary>
        /// 后台任务执行完毕后事件
        /// </summary>
        public event EventHandler<BackgroundWorkerEventArgs> BackgroundWorkerCompleted;

        public ProgressOperator()
        {
            this._backgroundWorker = new BackgroundWorker();
            this._processForm = new ProgressForm();
            this._eventArgs = new BackgroundWorkerEventArgs();
            this._backgroundWorker.DoWork += new DoWorkEventHandler(this.backgroundWorker_DoWork);
            this._backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Start()
        {
            this._backgroundWorker.RunWorkerAsync();
            this._processForm.ShowDialog();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.BackgroundWork != null)
            {
                try
                {
                    this.BackgroundWork();
                }
                catch (Exception ex)
                {
                    this._eventArgs.BackGroundException = ex;
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this._processForm.Visible == true)
            {
                this._processForm.Close();
            }
            if (this.BackgroundWorkerCompleted != null)
            {
                this.BackgroundWorkerCompleted(null, this._eventArgs);
            }
        }
    }
}