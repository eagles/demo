using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace FJXY.Demo.Basic.GridViewBindingWithList
{
    public partial class GridViewForm : Form
    {
        public GridViewForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            BindGridView();
        }

        /// <summary>
        /// Binding cusomters with gridview control
        /// </summary>
        private void BindGridView()
        {
            List<Customer> customers = GetCustomers();
            dataGridView1.DataSource = customers;
            dataGridView2.DataSource = customers;
        }

        /// <summary>
        /// Prepare cusomter collections
        /// </summary>
        /// <returns>A List of customers</returns>
        private List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 1; i <= 500; i++)
            {
                customers.Add(new Customer
                    {
                        Id = "cus" + i,
                        Name = string.Format("Cusomter-{0}", i),
                        Age = 10 + i,
                        Sex = (i % 2 == 0 ? "Male" : "Female"),
                        Company = String.Format("Company {0}", i)
                    }
                );
            }

            return customers;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height); 
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(CultureInfo.InvariantCulture),
                dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle, dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {
                // Use fixed size to make sure the icon is not shaped.
                Rectangle newRect = new Rectangle(e.CellBounds.X, (e.CellBounds.Y  + (e.CellBounds.Height / 2 - 8)), 16, 16);
                // Create a new icon
                Icon ico = new Icon("icon.ico");

                using (Brush gridBrush = new SolidBrush(dataGridView2.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush, 2))
                    {
                        // Erase the cell.
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        //Draw line
                        Point p1 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top);
                        Point p2 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top + e.CellBounds.Height);
                        Point p3 = new Point(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height);
                        Point[] ps = new Point[] { p1, p2, p3 };
                        e.Graphics.DrawLines(gridLinePen, ps);

                        //Draw icon
                        e.Graphics.DrawIcon(ico, newRect);

                        //Draw character string
                        e.Graphics.DrawString((e.RowIndex + 1).ToString(CultureInfo.InvariantCulture),
                            e.CellStyle.Font,
                            Brushes.Crimson, e.CellBounds.Left + 20,
                            (e.CellBounds.Y + (e.CellBounds.Height / 2 - dataGridView2.Font.Height / 2)),
                            StringFormat.GenericDefault);

                        e.Handled = true;
                    }
                }
            }
        }

    }
}
