using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.Model;

namespace Wypozyczalnia.View
{
    public partial class ClientsView : BaseView
    {

        public ClientsView()
        {
            InitializeComponent();
            //InitColumns();
        }

        //private void InitColumns()
        //{
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("ID", typeof(int));
        //    dataTable.Columns.Add("Imię", typeof(string));
        //    dataTable.Columns.Add("Nazwisko", typeof(string));
        //    dataTable.Columns.Add("Nr_dowodu", typeof(string));
        //    dataGridView1.DataSource = dataTable;
        //}

        // Wywolanie funkcji obslugujacych zdarzenia

        private void ActionAdd(object sender, EventArgs e)
        {
            controller.ShowClientAddForm();
        }

        private void ActionEdit(object sender, EventArgs e)
        {
            controller.ShowClientEditForm();
        }

        private void ActionDelete(object sender, EventArgs e)
        {
            controller.ShowClientDeleteForm();
        }

        private void ActionResized(object sender, EventArgs e)
        {
            SetColumns();
        }

        private void ActionReservations(object sender, EventArgs e)
        {
            // TODO
        }

        private void ActionSearchBySurname(object sender, EventArgs e)
        {
            controller.SearchClientBySurname();
        }

        // Pobranie z tabeli danych i utworzenie obiektu Client
        public Client GetActiveElement()
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;

                return new Client(
                    Convert.ToInt32(dataGridView1[0, index].Value),
                    dataGridView1[1, index].Value.ToString(),
                    dataGridView1[2, index].Value.ToString(),
                    dataGridView1[3, index].Value.ToString());
            }
            catch (FormatException ex)
            {
            }
            return null;
        }

        // Ustawienie szerokosci kolumn oraz naglowkow
        public void SetColumns()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width = (int)(0.1 * width);
                dataGridView1.Columns[1].Width = (int)(0.3 * width);
                dataGridView1.Columns[2].Width = (int)(0.3 * width);
                dataGridView1.Columns[3].Width = (int)(0.3 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

            DataGridViewColumnCollection columns = dataGridView1.Columns;
            foreach (DataGridViewColumn column in columns) {
                column.HeaderText = column.HeaderText.Replace('_',' ');
            }
            
        }

        public string ClientFilterSurname
        {
            get { return toolStripTextBox1.Text; }
        }

    }
}
