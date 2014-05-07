using System;

namespace Wypozyczalnia.View
{
    public partial class OrderForm : BaseForm
    {
        public OrderForm()
        {
            InitializeComponent();
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

        public string TextBox3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
    }
}
