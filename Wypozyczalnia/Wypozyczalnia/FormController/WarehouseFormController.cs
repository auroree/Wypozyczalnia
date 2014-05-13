using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.Database;
using Wypozyczalnia.View;

namespace Wypozyczalnia.FormController
{
    public class WarehouseFormController: IFormController
    {
        private WarehouseForm form;
        private Operation operation;
        private QueriesWarehouse query;

        public WarehouseFormController(WarehouseForm form)
        {
            this.form = form;
            form.SetController(this);
        }

        public WarehouseFormController(WarehouseForm form, Operation operation)
        {
            this.form = form;
            form.SetController(this);
            this.operation = operation;
            SetFormTitle();
            SetTextBoxesState();
        }

        public QueriesWarehouse Queries
        {
            set { this.query = value; }
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
                // LINQ
                Część part = new Część
                {
                    Nazwa = form.TextBox2,
                   // Zamówienie_Zamówienie_ID = Convert.ToInt32(form.TextBox3),
                    Zamówienie = query.GetZamowienie(Convert.ToInt32(form.TextBox3)),
                    Cena = Convert.ToSingle(form.TextBox4),
                  //  Statek_Statek_ID = Convert.ToInt32(form.TextBox5),
                    Statek = query.GetStatek(Convert.ToInt32(form.TextBox5)),
                   // Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    Status_części = query.GetStatus(form.ComboBox1)
                    //Status_części = new Status_części()
                    //{
                    //    Status = form.ComboBox1
                    //}
                };
                query.Insert(part);
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
                MessageBox.Show(ex.ToString(), "Błąd komunikacji z bazą danych");
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
                Część part = new Część
                {
                    Nazwa = form.TextBox2,
                    Zamówienie_Zamówienie_ID = Convert.ToInt32(form.TextBox3),
                    Cena = Convert.ToSingle(form.TextBox4),
                    Statek_Statek_ID = Convert.ToInt32(form.TextBox5),
                    Status_części = query.GetStatus(form.ComboBox1)
                };
                query.Edit(part);
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
                // LINQ
                Część part = new Część
                {
                    Nazwa = form.TextBox2,
                    Zamówienie_Zamówienie_ID = Convert.ToInt32(form.TextBox3),
                    Cena = Convert.ToSingle(form.TextBox4),
                    Statek_Statek_ID = Convert.ToInt32(form.TextBox5),
                    Status_części = query.GetStatus(form.ComboBox1)
                };
                query.Delete(part);
                // zakmniecie formularza
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
            if ((form.TextBox2.Length <= 0) || (form.TextBox3.Length <= 0) || (form.ComboBox1.Length <= 0))
            {
                throw new DataIncorrect(message);
            }
        }
        
        private void SetTextBoxesState()        //dziwne, obczaić
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
                    form.Title = "Dodawanie nowej części";
                    break;
                case Operation.Edit:
                    form.Title = "Edycja części";
                    break;
                case Operation.Delete:
                    form.Title = "Usuwanie części";
                    break;
            }
        }
    }
}
