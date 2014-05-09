using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Wypozyczalnia.FormController;

namespace Wypozyczalnia.View
{
    public partial class ReservationForm : Wypozyczalnia.View.BaseForm
    {
        public ReservationFormController controller;

        public ReservationForm()
        {
            InitializeComponent();
            unsetRowHeadersVisible();
        }

        public ReservationForm(Rezerwacja reservation)
        {
            InitializeComponent();
            unsetRowHeadersVisible();
            textBox1.Text = reservation.Data_wypożyczenia.ToString("yyyy-MM-dd");
            //nullable
            if (reservation.Data_zwrotu != null)
            {
                textBox2.Text = reservation.Data_zwrotu.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                textBox2.Text = null;
            }
            textBoxID.Text = reservation.Rezerwacja_ID.ToString();
        }

        public void SetController(ReservationFormController controller)
        {
            this.controller = controller;
            SetController((IFormController)controller);
        }

        public string TextBoxID
        {
            get { return textBoxID.Text; }
            set { textBoxID.Text = value; }
        }

        private void unsetRowHeadersVisible()
        {
            dataGridViewAddedClient.RowHeadersVisible = false;
            dataGridViewClients.RowHeadersVisible = false;
            dataGridViewShips.RowHeadersVisible = false;
            dataGridViewAddedShip.RowHeadersVisible = false;
            dataGridViewEmployees.RowHeadersVisible = false;
            dataGridViewAddedEmployees.RowHeadersVisible = false;
        }

        public DataTable AddedClientDataTable
        {
            get { return (DataTable)this.dataGridViewAddedClient.DataSource; }
            set { this.dataGridViewAddedClient.DataSource = value; }
        }

        public DataTable ClientsDataTable
        {
            get { return (DataTable)this.dataGridViewClients.DataSource; }
            set { this.dataGridViewClients.DataSource = value; }
        }

        public DataTable ShipsDataTable
        {
            get { return (DataTable)this.dataGridViewShips.DataSource; }
            set { this.dataGridViewShips.DataSource = value; }
        }

        public DataTable AddedShipDataTable
        {
            get { return (DataTable)this.dataGridViewAddedShip.DataSource; }
            set { this.dataGridViewAddedShip.DataSource = value; }
        }

        public DataTable EmployeesDataTable
        {
            get { return (DataTable)this.dataGridViewEmployees.DataSource; }
            set { this.dataGridViewEmployees.DataSource = value; }
        }

        public DataTable AddedEmployeesDataTable
        {
            get { return (DataTable)this.dataGridViewAddedEmployees.DataSource; }
            set { this.dataGridViewAddedEmployees.DataSource = value; }
        }

        public virtual void SetColumnNames()
        {
            DataGridViewColumnCollection columns = dataGridViewAddedClient.Columns;
            foreach (DataGridViewColumn column in columns)
            {
                column.HeaderText = column.HeaderText.Replace('_', ' ');
            }
            columns = dataGridViewClients.Columns;
            foreach (DataGridViewColumn column in columns)
            {
                column.HeaderText = column.HeaderText.Replace('_', ' ');
            }
            columns = dataGridViewShips.Columns;
            foreach (DataGridViewColumn column in columns)
            {
                column.HeaderText = column.HeaderText.Replace('_', ' ');
            }
            columns = dataGridViewAddedShip.Columns;
            foreach (DataGridViewColumn column in columns)
            {
                column.HeaderText = column.HeaderText.Replace('_', ' ');
            }
            columns = dataGridViewEmployees.Columns;
            foreach (DataGridViewColumn column in columns)
            {
                column.HeaderText = column.HeaderText.Replace('_', ' ');
            }
            columns = dataGridViewAddedEmployees.Columns;
            foreach (DataGridViewColumn column in columns)
            {
                column.HeaderText = column.HeaderText.Replace('_', ' ');
            }
        }

        public void SetColumns()
        {
            SetColumnNames();
            SetColumnsWidth();
        }

