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
    public partial class EmployeesView : BaseView
    {
        private List<string> functions = null;
        private string everyFunction = "Każda";

        public EmployeesView()
        {
            InitializeComponent();
            filterFunction.Items.Add(everyFunction);
            filterFunction.SelectedItem = everyFunction;
        }

        public string FilterSurname
        {
            get { return filterSurname.Text; }
        }

        public string FilterFunction
        {
            get { return filterFunction.SelectedItem.ToString(); }
        }

        // Ustawienie szerokosci kolumn oraz naglowkow
        public override void SetColumnsWidth()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width = (int)(0.07 * width);
                dataGridView1.Columns[1].Width = (int)(0.2 * width);
                dataGridView1.Columns[2].Width = (int)(0.2 * width);
                dataGridView1.Columns[3].Width = (int)(0.13 * width);
                dataGridView1.Columns[4].Width = (int)(0.2 * width);
                dataGridView1.Columns[5].Width = (int)(0.1 * width);
                dataGridView1.Columns[6].Width = (int)(0.1 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
        }

        public void FillFunctionsList(List<string> functions)
        {
            this.functions = functions;
            filterFunction.Items.Clear();
            filterFunction.Items.Add(everyFunction);
            filterFunction.SelectedItem = everyFunction;
            foreach (string function in functions)
            {
                filterFunction.Items.Add(function);
            }
        }

        /// <summary>
        /// Pobranie z tabeli danych i utworzenie obiektu Pracownik
        /// </summary>
        /// <returns></returns>
        public Pracownik GetActiveElement()
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;

                return new Pracownik()
                {
                    Pracownik_ID = Convert.ToInt32(dataGridView1[0, index].Value),
                    Imię = dataGridView1[1, index].Value.ToString(),
                    Nazwisko = dataGridView1[2, index].Value.ToString(),
                    Data_urodzenia = Convert.ToDateTime(dataGridView1[3, index].Value),
                    Miejsce_urodzenia = dataGridView1[4, index].Value.ToString(),
                    Pensja = Convert.ToSingle(dataGridView1[5, index].Value),
                    Funkcja = new Funkcja() {
                        Nazwa_funkcji = dataGridView1[6, index].Value.ToString()
                    }
                };
            }
            catch (FormatException ex)
            {
                return null;
            }      
        }

        public string DataToPrint()
        {
            string text = string.Empty;
            string ID_Imie = new string(' ', 3);
            string Imie_Nazwisko = new string(' ', 5);
            string Nazwisko_Data = new string(' ', 5);
            string Data_Miejsce = new string(' ', 3);
            string Miejsce_Pensja = new string(' ', 3);
            string Pensja_Funkcja = new string(' ', 1);


            string tmpID, tmpImie, tmpNazwisko, tmpData, tmpMiejsce, tmpPensja, tmpFunkcja;
            text += "                             Pracownicy\n\n";
            text += "ID" + ID_Imie + "|Imię" + Imie_Nazwisko + "|Nazwisko" + Nazwisko_Data + 
                "|Data ur." + Data_Miejsce + "|Miejsce ur." + Miejsce_Pensja + "|Pensja" + 
                Pensja_Funkcja + "|Funkcja\n";
            text += new string('-', 2 + ID_Imie.Length) + "|";
            text += new string('-', 4 + Imie_Nazwisko.Length) + "|";
            text += new string('-', 8 + Nazwisko_Data.Length) + "|";
            text += new string('-', 8 + Data_Miejsce.Length) + "|";
            text += new string('-', 11 + Miejsce_Pensja.Length) + "|";
            text += new string('-', 6 + Pensja_Funkcja.Length) + "|";
            text += new string('-', 7) + "\n";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                tmpID = dataGridView1[0, i].Value.ToString();
                tmpImie = dataGridView1[1, i].Value.ToString();
                tmpNazwisko = dataGridView1[2, i].Value.ToString();
                tmpData = dataGridView1[3, i].Value.ToString().Remove(10);
                tmpMiejsce = dataGridView1[4, i].Value.ToString();
                tmpPensja = dataGridView1[5, i].Value.ToString();
                tmpFunkcja = dataGridView1[6, i].Value.ToString();

                tmpID += new string(' ', 2 + ID_Imie.Length - tmpID.Length) + '|';
                tmpImie += new string(' ', 4 + Imie_Nazwisko.Length - tmpImie.Length) + '|';
                tmpNazwisko += new string(' ', 8 + Nazwisko_Data.Length - tmpNazwisko.Length) + '|';
                tmpData += new string(' ', 8 + Data_Miejsce.Length - tmpData.Length) + '|';
                tmpMiejsce += new string(' ', 11 + Miejsce_Pensja.Length - tmpMiejsce.Length) + '|';
                tmpPensja += new string(' ', 6 + Pensja_Funkcja.Length - tmpPensja.Length) + '|';

                text += tmpID + tmpImie + tmpNazwisko + tmpData + tmpMiejsce + tmpPensja + tmpFunkcja;
                text += "\n";
            }
            return text;
        }

        private void ActionAdd(object sender, EventArgs e)
        {
            controller.ShowEmployeeAddForm();
        }

        private void ActionEdit(object sender, EventArgs e)
        {
            controller.ShowEmployeeEditForm();
        }

        private void ActionDelete(object sender, EventArgs e)
        {
            controller.ShowEmployeeDeleteForm();
        }

        private void ActionResized(object sender, EventArgs e)
        {
            this.SetColumns();
        }

        private void ActionSearchBySurname(object sender, EventArgs e)
        {
            controller.SelectEmployeeBySurname();
        }

        private void ActionSearchByFunction(object sender, EventArgs e)
        {
            try
            {
                controller.SelectEmployeeByFunction();
            }
            catch (NullReferenceException ex)
            {

            }
        }
    }
}
