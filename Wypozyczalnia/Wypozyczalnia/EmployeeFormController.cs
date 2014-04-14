using System;
using System.Collections.Generic;
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
    public class EmployeeFormController : IFormController
    {
        private EmployeeForm form;
        private Operation operation;
        private DatabaseConnection dc;

        public EmployeeFormController(EmployeeForm form)
        {
            this.form = form;
            form.SetController(this);
        }

        public EmployeeFormController(EmployeeForm form, Operation operation)
        {
            this.form = form;
            form.SetController(this);
            this.operation = operation;
            SetFormTitle();
            SetTextBoxesState();
        }

        public void SetConnection(DatabaseConnection dc)
        {
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
            form.DialogResult = DialogResult.None;
            try
            {
                // sprawdzenie poprawnosci danych
                IsDataCorrect();

                Employee employee = new Employee(form.TextBox2, form.TextBox3, Convert.ToDateTime(form.TextBox4),
                    form.TextBox5, Convert.ToSingle(form.TextBox6), form.ComboBox1);
                // komunikacja z baza danych
                dc.OpenConnection();
                dc.ExecuteQuery(DBEmployee.InsertQuery(employee));
                dc.CloseConnection();
                // komunikat o wyniku operacji (lub tylko bledzie jesli wystapil ?)
                MessageBox.Show("Dodano nowy wpis", "Dodano");
                // zamkniecie formularza
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

                Employee employee = new Employee(Convert.ToInt32(form.TextBox1), form.TextBox2,
                    form.TextBox3, Convert.ToDateTime(form.TextBox4),
                    form.TextBox5, Convert.ToSingle(form.TextBox6), form.ComboBox1);
                // komunikacja z baza danych
                dc.OpenConnection();
                dc.ExecuteQuery(DBEmployee.UpdateQuery(employee));
                dc.CloseConnection();
                // komunikat o wyniku operacji (lub tylko bledzie jesli wystapil ?)
                MessageBox.Show("Dodano nowy wpis", "Dodano");
                // zamkniecie formularza
                form.DialogResult = DialogResult.OK; ;
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

        public void Delete()
        {
            form.DialogResult = DialogResult.None;
            try
            {
                Employee employee = new Employee(Convert.ToInt32(form.TextBox1), form.TextBox2,
                        form.TextBox3, Convert.ToDateTime(form.TextBox4),
                        form.TextBox5, Convert.ToSingle(form.TextBox6), form.ComboBox1);

                dc.OpenConnection();
                dc.ExecuteQuery(DBEmployee.DeleteQuery(employee));
                dc.CloseConnection();

                form.DialogResult = DialogResult.OK;
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

        private void IsDataCorrect()
        {
            string message = "Pole nie może być puste.";
            if ((form.TextBox2.Length <= 0) || (form.TextBox3.Length <= 0) || (form.TextBox4.Length <= 0) ||
                (form.TextBox5.Length <= 0) || (form.TextBox6.Length <= 0))
            {
                throw new DataIncorrect(message);
            }
        }

        private void SetTextBoxesState()
        {
            switch (operation)
            {
                case Operation.Add:
                    form.EnabledTextBox1 = false;
                    break;
                case Operation.Edit:
                    form.EnabledTextBox1 = false;
                    break;
                case Operation.Delete:
                    form.DisableAllFields();
                    break;
            }
        }

        private void SetFormTitle()
        {
            switch (operation)
            {
                case Operation.Add:
                    form.Title = "Dodawanie nowego pracownika";
                    break;
                case Operation.Edit:
                    form.Title = "Edycja pracownika";
                    break;
                case Operation.Delete:
                    form.Title = "Usuwanie pracownika";
                    break;
            }
        }
    }
}
