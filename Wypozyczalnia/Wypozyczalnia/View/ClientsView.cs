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
        public partial class ClientsView : BaseView
        {
            private DataTable dt;

            public ClientsView()
            {
                InitializeComponent();
                InitColumns();
            }

            private void actionAdd(object sender, EventArgs e)
            {
                controller.ShowForm();
            }

            private void InitColumns()
            {
                dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Imię", typeof(string));
                dt.Columns.Add("Nazwisko", typeof(string));
                dt.Columns.Add("Rok urodzenia", typeof(string));
                dataGridView1.DataSource = dt;
            }
        }
    }
}
