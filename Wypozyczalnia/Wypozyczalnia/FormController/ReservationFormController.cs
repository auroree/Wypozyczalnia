using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.Database;
using Wypozyczalnia.View;

namespace Wypozyczalnia.FormController 
{
    public class ReservationFormController : IFormController
    {
        private ReservationForm form;
        private Operation operation;
        private QueriesReservation queriesReservation;

        public ReservationFormController()
        {
            //this.form = form;
            form.SetController(this);
        }

        public ReservationFormController(ReservationForm form, Operation operation)
        {
            this.form = form;
            form.SetController(this);
            this.operation = operation;
            SetFormTitle();
            SetTextBoxesState();
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
            }
        }

        private void IsDataCorrect()
        {
            string message = "Pole nie może być puste.";
            if ((form.TextBox1.Length <= 0) || (form.AddedClientDataTable.Rows.Count <= 0) || (form.AddedEmployeesDataTable.Rows.Count <= 0) || (form.AddedShipDataTable.Rows.Count <= 0))
            {
                throw new DataIncorrect(message);
            }

        }

        public void refreshAvailableItems(String HireDate, int? id = null)
        {
            DateTime hireDate = Convert.ToDateTime(HireDate);
            try
            {
                if (id == null)
                {
                    form.EmployeesDataTable = queriesReservation.SelectEmployeesByDate(hireDate);
                    form.ShipsDataTable = queriesReservation.SelectShipsByDate(hireDate);
                }
                else
                {
                    form.EmployeesDataTable = queriesReservation.SelectEmployeesByDate(Convert.ToInt32(id), hireDate);
                    form.ShipsDataTable = queriesReservation.SelectShipsByDate(Convert.ToInt32(id), hireDate);
                }

                form.AddedShipDataTable = form.ShipsDataTable.Clone();
                form.AddedEmployeesDataTable = form.EmployeesDataTable.Clone();

                form.SetColumns();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

        public void showReservationItmes(int id, String HireDate, String DueDate = null)
        {
            DateTime hireDate = Convert.ToDateTime(HireDate);
            DateTime? dueDate;
            if (DueDate != null)
            {
                dueDate = Convert.ToDateTime(DueDate);
            }
            else
            {
                dueDate = null;
            }

            try
            {
                form.AddedClientDataTable = queriesReservation.SelectSingleClient(id);
                form.AddedShipDataTable = queriesReservation.SelectSingleShip(id);
                form.AddedEmployeesDataTable = queriesReservation.SelectReservationEmployee(id);

                form.ClientsDataTable = queriesReservation.SelectAllWithoutSingle(id);
                form.EmployeesDataTable = queriesReservation.SelectEmployeesByDate(hireDate, dueDate);
                form.ShipsDataTable = queriesReservation.SelectShipsByDate(hireDate, dueDate);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

        /*
        public void refreshAllTables(String HireDate, String DueDate = null)
        {

            DateTime hireDate = Convert.ToDateTime(HireDate);
            DateTime? dueDate;
            if (DueDate != null)
            {
                dueDate = Convert.ToDateTime(DueDate);
            }
            else
            {
                dueDate = null;
            }

            form.EmployeesDataTable = queriesReservation.SelectEmployeesByDate(hireDate, dueDate);
            form.ShipsDataTable = queriesReservation.SelectShipsByDate(hireDate, dueDate);

            form.AddedShipDataTable = form.ShipsDataTable.Clone();
            form.AddedEmployeesDataTable = form.EmployeesDataTable.Clone();

            form.SetColumns();
        }

        public void refreshAllTables(int id, String HireDate, String DueDate =  null)
        {
            DateTime hireDate = Convert.ToDateTime(HireDate);
            DateTime? dueDate;
            if (DueDate != null)
            {
                dueDate = Convert.ToDateTime(DueDate);
            }
            else
            {
                dueDate = null;
            }

            form.EmployeesDataTable = queriesReservation.SelectEmployeesByDate(id, hireDate, dueDate);
            form.ShipsDataTable = queriesReservation.SelectShipsByDate(id, hireDate, dueDate);

            form.AddedShipDataTable = form.ShipsDataTable.Clone();
            form.AddedEmployeesDataTable = form.EmployeesDataTable.Clone();
            form.AddedClientDataTable = queriesReservation.SelectSingleClient(id);


            form.SetColumns();
        }
        */

        public QueriesReservation Queries
        {
            set { this.queriesReservation = value; }
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
            }
        }

        public void Add()
        {
            form.DialogResult = DialogResult.None;
            try
            {
                // sprawdzenie poprawnosci danych
                IsDataCorrect();
                // LINQ
                DateTime? Date;
                if (form.TextBox2.Length > 0)
                {
                    Date = Convert.ToDateTime(form.TextBox2);
                }
                else
                {
                    Date = null;
                }

                Rezerwacja reservation = new Rezerwacja
                {
                    Data_zwrotu = Date,
                    Data_wypożyczenia = Convert.ToDateTime(form.TextBox1),
                    Statek_Statek_ID = Convert.ToInt32(form.AddedShipDataTable.Rows[0].ItemArray[0]),
                    Klient_Klient_ID = Convert.ToInt32(form.AddedClientDataTable.Rows[0].ItemArray[0])

                };
                decimal newId = queriesReservation.InsertReservation(reservation);

                for (int i = 0; i < form.AddedEmployeesDataTable.Rows.Count; i++ )
                {
                    pilotuje p = new pilotuje
                    {
                        Rezerwacja_Rezerwacja_ID = newId,
                        Pracownik_Pracownik_ID = Convert.ToInt32(form.AddedEmployeesDataTable.Rows[i].ItemArray[0])
                    };
                    queriesReservation.InsertReservationEmployee(p);
                }

                form.DialogResult = DialogResult.OK;
                form.Dispose();
            }
            catch (DataIncorrect ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Błędny format danych.", "Błąd");
            }
            catch (SqlException ex)
            {
                //nie udalo sie polaczyc/bledna skladnia zapytania/bledne dane w zapytaniu/?
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

        public void Edit()
        {
            form.DialogResult = DialogResult.None;
            try
            {
                // sprawdzenie poprawnosci danych
                IsDataCorrect();
                // LINQ
                DateTime? Date;
                if (form.TextBox2.Length > 0)
                {
                    Date = Convert.ToDateTime(form.TextBox2);
                }
                else
                {
                    Date = null;
                }

                Rezerwacja reservation = new Rezerwacja
                {
                    Rezerwacja_ID = Convert.ToInt32(form.TextBoxID),
                    Data_zwrotu = Date,
                    Data_wypożyczenia = Convert.ToDateTime(form.TextBox1),
                    Statek_Statek_ID =  Convert.ToInt32(form.AddedShipDataTable.Rows[0].ItemArray[0]),
                    Klient_Klient_ID = Convert.ToInt32(form.AddedClientDataTable.Rows[0].ItemArray[0])

                };
                queriesReservation.DeleteReservtionEmployees(Convert.ToInt32(form.TextBoxID));
                queriesReservation.EditReservation(reservation);

               for (int i = 0; i < form.AddedEmployeesDataTable.Rows.Count; i++)
                {
                    pilotuje p = new pilotuje
                    {
                        Rezerwacja_Rezerwacja_ID = Convert.ToInt32(form.TextBoxID),
                        Pracownik_Pracownik_ID = Convert.ToInt32(form.AddedEmployeesDataTable.Rows[i].ItemArray[0])
                    };
                    queriesReservation.InsertReservationEmployee(p);
                }

                form.DialogResult = DialogResult.OK;
                //form.Dispose();
            }
            catch (DataIncorrect ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Błędny format danych.", "Błąd");
            }
            catch (SqlException ex)
            {
                //nie udalo sie polaczyc/bledna skladnia zapytania/bledne dane w zapytaniu/?
                MessageBox.Show("Błąd komunikacji z bazą danych", "Błąd");
            }
        }

        public void Delete()
        {
            
        }

        private bool IsDateCorrect(String date)
        {
            string correctFormat = "yyyy-MM-dd";
            bool correct = false;
            if (date.Length != 10)
            {
                return false;
            }
            DateTime dateTime;
            if (DateTime.TryParseExact(date, correctFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateTime))
            {
                return true;
            }
            return correct;
        }

        private void SetTextBoxesState()
        {
            switch (operation)
            {
                case Operation.Add:
                    form.EnabledTextBox2 = false;
                    break;
            }
        }
    }
}
