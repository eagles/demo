using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// From: http://www.csharpwin.com/csharpspace/13450r130.shtml
// WinForm多线程及委托防止界面假死
// 当有大量数据需要计算、显示在界面或者调用sleep函数时，容易导致界面卡死，可以采用多线程加委托的方法解决。

namespace WinformProgressDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmProgressDemo());
        }
    }
}
