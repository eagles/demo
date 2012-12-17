namespace ProgressBarEx
{
    using System;
    using System.ComponentModel;

    using ProgressBarEx;

    public class PercentProgressOperator
    {
        private BackgroundWorker _backgroundWorker;//后台线程
        private ProgressForm _processForm;//进度条窗体
        private BackgroundWorkerEventArgs _eventArgs;//异常参数

        public PercentProgressOperator()
        {
            this._processForm = new ProgressForm();
            this._eventArgs = new BackgroundWorkerEventArgs();
            this._processForm.ProcessStyle = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._backgroundWorker = new BackgroundWorker();
            this._backgroundWorker.WorkerReportsProgress = true;
            this._backgroundWorker.DoWork += new DoWorkEventHandler(this._backgroundWorker_DoWork);
            this._backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._backgroundWorker_RunWorkerCompleted);
            this._backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this._backgroundWorker_ProgressChanged);
        }

        //显示进度
        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this._processForm.MessageInfo = "已完成：" + e.ProgressPercentage.ToString() + "%";
            this._processForm.ProcessValue = e.ProgressPercentage;
        }

        //操作进行完毕后关闭进度条窗体
        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        //后台执行的操作
        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.BackgroundWork != null)
            {
                try
                {
                    this.BackgroundWork(this.ReportPercent);
                }
                catch (Exception ex)
                {
                    this._eventArgs.BackGroundException = ex;
                }
            }
        }

        #region 公共方法、属性、事件

        /// <summary>
        /// <para>后台执行的操作,参数为一个参数为int型的委托；
        /// 在客户端要执行的后台方法中可以使用Action&lt;int&gt;预报完成进度,如：
        /// <example>
        /// <code>
        /// PercentProcessOperator o = new PercentProcessOperator();
        /// o.BackgroundWork = this.DoWord;
        /// 
        /// private void DoWork(Action&lt;int&gt; Report)
        /// {
        ///     Report(0);
        ///     //do soming;
        ///     Report(10);
        ///     //do soming;
        ///     Report(50);
        ///     //do soming
        ///     Report(100);
        /// }
        /// </code>
        /// </example></para>
        /// </summary>
        public Action<Action<int>> BackgroundWork { get; set; }

        /// <summary>
        /// 后台任务执行完毕后事件
        /// </summary>
        public event EventHandler<BackgroundWorkerEventArgs> BackgroundWorkerCompleted;

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Start()
        {
            this._backgroundWorker.RunWorkerAsync();
            this._processForm.ShowDialog();
        }

        #endregion

        //报告完成百分比
        private void ReportPercent(int i)
        {
            if (i >= 0 && i <= 100)
            {
                this._backgroundWorker.ReportProgress(i);
            }
        }
    }
}
