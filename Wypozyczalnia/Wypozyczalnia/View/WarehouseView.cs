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
    public partial class WarehouseView : BaseView
    {
        #region Elementy widoku
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox filterStatus;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox filterName;
        private ToolStripButton toolStripButton1;
        #endregion

        private List<string> statuses = null;
        private string everyStatus = "Każda";
    
        public WarehouseView()
        {
            InitializeComponent();
            filterStatus.Items.Add(everyStatus);
            filterStatus.SelectedItem = everyStatus;
        }

        public string FilterName
        {
            get { return filterName.Text; }
        }

        public string FilterStatus
        {
            get { return filterStatus.SelectedItem.ToString(); }
        }

        public override void SetColumnsWidth()
        {
            try
            {
                double width = dataGridView1.Width - 20;
                dataGridView1.Columns[0].Width = (int)(0.2 * width); 
                dataGridView1.Columns[1].Width = (int)(0.2 * width);
                dataGridView1.Columns[2].Width = (int)(0.2 * width);
                dataGridView1.Columns[3].Width = (int)(0.1 * width);
                dataGridView1.Columns[4].Width = (int)(0.1 * width);
                dataGridView1.Columns[5].Width = (int)(0.2 * width);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
        }

        public void FillStatusList(List<string> statuses)
        {
            this.statuses = statuses;
            filterStatus.Items.Clear();
            filterStatus.Items.Add(everyStatus);
            filterStatus.SelectedItem = everyStatus;
            foreach (string status in statuses)
            {
                filterStatus.Items.Add(status);
            }
        }

        public Część GetActiveElement()
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                if (dataGridView1[2, index].Value.ToString() == "Zamontowana")
                    return new Część()
                    {
                        Część_ID = Convert.ToInt32(dataGridView1[0, index].Value),
                        Nazwa = dataGridView1[1, index].Value.ToString(),
                        Zamówienie_Zamówienie_ID = Convert.ToInt32(dataGridView1[3, index].Value),                  
                        Cena = Convert.ToSingle(dataGridView1[4, index].Value.ToString()),
                        Statek_Statek_ID = Convert.ToInt32(dataGridView1[5, index].Value),
                        Status_części = new Status_części() {
                           // Status_części_ID = Convert.ToInt32(dataGridView1[2, index].Value),
                           // Status = statuses[Convert.ToInt32(dataGridView1[2, index].Value)-1]
                            Status = dataGridView1[2, index].Value.ToString()
                        }
                    };
                else if (dataGridView1[2, index].Value.ToString() == "Zamówiona")
                    return new Część()
                    {
                        Część_ID = Convert.ToInt32(dataGridView1[0, index].Value),
                        Nazwa = dataGridView1[1, index].Value.ToString(),
                        Zamówienie_Zamówienie_ID = Convert.ToInt32(dataGridView1[3, index].Value),
                        Cena = Convert.ToSingle(dataGridView1[4, index].Value.ToString()),
                        Status_części = new Status_części()
                        {
                            // Status_części_ID = Convert.ToInt32(dataGridView1[2, index].Value),
                            // Status = statuses[Convert.ToInt32(dataGridView1[2, index].Value)-1]
                            Status = dataGridView1[2, index].Value.ToString()
                        }
                    };
                else if (dataGridView1[2, index].Value.ToString() == "W magazynie")
                    return new Część()
                    {
                        Część_ID = Convert.ToInt32(dataGridView1[0, index].Value),
                        Nazwa = dataGridView1[1, index].Value.ToString(),
                        Zamówienie_Zamówienie_ID = Convert.ToInt32(dataGridView1[3, index].Value),
                        Cena = Convert.ToSingle(dataGridView1[4, index].Value.ToString()),
                        Status_części = new Status_części()
                        {
                            // Status_części_ID = Convert.ToInt32(dataGridView1[2, index].Value),
                            // Status = statuses[Convert.ToInt32(dataGridView1[2, index].Value)-1]
                            Status = dataGridView1[2, index].Value.ToString()
                        }
                    };
                else 
                    return new Część()
                    {
                        Część_ID = Convert.ToInt32(dataGridView1[0, index].Value),
                        Nazwa = dataGridView1[1, index].Value.ToString(),
                        Status_części = new Status_części()
                        {
                            // Status_części_ID = Convert.ToInt32(dataGridView1[2, index].Value),
                            // Status = statuses[Convert.ToInt32(dataGridView1[2, index].Value)-1]
                            Status = dataGridView1[2, index].Value.ToString()
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
            string ID_Nazwa = new string(' ', 4);
            string Nazwa_Status = new string(' ', 13);
            string Status_Zamowienie = new string(' ', 2);
            string Zamowienie_Cena = new string(' ', 2);
            string Cena_Statek = new string(' ', 2);
            string tmpID, tmpNazwa, tmpStatus, tmpZamowienie, tmpCena, tmpStatek;
            text += "                             MAGAZYN CZĘŚCI\n\n";
            text += "ID"+ID_Nazwa+"|Nazwa"+Nazwa_Status+"|Status części"+Status_Zamowienie
                +"|ID zam."+Zamowienie_Cena+"|Cena"+Cena_Statek+"|ID statku\n";
            text += new string('-', 2 + ID_Nazwa.Length) + "|";
            text += new string('-', 5 + Nazwa_Status.Length) + "|";
            text += new string('-', 13 + Status_Zamowienie.Length) + "|";
            text += new string('-', 7 + Zamowienie_Cena.Length) + "|";
            text += new string('-', 4 + Cena_Statek.Length) + "|";
            text += new string('-', 10) + "\n";

            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                tmpID = dataGridView1[0, i].Value.ToString();
                tmpNazwa = dataGridView1[1, i].Value.ToString();
                tmpStatus = dataGridView1[2, i].Value.ToString();
                tmpZamowienie = dataGridView1[3, i].Value.ToString();
                tmpCena = dataGridView1[4, i].Value.ToString();
                tmpStatek = dataGridView1[5, i].Value.ToString();

                tmpID += new string(' ', 2 + ID_Nazwa.Length - tmpID.Length) + '|';
                tmpNazwa += new string(' ', 5 + Nazwa_Status.Length - tmpNazwa.Length) + '|';
                tmpStatus += new string(' ', 13 + Status_Zamowienie.Length - tmpStatus.Length) + '|';
                tmpZamowienie += new string(' ', 7 + Zamowienie_Cena.Length - tmpZamowienie.Length) + '|';
                tmpCena += new string(' ', 4 + Cena_Statek.Length - tmpCena.Length) + '|';

                text += tmpID + tmpNazwa + tmpStatus + tmpZamowienie + tmpCena + tmpStatek;
                text += "\n";
            }
            return text;
        }

        private void ActionAdd(object sender, EventArgs e)
        {
            controller.ShowWarehouseAddForm();
        }

        private void ActionEdit(object sender, EventArgs e)
        {
            controller.ShowWarehouseEditForm();
        }

        private void ActionDelete(object sender, EventArgs e)
        {
            controller.ShowWarehouseDeleteForm();
        }

        private void ActionSearchByName(object sender, EventArgs e)
        {
            controller.SelectPartsByName();
        }

        private void ActionSearchByStatus(object sender, EventArgs e)
        {
            try
            {
                controller.SelectPartsByStatus();
            }
            catch (NullReferenceException ex)
            {

            }
        }

        private void ActionResized(object sender, EventArgs e)
        {
            this.SetColumns();
        }

        #region InitializeComponent()
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.filterStatus = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.filterName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Click += new System.EventHandler(this.ActionAdd);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Click += new System.EventHandler(this.ActionEdit);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Click += new System.EventHandler(this.ActionDelete);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.filterStatus,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.filterName,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Status";
            // 
            // filterStatus
            // 
            this.filterStatus.Name = "filterStatus";
            this.filterStatus.Size = new System.Drawing.Size(121, 25);
            this.filterStatus.Text = "Status";
            this.filterStatus.TextChanged += new System.EventHandler(this.ActionSearchByStatus);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel2.Text = "Nazwa";
            // 
            // filterName
            // 
            this.filterName.Name = "filterName";
            this.filterName.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Szukaj";
            this.toolStripButton1.Click += new System.EventHandler(this.ActionSearchByName);
            // 
            // WarehouseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WarehouseView";
            this.SizeChanged += new System.EventHandler(this.ActionResized);
            this.Click += new System.EventHandler(this.ActionSearchByName);
            this.Controls.SetChildIndex(this.buttonAdd, 0);
            this.Controls.SetChildIndex(this.buttonEdit, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
