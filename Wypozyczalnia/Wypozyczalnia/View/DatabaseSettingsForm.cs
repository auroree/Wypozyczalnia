using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia.View
{
    public partial class DatabaseSettingsForm : BaseForm
    {
        private DatabaseSettingsController settingsContoller;

        public DatabaseSettingsForm()
        {
            InitializeComponent();
            InitTextBoxes();
        }

        public void SetController(DatabaseSettingsController controller)
        {
            this.settingsContoller = controller;
        }

        public void InitTextBoxes()
        {
            textBox1.Text = ConfigurationManager.AppSettings["server"];
            textBox2.Text = ConfigurationManager.AppSettings["database"];
            textBox3.Text = ConfigurationManager.AppSettings["user"];
            textBox4.Text = ConfigurationManager.AppSettings["password"];
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

        private void ActionConfirm(object sender, EventArgs e)
        {
            settingsContoller.Confirm();
        }

        private void ActionCancel(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
