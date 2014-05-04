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
    public partial class WarehouseForm : BaseForm
    {
        public WarehouseForm()
        {
            InitializeComponent();
        }

        public WarehouseForm(List<string> statuses)
        {
            InitializeComponent();
            FillStatusList(statuses);
        }

        public WarehouseForm(Część part, List<string> statuses)
        {
            InitializeComponent();

            textBox1.Text = "" + part.Część_ID;
            textBox2.Text = part.Nazwa;
            textBox3.Text = part.Zamówienie_Zamówienie_ID.ToString();
            textBox4.Text = part.Cena.ToString();
            textBox5.Text = part.Statek_Statek_ID.ToString();
            FillStatusList(statuses);
            comboBox1.SelectedItem = part.Status_części.Status;
        }

        public override void DisableAllFields()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            comboBox1.Enabled = false;
        }

        public string TextBox3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public string TextBox4
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public string TextBox5
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }

        public string ComboBox1
        {
            get { return comboBox1.SelectedItem.ToString(); }
            set { comboBox1.SelectedItem = value; }
        }

        private void FillStatusList(List<string> statuses)
        {
            foreach (string status in statuses)
            {
                comboBox1.Items.Add(status);
            }
        }
    }
}
