namespace Wypozyczalnia.View
{
    partial class OrderForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addPartToOrder = new System.Windows.Forms.Button();
            this.partsNotAdded = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxPrice = new System.Windows.Forms.TextBox();
            this.setPrice = new System.Windows.Forms.Button();
            this.partsAdded = new System.Windows.Forms.DataGridView();
            this.removePartFromOrder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsNotAdded)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsAdded)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.Text = "Data zamówienia";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(192, 627);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(16, 627);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Data odbioru";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(120, 108);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(202, 20);
            this.textBox3.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addPartToOrder);
            this.groupBox1.Controls.Add(this.partsNotAdded);
            this.groupBox1.Location = new System.Drawing.Point(16, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 220);
            this.groupBox1.TabIndex = 109;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Części możliwe do wyboru";
            // 
            // addPartToOrder
            // 
            this.addPartToOrder.Location = new System.Drawing.Point(16, 175);
            this.addPartToOrder.Name = "addPartToOrder";
            this.addPartToOrder.Size = new System.Drawing.Size(140, 23);
            this.addPartToOrder.TabIndex = 1;
            this.addPartToOrder.Text = "Dodaj do zamówienia";
            this.addPartToOrder.UseVisualStyleBackColor = true;
            this.addPartToOrder.Click += new System.EventHandler(this.AddPartToOrder);
            // 
            // partsNotAdded
            // 
            this.partsNotAdded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsNotAdded.Location = new System.Drawing.Point(16, 19);
            this.partsNotAdded.MultiSelect = false;
            this.partsNotAdded.Name = "partsNotAdded";
            this.partsNotAdded.ReadOnly = true;
            this.partsNotAdded.RowHeadersVisible = false;
            this.partsNotAdded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsNotAdded.Size = new System.Drawing.Size(580, 150);
            this.partsNotAdded.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TextBoxPrice);
            this.groupBox2.Controls.Add(this.setPrice);
            this.groupBox2.Controls.Add(this.partsAdded);
            this.groupBox2.Controls.Add(this.removePartFromOrder);
            this.groupBox2.Location = new System.Drawing.Point(16, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 220);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wybrane części";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cena:";
            // 
            // TextBoxPrice
            // 
            this.TextBoxPrice.Location = new System.Drawing.Point(348, 176);
            this.TextBoxPrice.Name = "TextBoxPrice";
            this.TextBoxPrice.Size = new System.Drawing.Size(101, 20);
            this.TextBoxPrice.TabIndex = 3;
            // 
            // setPrice
            // 
            this.setPrice.Location = new System.Drawing.Point(455, 176);
            this.setPrice.Name = "setPrice";
            this.setPrice.Size = new System.Drawing.Size(140, 23);
            this.setPrice.TabIndex = 2;
            this.setPrice.Text = "Nadaj cenę";
            this.setPrice.UseVisualStyleBackColor = true;
            this.setPrice.Click += new System.EventHandler(this.SetPartPrice);
            // 
            // partsAdded
            // 
            this.partsAdded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsAdded.Location = new System.Drawing.Point(15, 20);
            this.partsAdded.MultiSelect = false;
            this.partsAdded.Name = "partsAdded";
            this.partsAdded.ReadOnly = true;
            this.partsAdded.RowHeadersVisible = false;
            this.partsAdded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsAdded.Size = new System.Drawing.Size(580, 150);
            this.partsAdded.TabIndex = 1;
            // 
            // removePartFromOrder
            // 
            this.removePartFromOrder.Location = new System.Drawing.Point(15, 176);
            this.removePartFromOrder.Name = "removePartFromOrder";
            this.removePartFromOrder.Size = new System.Drawing.Size(140, 23);
            this.removePartFromOrder.TabIndex = 0;
            this.removePartFromOrder.Text = "Usuń z zamówienia";
            this.removePartFromOrder.UseVisualStyleBackColor = true;
            this.removePartFromOrder.Click += new System.EventHandler(this.RemovePartFromOrder);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 662);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Name = "OrderForm";
            this.Text = "Zamówienie";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.buttonConfirm, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.title, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.partsNotAdded)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsAdded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addPartToOrder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button removePartFromOrder;
        private System.Windows.Forms.DataGridView partsNotAdded;
        private System.Windows.Forms.DataGridView partsAdded;
        private System.Windows.Forms.Button setPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxPrice;
    }
}