using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.Database;
using Wypozyczalnia.View;

namespace Wypozyczalnia
{
    public class LoginController
    {
        private LoginForm form;

        public LoginController(LoginForm form)
        {
            this.form = form;
            form.SetController(this);
        }

        public void Login()
        {
            LoginClassesDataContext dbin = new LoginClassesDataContext(
                DatabaseSettings.CreateConnectionString(
                "hania-laptop\\sqlexpress", "Wypozyczalnia",
                "sa", "Admin1"
                ));
            Użytkownik u = new Użytkownik();
            u.Nazwa = "Krysia";
            u.Hasło = dbin.HashMD5("12345");
            u.Uprawnienia_Uprawnienia_ID = 1;
            dbin.Użytkowniks.InsertOnSubmit(u);
            dbin.SubmitChanges();
            try
            {
                string user = "LoginAccessor";
                string pass = "specialpassword";
                // autoryzacja uzytkownika
                LoginClassesDataContext db = new LoginClassesDataContext(
                    DatabaseSettings.CreateConnectionString(
                    form.Server, form.Database,
                    user, pass
                    ));
                IEnumerator<LoginAsResult> res = db.LoginAs(form.UserName, db.HashMD5(form.Password)).GetEnumerator();
                res.MoveNext();                

                WypozyczalniaDataClassesDataContext dbContext = new WypozyczalniaDataClassesDataContext(
                    DatabaseSettings.CreateConnectionString(
                    form.Server, form.Database,
                    res.Current.Funkcja, res.Current.Hasło));
                DatabaseAccess.DB = dbContext;
                // zapis ustawien
                DatabaseSettings.Save(form.Server, form.Database, form.UserName);
                
                BaseView initForm = new ClientsView();
                Controller controller = new Controller(initForm);
                initForm.Show();
                form.Hide();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Błędna nazwa użytkownika lub hasło.", "Błąd");
                form.InProgressVisible = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
                form.InProgressVisible = false;
            }
        }
    }
}
