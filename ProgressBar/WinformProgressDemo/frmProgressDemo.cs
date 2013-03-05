using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WinformProgressDemo
{
    public partial class frmProgressDemo : Form
    {
        DataTable table;
        int currentIndex = 0;
        int max = 10000;

        public frmProgressDemo()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SetLableText("数据加载中...");
            currentIndex = 0;

            table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("name");
            table.Columns.Add("age");

            while (currentIndex < max)
            {
                SetLableText(string.Format("当前行:{0},剩余量:{1},完成比例:{2}%", currentIndex, max - currentIndex,
                         (Convert.ToDecimal(currentIndex) / Convert.ToDecimal(max) * 100).ToString("f0")));

                SetPbValue(currentIndex);
                DataRow dr = table.NewRow();
                dr["id"] = currentIndex;
                string name = "张三";
                dr["name"] = name;
                dr["age"] = currentIndex + 5;
                table.Rows.Add(dr);
                currentIndex++;
            }

            SetDgvDataSource(table);
            SetLableText("数据加载完成！");

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                btnLoad.Enabled = true;
            }));
        }

        delegate void labDelegate(string str);

        private void SetLableText(string str)
        {
            if (lblMsg.InvokeRequired)
            {
                Invoke(new labDelegate(SetLableText), new string[] { str });
            }
            else
            {
                lblMsg.Text = str;
            }
        }

        delegate void dgvDelegate(DataTable table);

        private void SetDgvDataSource(DataTable table)
        {
            if (dataGridView1.InvokeRequired)
            {
                Invoke(new dgvDelegate(SetDgvDataSource), new object[] { table });
            }
            else
            {
                dataGridView1.DataSource = table;
            }
        }

        delegate void pbDelegate(int value);

        private void SetPbValue(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                Invoke(new pbDelegate(SetPbValue), new object[] { value });
            }
            else
            {
                progressBar1.Value = value;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            Thread thread = new Thread(new ThreadStart(LoadData));
            thread.IsBackground = true;
            thread.Start();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = max;
        }
    }
}
