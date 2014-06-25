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
                Część part;

                if (form.ComboBox1 == "Zamontowana")
                    part = new Część
                    {
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4),
                        Statek_Statek_ID = query.GetStatek(Convert.ToInt32(form.TextBox5)).Statek_ID,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else if (form.ComboBox1 == "Zamówiona")
                    part = new Część
                    {
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4), Statek_Statek_ID = query.GetStatek(Convert.ToInt32(form.TextBox5)).Statek_ID,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else if (form.ComboBox1 == "W magazynie")
                    part = new Część
                    {
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4),Statek_Statek_ID = query.GetStatek(Convert.ToInt32(form.TextBox5)).Statek_ID,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else //Do zamowienia
                    part = new Część
                    {
                        Nazwa = form.TextBox2,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
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
                Część part;

                if (form.ComboBox1 == "Zamontowana")
                    part = new Część
                    {
                        Część_ID = Convert.ToInt32(form.TextBox1),
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4),
                        Statek_Statek_ID = query.GetStatek(Convert.ToInt32(form.TextBox5)).Statek_ID,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else if (form.ComboBox1 == "Zamówiona")
                    part = new Część
                    {
                        Część_ID = Convert.ToInt32(form.TextBox1),
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4),
                        Statek_Statek_ID = query.GetStatek(Convert.ToInt32(form.TextBox5)).Statek_ID,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else if (form.ComboBox1 == "W magazynie")
                    part = new Część
                    {
                        Część_ID = Convert.ToInt32(form.TextBox1),
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4),
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else //Do zamowienia
                    part = new Część
                    {
                        Część_ID = Convert.ToInt32(form.TextBox1),
                        Nazwa = form.TextBox2,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
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
                Część part;

                if (form.ComboBox1 == "Zamontowana")
                    part = new Część
                    {
                        Część_ID = Convert.ToInt32(form.TextBox1),
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4),
                        Statek_Statek_ID = query.GetStatek(Convert.ToInt32(form.TextBox5)).Statek_ID,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else if (form.ComboBox1 == "Zamówiona")
                    part = new Część
                    {
                        Część_ID = Convert.ToInt32(form.TextBox1),
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4),
                        Statek_Statek_ID = query.GetStatek(Convert.ToInt32(form.TextBox5)).Statek_ID,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else if (form.ComboBox1 == "W magazynie")
                    part = new Część
                    {
                        Część_ID = Convert.ToInt32(form.TextBox1),
                        Nazwa = form.TextBox2,
                        Zamówienie_Zamówienie_ID = query.GetZamowienie(Convert.ToInt32(form.TextBox3)).Zamówienie_ID,
                        Cena = Convert.ToSingle(form.TextBox4),
                        Statek_Statek_ID = query.GetStatek(Convert.ToInt32(form.TextBox5)).Statek_ID,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
                    };
                else //Do zamowienia
                    part = new Część
                    {
                        Część_ID = Convert.ToInt32(form.TextBox1),
                        Nazwa = form.TextBox2,
                        Status_części_Status_części_ID = query.GetStatus(form.ComboBox1).Status_części_ID
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
            if ((form.ComboBox1 != "Zamontowana") && (form.ComboBox1 != "Zamówiona") && (form.ComboBox1 != "W magazynie") && (form.ComboBox1 != "Do zamówienia"))
            {
                throw new DataIncorrect("Nie wybrano odpowiedniego statusu");
            }
            if ((form.ComboBox1 == "Zamontowana") && ((form.TextBox2.Length <= 0) || (form.TextBox3.Length <= 0) || (form.TextBox4.Length <= 0) || (form.TextBox5.Length <= 0)))
            {
                throw new DataIncorrect("Muszą być wypełnione wszystkie pola");
            }
            if ((form.ComboBox1 == "Zamówiona") && ((form.TextBox2.Length <= 0) || (form.TextBox3.Length <= 0) || (form.TextBox4.Length <= 0)))
            {
                throw new DataIncorrect("Tylko ID statku może nie być wypełnione");
            }
            if ((form.ComboBox1 == "W magazynie") && ((form.TextBox2.Length <= 0) || (form.TextBox3.Length <= 0) || (form.TextBox4.Length <= 0)))
            {
                throw new DataIncorrect("Tylko ID statku może nie być wypełnione");
            }
            if ((form.ComboBox1 == "Do zamówienia") && (form.TextBox2.Length <= 0))
            {
                throw new DataIncorrect("Nazwa musi być wypełniona");
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
