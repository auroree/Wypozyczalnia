using System;
using System.Data;
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
        private QueriesWarehouse qw;

        public OrderFormController(OrderForm form)
        {
            this.form = form;
            try
            {
                form.SetController(this);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Posługiwanie się nullowym obiektem.", "Błąd");
            }
        }

        public OrderFormController(OrderForm form, Operation operation)
        {
            this.form = form;
            this.operation = operation;
            try
            {
                form.SetController(this);
                SetFormTitle();
                SetTextBoxesState();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Posługiwanie się nullowym obiektem.", "Błąd");
            }
        }

        public QueriesOrder OrderQuery
        {
            set { this.qo = value; }
        }

        public QueriesWarehouse WarehouseQuery
        {
            set { this.qw = value; }
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

        // przypisanie dodanej części: ID zamówienia, statusu "Zamówiona" i ceny
        public void MarkSelectedPartsAsOrdered(decimal orderId)
        {
            foreach (DataRow dtRow in form.PartsAddedToOrder.Rows)
            {
                if (Convert.ToString(dtRow.ItemArray[2]) == "Do zamówienia")
                {
                    Część cz = new Część()
                    {
                        Część_ID = Convert.ToInt32(dtRow.ItemArray[0]),
                        Nazwa = Convert.ToString(dtRow.ItemArray[1]),
                        Status_części_Status_części_ID = qw.GetStatus("Zamówiona").Status_części_ID,
                        Zamówienie_Zamówienie_ID = orderId,
                        Cena = Convert.ToSingle(dtRow.ItemArray[4]),
                        Statek_Statek_ID = dtRow.ItemArray[5] != DBNull.Value ? Convert.ToInt32(dtRow.ItemArray[5]) : (Int32?)null,
                    };
                    if (cz != null)
                        qw.Edit(cz);
                }
            }
        }

        // usuniętym częściom wymazujemy ID zamówienia, cenę i jeżeli miały status "Zamówiona", to z powrotem ustawiamy status na "Do zamówienia"
        public void MarkRemovedPartsAsNotOrdered()
        {
            foreach (DataRow dtRow in form.PartsNotAddedToOrder.Rows)
                if (dtRow.ItemArray[3] != DBNull.Value)
                {
                    Część cz = new Część()
                    {
                        Część_ID = Convert.ToInt32(dtRow.ItemArray[0]),
                        Nazwa = Convert.ToString(dtRow.ItemArray[1]),
                        Status_części_Status_części_ID = qw.GetStatus(Convert.ToString(dtRow.ItemArray[2])).Status_części_ID == qw.GetStatus("Zamówiona").Status_części_ID ? qw.GetStatus("Do zamówienia").Status_części_ID : qw.GetStatus(Convert.ToString(dtRow.ItemArray[2])).Status_części_ID,
                        Zamówienie_Zamówienie_ID = null,
                        Cena = null,
                        Statek_Statek_ID = dtRow.ItemArray[5] != DBNull.Value ? Convert.ToInt32(dtRow.ItemArray[5]) : (Int32?)null,
                    };
                    if (cz != null)
                        qw.Edit(cz);
                }
        }

        // wszystkim częściom o danym ID zamówienia wymazujemy ID zamówienia, cenę i jeżeli miały status "Zamówiona", to z powrotem ustawiamy status na "Do zamówienia"
        public void MarkAllPartsAsNotOrdered(decimal orderId)
        {
            foreach (DataRow dtRow in qo.SelectPartsByOrder((int)orderId).Rows)
            {
                Część cz = new Część()
                {
                    Część_ID = Convert.ToInt32(dtRow.ItemArray[0]),
                    Nazwa = Convert.ToString(dtRow.ItemArray[1]),
                    Status_części_Status_części_ID = qw.GetStatus(Convert.ToString(dtRow.ItemArray[2])).Status_części_ID == qw.GetStatus("Zamówiona").Status_części_ID ? qw.GetStatus("Do zamówienia").Status_części_ID : qw.GetStatus(Convert.ToString(dtRow.ItemArray[2])).Status_części_ID,
                    Zamówienie_Zamówienie_ID = null,
                    Cena = null,
                    Statek_Statek_ID = dtRow.ItemArray[5] != DBNull.Value ? Convert.ToInt32(dtRow.ItemArray[5]) : (Int32?)null,
                };
                if (cz != null)
                    qw.Edit(cz);
            }
        }

        // aktualizacja cen części już należących do zamówienia
        public void UpdatePartsPrices()
        {
            foreach (DataRow dtRow in form.PartsAddedToOrder.Rows)
                if (Convert.ToString(dtRow.ItemArray[2]) != "Do zamówienia")
                {
                    Część cz = new Część()
                    {
                        Część_ID = Convert.ToInt32(dtRow.ItemArray[0]),
                        Nazwa = Convert.ToString(dtRow.ItemArray[1]),
                        Status_części_Status_części_ID = qw.GetStatus(Convert.ToString(dtRow.ItemArray[2])).Status_części_ID,
                        Zamówienie_Zamówienie_ID = Convert.ToInt32(dtRow.ItemArray[3]),
                        Cena = Convert.ToSingle(dtRow.ItemArray[4]),
                        Statek_Statek_ID = dtRow.ItemArray[5] != DBNull.Value ? Convert.ToInt32(dtRow.ItemArray[5]) : (Int32?)null,
                    };
                    if (cz != null)
                        qw.Edit(cz);
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
                decimal orderId = qo.Insert(order);
                MarkSelectedPartsAsOrdered(orderId);
                form.DialogResult = DialogResult.OK;
                form.Dispose();
            }
            catch (DataIncorrect ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędny format daty.", "Błąd");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Błąd");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Posługiwanie się nullowym obiektem.", "Błąd");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Nieprawidłowo wypełnione obiekty typu Część (próba konwersji z wartości DBNull).", "Błąd");
            }
        }

        public void Edit()
        {
            try
            {
                form.DialogResult = DialogResult.None;
                IsDataCorrect();
                Zamówienie order = new Zamówienie
                {
                    Data_zamówienia = Convert.ToDateTime(form.TextBox2),
                    Data_odbioru = form.TextBox3.Length > 0 ? Convert.ToDateTime(form.TextBox3) : (DateTime?)null,
                    Zamówienie_ID = Convert.ToInt32(form.TextBox1)
                };
                qo.Edit(order);
                MarkRemovedPartsAsNotOrdered();
                MarkSelectedPartsAsOrdered(order.Zamówienie_ID);
                UpdatePartsPrices();
                form.DialogResult = DialogResult.OK;
                form.Dispose();
            }
            catch (DataIncorrect ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędny format daty.", "Błąd");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Błąd");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Posługiwanie się nullowym obiektem.", "Błąd");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Nieprawidłowo wypełnione obiekty typu Część (występuje konwersja z wartości DBNull).", "Błąd");
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
                MarkAllPartsAsNotOrdered(order.Zamówienie_ID);
                qo.Delete(order);
                form.DialogResult = DialogResult.OK;
                form.Dispose();
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędne dane.", "Błąd");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Błąd");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Posługiwanie się nullowym obiektem.", "Błąd");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Nieprawidłowo wypełnione obiekty typu Część (występuje konwersja z wartości DBNull).", "Błąd");
            }
        }

        private void IsDataCorrect()
        {
            try
            {
                if (form.TextBox2.Length < 1)
                    throw new DataIncorrect("Pole \"Data zamówienia\" nie może być puste.");
                if (form.TextBox3.Length > 0)
                    if (DateTime.Compare(Convert.ToDateTime(form.TextBox2), Convert.ToDateTime(form.TextBox3)) > 0)
                        throw new DataIncorrect("Data odbioru nie może być wcześniejsza od daty zamówienia.");
                foreach (DataRow dtRow in form.PartsAddedToOrder.Rows)
                    if (dtRow.ItemArray[4] == DBNull.Value)
                        throw new DataIncorrect("Ceny wybranych części muszą być określone.");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Posługiwanie się nullowym obiektem.", "Błąd");
            }
            catch (FormatException)
            {

            }
        }

        private void SetFormTitle()
        {
            try
            {
                switch (operation)
                {
                    case Operation.Add:
                        form.Title = "Dodawanie nowego zamówienia";
                        break;
                    case Operation.Edit:
                        form.Title = "Edycja zamówienia";
                        break;
                    /*
                    case Operation.Delete:
                        form.Title = "Usuwanie zamówienia";
                        break;
                    */
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Posługiwanie się nullowym obiektem.", "Błąd");
            }
        }

        private void SetTextBoxesState()
        {
            try
            {
                switch (operation)
                {
                    case Operation.Add:
                    case Operation.Edit:
                        form.EnabledTextBox1 = false;
                        break;
                    /*
                    case Operation.Delete:
                        form.DisableAllFields();
                        break;
                    */
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Posługiwanie się nullowym obiektem.", "Błąd");
            }
        }
    }
}
