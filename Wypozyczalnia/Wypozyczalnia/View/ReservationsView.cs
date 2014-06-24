using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wypozyczalnia.View
{
    public partial class ReservationsView : Wypozyczalnia.View.BaseView
    {
        public ReservationsView()
        {
            InitializeComponent();
        }

        public int GetActiveElementId()
        {
            int index = dataGridView1.CurrentRow.Index;
            int CurrentId = Convert.ToInt32(dataGridView1[0, index].Value);

            return CurrentId;
        }

        /// <summary>
        /// Pobranie z tabeli danych i utworzenie niepelnego obiektu Rezerwacja
        /// </summary>
        /// <returns></returns>
        public Rezerwacja GetActiveElement()
        {
            try
            {
                DateTime? Date;
                int index = dataGridView1.CurrentRow.Index;
                if (!String.IsNullOrEmpty(dataGridView1[6, index].Value.ToString()))
                {
                    Date = Convert.ToDateTime(dataGridView1[6, index].Value);
                }
                else
                {
                    Date = null;
                }
                return new Rezerwacja()
                {
                    Rezerwacja_ID = Convert.ToInt32(dataGridView1[0, index].Value),
                    Data_wypożyczenia = Convert.ToDateTime(dataGridView1[5, index].Value),
                    Data_zwrotu = Date
                };
            }
            catch (FormatException ex)
            {
                return null;
            }
        }

        public override void SetColumnsWidth()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width = (int)(0.1 * width);
                dataGridView1.Columns[1].Width = (int)(0.15 * width);
                dataGridView1.Columns[2].Width = (int)(0.15 * width);
                dataGridView1.Columns[3].Width = (int)(0.15 * width);
                dataGridView1.Columns[4].Width = (int)(0.15 * width);
                dataGridView1.Columns[5].Width = (int)(0.15 * width);
                dataGridView1.Columns[6].Width = (int)(0.15 * width);
                dataGridView1.Columns[7].Width = (int)(0.15 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
        }

        public string FilterSurname
        {
            get { return filterSurname.Text; }
        }

        public string DataToPrint()
        {
            string text = string.Empty;
            string ID_Imie = new string(' ', 3);
            string Imie_Nazwisko = new string(' ', 4);
            string Nazwisko_Statek = new string(' ', 4);
            string Statek_Cena = new string(' ', 10);
            string Cena_Data = new string(' ', 2);
            string Data_Data = new string(' ', 2);


            string tmpID, tmpImie, tmpNazwisko, tmpStatek, tmpCena, tmpWyp, tmpZwr;
            text += "                             REZERWACJE\n\n";
            text += "ID" + ID_Imie + "|Imię" + Imie_Nazwisko + "|Nazwisko" + Nazwisko_Statek +
                "|Statek" + Statek_Cena + "|Cena" + Cena_Data + "|Data wyp." +
                Data_Data + "|Data zwr.\n";
            text += new string('-', 2 + ID_Imie.Length) + "|";
            text += new string('-', 4 + Imie_Nazwisko.Length) + "|";
            text += new string('-', 8 + Nazwisko_Statek.Length) + "|";
            text += new string('-', 6 + Statek_Cena.Length) + "|";
            text += new string('-', 4 + Cena_Data.Length) + "|";
            text += new string('-', 9 + Data_Data.Length) + "|";
            text += new string('-', 9) + "\n";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                tmpID = dataGridView1[0, i].Value.ToString();
                tmpImie = dataGridView1[1, i].Value.ToString();
                tmpNazwisko = dataGridView1[2, i].Value.ToString();
                tmpStatek = dataGridView1[3, i].Value.ToString();
                tmpCena = dataGridView1[4, i].Value.ToString();
                tmpWyp = dataGridView1[5, i].Value.ToString().Remove(10);
                tmpZwr = dataGridView1[6, i].Value.ToString();
                if (tmpZwr.Length > 0)
                    tmpZwr = tmpZwr.Remove(10);

                tmpID += new string(' ', 2 + ID_Imie.Length - tmpID.Length) + '|';
                tmpImie += new string(' ', 4 + Imie_Nazwisko.Length - tmpImie.Length) + '|';
                tmpNazwisko += new string(' ', 8 + Nazwisko_Statek.Length - tmpNazwisko.Length) + '|';
                tmpStatek += new string(' ', 6 + Statek_Cena.Length - tmpStatek.Length) + '|';
                tmpCena += new string(' ', 4 + Cena_Data.Length - tmpCena.Length) + '|';
                tmpWyp += new string(' ', 9 + Data_Data.Length - tmpWyp.Length) + '|';

                text += tmpID + tmpImie + tmpNazwisko + tmpStatek + tmpCena + tmpWyp + tmpZwr;
                text += "\n";
            }
            return text;
        }

        private void ActionAdd(object sender, EventArgs e)
        {
            controller.ShowReservationAddForm();
        }

        private void ActionEdit(object sender, EventArgs e)
        {
            controller.ShowReservationEditForm();
        }

        private void ActionDelete(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                controller.DeleteReservation();
            }
        }

        private void ActionResized(object sender, EventArgs e)
        {
            SetColumns();
        }

        private void ActionSearchBySurname(object sender, EventArgs e)
        {
            controller.SearchReservationsBySurname();
        }

        private void ActionShowEmploees(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                controller.ShowReservationEmploeesForm();
            }
        }
    }
}
