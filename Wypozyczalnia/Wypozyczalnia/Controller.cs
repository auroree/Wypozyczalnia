using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.Database;
using Wypozyczalnia.FormController;
using Wypozyczalnia.View;

namespace Wypozyczalnia
{
    // Typ operacji formularza
    public enum Operation { Add, Edit, Delete }

    // Glowny kontroler programu
    //
    public class Controller
    {
        // okienka
        private ClientsView clients;
        private EmployeesView employees;
        private WarehouseView warehouse;
        private OrdersView orders;
        private ReservationsView reservations;
        private SpacecraftsView spacecrafts;
        private HelpView help;
        // referencja do aktywnego obiektu
        private BaseView activeView;
        // informacja czy aplikacja ma zostac zamknieta
        public Boolean IsClosing { get; set; }
        // lista funkcji pracownika
        private List<string> functions = null;
        private List<string> statuses = null;
        private List<string> types = null;
        // wynik dzialania forularza
        private DialogResult dr;
        // mapowanie bd
        private WypozyczalniaDataClassesDataContext dbContext;
        private QueriesClient queriesClient;
        private QueriesEmployee queriesEmployee;
        private QueriesWarehouse queriesWarehouse;
        private QueriesOrder queriesOrder;
        private QueriesReservation queriesReservation;
        private QueriesSpacecrafts queriesSpacecrafts;

