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
    public partial class BaseView : Form
    {
        protected Controller controller;

        public BaseView()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
        }

        public void SetDataTable(DataTable dataTable) 
        {
            this.dataGridView1.DataSource = dataTable;
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        private void ActionShowClientsView(object sender, EventArgs e)
        {
            controller.ShowClientsView();
        }

        private void ActionShowEmployeesView(object sender, EventArgs e)
        {
            controller.ShowEmployeesView();
        }

        private void ActionClose(object sender, FormClosingEventArgs e)
        {
            if (!controller.IsClosing)
            {
                if (MessageBox.Show("Wyjść?", "Wypożyczalnia",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.IsClosing = true;
                    Application.Exit();
                }
                else
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                }
            }
        }

        private void ActionExit(object sender, EventArgs e)
        {
            if (!controller.IsClosing)
            {
                if (MessageBox.Show("Wyjść?", "Wypożyczalnia",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.IsClosing = true;
                    Application.Exit();
                }
            }
        }

        private void ActionLoadData(object sender, EventArgs e)
        {
            controller.SelectAllAtActiveWindow();
        }

        public int GetActiveElementIndex()
        {
            return dataGridView1.CurrentRow.Index;
        }
    }
}

