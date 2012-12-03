/* ***********************************************
 * Author :  EASON
 * Email  :  wuyi@outlook.com
 * Function: 
 * history:  created by EASON 12/2/2012 10:48:34 PM
 * ***********************************************/

namespace ProgressBarEx
{
    using System;

    public class BackgroundWorkerEventArgs : EventArgs
    {
        /// <summary>
        /// 后台程序运行时抛出的异常
        /// </summary>
        public Exception BackGroundException { get; set; }
    }
}