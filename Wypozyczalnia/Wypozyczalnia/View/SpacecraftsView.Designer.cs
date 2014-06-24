namespace Wypozyczalnia.View
{
    partial class SpacecraftsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpacecraftsView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.filterType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.filterName = new System.Windows.Forms.ToolStripTextBox();
            this.Szukaj = new System.Windows.Forms.ToolStripButton();
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
            this.filterType,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.filterName,
            this.Szukaj});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel1.Text = "Typ statku";
            // 
            // filterType
            // 
            this.filterType.Name = "filterType";
            this.filterType.Size = new System.Drawing.Size(121, 25);
            this.filterType.Text = "Wszystkie";
            this.filterType.TextUpdate += new System.EventHandler(this.ActionSearchByType);
            this.filterType.TextChanged += new System.EventHandler(this.ActionSearchByType);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel2.Text = "Silnik";
            // 
            // filterName
            // 
            this.filterName.Name = "filterName";
            this.filterName.Size = new System.Drawing.Size(100, 25);
            // 
            // Szukaj
            // 
            this.Szukaj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Szukaj.Image = ((System.Drawing.Image)(resources.GetObject("Szukaj.Image")));
            this.Szukaj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Szukaj.Name = "Szukaj";
            this.Szukaj.Size = new System.Drawing.Size(23, 22);
            this.Szukaj.Text = "toolStripButton1";
            this.Szukaj.Click += new System.EventHandler(this.ActionSearchByEngine);
            // 
            // SpacecraftsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SpacecraftsView";
            this.SizeChanged += new System.EventHandler(this.ActionResized);
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

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox filterType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox filterName;
        private System.Windows.Forms.ToolStripButton Szukaj;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}