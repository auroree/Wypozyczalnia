using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Database;
using Wypozyczalnia.Model;
using Wypozyczalnia.View;

namespace Wypozyczalnia
{
    public enum Operation { Add, Edit, Delete }

    // Glowny kontroler programu
    //
    public class Controller
    {
        // okienka
        private ClientsView clients;
        private EmployeesView employees;
        // referencja do aktywnego obiektu
        private BaseView activeForm;
        // polaczenie do bazy danych
        private DatabaseConnection dc;
        // informacja czy aplikacja ma zostac zamknieta
        public Boolean IsClosing { get; set; }

        public Controller(BaseView initForm)
        {
            activeForm = initForm;
            clients = (ClientsView)initForm;
            employees = new EmployeesView();

            clients.SetController(this);
            employees.SetController(this);
            IsClosing = false;

            // KONSTRUKTOR POLACZENIA Z BAZA DANYCH
            // PODAC PARAMETRY BAZY!!
            // dc = new DatabaseConnection(server, database, user, password);
            // TODO: WCZYTYWANIE KONFIGURACJI BAZY Z PLIKU
            dc = new DatabaseConnection();

            // inicjalizacja danych w domslnym okienku
            SelectAllAtActiveWindow();
            clients.SetColumns();
        }

        public void ShowClientsView()
        {
            if (activeForm != clients)
            {
                activeForm.Hide();
                activeForm = clients;
                clients.Show();
                SelectAllAtActiveWindow();
            }
        }

        public void ShowEmployeesView()
        {
            if (activeForm != employees)
            {
                activeForm.Hide();
                activeForm = employees;
                employees.Show();
                SelectAllAtActiveWindow();
            }
        }

        public void ShowAddForm()
        {
            if (activeForm == clients)
            {
                ClientForm form = new ClientForm();
                ClientFormController formController = new ClientFormController(form, Operation.Add);
                formController.SetConnection(dc);
                form.EnabledTextBox1 = false;
                form.ShowDialog();
            }
        }

        public void ShowEditForm()
        {
            try
            {
                if (activeForm == clients)
                {
                    Client client = clients.GetActiveElement();
                    ClientForm form = new ClientForm(client);
                    ClientFormController formController = new ClientFormController(form, Operation.Edit);
                    formController.SetConnection(dc);
                    form.ReadOnlyTextBox1 = true;
                    form.ShowDialog();
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }

        public void ShowDeleteForm()
        {
            try
            {
                if (activeForm == clients)
                {
                    Client client = clients.GetActiveElement();
                    ClientForm form = new ClientForm(client);
                    ClientFormController formController = new ClientFormController(form, Operation.Delete);
                    formController.SetConnection(dc);
                    form.ReadOnlyTextBox1 = true;
                    form.ShowDialog();
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }

        // Zaladowanie do widoku danych uzyskanych w odpowiedzi na zapytanie SQL 
        //
        public void LoadData(SqlCommand query)
        {
            SqlDataReader myReader = null;

            if (query != null)
            {
                dc.OpenConnection(); 
                myReader = dc.ExecuteQueryReader(query);
                DataTable dt = new DataTable();
                dt.Load(myReader);
                activeForm.SetDataTable(dt);
            }
            dc.CloseConnection();
        }

        public void SelectAllAtActiveWindow()
        {
            SqlCommand query = null;
            // wybor zapytania do bazy danych
            if (activeForm == clients)
            {
                query = DBClient.SelectAllQuery();
            }
            else if (activeForm == employees)
            {
                //query = ?;
            }
            
            LoadData(query);
        }

        // --- --- --- --- --- FILTRY --- --- --- --- --- // 

        // --- KLIENT
        public void SearchClientBySurname()
        {
            LoadData(DBClient.SelectBySurnameQuery(clients.ClientFilterSurname));
        }

        // --- PRACOWNIK
    }
}
