using System;
using System.Data;
using System.Windows.Forms;

namespace Wypozyczalnia.View
{
    public partial class OrderPartsView : Form
    {
        public OrderPartsView()
        {
            InitializeComponent();
        }

        public virtual void SetColumnNames()
        {
            DataGridViewColumnCollection columns = dataGridView1.Columns;
            foreach (DataGridViewColumn column in columns)
                column.HeaderText = column.HeaderText.Replace('_', ' ');
        }

        public void SetColumnsWidth()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width =
                dataGridView1.Columns[1].Width =
                dataGridView1.Columns[2].Width =
                dataGridView1.Columns[4].Width = (int)(0.2 * width);

                dataGridView1.Columns[5].Width =
                dataGridView1.Columns[3].Width = (int)(0.1 * width);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void ActionResized(object sender, EventArgs e)
        {
            SetColumns();
        }

        public void SetColumns()
        {
            SetColumnNames();
            SetColumnsWidth();
        }

        public DataTable DataTable
        {
            set { this.dataGridView1.DataSource = value; }
        }

        private void ActionReturn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
