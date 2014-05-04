namespace Wypozyczalnia.View
{
    partial class ReservationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationForm));
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            this.buttonddClient = new System.Windows.Forms.Button();
            this.buttonRemoveClient = new System.Windows.Forms.Button();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.dataGridViewAddedClient = new System.Windows.Forms.DataGridView();
            this.groupBoxShip = new System.Windows.Forms.GroupBox();
            this.buttonAddShip = new System.Windows.Forms.Button();
            this.buttonRomoveShip = new System.Windows.Forms.Button();
            this.dataGridViewShips = new System.Windows.Forms.DataGridView();
            this.dataGridViewAddedShip = new System.Windows.Forms.DataGridView();
            this.groupBoxEmployees = new System.Windows.Forms.GroupBox();
            this.buttonAddEmployee = new System.Windows.Forms.Button();
            this.buttonRemoveEmployee = new System.Windows.Forms.Button();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.dataGridViewAddedEmployees = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedClient)).BeginInit();
            this.groupBoxShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedShip)).BeginInit();
            this.groupBoxEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.Controls.Add(this.buttonddClient);
            this.groupBoxClient.Controls.Add(this.buttonRemoveClient);
            this.groupBoxClient.Controls.Add(this.dataGridViewClients);
            this.groupBoxClient.Controls.Add(this.dataGridViewAddedClient);
            this.groupBoxClient.Location = new System.Drawing.Point(13, 13);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Size = new System.Drawing.Size(630, 214);
            this.groupBoxClient.TabIndex = 0;
            this.groupBoxClient.TabStop = false;
            this.groupBoxClient.Text = "Wybór klienta:";
            // 
            // buttonddClient
            // 
            this.buttonddClient.Image = ((System.Drawing.Image)(resources.GetObject("buttonddClient.Image")));
            this.buttonddClient.Location = new System.Drawing.Point(299, 78);
            this.buttonddClient.Name = "buttonddClient";
            this.buttonddClient.Size = new System.Drawing.Size(35, 25);
            this.buttonddClient.TabIndex = 6;
            this.buttonddClient.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveClient
            // 
            this.buttonRemoveClient.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveClient.Image")));
            this.buttonRemoveClient.Location = new System.Drawing.Point(258, 78);
            this.buttonRemoveClient.Name = "buttonRemoveClient";
            this.buttonRemoveClient.Size = new System.Drawing.Size(35, 25);
            this.buttonRemoveClient.TabIndex = 5;
            this.buttonRemoveClient.UseVisualStyleBackColor = true;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(6, 109);
            this.dataGridViewClients.MultiSelect = false;
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.ReadOnly = true;
            this.dataGridViewClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClients.Size = new System.Drawing.Size(618, 99);
            this.dataGridViewClients.TabIndex = 4;
            // 
            // dataGridViewAddedClient
            // 
            this.dataGridViewAddedClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAddedClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddedClient.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewAddedClient.MultiSelect = false;
            this.dataGridViewAddedClient.Name = "dataGridViewAddedClient";
            this.dataGridViewAddedClient.ReadOnly = true;
            this.dataGridViewAddedClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddedClient.Size = new System.Drawing.Size(618, 55);
            this.dataGridViewAddedClient.TabIndex = 3;
            // 
            // groupBoxShip
            // 
            this.groupBoxShip.Controls.Add(this.buttonAddShip);
            this.groupBoxShip.Controls.Add(this.buttonRomoveShip);
            this.groupBoxShip.Controls.Add(this.dataGridViewShips);
            this.groupBoxShip.Controls.Add(this.dataGridViewAddedShip);
            this.groupBoxShip.Location = new System.Drawing.Point(13, 290);
            this.groupBoxShip.Name = "groupBoxShip";
            this.groupBoxShip.Size = new System.Drawing.Size(630, 214);
            this.groupBoxShip.TabIndex = 7;
            this.groupBoxShip.TabStop = false;
            this.groupBoxShip.Text = "Wybór Statku:";
            // 
            // buttonAddShip
            // 
            this.buttonAddShip.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddShip.Image")));
            this.buttonAddShip.Location = new System.Drawing.Point(299, 80);
            this.buttonAddShip.Name = "buttonAddShip";
            this.buttonAddShip.Size = new System.Drawing.Size(35, 25);
            this.buttonAddShip.TabIndex = 8;
            this.buttonAddShip.UseVisualStyleBackColor = true;
            // 
            // buttonRomoveShip
            // 
            this.buttonRomoveShip.Image = ((System.Drawing.Image)(resources.GetObject("buttonRomoveShip.Image")));
            this.buttonRomoveShip.Location = new System.Drawing.Point(258, 80);
            this.buttonRomoveShip.Name = "buttonRomoveShip";
            this.buttonRomoveShip.Size = new System.Drawing.Size(35, 25);
            this.buttonRomoveShip.TabIndex = 7;
            this.buttonRomoveShip.UseVisualStyleBackColor = true;
            // 
            // dataGridViewShips
            // 
            this.dataGridViewShips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewShips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShips.Location = new System.Drawing.Point(6, 109);
            this.dataGridViewShips.MultiSelect = false;
            this.dataGridViewShips.Name = "dataGridViewShips";
            this.dataGridViewShips.ReadOnly = true;
            this.dataGridViewShips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShips.Size = new System.Drawing.Size(618, 99);
            this.dataGridViewShips.TabIndex = 4;
            // 
            // dataGridViewAddedShip
            // 
            this.dataGridViewAddedShip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAddedShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddedShip.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewAddedShip.MultiSelect = false;
            this.dataGridViewAddedShip.Name = "dataGridViewAddedShip";
            this.dataGridViewAddedShip.ReadOnly = true;
            this.dataGridViewAddedShip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddedShip.Size = new System.Drawing.Size(618, 55);
            this.dataGridViewAddedShip.TabIndex = 3;
            // 
            // groupBoxEmployees
            // 
            this.groupBoxEmployees.Controls.Add(this.buttonAddEmployee);
            this.groupBoxEmployees.Controls.Add(this.buttonRemoveEmployee);
            this.groupBoxEmployees.Controls.Add(this.dataGridViewEmployees);
            this.groupBoxEmployees.Controls.Add(this.dataGridViewAddedEmployees);
            this.groupBoxEmployees.Location = new System.Drawing.Point(13, 510);
            this.groupBoxEmployees.Name = "groupBoxEmployees";
            this.groupBoxEmployees.Size = new System.Drawing.Size(630, 214);
            this.groupBoxEmployees.TabIndex = 8;
            this.groupBoxEmployees.TabStop = false;
            this.groupBoxEmployees.Text = "Wybór Załogi:";
            // 
            // buttonAddEmployee
            // 
            this.buttonAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddEmployee.Image")));
            this.buttonAddEmployee.Location = new System.Drawing.Point(299, 78);
            this.buttonAddEmployee.Name = "buttonAddEmployee";
            this.buttonAddEmployee.Size = new System.Drawing.Size(35, 25);
            this.buttonAddEmployee.TabIndex = 8;
            this.buttonAddEmployee.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveEmployee
            // 
            this.buttonRemoveEmployee.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveEmployee.Image")));
            this.buttonRemoveEmployee.Location = new System.Drawing.Point(258, 78);
            this.buttonRemoveEmployee.Name = "buttonRemoveEmployee";
            this.buttonRemoveEmployee.Size = new System.Drawing.Size(35, 25);
            this.buttonRemoveEmployee.TabIndex = 7;
            this.buttonRemoveEmployee.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(6, 109);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(618, 99);
            this.dataGridViewEmployees.TabIndex = 4;
            // 
            // dataGridViewAddedEmployees
            // 
            this.dataGridViewAddedEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAddedEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddedEmployees.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewAddedEmployees.MultiSelect = false;
            this.dataGridViewAddedEmployees.Name = "dataGridViewAddedEmployees";
            this.dataGridViewAddedEmployees.ReadOnly = true;
            this.dataGridViewAddedEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddedEmployees.Size = new System.Drawing.Size(618, 55);
            this.dataGridViewAddedEmployees.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(149, 744);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(130, 23);
            this.buttonCancel.TabIndex = 101;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Location = new System.Drawing.Point(326, 744);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(130, 23);
            this.buttonConfirm.TabIndex = 102;
            this.buttonConfirm.Text = "Zawierdź";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 267);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(202, 20);
            this.textBox2.TabIndex = 106;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 20);
            this.textBox1.TabIndex = 105;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Data zwrotu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Data wypożyczenia";
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 785);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.groupBoxEmployees);
            this.Controls.Add(this.groupBoxShip);
            this.Controls.Add(this.groupBoxClient);
            this.Name = "ReservationForm";
            this.Text = "Formularz";
            this.groupBoxClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedClient)).EndInit();
            this.groupBoxShip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedShip)).EndInit();
            this.groupBoxEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.Button buttonddClient;
        private System.Windows.Forms.Button buttonRemoveClient;
        protected System.Windows.Forms.DataGridView dataGridViewClients;
        protected System.Windows.Forms.DataGridView dataGridViewAddedClient;
        private System.Windows.Forms.GroupBox groupBoxShip;
        protected System.Windows.Forms.DataGridView dataGridViewShips;
        protected System.Windows.Forms.DataGridView dataGridViewAddedShip;
        private System.Windows.Forms.GroupBox groupBoxEmployees;
        protected System.Windows.Forms.DataGridView dataGridViewEmployees;
        protected System.Windows.Forms.DataGridView dataGridViewAddedEmployees;
        private System.Windows.Forms.Button buttonAddShip;
        private System.Windows.Forms.Button buttonRomoveShip;
        private System.Windows.Forms.Button buttonAddEmployee;
        private System.Windows.Forms.Button buttonRemoveEmployee;
        protected System.Windows.Forms.Button buttonCancel;
        protected System.Windows.Forms.Button buttonConfirm;
        protected System.Windows.Forms.TextBox textBox2;
        protected System.Windows.Forms.TextBox textBox1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
    }
}