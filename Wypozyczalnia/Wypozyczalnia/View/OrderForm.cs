using System;
using System.Data;
using System.Windows.Forms;

namespace Wypozyczalnia.View
{
    public partial class OrderForm : BaseForm
    {
        public OrderForm()
        {
            InitializeComponent();
            textBox2.Text = DateTime.Today.ToString();
        }

        public OrderForm(Zamówienie order)
        {
            InitializeComponent();
            textBox1.Text = "" + order.Zamówienie_ID;
            textBox2.Text = order.Data_zamówienia.ToString();
            textBox3.Text = order.Data_odbioru.ToString();
        }

        public override void DisableAllFields()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        public virtual void SetColumnNames()
        {
            foreach (DataGridViewColumn column in partsAdded.Columns)
                column.HeaderText = column.HeaderText.Replace('_', ' ');
            foreach (DataGridViewColumn column in partsNotAdded.Columns)
                column.HeaderText = column.HeaderText.Replace('_', ' ');
        }

        public void SetColumnsWidth()
        {
            try
            {
                double width = partsNotAdded.Width - 20;
                partsNotAdded.Columns[0].Width =
                partsNotAdded.Columns[1].Width =
                partsNotAdded.Columns[2].Width =
                partsNotAdded.Columns[4].Width = (int)(0.2 * width);
                partsNotAdded.Columns[5].Width =
                partsNotAdded.Columns[3].Width = (int)(0.1 * width);

                width = partsAdded.Width - 20;
                partsAdded.Columns[0].Width =
                partsAdded.Columns[1].Width =
                partsAdded.Columns[2].Width =
                partsAdded.Columns[4].Width = (int)(0.2 * width);
                partsAdded.Columns[5].Width =
                partsAdded.Columns[3].Width = (int)(0.1 * width);
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

        public string TextBox3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        private void swapDataGrid(DataGridView dataGridViewFrom, DataGridView dataGridViewTo)
        {
            DataTable dataTable = (DataTable)dataGridViewTo.DataSource;
            DataRow dataRow = (dataGridViewFrom.CurrentRow.DataBoundItem as DataRowView).Row;
            dataTable.ImportRow(dataRow);
            dataGridViewFrom.Rows.Remove(dataGridViewFrom.CurrentRow);
        }

        public DataTable PartsAddedToOrder
        {
            get { return (DataTable)this.partsAdded.DataSource; }
            set { this.partsAdded.DataSource = value; }
        }

        public DataTable PartsNotAddedToOrder
        {
            get { return (DataTable)this.partsNotAdded.DataSource; }
            set { this.partsNotAdded.DataSource = value; }
        }

        private void AddPartToOrder(object sender, EventArgs e)
        {
            if (partsNotAdded.RowCount > 1)
                swapDataGrid(partsNotAdded, partsAdded);
        }

        private void RemovePartFromOrder(object sender, EventArgs e)
        {
            if (partsAdded.RowCount > 1)
                swapDataGrid(partsAdded, partsNotAdded);
        }

        private void SetPartPrice(object sender, EventArgs e)
        {
            try
            {
                Single price = Convert.ToSingle(TextBoxPrice.Text);
                if (price < 0)
                    MessageBox.Show("Cena nie może być liczbą ujemną", "Błąd");
                else
                {
                    partsAdded.CurrentRow.Cells[4].Value = price;
                    partsAdded.Focus(); // odświeżenie wartości komórki z ceną
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędny format ceny.", "Błąd");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Wartość ceny jest spoza zakresu.", "Błąd");
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
