using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    namespace View
    {
        public partial class ClientForm : BaseForm
        {
            public ClientForm()
            {
                InitializeComponent();
            }

            public string TextBox1
            {
                get { return textBox1.Text; }
                set { textBox1.Text = value; }
            }

            public string TextBox2
            {
                get { return textBox2.Text; }
                set { textBox2.Text = value; }
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

            private void actionCancel(object sender, EventArgs e)
            {
                this.Dispose();
            }

            private void actionCorfirm(object sender, EventArgs e)
            {
                controller.Add();
            }
        }
    }
}
