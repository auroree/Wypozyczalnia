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
    public partial class LoginForm : Form
    {
        private LoginController controller;
        private bool dbSettingsHidden = true;

        public LoginForm()
        {
            InitializeComponent();
            InitTextBoxes();
        }

        public void SetController(LoginController controller)
        {
            this.controller = controller;
        }

        public void InitTextBoxes()
        {
            textBoxServer.Text = ConfigurationManager.AppSettings["server"];
            textBoxDB.Text = ConfigurationManager.AppSettings["database"];
            textBox1.Text = ConfigurationManager.AppSettings["user"];
        }

        public string UserName
        {
            get { return textBox1.Text; }
        }

        public string Password
        {
            get { return textBox2.Text; }
        }

        public string Server
        {
            get { return textBoxServer.Text; }
        }

        public string Database
        {
            get { return textBoxDB.Text; }
        }
        
        public Boolean InProgressVisible
        {
            set { labelInProgress.Visible = value; }
        }

        private void ActionConfirm(object sender, EventArgs e)
        {
            labelInProgress.Visible = true;
            labelInProgress.Update();
            controller.Login();
        }

        private void ActionExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ActionDBSettings(object sender, EventArgs e)
        {

            this.labelDB.Visible = dbSettingsHidden;
            this.labelServer.Visible = dbSettingsHidden;
            this.textBoxDB.Visible = dbSettingsHidden;
            this.textBoxServer.Visible = dbSettingsHidden;

            dbSettingsHidden = !dbSettingsHidden;
        }
    }
}

