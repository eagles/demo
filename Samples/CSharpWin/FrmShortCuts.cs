using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace CSharpWin
{
    /// <summary>
    /// 需要引入Windows Host Script Object in COM+
    /// </summary>
    public partial class FrmShortCuts : Form
    {
        private string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//得到桌面文件夹
        private WshShell shell = new WshShell();

        public FrmShortCuts()
        {
            InitializeComponent();
        }

        private void btnCreateClick(object sender, EventArgs e)
        {
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(desktopPath + "\\FSCapture.lnk");

            shortcut.TargetPath = @"D:\software\FSCapture.exe";
            shortcut.Arguments = "";
            shortcut.Description = "截图工具FSCapture";
            shortcut.WorkingDirectory = @"D:\software\";
            shortcut.IconLocation = @"D:\software\FSCapture.exe,0";
            //shortcut.Hotkey = "CTRL+SHIFT+X";//热键
            shortcut.WindowStyle = 1;
            shortcut.Save();

            MessageBox.Show("Created a shortcut for FSCature application", "INFO");
        }

        private void btnCreateWebShortcutClick(object sender, EventArgs e)
        {
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(desktopPath + "\\cnblogs.lnk");

            shortcut.TargetPath = @"%HOMEDRIVE%/Program Files (x86)\Internet Explorer\IEXPLORE.EXE";
            shortcut.Arguments = "http://easonwu.cnblogs.com";// 参数
            shortcut.Description = "cnblogs";
            shortcut.WorkingDirectory = Application.StartupPath; //程序所在文件夹，在快捷方式图标点击右键可以看到此属性 
            shortcut.IconLocation = @"%HOMEDRIVE%/Program Files (x86)\Internet Explorer\IEXPLORE.EXE, 0";//图标 
            shortcut.Hotkey = "CTRL+SHIFT+Z";//热键
            shortcut.WindowStyle = 1;
            shortcut.Save();

            MessageBox.Show("Created a shortcut for cnblogs.com", "INFO");
        }
    }
}
