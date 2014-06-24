using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.FormController;
using Wypozyczalnia.Database;

namespace Wypozyczalnia.View
{

    public partial class SpacecraftsForm : BaseForm
    {
        private QueriesSpacecrafts qe;
        private List<string> types = null;
        private SpacecraftsView sv;

        public SpacecraftsForm()
        {
            InitializeComponent();
        }

        public SpacecraftsForm(List<string> types)
        {

            InitializeComponent();
            FillTypesList(types);
            comboBox1.SelectedItem = types[0];
            comboBox2.SelectedItem = types[0];
        }

        public SpacecraftsForm(Statek spacecraft, List<string> types)
        {
            InitializeComponent();

            textBox1.Text = "" + spacecraft.Statek_ID;
            FillTypesList(types);
            comboBox1.SelectedItem = spacecraft.Typ_statku.Nazwa_typu;
            textBox2.Text = spacecraft.Silnik;
            textBox3.Text = spacecraft.Rok_produkcji.ToString();
            textBox4.Text = spacecraft.Cena_za_dobę.ToString();
            comboBox2.SelectedItem = types[0];
        }

        public override void DisableAllFields()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }

        //public string TextBox2
        //{
        //    get { return textBox2.Text; }
        //    set { textBox2.Text = value; }
        //}

        public string TextBox3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public string TextBox4
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public string TextBox5
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }

        public string ComboBox1
        {
            get { return comboBox1.SelectedItem.ToString(); }
            set { comboBox1.SelectedItem = value; }
        }

        public string ComboBox2
        {
            get { return comboBox2.SelectedItem.ToString(); }
            set { comboBox2.SelectedItem = value; }
        }

        public QueriesSpacecrafts Queries
        {
            set { this.qe = value; }
        }

        private void FillTypesList(List<string> types)
        {
            foreach (string type in types)
            {
                comboBox1.Items.Add(type);
                comboBox2.Items.Add(type);
            }
        }
        private void ActionInsertType(object sender, EventArgs e)
        {
            this.AddType();
        }

        private void ActionDeleteType(object sender, EventArgs e)
        {
            this.DeleteType();
        }

        public void AddType()
        {

            this.DialogResult = DialogResult.None;
            try
            {
                if (this.TextBox5 != "")
                {
                    // LINQ
                    Typ_statku type = new Typ_statku
                    {
                        Nazwa_typu = this.TextBox5
                    };

                    this.qe.InsertType(type);
                    // zamkniecie formularza
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Pole nie może być puste.", "Błąd");
                }
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

        public void DeleteType()
        {
            this.DialogResult = DialogResult.None;
            try
            {
                // LINQ
                Typ_statku type = new Typ_statku
                {
                    Typ_statku_ID = this.qe.GetType(this.ComboBox2).Typ_statku_ID
                };
                this.qe.DeleteType(type);
                // zakmniecie formularza
                this.DialogResult = DialogResult.OK;
                this.Dispose();
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
    }
}
