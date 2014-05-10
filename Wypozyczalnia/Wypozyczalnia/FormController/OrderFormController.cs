using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Wypozyczalnia.Database;
using Wypozyczalnia.View;

namespace Wypozyczalnia
{
    class OrderFormController : IFormController
    {
        private OrderForm form;
        private Operation operation;
        private QueriesOrder qo;

        public OrderFormController(OrderForm form)
        {
            this.form = form;
            form.SetController(this);
        }

        public OrderFormController(OrderForm form, Operation operation)
        {
            this.form = form;
            form.SetController(this);
            this.operation = operation;
            SetFormTitle();
            SetTextBoxesState();
        }

        public QueriesOrder Queries
        {
            set { this.qo = value; }
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
                IsDataCorrect();
                Zamówienie order = new Zamówienie
                {
                    Data_zamówienia = Convert.ToDateTime(form.TextBox2),
                    Data_odbioru = form.TextBox3.Length > 0 ? Convert.ToDateTime(form.TextBox3) : (DateTime?)null
                };
                qo.Insert(order);
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
                MessageBox.Show(ex.Message.ToString(), "Błąd");
            }
        }

        public void Edit()
        {
            form.DialogResult = DialogResult.None;
            try
            {
                IsDataCorrect();
                Zamówienie order = new Zamówienie
                {
                    Data_zamówienia = Convert.ToDateTime(form.TextBox2),
                    Data_odbioru = form.TextBox3.Length > 0 ? Convert.ToDateTime(form.TextBox3) : (DateTime?)null,
                    Zamówienie_ID = Convert.ToInt32(form.TextBox1)
                };
                qo.Edit(order);
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
                MessageBox.Show(ex.Message.ToString(), "Błąd");
            }
        }

        public void Delete()
        {
            form.DialogResult = DialogResult.None;
            try
            {
                Zamówienie order = new Zamówienie
                {
                    Data_zamówienia = Convert.ToDateTime(form.TextBox2),
                    Data_odbioru = form.TextBox3.Length > 0 ? Convert.ToDateTime(form.TextBox3) : (DateTime?)null,
                    Zamówienie_ID = Convert.ToInt32(form.TextBox1)
                };
                qo.Delete(order);
                form.DialogResult = DialogResult.OK;
                form.Dispose();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Błędne dane.", "Błąd");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Błąd");
            }
        }

        private void IsDataCorrect()
        {
            string message = "Pole \"Data zamówienia\" nie może być puste.";
            if (form.TextBox2.Length < 1)
            {
                throw new DataIncorrect(message);
            }
        }

        private void SetFormTitle()
        {
            switch (operation)
            {
                case Operation.Add:
                    form.Title = "Dodawanie nowego zamówienia";
                    break;
                case Operation.Edit:
                    form.Title = "Edycja zamówienia";
                    break;
                case Operation.Delete:
                    form.Title = "Usuwanie zamówienia";
                    break;
            }
        }

        private void SetTextBoxesState()
        {
            switch (operation)
            {
                case Operation.Add:
                case Operation.Edit:
                    form.EnabledTextBox1 = false;
                    break;
                case Operation.Delete:
                    form.DisableAllFields();
                    break;
            }
        }
    }
}
