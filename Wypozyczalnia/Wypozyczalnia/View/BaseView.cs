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
        public partial class BaseView : Form
        {
            protected Controller controller;

            public BaseView()
            {
                InitializeComponent();
            }

            public void SetController(Controller controller)
            {
                this.controller = controller;
            }

            private void actionShowClientsView(object sender, EventArgs e)
            {
                controller.ShowClientsView();
            }

            private void actionShowEmployeesView(object sender, EventArgs e)
            {
                controller.ShowEmployeesView();
            }

            private void actionClose(object sender, FormClosingEventArgs e)
            {
                if (!controller.Closing)
                {
                    if (MessageBox.Show("Wyjść?", "Wypożyczalnia",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        controller.Closing = true;
                        Application.Exit();
                    }
                    else
                    {
                        // Cancel the Closing event from closing the form.
                        e.Cancel = true;
                    }
                }
            }

            private void actionExit(object sender, EventArgs e)
            {
                if (!controller.Closing)
                {
                    if (MessageBox.Show("Wyjść?", "Wypożyczalnia",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        controller.Closing = true;
                        Application.Exit();
                    }
                }
            }

        }
    }
}
