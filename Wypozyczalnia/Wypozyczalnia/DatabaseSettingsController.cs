using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.View;

namespace Wypozyczalnia
{
    public class DatabaseSettingsController
    {
        private DatabaseSettingsForm form;

        public DatabaseSettingsController(DatabaseSettingsForm form)
        {
            this.form = form;
            form.SetController(this);
        }

        public void Confirm()
        {
            if ((form.TextBox1.Length > 0) && (form.TextBox2.Length > 0) &&
                (form.TextBox3.Length > 0) && (form.TextBox4.Length > 0))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["server"].Value = form.TextBox1;
                config.AppSettings.Settings["database"].Value = form.TextBox2;
                config.AppSettings.Settings["user"].Value = form.TextBox3;
                config.AppSettings.Settings["password"].Value = form.TextBox4;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                form.Dispose();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Pola nie mogą być puste", "Błąd");
                form.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

    }
}
