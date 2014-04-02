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
            public ClientsView()
            {
                InitializeComponent();
            }

            private void actionAdd(object sender, EventArgs e)
            {
                controller.ShowForm();
            }
        }
    }
}
