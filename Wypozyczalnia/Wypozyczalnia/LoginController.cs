using System;
using System.Collections.Generic;
using System.Linq;
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
            if ((form.UserName == "login") && (form.Password == "haslo"))
            {
                DatabaseConnection dc = new DatabaseConnection();
                BaseView initForm = new ClientsView();
                Controller controller = new Controller(dc, initForm);
                initForm.Show();
                form.Hide();
            }
            else
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło", "Błąd");
            }

        }
    }
}