        public virtual void SetColumnsWidth()
        {
            try
            {
                double width = dataGridViewAddedEmployees.Width;
                dataGridViewAddedEmployees.Columns[0].Width = (int)(0.2 * width);
                dataGridViewAddedEmployees.Columns[1].Width = (int)(0.2 * width);
                dataGridViewAddedEmployees.Columns[2].Width = (int)(0.2 * width);
                dataGridViewAddedEmployees.Columns[3].Width = (int)(0.2 * width);
                dataGridViewAddedEmployees.Columns[4].Width = (int)(0.2 * width);
                dataGridViewAddedEmployees.Columns[5].Width = (int)(0.2 * width);
                dataGridViewAddedEmployees.Columns[6].Width = (int)(0.2 * width);

            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

            try
            {
                double width = dataGridViewEmployees.Width;
                dataGridViewEmployees.Columns[0].Width = (int)(0.2 * width);
                dataGridViewEmployees.Columns[1].Width = (int)(0.2 * width);
                dataGridViewEmployees.Columns[2].Width = (int)(0.2 * width);
                dataGridViewEmployees.Columns[3].Width = (int)(0.2 * width);
                dataGridViewEmployees.Columns[4].Width = (int)(0.2 * width);
                dataGridViewEmployees.Columns[5].Width = (int)(0.2 * width);
                dataGridViewEmployees.Columns[6].Width = (int)(0.2 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

            try
            {

                double width = dataGridViewAddedShip.Width;
                dataGridViewAddedShip.Columns[0].Width = (int)(0.1 * width);
                dataGridViewAddedShip.Columns[1].Width = (int)(0.3 * width);
                dataGridViewAddedShip.Columns[2].Width = (int)(0.3 * width);
                dataGridViewAddedShip.Columns[3].Width = (int)(0.3 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

            try
            {
                double width = dataGridViewShips.Width;
                dataGridViewShips.Columns[0].Width = (int)(0.1 * width);
                dataGridViewShips.Columns[1].Width = (int)(0.3 * width);
                dataGridViewShips.Columns[2].Width = (int)(0.3 * width);
                dataGridViewShips.Columns[3].Width = (int)(0.3 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }


            try
            {
                double width = dataGridViewClients.Width;
                dataGridViewClients.Columns[0].Width = (int)(0.15 * width);
                dataGridViewClients.Columns[1].Width = (int)(0.3 * width);
                dataGridViewClients.Columns[2].Width = (int)(0.3 * width);
                dataGridViewClients.Columns[3].Width = (int)(0.25 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

            try
            {
                double width = dataGridViewAddedClient.Width;
                dataGridViewAddedClient.Columns[0].Width = (int)(0.15 * width);
                dataGridViewAddedClient.Columns[1].Width = (int)(0.3 * width);
                dataGridViewAddedClient.Columns[2].Width = (int)(0.3 * width);
                dataGridViewAddedClient.Columns[3].Width = (int)(0.25 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

        }

        private void ActionDateOfHireOnChanged(object sender, EventArgs e)
        {

            if (IsDateCorrect(textBox1.Text))
            {
                tabControl1.Enabled = true;
                labelHireDateInfo.ForeColor = System.Drawing.Color.Black;
                if (controller != null)
                {
                    if (textBoxID.Text.Length > 0)
                    {
                        controller.refreshAvailableItems(textBox1.Text, Convert.ToInt32(textBoxID.Text)); // Wyswietlenie dostepnych pracownikow wyzerowanie starych to samo dla statkow
                    }
                    else
                    {
                        controller.refreshAvailableItems(textBox1.Text);
                    }
                }
            }
            else
            {
                tabControl1.Enabled = false;
                labelHireDateInfo.ForeColor = System.Drawing.Color.Red;
                
            }
        }

        private void ActionDueDateOnChanged(object sender, EventArgs e)
        {

            if (IsDateCorrect(textBox2.Text))
            {
                labelDueDateInfo.ForeColor = System.Drawing.Color.Black;
                textBox1.ReadOnly = true;
                tabControl1.Enabled = false;
                buttonAddClient.Enabled = false;
                buttonRemoveClient.Enabled = false;
                if (controller != null)
                {
                     if (IsDateCorrect(textBox1.Text))
                     {
                         controller.showReservationItmes(Convert.ToInt32(textBoxID.Text), textBox1.Text); // Przywrocenie danych o rezerwacji
                     }
                }
            }
            else
            {
                labelDueDateInfo.ForeColor = System.Drawing.Color.Red;
                textBox1.ReadOnly = true;
                tabControl1.Enabled = false;
                buttonAddClient.Enabled = false;
                buttonRemoveClient.Enabled = false;
            }

            if (textBox2.Text.Length == 0)
            { 
                textBox1.ReadOnly = false;
                tabControl1.Enabled = true;
                buttonAddClient.Enabled = true;
                buttonRemoveClient.Enabled = true;
                labelDueDateInfo.ForeColor = System.Drawing.Color.Black;
            }
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

        private void swapRow(DataGridView dataGridViewTo, DataGridView dataGridViewFrom)
        {
            DataTable dt1 = (DataTable)dataGridViewTo.DataSource;
            DataRow dr = (dataGridViewFrom.CurrentRow.DataBoundItem as DataRowView).Row;
            dt1.ImportRow(dr);
            dataGridViewFrom.Rows.Remove(dataGridViewFrom.CurrentRow);
        }

        private void ActionMoveClientUp(object sender, EventArgs e)
        {
            if (dataGridViewClients.RowCount > 1)
            {
                if (dataGridViewAddedClient.RowCount < 2)
                {
                    swapRow(dataGridViewAddedClient, dataGridViewClients);
                }
                else
                {
                    swapRow(dataGridViewAddedClient, dataGridViewClients);
                    swapRow(dataGridViewClients, dataGridViewAddedClient);
                }
            }
        }

        private void ActionMoveClientDown(object sender, EventArgs e)
        {
            if (dataGridViewAddedClient.RowCount > 1)
            {
                swapRow(dataGridViewClients, dataGridViewAddedClient);
            }
        }

        private void ActionMoveShipDown(object sender, EventArgs e)
        {
            if (dataGridViewAddedShip.RowCount > 1)
            {
                swapRow(dataGridViewShips, dataGridViewAddedShip);
            }
        }

        private void ActionMoveShipUp(object sender, EventArgs e)
        {
            if (dataGridViewShips.RowCount > 1)
            {
                if (dataGridViewAddedShip.RowCount < 2)
                {
                    swapRow(dataGridViewAddedShip, dataGridViewShips);
                }
                else
                {
                    swapRow(dataGridViewAddedShip, dataGridViewShips);
                    swapRow(dataGridViewShips, dataGridViewAddedShip);
                }
            }
        }

        private void ActionMoveEmployeeDown(object sender, EventArgs e)
        {
            if (dataGridViewAddedEmployees.RowCount > 1)
            {
                swapRow(dataGridViewEmployees, dataGridViewAddedEmployees);
            }
        }

        private void ActionMoveEmployeeUp(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.RowCount > 1)
            {
                swapRow(dataGridViewAddedEmployees, dataGridViewEmployees);
            }
        }


        public Boolean EnabledTextBox2
        {
            set { textBox2.Enabled = value; }
        }
    }
}
