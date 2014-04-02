using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.Model;
using Wypozyczalnia.View;

namespace Wypozyczalnia
{
    public class ClientFormController : IFormController
    {
        private ClientForm form;

        public ClientFormController(ClientForm form)
        {
            this.form = form;
            form.SetController(this);
        }

        public void Add()
        {
            try
            {
                // sprawdzenie poprawnosci danych (w osobnej funkcji (?))
                Client client = new Client(Convert.ToInt32(form.TextBox1), form.TextBox2, form.TextBox3,
                    Convert.ToInt32(form.TextBox4), Convert.ToInt32(form.TextBox5));
                // komunikacja z baza danych (?)

                // komunikat o wyniku operacji (lub tylko bledzie jesli wystapil)
                MessageBox.Show("Dodano", "Dodano");
                // zamkniecie formularza
                form.Dispose();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Błędne dane.", "Błąd");
            }
        }

        public void Edit()
        {

        }

        public void Delete()
        {

        }

    }
}
