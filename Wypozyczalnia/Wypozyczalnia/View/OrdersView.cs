using System;

namespace Wypozyczalnia.View
{
    public partial class OrdersView : BaseView
    {
        public OrdersView()
        {
            InitializeComponent();
        }

        public override void SetColumnsWidth()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width =
                dataGridView1.Columns[1].Width = (int)(0.35 * width);
                dataGridView1.Columns[2].Width = (int)(0.3 * width);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        public string DataToPrint()
        {
            string text = string.Empty;
            string ID_Data = new string(' ', 10);
            string Data_Data = new string(' ', 20);

            string tmpID, tmpZam, tmpOdb;
            text += "                           ZAMÓWIENIA\n\n";
            text += "ID" + ID_Data + "|Data zamówienia" + Data_Data + "|Data odbioru\n";
            text += new string('-', 2 + ID_Data.Length) + "|";
            text += new string('-', 15 + Data_Data.Length) + "|";
            text += new string('-', 10) + "\n";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                tmpID = dataGridView1[2, i].Value.ToString();
                tmpZam = dataGridView1[1, i].Value.ToString().Remove(10);
                tmpOdb = dataGridView1[0, i].Value.ToString().Remove(10);

                tmpID += new string(' ', 2 + ID_Data.Length - tmpID.Length) + '|';
                tmpZam += new string(' ', 15 + Data_Data.Length - tmpZam.Length) + '|';

                text += tmpID + tmpZam + tmpOdb;
                text += "\n";
            }
            return text;
        }

        private void ActionResized(object sender, EventArgs e)
        {
            SetColumns();
        }

        private void ActionAdd(object sender, EventArgs e)
        {
            controller.ShowOrderAddForm();
        }

        private void ActionEdit(object sender, EventArgs e)
        {
            controller.ShowOrderEditForm();
        }

        private void ActionDelete(object sender, EventArgs e)
        {
            controller.ShowOrderDeleteForm();
        }

        public Zamówienie GetActiveElement()
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                return new Zamówienie()
                {
                    Data_zamówienia = Convert.ToDateTime(dataGridView1[0, index].Value),
                    Data_odbioru = dataGridView1[1, index].Value.ToString().Length > 0 ? Convert.ToDateTime(dataGridView1[1, index].Value) : (DateTime?)null,
                    Zamówienie_ID = Convert.ToInt32(dataGridView1[2, index].Value)
                };
            }
            catch (FormatException)
            {
                return null;
            }
        }

        private void ActionShowParts(object sender, EventArgs e)
        {
            controller.ShowOrderPartsView();
        }

        private void ActionSearchByOrderDate(object sender, EventArgs e)
        {
            controller.SelectOrdersByOrderDate();
        }

        public DateTime? FilterOrderDate
        {
            get { return filterOrderDate.Text.Length > 0 ? Convert.ToDateTime(filterOrderDate.Text) : (DateTime?)null; }
        }

        private void ActionOrderDelivered(object sender, EventArgs e)
        {
            controller.ShowOrderDeliveryForm();
        }
    }
}
