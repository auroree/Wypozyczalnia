using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Database;
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
                try
                {
                    string user = "LoginAccessor";
                    string pass = "specialpassword";
                    // autoryzacja uzytkownika
                    LoginClassesDataContext db = new LoginClassesDataContext(
                        DatabaseSettings.CreateConnectionString(
                        form.TextBox1, form.TextBox2,
                        user, pass
                        ));
                    IEnumerator<LoginAsResult> res = db.LoginAs(form.TextBox3, db.HashMD5(form.TextBox4)).GetEnumerator();
                    res.MoveNext();

                    WypozyczalniaDataClassesDataContext dbContext = new WypozyczalniaDataClassesDataContext(
                        DatabaseSettings.CreateConnectionString(
                        form.TextBox1, form.TextBox2,
                        res.Current.Funkcja, res.Current.Hasło));
                    DatabaseAccess.DB = dbContext;
                    
                    // zapis ustawien
                    DatabaseSettings.Save(form.TextBox1, form.TextBox2, form.TextBox3);
                    form.Dispose();
                }
                catch (NullReferenceException)
                {
                    System.Windows.Forms.MessageBox.Show("Błędna nazwa użytkownika lub hasło.", "Błąd");
                }
                catch (SqlException)
                {
                    System.Windows.Forms.MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Pola nie mogą być puste", "Błąd");
                form.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

    }
}
