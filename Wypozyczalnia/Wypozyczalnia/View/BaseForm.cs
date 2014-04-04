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
        public partial class BaseForm : Form
        {
            protected IFormController controller;

            public BaseForm()
            {
                InitializeComponent();
            }

            public void SetController(IFormController controller)
            {
                this.controller = controller;
            }
        }
    }
}
