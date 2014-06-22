using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia.View
{
    public partial class ClientsView : BaseView
    {

        public ClientsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pobranie z tabeli danych i utworzenie obiektu Klient
        /// </summary>
        /// <returns></returns>
        public Klient GetActiveElement()
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;

                return new Klient()
                {
                    Klient_ID = Convert.ToInt32(dataGridView1[0, index].Value),
                    Imię = dataGridView1[1, index].Value.ToString(),
                    Nazwisko = dataGridView1[2, index].Value.ToString(),
                    Nr_dowodu = dataGridView1[3, index].Value.ToString()
                };
            }
            catch (FormatException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Ustawienie szerokosci kolumn oraz naglowkow
        /// </summary>
        public override void SetColumnsWidth()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width = (int)(0.1 * width);
                dataGridView1.Columns[1].Width = (int)(0.3 * width);
                dataGridView1.Columns[2].Width = (int)(0.3 * width);
                dataGridView1.Columns[3].Width = (int)(0.3 * width);
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
            string ID_Imie = new string(' ', 4);
            string Imie_Nazwisko = new string(' ', 18);
            string Nazwisko_Dowod = new string(' ', 18);

            string tmpID, tmpImie, tmpNazwisko, tmpDowod;
            text += "                             KLIENCI\n\n";
            text += "ID" + ID_Imie + "|Imię" + Imie_Nazwisko + "|Nazwisko" + Nazwisko_Dowod + "|Nr dowodu\n";
            text += new string('-', 2 + ID_Imie.Length) + "|";
            text += new string('-', 4 + Imie_Nazwisko.Length) + "|";
            text += new string('-', 8 + Nazwisko_Dowod.Length) + "|";
            text += new string('-', 10) + "\n";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                tmpID = dataGridView1[0, i].Value.ToString();
                tmpImie = dataGridView1[1, i].Value.ToString();
                tmpNazwisko = dataGridView1[2, i].Value.ToString();
                tmpDowod = dataGridView1[3, i].Value.ToString();

                tmpID += new string(' ', 2 + ID_Imie.Length - tmpID.Length) + '|';
                tmpImie += new string(' ', 4 + Imie_Nazwisko.Length - tmpImie.Length) + '|';
                tmpNazwisko += new string(' ', 8 + Nazwisko_Dowod.Length - tmpNazwisko.Length) + '|';

                text += tmpID + tmpImie + tmpNazwisko + tmpDowod;
                text += "\n";
            }
            return text;
        }

        // Wywolanie funkcji obslugujacych zdarzenia

        private void ActionAdd(object sender, EventArgs e)
        {
            controller.ShowClientAddForm();
        }

        private void ActionEdit(object sender, EventArgs e)
        {
            controller.ShowClientEditForm();
        }

        private void ActionDelete(object sender, EventArgs e)
        {
            controller.ShowClientDeleteForm();
        }

        private void ActionResized(object sender, EventArgs e)
        {
            SetColumns();
        }

        private void ActionReservations(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            controller.ShowReservationsView(Convert.ToInt32(dataGridView1[0, index].Value));
        }

        private void ActionSearchBySurname(object sender, EventArgs e)
        {
            controller.SearchClientBySurname();
        }

    }
}
