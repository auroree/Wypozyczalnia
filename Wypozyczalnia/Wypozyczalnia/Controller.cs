using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private BaseView activeView;
        // polaczenie do bazy danych
        private DatabaseConnection dc;
        // informacja czy aplikacja ma zostac zamknieta
        public Boolean IsClosing { get; set; }

        public Controller(BaseView initForm)
        {
            activeView = initForm;
            clients = (ClientsView)initForm;
            employees = new EmployeesView();

            clients.SetController(this);
            employees.SetController(this);
            IsClosing = false;

            // KONSTRUKTOR POLACZENIA Z BAZA DANYCH
            // PODAC PARAMETRY BAZY!!
            // w pliku konfiguracyjnym App.config
            dc = new DatabaseConnection();

            // inicjalizacja danych w domslnym okienku
            SelectAllAtActiveWindow();
            UpdateDBStatus();
            clients.SetColumns();
        }

        public void UpdateDBStatus()
        {
            if (ConfigurationManager.AppSettings["database"] != activeView.DBStatus)
            {
                try
                {
                    dc.OpenConnection();
                    activeView.DBStatus = ConfigurationManager.AppSettings["database"];
                    dc.CloseConnection();
                }
                catch (SqlException ex)
                {
                    activeView.DBStatus = "brak połączenia";
                }
            }
        }

        public void ShowClientsView()
        {
            if (activeView != clients)
            {
                activeView.Hide();
                activeView = clients;
                clients.Show();
                SelectAllAtActiveWindow();
                UpdateDBStatus();
            }
        }

        public void ShowEmployeesView()
        {
            if (activeView != employees)
            {
                activeView.Hide();
                activeView = employees;
                employees.Show();
                SelectAllAtActiveWindow();
                UpdateDBStatus();
            }
        }

        public void ChangeDBSettings()
        {
            DatabaseSettingsForm form = new DatabaseSettingsForm();
            DatabaseSettingsController formController = new DatabaseSettingsController(form);
            form.ShowDialog();
            dc = new DatabaseConnection();
            UpdateDBStatus();
        }

        public void ShowAddForm()
        {
            if (activeView == clients)
            {
                ClientForm form = new ClientForm();
                ClientFormController formController = new ClientFormController(form, Operation.Add);
                formController.SetConnection(dc);
                form.ShowDialog();
                // odswiezenie danych
                SelectAllAtActiveWindow();
            }
        }

        public void ShowEditForm()
        {
            try
            {
                if (activeView == clients)
                {
                    Client client = clients.GetActiveElement();
                    ClientForm form = new ClientForm(client);
                    ClientFormController formController = new ClientFormController(form, Operation.Edit);
                    formController.SetConnection(dc);
                    form.ShowDialog();
                }
                // TODO: sprawdzenie czy nie kliknieto "Anuluj"
                // odswiezenie danych
                SelectAllAtActiveWindow();
            }
            catch (NullReferenceException ex)
            {
                // pusta tabela/?
            }
        }

        public void ShowDeleteForm()
        {
            try
            {
                if (activeView == clients)
                {
                    Client client = clients.GetActiveElement();
                    ClientForm form = new ClientForm(client);
                    ClientFormController formController = new ClientFormController(form, Operation.Delete);
                    formController.SetConnection(dc);
                    form.ShowDialog();
                    // odswiezenie danych
                    SelectAllAtActiveWindow();
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
            try
            {
                dc.OpenConnection();
                myReader = dc.ExecuteQueryReader(query);
                DataTable dt = new DataTable();
                dt.Load(myReader);
                activeView.SetDataTable(dt);
            }
            catch (NullReferenceException ex)
            {

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
                activeView.ClearTable();
            }
            dc.CloseConnection();
        }

        public void SelectAllAtActiveWindow()
        {
            SqlCommand query = null;
            // wybor zapytania do bazy danych
            if (activeView == clients)
            {
                query = DBClient.SelectAllQuery();
            }
            else if (activeView == employees)
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
