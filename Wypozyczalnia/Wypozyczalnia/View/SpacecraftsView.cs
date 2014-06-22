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
