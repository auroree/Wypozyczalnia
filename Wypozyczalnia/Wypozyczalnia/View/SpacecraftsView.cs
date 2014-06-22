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
    public partial class SpacecraftsView : BaseView
    {
        private List<string> types = null;
        private string allTypes = "Wszystkie";

        public SpacecraftsView()
        {
            InitializeComponent();
            filterType.SelectedItem = allTypes;
            filterType.Items.Add(allTypes);
        }

        public string FilterType
        {
            get { return filterType.SelectedItem.ToString(); }
        }

        public string FilterEngine
        {
            get { return filterName.Text; }
        }

        private void ActionSearchByEngine(object sender, EventArgs e)
        {
            try
            {
                controller.SelectSpacecraftsByEngine();
            }
            catch (NullReferenceException ex)
            {

            }
        }

        private void ActionSearchByType(object sender, EventArgs e)
        {
            try
            {
                controller.SelectSpacecraftsByType();
            }
            catch (NullReferenceException ex)
            {

            }
        }

        public void FillTypeList(List<string> types)
        {
            this.types = types;
            filterType.Items.Clear();
            filterType.Items.Add(allTypes);
            filterType.SelectedItem = allTypes;
            foreach (string type in types)
            {
                filterType.Items.Add(type);
            }
        }

        public override void SetColumnsWidth()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width = (int)(0.1 * width);
                dataGridView1.Columns[1].Width = (int)(0.3 * width);
                dataGridView1.Columns[2].Width = (int)(0.2 * width);
                dataGridView1.Columns[3].Width = (int)(0.2 * width);
                dataGridView1.Columns[4].Width = (int)(0.2 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
        }

        public Statek GetActiveElement()
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;

                return new Statek()
                {
                    Statek_ID = Convert.ToInt32(dataGridView1[0, index].Value),
                    Typ_statku = new Typ_statku()
                    {
                        Nazwa_typu = dataGridView1[1, index].Value.ToString(),
                    },
                    Silnik = dataGridView1[2, index].Value.ToString(),
                    Rok_produkcji = Convert.ToInt32(dataGridView1[3, index].Value),
                    Cena_za_dobę = Convert.ToInt32(dataGridView1[4, index].Value.ToString())
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
            string ID_Typ = new string(' ', 4);
            string Typ_Silnik = new string(' ', 15);
            string Silnik_Rok = new string(' ', 12);
            string Rok_Cena = new string(' ', 12);
            string tmpID, tmpTyp, tmpSilnik, tmpRok, tmpCena;
            text += "                                 STATKI\n\n";
            text += "ID" + ID_Typ + "|Typ" + Typ_Silnik + "|Silnik" + Silnik_Rok
                + "|Rok prod." + Rok_Cena + "|Cena\n";
            text += new string('-', 2 + ID_Typ.Length) + "|";
            text += new string('-', 3 + Typ_Silnik.Length) + "|";
            text += new string('-', 6 + Silnik_Rok.Length) + "|";
            text += new string('-', 9 + Rok_Cena.Length) + "|";
            text += new string('-', 8) + "\n";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                tmpID = dataGridView1[0, i].Value.ToString();
                tmpTyp = dataGridView1[1, i].Value.ToString();
                tmpSilnik = dataGridView1[2, i].Value.ToString();
                tmpRok = dataGridView1[3, i].Value.ToString();
                tmpCena = dataGridView1[4, i].Value.ToString();

                tmpID += new string(' ', 2 + ID_Typ.Length - tmpID.Length) + '|';
                tmpTyp += new string(' ', 3 + Typ_Silnik.Length - tmpTyp.Length) + '|';
                tmpSilnik += new string(' ', 6 + Silnik_Rok.Length - tmpSilnik.Length) + '|';
                tmpRok += new string(' ', 9 + Rok_Cena.Length - tmpRok.Length) + '|';

                text += tmpID + tmpTyp + tmpSilnik + tmpRok + tmpCena;
                text += "\n";
            }
            return text;
        }

        private void ActionResized(object sender, EventArgs e)
        {
            this.SetColumns();
        }

        private void ActionAdd(object sender, EventArgs e)
        {
            controller.ShowSpacecraftsAddForm();
        }

        private void ActionEdit(object sender, EventArgs e)
        {
            controller.ShowSpacecraftsEditForm();
        }

        private void ActionDelete(object sender, EventArgs e)
        {
            controller.ShowSpacecraftsDeleteForm();
        }
    }
}
