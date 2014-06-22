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
    class SpacecraftsFormController : IFormController
    {
        private SpacecraftsForm form;
        private Operation operation;
        private QueriesSpacecrafts qe;

        public SpacecraftsFormController(SpacecraftsForm form)
        {
            this.form = form;
            form.SetController(this);
        }

        public SpacecraftsFormController(SpacecraftsForm form, Operation operation)
        {
            this.form = form;
            form.SetController(this);
            this.operation = operation;
            SetFormTitle();
            SetTextBoxesState();
        }

        public QueriesSpacecrafts Queries
        {
            set { this.qe = value; }
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
                Statek spacecraft = new Statek
                {
                    Typ_statku = qe.GetType(form.ComboBox1),
                    Silnik = form.TextBox2,
                    Rok_produkcji = Convert.ToInt32(form.TextBox3),
                    Cena_za_dobę = Convert.ToInt32(form.TextBox4),
                };
                qe.Insert(spacecraft);
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
                Statek spacecraft = new Statek
                {
                    Statek_ID = Convert.ToInt32(form.TextBox1),
                    Typ_statku_Typ_statku_ID = qe.GetType(form.ComboBox1).Typ_statku_ID,
                    Silnik = form.TextBox2,
                    Rok_produkcji = Convert.ToInt32(form.TextBox3),
                    Cena_za_dobę = Convert.ToInt32(form.TextBox4),
                };
                qe.Edit(spacecraft);
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
                Statek spacecraft = new Statek
                {
                    Statek_ID = Convert.ToInt32(form.TextBox1),
                    Typ_statku_Typ_statku_ID = qe.GetType(form.ComboBox1).Typ_statku_ID,    // ???
                    Silnik = form.TextBox2,
                    Rok_produkcji = Convert.ToInt32(form.TextBox3),
                    Cena_za_dobę = Convert.ToInt32(form.TextBox4),
                };
                qe.Delete(spacecraft);
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

        public SpacecraftsForm getForm()
        {
            return this.form;
        }

        private void IsDataCorrect()
        {
            string message = "Pole nie może być puste.";
            if ((form.TextBox2.Length <= 0) || (form.TextBox3.Length <= 0) || (form.TextBox4.Length <= 0))
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
                    form.Title = "Dodawanie nowego statku";
                    break;
                case Operation.Edit:
                    form.Title = "Edycja statku";
                    break;
                case Operation.Delete:
                    form.Title = "Usuwanie statku";
                    break;
            }
        }
    }
}
