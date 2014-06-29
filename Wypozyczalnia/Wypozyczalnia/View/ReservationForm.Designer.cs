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
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelEmployees = new System.Windows.Forms.Label();
            this.buttonAddEmployee = new System.Windows.Forms.Button();
            this.buttonRemoveEmployee = new System.Windows.Forms.Button();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.dataGridViewAddedEmployees = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelClient = new System.Windows.Forms.Label();
            this.dataGridViewAddedClient = new System.Windows.Forms.DataGridView();
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.buttonRemoveClient = new System.Windows.Forms.Button();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelShip = new System.Windows.Forms.Label();
            this.buttonAddShip = new System.Windows.Forms.Button();
            this.buttonRomoveShip = new System.Windows.Forms.Button();
            this.dataGridViewShips = new System.Windows.Forms.DataGridView();
            this.dataGridViewAddedShip = new System.Windows.Forms.DataGridView();
            this.labelHireDateInfo = new System.Windows.Forms.Label();
            this.labelDueDateInfo = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedEmployees)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedShip)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.Text = "Data wypożyczenia:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 59);
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.Text = "Data zwrotu:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 30);
            this.textBox1.TextChanged += new System.EventHandler(this.ActionDateOfHireOnChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(119, 56);
            this.textBox2.TextChanged += new System.EventHandler(this.ActionDueDateOnChanged);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(409, 614);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(232, 614);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(12, 5);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(327, 5);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(18, 13);
            this.labelId.TabIndex = 111;
            this.labelId.Text = "ID";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(352, 5);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(136, 20);
            this.textBoxID.TabIndex = 112;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelEmployees);
            this.tabPage2.Controls.Add(this.buttonAddEmployee);
            this.tabPage2.Controls.Add(this.buttonRemoveEmployee);
            this.tabPage2.Controls.Add(this.dataGridViewEmployees);
            this.tabPage2.Controls.Add(this.dataGridViewAddedEmployees);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Załoga";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelEmployees
            // 
            this.labelEmployees.AutoSize = true;
            this.labelEmployees.Location = new System.Drawing.Point(6, 17);
            this.labelEmployees.Name = "labelEmployees";
            this.labelEmployees.Size = new System.Drawing.Size(108, 13);
            this.labelEmployees.TabIndex = 112;
            this.labelEmployees.Text = "Wybór Pracowników:";
            // 
            // buttonAddEmployee
            // 
            this.buttonAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddEmployee.Image")));
            this.buttonAddEmployee.Location = new System.Drawing.Point(356, 225);
            this.buttonAddEmployee.Name = "buttonAddEmployee";
            this.buttonAddEmployee.Size = new System.Drawing.Size(35, 25);
            this.buttonAddEmployee.TabIndex = 12;
            this.buttonAddEmployee.UseVisualStyleBackColor = true;
            this.buttonAddEmployee.Click += new System.EventHandler(this.ActionMoveEmployeeUp);
            // 
            // buttonRemoveEmployee
            // 
            this.buttonRemoveEmployee.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveEmployee.Image")));
            this.buttonRemoveEmployee.Location = new System.Drawing.Point(315, 225);
            this.buttonRemoveEmployee.Name = "buttonRemoveEmployee";
            this.buttonRemoveEmployee.Size = new System.Drawing.Size(35, 25);
            this.buttonRemoveEmployee.TabIndex = 11;
            this.buttonRemoveEmployee.UseVisualStyleBackColor = true;
            this.buttonRemoveEmployee.Click += new System.EventHandler(this.ActionMoveEmployeeDown);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(6, 256);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(714, 244);
            this.dataGridViewEmployees.TabIndex = 10;
            // 
            // dataGridViewAddedEmployees
            // 
            this.dataGridViewAddedEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddedEmployees.Location = new System.Drawing.Point(6, 33);
            this.dataGridViewAddedEmployees.MultiSelect = false;
            this.dataGridViewAddedEmployees.Name = "dataGridViewAddedEmployees";
            this.dataGridViewAddedEmployees.ReadOnly = true;
            this.dataGridViewAddedEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddedEmployees.Size = new System.Drawing.Size(714, 186);
            this.dataGridViewAddedEmployees.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelClient);
            this.tabPage1.Controls.Add(this.dataGridViewAddedClient);
            this.tabPage1.Controls.Add(this.buttonAddClient);
            this.tabPage1.Controls.Add(this.buttonRemoveClient);
            this.tabPage1.Controls.Add(this.dataGridViewClients);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(726, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Klienci";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(6, 12);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(76, 13);
            this.labelClient.TabIndex = 110;
            this.labelClient.Text = "Wybór Klienta:";
            // 
            // dataGridViewAddedClient
            // 
            this.dataGridViewAddedClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddedClient.Location = new System.Drawing.Point(6, 28);
            this.dataGridViewAddedClient.MultiSelect = false;
            this.dataGridViewAddedClient.Name = "dataGridViewAddedClient";
            this.dataGridViewAddedClient.ReadOnly = true;
            this.dataGridViewAddedClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddedClient.Size = new System.Drawing.Size(714, 78);
            this.dataGridViewAddedClient.TabIndex = 106;
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddClient.Image")));
            this.buttonAddClient.Location = new System.Drawing.Point(354, 112);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Size = new System.Drawing.Size(35, 25);
            this.buttonAddClient.TabIndex = 109;
            this.buttonAddClient.UseVisualStyleBackColor = true;
            this.buttonAddClient.Click += new System.EventHandler(this.ActionMoveClientUp);
            // 
            // buttonRemoveClient
            // 
            this.buttonRemoveClient.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveClient.Image")));
            this.buttonRemoveClient.Location = new System.Drawing.Point(314, 112);
            this.buttonRemoveClient.Name = "buttonRemoveClient";
            this.buttonRemoveClient.Size = new System.Drawing.Size(35, 25);
            this.buttonRemoveClient.TabIndex = 108;
            this.buttonRemoveClient.UseVisualStyleBackColor = true;
            this.buttonRemoveClient.Click += new System.EventHandler(this.ActionMoveClientDown);
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(6, 143);
            this.dataGridViewClients.MultiSelect = false;
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.ReadOnly = true;
            this.dataGridViewClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClients.Size = new System.Drawing.Size(714, 355);
            this.dataGridViewClients.TabIndex = 107;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 530);
            this.tabControl1.TabIndex = 105;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelShip);
            this.tabPage3.Controls.Add(this.buttonAddShip);
            this.tabPage3.Controls.Add(this.buttonRomoveShip);
            this.tabPage3.Controls.Add(this.dataGridViewShips);
            this.tabPage3.Controls.Add(this.dataGridViewAddedShip);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(726, 504);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statki";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelShip
            // 
            this.labelShip.AutoSize = true;
            this.labelShip.Location = new System.Drawing.Point(6, 12);
            this.labelShip.Name = "labelShip";
            this.labelShip.Size = new System.Drawing.Size(75, 13);
            this.labelShip.TabIndex = 116;
            this.labelShip.Text = "Wybór Statku:";
            // 
            // buttonAddShip
            // 
            this.buttonAddShip.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddShip.Image")));
            this.buttonAddShip.Location = new System.Drawing.Point(354, 112);
            this.buttonAddShip.Name = "buttonAddShip";
            this.buttonAddShip.Size = new System.Drawing.Size(35, 25);
            this.buttonAddShip.TabIndex = 115;
            this.buttonAddShip.UseVisualStyleBackColor = true;
            this.buttonAddShip.Click += new System.EventHandler(this.ActionMoveShipUp);
            // 
            // buttonRomoveShip
            // 
            this.buttonRomoveShip.Image = ((System.Drawing.Image)(resources.GetObject("buttonRomoveShip.Image")));
            this.buttonRomoveShip.Location = new System.Drawing.Point(314, 112);
            this.buttonRomoveShip.Name = "buttonRomoveShip";
            this.buttonRomoveShip.Size = new System.Drawing.Size(35, 25);
            this.buttonRomoveShip.TabIndex = 114;
            this.buttonRomoveShip.UseVisualStyleBackColor = true;
            this.buttonRomoveShip.Click += new System.EventHandler(this.ActionMoveShipDown);
            // 
            // dataGridViewShips
            // 
            this.dataGridViewShips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShips.Location = new System.Drawing.Point(6, 143);
            this.dataGridViewShips.MultiSelect = false;
            this.dataGridViewShips.Name = "dataGridViewShips";
            this.dataGridViewShips.ReadOnly = true;
            this.dataGridViewShips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShips.Size = new System.Drawing.Size(714, 355);
            this.dataGridViewShips.TabIndex = 113;
            // 
            // dataGridViewAddedShip
            // 
            this.dataGridViewAddedShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddedShip.Location = new System.Drawing.Point(6, 28);
            this.dataGridViewAddedShip.MultiSelect = false;
            this.dataGridViewAddedShip.Name = "dataGridViewAddedShip";
            this.dataGridViewAddedShip.ReadOnly = true;
            this.dataGridViewAddedShip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddedShip.Size = new System.Drawing.Size(714, 78);
            this.dataGridViewAddedShip.TabIndex = 112;
            // 
            // labelHireDateInfo
            // 
            this.labelHireDateInfo.AutoSize = true;
            this.labelHireDateInfo.ForeColor = System.Drawing.Color.Red;
            this.labelHireDateInfo.Location = new System.Drawing.Point(327, 33);
            this.labelHireDateInfo.Name = "labelHireDateInfo";
            this.labelHireDateInfo.Size = new System.Drawing.Size(266, 13);
            this.labelHireDateInfo.TabIndex = 112;
            this.labelHireDateInfo.Text = "Podaj prawidłową date wypożyczenia [RRRR-MM-DD]";
            // 
            // labelDueDateInfo
            // 
            this.labelDueDateInfo.AutoSize = true;
            this.labelDueDateInfo.Location = new System.Drawing.Point(328, 56);
            this.labelDueDateInfo.Name = "labelDueDateInfo";
            this.labelDueDateInfo.Size = new System.Drawing.Size(374, 13);
            this.labelDueDateInfo.TabIndex = 113;
            this.labelDueDateInfo.Text = "(Opcjonalne - Zamknięcie rezerwacji) Podaj prawidłową date [RRRR-MM-DD]";
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(758, 644);
            this.Controls.Add(this.labelDueDateInfo);
            this.Controls.Add(this.labelHireDateInfo);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.tabControl1);
            this.Name = "ReservationForm";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.labelId, 0);
            this.Controls.SetChildIndex(this.textBoxID, 0);
            this.Controls.SetChildIndex(this.labelHireDateInfo, 0);
            this.Controls.SetChildIndex(this.labelDueDateInfo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.buttonConfirm, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.title, 0);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedEmployees)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedShip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelEmployees;
        private System.Windows.Forms.Button buttonAddEmployee;
        private System.Windows.Forms.Button buttonRemoveEmployee;
        protected System.Windows.Forms.DataGridView dataGridViewEmployees;
        protected System.Windows.Forms.DataGridView dataGridViewAddedEmployees;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.DataGridView dataGridViewAddedClient;
        protected System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Button buttonRemoveClient;
        private System.Windows.Forms.Button buttonAddClient;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label labelHireDateInfo;
        private System.Windows.Forms.Label labelDueDateInfo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelShip;
        private System.Windows.Forms.Button buttonAddShip;
        private System.Windows.Forms.Button buttonRomoveShip;
        protected System.Windows.Forms.DataGridView dataGridViewShips;
        protected System.Windows.Forms.DataGridView dataGridViewAddedShip;
    }
}
