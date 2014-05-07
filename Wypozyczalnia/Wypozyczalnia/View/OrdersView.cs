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
                dataGridView1.Columns[0].Width = (int)(0.35 * width);
                dataGridView1.Columns[1].Width = (int)(0.35 * width);
                dataGridView1.Columns[2].Width = (int)(0.3 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
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
                    Data_odbioru = Convert.ToDateTime(dataGridView1[1, index].Value),
                    Zamówienie_ID = Convert.ToInt32(dataGridView1[2, index].Value)
                };
            }
            catch (FormatException ex)
            {
                return null;
            }
        }
    }
}