        public Controller(WypozyczalniaDataClassesDataContext dbContext, BaseView initForm)
        {
            activeView = initForm;
            this.dbContext = dbContext;
            // TODO: sprawdzenie typu przekazanego parametru
            clients = (ClientsView)initForm;

            // zainicjalizowanie pozostalych okienek
            employees = new EmployeesView();
            warehouse = new WarehouseView();
            reservations = new ReservationsView();
            orders = new OrdersView();
            spacecrafts = new SpacecraftsView();
            help = new HelpView();
            clients.SetController(this);
            employees.SetController(this);
            warehouse.SetController(this);
            orders.SetController(this);
            reservations.SetController(this);
            spacecrafts.SetController(this);
            IsClosing = false;

            // inicjalizacja obiektow dbContext
            queriesClient = new QueriesClient(dbContext);
            queriesEmployee = new QueriesEmployee(dbContext);
            queriesWarehouse = new QueriesWarehouse(dbContext);
            queriesOrder = new QueriesOrder(dbContext);
            queriesReservation = new QueriesReservation(dbContext);
            queriesSpacecrafts = new QueriesSpacecrafts(dbContext);

            // inicjalizacja DialogResult
            dr = DialogResult.None;

            // inicjalizacja danych w domyslnym okienku
            SelectAllAtActiveWindow();
            UpdateDBStatus();
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
                if (functions == null)
                {
                    try
                    {
                        functions = queriesEmployee.GetAllFunctions();
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

        public void ShowWarehouseView()
        {
            if (activeView != warehouse)
            {
                activeView.Hide();
                warehouse.CopyWindowState(activeView);
                activeView = warehouse;
                // lista funkcji
                if (statuses == null)
                {
                    try
                    {
                        statuses = queriesWarehouse.GetAllStatuses();
                        warehouse.FillStatusList(statuses);
                    }
                    catch (SqlException ex)
                    {
                        // TODO: co teraz?
                    }
                }
                warehouse.Show();
                SelectAllAtActiveWindow();
                UpdateDBStatus();
            }

        }

        public void ShowReservationsView()
        {
            if (activeView != reservations)
            {
                activeView.Hide();
                reservations.CopyWindowState(activeView);
                activeView = reservations;
                reservations.Show();
                SelectAllAtActiveWindow();
                UpdateDBStatus();
            }
        }

        public void ShowReservationsView(int clientId)
        {
            if (activeView != reservations)
            {
                activeView.Hide();
                reservations.CopyWindowState(activeView);
                activeView = reservations;
                reservations.Show();
                activeView.DataTable = queriesReservation.SelectById(clientId);
                UpdateDBStatus();
            }
        }

        public void ShowOrdersView()
        {
            if (activeView != orders)
            {
                activeView.Hide();
                orders.CopyWindowState(activeView);
                activeView = orders;
                orders.Show();
                SelectAllAtActiveWindow();
                UpdateDBStatus();
            }
        }

        public void ShowSpacecraftsView()
        {
            if (activeView != spacecrafts)
            {
                activeView.Hide();
                spacecrafts.CopyWindowState(activeView);
                activeView = spacecrafts;
                if (types == null)
                {
                    try
                    {
                        types = queriesSpacecrafts.GetAllTypes();
                        spacecrafts.FillTypeList(types);
                    }
                    catch (SqlException ex)
                    {
                    }
                }
                spacecrafts.Show();
                SelectAllAtActiveWindow();
                UpdateDBStatus();
            }
        }
        #endregion

        // --- --- --- --- --- OBSLUGA BD --- --- --- --- --- // 
        #region Obsluga BD

        /// <summary>
        /// Wywolania okna dialogowego do zmiany ustawien bazy danych i zastosowanie ich
        /// </summary>
        public void ChangeDBSettings()
        {
            DatabaseSettingsForm form = new DatabaseSettingsForm();
            DatabaseSettingsController formController = new DatabaseSettingsController(form);
            formController.DbContext = dbContext;
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                UpdateDBStatus();
            }
        }

        /// <summary>
        /// Sprawdzenie czy parametry konfiguracji pozwalaja na polaczenie z baza danych
        /// </summary>
        public void UpdateDBStatus()
        {
            if (ConfigurationManager.AppSettings["database"] != activeView.DBStatus)
            {
                try
                {
                    // sprawdzenie polaczenia
                    dbContext.Connection.Open();
                    activeView.DBStatus = ConfigurationManager.AppSettings["database"];
                    dbContext.Connection.Close();
                    activeView.DBStatusColor = new System.Drawing.Color();
                }
                catch (SqlException ex)
                {
                    activeView.DBStatus = "brak połączenia";
                    activeView.DBStatusColor = System.Drawing.Color.Red;
                }
            }
        }

        /// <summary>
        /// Wybranie wszystkich rekordow aktywnej tabeli i zaladowanie do widoku
        /// </summary>
        public void SelectAllAtActiveWindow()
        {
            try
            {
                // wybor zapytania do bazy danych
                if (activeView == clients)
                {
                    activeView.DataTable = queriesClient.SelectAll();
                }
                else if (activeView == employees)
                {
                    activeView.DataTable = queriesEmployee.SelectAll();
                }
                else if (activeView == warehouse)
                {
                    activeView.DataTable = queriesWarehouse.SelectAll();
                }

                else if (activeView == orders)
                {
                    activeView.DataTable = queriesOrder.SelectAll();
                }

                else if (activeView == reservations)
                {
                    activeView.DataTable = queriesReservation.SelectAll();
                }

                else if (activeView == spacecrafts)
                {
                    activeView.DataTable = queriesSpacecrafts.SelectAll();
                }

                activeView.SetColumns();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
                //MessageBox.Show(ex.Message.ToString(), "błąd");
                activeView.ClearTable();
            }
        }

        /// <summary>
        /// Sprawdza czy ostatni formularz zwrocil OK, jesli tak, odswieza dane w tabeli 
        /// </summary>
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
            formController.Queries = queriesClient;
            dr = form.ShowDialog();
            // odswiezenie danych
            ReloadIfFormReturnedOK();
        }

        public void ShowClientEditForm()
        {
            try
            {
                Klient client = clients.GetActiveElement();
                ClientForm form = new ClientForm(client);
                ClientFormController formController = new ClientFormController(form, Operation.Edit);
                formController.Queries = queriesClient;
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
                Klient client = clients.GetActiveElement();
                ClientForm form = new ClientForm(client);
                ClientFormController formController = new ClientFormController(form, Operation.Delete);
                formController.Queries = queriesClient;
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
            string surname = clients.FilterSurname;
            if (surname.Length > 0)
            {
                activeView.DataTable = queriesClient.SelectBySurname(surname);
            }
            else
            {
                activeView.DataTable = queriesClient.SelectAll();
            }
            activeView.SetColumns();
        }

        #endregion

        // --- --- --- --- --- PRACOWNIK --- --- --- --- --- // 
        #region Pracownik
        // --- FORMULARZE

        public void ShowEmployeeAddForm()
        {
            EmployeeForm form = new EmployeeForm(functions);
            EmployeeFormController formController = new EmployeeFormController(form, Operation.Add);
            formController.Queries = queriesEmployee;
            dr = form.ShowDialog();
            // odswiezenie danych
            ReloadIfFormReturnedOK();
        }

        public void ShowEmployeeEditForm()
        {
            try
            {
                Pracownik employee = employees.GetActiveElement();
                EmployeeForm form = new EmployeeForm(employee, functions);
                EmployeeFormController formController = new EmployeeFormController(form, Operation.Edit);
                formController.Queries = queriesEmployee;
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
                Pracownik employee = employees.GetActiveElement();
                EmployeeForm form = new EmployeeForm(employee, functions);
                EmployeeFormController formController = new EmployeeFormController(form, Operation.Delete);
                formController.Queries = queriesEmployee;
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
            string surname = employees.FilterSurname;
            if (surname.Length > 0)
            {
                activeView.DataTable = queriesEmployee.SelectBySurname(surname);
            }
            else
            {
                activeView.DataTable = queriesEmployee.SelectAll();
            }
            activeView.SetColumns();
        }

        public void SelectEmployeeByFunction()
        {
            string function = employees.FilterFunction;
            if (functions.Contains(function))
            {
                activeView.DataTable = queriesEmployee.SelectByFunction(function);
            }
            else
            {
                activeView.DataTable = queriesEmployee.SelectAll();
            }
            activeView.SetColumns();
        }

        #endregion

        // --- --- --- --- --- MAGAZYN --- --- --- --- --- //
        #region Magazyn

        // --- FILTRY
        public void ShowWarehouseAddForm()
        {
            WarehouseForm form = new WarehouseForm(statuses);
            WarehouseFormController formController = new WarehouseFormController(form, Operation.Add);
            formController.Queries = queriesWarehouse;
            dr = form.ShowDialog();
            // odswiezenie danych
            ReloadIfFormReturnedOK();
        }

        public void ShowWarehouseEditForm()
        {
            try
            {
                Część part = warehouse.GetActiveElement();
                WarehouseForm form = new WarehouseForm(part, statuses);
                WarehouseFormController formController = new WarehouseFormController(form, Operation.Edit);
                formController.Queries = queriesWarehouse;
                dr = form.ShowDialog();
                // odswiezenie danych
                ReloadIfFormReturnedOK();
            }
            catch (NullReferenceException ex)
            {
                // pusta tabela/?
            }
        }

        public void ShowWarehouseDeleteForm()
        {
            try
            {
                Część part = warehouse.GetActiveElement();
                WarehouseForm form = new WarehouseForm(part, statuses);
                WarehouseFormController formController = new WarehouseFormController(form, Operation.Delete);
                formController.Queries = queriesWarehouse;
                form.ShowDialog();
                // odswiezenie danych
                SelectAllAtActiveWindow();
            }
            catch (NullReferenceException ex)
            {

            }
        }

        public void SelectPartsByName()
        {
            string name = warehouse.FilterName;
            if (name.Length > 0)
            {
                activeView.DataTable = queriesWarehouse.SelectByName(name);
            }
            else
            {
                activeView.DataTable = queriesWarehouse.SelectAll();
            }
            activeView.SetColumns();
        }

        public void SelectPartsByStatus()
        {
            string status = warehouse.FilterStatus;
            if (statuses.Contains(status))
            {
                activeView.DataTable = queriesWarehouse.SelectByStatus(status);
            }
            else
            {
                activeView.DataTable = queriesWarehouse.SelectAll();
            }
            activeView.SetColumns();
        }
        #endregion

        // --- --- --- --- --- ZAMÓWIENIE --- --- --- --- --- //
        #region Zamówienie

        // --- FORMULARZE

        public void ShowOrderAddForm()
        {
            OrderForm form = new OrderForm();
            OrderFormController formController = new OrderFormController(form, Operation.Add);
            formController.Queries = queriesOrder;
            dr = form.ShowDialog();
            ReloadIfFormReturnedOK();
        }

        public void ShowOrderEditForm()
        {
            try
            {
                Zamówienie order = orders.GetActiveElement();
                OrderForm form = new OrderForm(order);
                OrderFormController formController = new OrderFormController(form, Operation.Edit);
                formController.Queries = queriesOrder;
                dr = form.ShowDialog();
                ReloadIfFormReturnedOK();
            }
            catch (NullReferenceException ex)
            {

            }
        }

        public void ShowOrderDeleteForm()
        {
            try
            {
                Zamówienie order = orders.GetActiveElement();
                OrderForm form = new OrderForm(order);
                OrderFormController formController = new OrderFormController(form, Operation.Delete);
                formController.Queries = queriesOrder;
                form.ShowDialog();
                SelectAllAtActiveWindow();
            }
            catch (NullReferenceException ex)
            {
            }
        }

        #endregion

        // --- --- --- --- --- REZERWACJA --- --- --- --- --- //
        #region Rezerwacja
        // --- FORMULARZE
        public void ShowReservationEmploeesForm()
        {
            int id = reservations.GetActiveElementId();
            ReservationEmployeesForm form = new ReservationEmployeesForm();
            form.DataTable = queriesReservation.SelectReservationEmployee(id);
            form.SetColumns();
            dr = form.ShowDialog();
        }

        public void ShowReservationEditForm()
        {
            try
            {
                Rezerwacja reservation = reservations.GetActiveElement();
                ReservationForm form = new ReservationForm(reservation);
                ReservationFormController formController = new ReservationFormController(form, Operation.Edit);
                formController.Queries = queriesReservation;

                form.AddedClientDataTable = queriesReservation.SelectSingleClient((int)reservation.Rezerwacja_ID);
                form.AddedShipDataTable = queriesReservation.SelectSingleShip((int)reservation.Rezerwacja_ID);
                form.AddedEmployeesDataTable = queriesReservation.SelectReservationEmployee((int)reservation.Rezerwacja_ID);

                form.ClientsDataTable = queriesReservation.SelectAllWithoutSingle((int)reservation.Rezerwacja_ID);
                form.EmployeesDataTable = queriesReservation.SelectEmployeesByDate(reservation.Data_wypożyczenia, reservation.Data_zwrotu);
                form.ShipsDataTable = queriesReservation.SelectShipsByDate(reservation.Data_wypożyczenia, reservation.Data_zwrotu);

                form.SetColumns();
                dr = form.ShowDialog();
                ReloadIfFormReturnedOK();
            }
            catch (NullReferenceException ex)
            {
                // pusta tabela/?
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

        public void ShowReservationAddForm()
        {
            try
            {
                ReservationForm form = new ReservationForm();
                ReservationFormController formController = new ReservationFormController(form, Operation.Add);
                formController.Queries = queriesReservation;

                form.ClientsDataTable = queriesClient.SelectAll();
                form.AddedClientDataTable = form.ClientsDataTable.Clone();

                form.SetColumns();
                dr = form.ShowDialog();
                ReloadIfFormReturnedOK();
            }
            catch (NullReferenceException ex)
            {
                // pusta tabela/?
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

        // --- FILTRY
        public void SearchReservationsBySurname()
        {
            string surname = reservations.FilterSurname;
            if (surname.Length > 0)
            {
                activeView.DataTable = queriesReservation.SelectBySurname(surname);
            }
            else
            {
                activeView.DataTable = queriesReservation.SelectAll();
            }
            activeView.SetColumns();
        }

        // --- Delete

        public void DeleteReservation()
        {
            if (MessageBox.Show("Czy chcesz usunąć rezerwacje?", "Wypożyczalnia",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = reservations.GetActiveElementId();
                queriesReservation.Delete(id);
                dr = DialogResult.OK;
                ReloadIfFormReturnedOK();
            }
        }

        #endregion

        // --- --- --- --- --- STATKI --- --- --- --- --- //
        #region Statki

        public void SelectSpacecraftsByType()
        {
            string type = spacecrafts.FilterType;
            if (types.Contains(type))
            {
                activeView.DataTable = queriesSpacecrafts.SelectByType(type);
            }
            else
            {
                activeView.DataTable = queriesSpacecrafts.SelectAll();
            }
            activeView.SetColumns();
        }

        public void SelectSpacecraftsByEngine()
        {
            string name = spacecrafts.FilterEngine;
            if (name.Length > 0)
            {
                activeView.DataTable = queriesSpacecrafts.SelectByEngine(name);
            }
            else
            {
                activeView.DataTable = queriesSpacecrafts.SelectAll();
            }
            activeView.SetColumns();
        }

        public void UpdateTypesList()
        {
            types = queriesSpacecrafts.GetAllTypes();
            spacecrafts.FillTypeList(types);
        }

        public void ShowSpacecraftsAddForm()
        {
            UpdateTypesList();
            SpacecraftsForm form = new SpacecraftsForm(types);
            SpacecraftsFormController formController = new SpacecraftsFormController(form, Operation.Add);
            form.Queries = queriesSpacecrafts;
            formController.Queries = queriesSpacecrafts;
            dr = form.ShowDialog();
            // odswiezenie danych
            UpdateTypesList();
            ReloadIfFormReturnedOK();
        }

        public void ShowSpacecraftsEditForm()
        {
            try
            {
                Statek spacecraft = spacecrafts.GetActiveElement();
                UpdateTypesList();
                SpacecraftsForm form = new SpacecraftsForm(spacecraft, types);
                SpacecraftsFormController formController = new SpacecraftsFormController(form, Operation.Edit);
                form.Queries = queriesSpacecrafts;
                formController.Queries = queriesSpacecrafts;
                dr = form.ShowDialog();
                // odswiezenie danych
                UpdateTypesList();
                ReloadIfFormReturnedOK();
            }
            catch (NullReferenceException ex)
            {
                // pusta tabela/?
            }
        }

        public void ShowSpacecraftsDeleteForm()
        {
            try
            {
                Statek spacecraft = spacecrafts.GetActiveElement();
                UpdateTypesList();
                SpacecraftsForm form = new SpacecraftsForm(spacecraft, types);
                SpacecraftsFormController formController = new SpacecraftsFormController(form, Operation.Delete);
                form.Queries = queriesSpacecrafts;
                formController.Queries = queriesSpacecrafts;
                form.ShowDialog();
                // odswiezenie danych
                UpdateTypesList();
                SelectAllAtActiveWindow();
            }
            catch (NullReferenceException ex)
            {

            }
        }

        #endregion

        // --- --- --- --- --- HELP --- --- --- --- --- //
        #region Okno pomocy

        public void ShowHelpView()
        {
           //     activeView.Hide();
           //     spacecrafts.CopyWindowState(activeView);
           //     activeView = spacecrafts;
                help.Show();
           //     SelectAllAtActiveWindow();
        }
        #endregion
    }
}