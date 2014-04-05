using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Wypozyczalnia.Database;
using Wypozyczalnia.Model;
using Wypozyczalnia.View;

namespace Wypozyczalnia
{
    public class ClientFormController : IFormController
    {
        private ClientForm form;
        private Operation operation;
        private DatabaseConnection dc;
        
        public ClientFormController(ClientForm form)
        {
            this.form = form;
            form.SetController(this);
        }

        public ClientFormController(ClientForm form, Operation operation)
        {
            this.form = form;
            form.SetController(this);
            this.operation = operation;
            SetFormTitle();
        }

        private void SetFormTitle()
        {
            switch (operation)
            {
                case Operation.Add:
                    form.Title = "Dodawanie nowego klienta";
                    break;
                case Operation.Edit:
                    form.Title = "Edycja klienta";
                    break;
                case Operation.Delete:
                    form.Title = "Usuwanie klienta";
                    break;
            }
        }

        public void SetConnection(DatabaseConnection dc) {
            this.dc = dc;
        }

        public void Confirm()
        {
            switch (operation)
            {
                case Operation.Add: 
                    Add();
                    break;
                case Operation.Edit: 
                    Edit();
                    break;
                case Operation.Delete: 
                    Delete();
                    break;
            }
        }

        public void Add()
        {
            try
            {
                // sprawdzenie poprawnosci danych (w osobnej funkcji (?))
                Client client = new Client(form.TextBox2, form.TextBox3, form.TextBox4);
                // komunikacja z baza danych
                dc.OpenConnection();
                dc.ExecuteQuery(DBClient.InsertQuery(client));
                dc.CloseConnection();
                // komunikat o wyniku operacji (lub tylko bledzie jesli wystapil ?)
                MessageBox.Show("Dodano nowy wpis", "Dodano");
                // zamkniecie formularza
                form.Dispose();
            }
            //catch (FormatException ex)
            //{
            //    MessageBox.Show("Błędne dane.", "Błąd");
            //}
            catch (SqlException ex)
            {
                //nie udalo sie polaczyc/bledna skladnia zapytania/bledne dane w zapytaniu/?
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

        public void Edit()
        {
            try
            {
                // sprawdzenie poprawnosci danych (w osobnej funkcji (?))
                Client client = new Client(Convert.ToInt32(form.TextBox1), form.TextBox2, form.TextBox3, form.TextBox4);
                // komunikacja z baza danych
                dc.OpenConnection();
                dc.ExecuteQuery(DBClient.UpdateQuery(client));
                dc.CloseConnection();
                // komunikat o wyniku operacji (lub tylko bledzie jesli wystapil ?)
                MessageBox.Show("Zaktualizowano wpis", "Zaktualizowano");
                // zamkniecie formularza
                form.Dispose();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Błędne dane.", "Błąd");
            }
            catch (SqlException ex)
            {
                //nie udalo sie polaczyc/bledna skladnia zapytania/bledne dane w zapytaniu/?
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

        public void Delete()
        {
            try
            {
                Client client = new Client(Convert.ToInt32(form.TextBox1), form.TextBox2, form.TextBox3, form.TextBox4);
                
                dc.OpenConnection();
                dc.ExecuteQuery(DBClient.DeleteQuery(client));
                dc.CloseConnection();

                form.Dispose();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Błędne dane.", "Błąd");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

    }
}
