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
        // lista funkcji pracownika
        private List<string> functions = null;
        // wynik dzialania forularza
        DialogResult dr;

        public Controller(DatabaseConnection dc, BaseView initForm)
        {
            activeView = initForm;
            // TODO: sprawdzenie typu przekazanego parametru
            clients = (ClientsView)initForm;

            // zainicjalizowanie pozostalych okienek
            employees = new EmployeesView();
            clients.SetController(this);
            employees.SetController(this);
            IsClosing = false;

            // KONSTRUKTOR POLACZENIA Z BAZA DANYCH
            // PODAC PARAMETRY BAZY!!
            // w pliku konfiguracyjnym App.config
            // Uwaga! zmiana ustawien przy debugowaniu nie zostanie zapamietana
            // w LoginContoller zostanie zaimplementowana docelowa wersja ustawiania polaczenia
            // dlatego powinna byc przekazywana do tego kontrolera
            this.dc = dc;

            // inicjalizacja DialogResult
            dr = DialogResult.None;

            // inicjalizacja danych w domslnym okienku
            SelectAllAtActiveWindow();
            UpdateDBStatus();
            //clients.SetColumns();
        }

        // --- --- --- --- --- ZMIANA AKTYWNEGO OKNA --- --- --- --- --- // 
        #region Zmiana aktywnego okna

        public void ShowClientsView()
        {
            if (activeView != clients)
            {
                activeView.Hide();
                clients.CopyWindowState(activeView);
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
                employees.CopyWindowState(activeView);
                activeView = employees;
                // lista funkcji
                SqlDataReader myReader = null;
                if (functions == null)
                {
                    try
                    {
                        dc.OpenConnection();
                        myReader = dc.ExecuteQueryReader(DBEmployee.SelectFunctions());
                        functions = new List<string>();
                        while (myReader.Read())
                        {
                            functions.Add(myReader.GetString(0));
                        }
                        dc.CloseConnection();
                        employees.FillFunctionsList(functions);
                    }
                    catch (SqlException ex)
                    {
                        // TODO: co teraz?
                    }
                }
                employees.Show();
                SelectAllAtActiveWindow();
                UpdateDBStatus();
            }
        }
        #endregion

        // --- --- --- --- --- OBSLUGA BD --- --- --- --- --- // 
        #region Obsluga BD

        // Zmiana ustawien bazy danych i zastosowanie nowych
        //
        public void ChangeDBSettings()
        {
            DatabaseSettingsForm form = new DatabaseSettingsForm();
            DatabaseSettingsController formController = new DatabaseSettingsController(form);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dc = new DatabaseConnection();
                UpdateDBStatus();
            }
        }

        // Sprawdzenie czy parametry konfiguracji pozwalaja na polaczenie z baza danych
        //
        public void UpdateDBStatus()
        {
            //if (ConfigurationManager.AppSettings["database"] != activeView.DBStatus)
            //{
                try
                {
                    dc.OpenConnection();
                    activeView.DBStatus = ConfigurationManager.AppSettings["database"];
                    dc.CloseConnection();
                    activeView.DBStatusColor = new System.Drawing.Color();
                }
                catch (SqlException ex)
                {
                    activeView.DBStatus = "brak połączenia";
                    activeView.DBStatusColor = System.Drawing.Color.Red;
                }
            //}
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
                activeView.DataTable = dt;
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

        // Wybranie wszystkich rekordow aktywnej tabeli
        //
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
                query = DBEmployee.SelectAllQuery();
            }

            LoadData(query);
            activeView.SetColumns();
        }

        // Sprawdza czy ostatni formularz zwrocil OK, jesli tak, odswieza dane w tabeli
        //
        public void ReloadIfFormReturnedOK()
        {
            if (dr == DialogResult.OK)
            {
                // odswiezenie danych
                SelectAllAtActiveWindow();
            }
            // zresetowanie stanu dr
            dr = DialogResult.None;
        }

        #endregion

        // --- --- --- --- --- KLIENT --- --- --- --- --- // 
        #region Klient
        // --- FORMULARZE

        public void ShowClientAddForm()
        {
            ClientForm form = new ClientForm();
            ClientFormController formController = new ClientFormController(form, Operation.Add);
            formController.SetConnection(dc);
            dr = form.ShowDialog();
            // odswiezenie danych
            ReloadIfFormReturnedOK();
        }

        public void ShowClientEditForm()
        {
            try
            {
                Client client = clients.GetActiveElement();
                ClientForm form = new ClientForm(client);
                ClientFormController formController = new ClientFormController(form, Operation.Edit);
                formController.SetConnection(dc);
                dr = form.ShowDialog();
                // odswiezenie danych
                ReloadIfFormReturnedOK();
            }
            catch (NullReferenceException ex)
            {
                // pusta tabela/?
            }
        }

        public void ShowClientDeleteForm()
        {
            try
            {
                Client client = clients.GetActiveElement();
                ClientForm form = new ClientForm(client);
                ClientFormController formController = new ClientFormController(form, Operation.Delete);
                formController.SetConnection(dc);
                dr = form.ShowDialog();
                // odswiezenie danych
                ReloadIfFormReturnedOK();
            }
            catch (NullReferenceException ex)
            {

            }
        }

        // --- FILTRY

        public void SearchClientBySurname()
        {
            LoadData(DBClient.SelectBySurnameQuery(clients.FilterSurname));
        }

        #endregion

        // --- --- --- --- --- PRACOWNIK --- --- --- --- --- // 
        #region Pracownik
        // --- FORMULARZE
        
        public void ShowEmployeeAddForm()
        {
            EmployeeForm form = new EmployeeForm(functions);
            EmployeeFormController formController = new EmployeeFormController(form, Operation.Add);
            formController.SetConnection(dc);
            dr = form.ShowDialog();
            // odswiezenie danych
            ReloadIfFormReturnedOK();
        }

        public void ShowEmployeeEditForm()
        {
            try
            {
                Employee employee = employees.GetActiveElement();
                EmployeeForm form = new EmployeeForm(employee, functions);
                EmployeeFormController formController = new EmployeeFormController(form, Operation.Edit);
                formController.SetConnection(dc);
                dr = form.ShowDialog();
                // odswiezenie danych
                ReloadIfFormReturnedOK();
            }
            catch (NullReferenceException ex)
            {
                // pusta tabela/?
            }
        }

        public void ShowEmployeeDeleteForm()
        {
            try
            {
                Employee employee = employees.GetActiveElement();
                EmployeeForm form = new EmployeeForm(employee, functions);
                EmployeeFormController formController = new EmployeeFormController(form, Operation.Delete);
                formController.SetConnection(dc);
                form.ShowDialog();
                // odswiezenie danych
                SelectAllAtActiveWindow();
            }
            catch (NullReferenceException ex)
            {

            }
        }

        // --- FILTRY

        public void SelectEmployeeBySurname()
        {
            LoadData(DBEmployee.SelectBySurnameQuery(employees.FilterSurname));
        }

        public void SelectEmployeeByFunction()
        {
            string function = employees.FilterFunction;
            if (functions.Contains(function))
            {
                LoadData(DBEmployee.SelectByFunctionQuery(function));
            }
            else
            {
                LoadData(DBEmployee.SelectAllQuery());
            }
        }

        #endregion
    }
}
