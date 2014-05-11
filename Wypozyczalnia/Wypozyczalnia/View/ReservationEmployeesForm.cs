using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia.View
{
    public partial class ReservationEmployeesForm : Form
    {
        protected Controller controller;

        public ReservationEmployeesForm()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        /// <summary>
        /// Ustawia DataTable tablice, ktorej zawartosc ma byc wyswietlona
        /// </summary>
        public DataTable DataTable
        {
            set { this.dataGridView1.DataSource = value; }
        }

        public virtual void SetColumnNames()
        {
            DataGridViewColumnCollection columns = dataGridView1.Columns;
            foreach (DataGridViewColumn column in columns)
            {
                column.HeaderText = column.HeaderText.Replace('_', ' ');
            }
        }

        /// <summary>
        /// Ustawia nazwy i szerokosci kolumn
        /// </summary>
        public void SetColumns()
        {
            SetColumnNames();
            SetColumnsWidth();
        }

        private void ActionResized(object sender, EventArgs e)
        {
            SetColumns();
        }

        public virtual void SetColumnsWidth()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width = (int)(0.1 * width);
                dataGridView1.Columns[1].Width = (int)(0.2 * width);
                dataGridView1.Columns[2].Width = (int)(0.2 * width);
                dataGridView1.Columns[3].Width = (int)(0.13 * width);
                dataGridView1.Columns[4].Width = (int)(0.2 * width);
                dataGridView1.Columns[5].Width = (int)(0.1 * width);
                dataGridView1.Columns[6].Width = (int)(0.1 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

        }

        private void ActionReturn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
