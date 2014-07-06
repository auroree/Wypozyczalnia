namespace Wypozyczalnia.View
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDBSettings = new System.Windows.Forms.Button();
            this.labelDB = new System.Windows.Forms.Label();
            this.textBoxDB = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.labelInProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa użytkownika";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasło";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(126, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(197, 209);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Zaloguj";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.ActionConfirm);
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(12, 209);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Wyjście";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ActionExit);
            // 
            // buttonDBSettings
            // 
            this.buttonDBSettings.Location = new System.Drawing.Point(13, 86);
            this.buttonDBSettings.Name = "buttonDBSettings";
            this.buttonDBSettings.Size = new System.Drawing.Size(259, 23);
            this.buttonDBSettings.TabIndex = 6;
            this.buttonDBSettings.Text = "Ustawienia bazy danych";
            this.buttonDBSettings.UseVisualStyleBackColor = true;
            this.buttonDBSettings.Click += new System.EventHandler(this.ActionDBSettings);
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.Location = new System.Drawing.Point(23, 155);
            this.labelDB.Name = "labelDB";
            this.labelDB.Size = new System.Drawing.Size(69, 13);
            this.labelDB.TabIndex = 10;
            this.labelDB.Text = "Baza danych";
            this.labelDB.Visible = false;
            // 
            // textBoxDB
            // 
            this.textBoxDB.Location = new System.Drawing.Point(131, 152);
            this.textBoxDB.Name = "textBoxDB";
            this.textBoxDB.Size = new System.Drawing.Size(126, 20);
            this.textBoxDB.TabIndex = 9;
            this.textBoxDB.Visible = false;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(23, 129);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(40, 13);
            this.labelServer.TabIndex = 8;
            this.labelServer.Text = "Serwer";
            this.labelServer.Visible = false;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(131, 126);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(126, 20);
            this.textBoxServer.TabIndex = 7;
            this.textBoxServer.Visible = false;
            // 
            // labelInProgress
            // 
            this.labelInProgress.Location = new System.Drawing.Point(13, 186);
            this.labelInProgress.Name = "labelInProgress";
            this.labelInProgress.Size = new System.Drawing.Size(259, 20);
            this.labelInProgress.TabIndex = 11;
            this.labelInProgress.Text = "Trwa łączenie z bazą danych...";
            this.labelInProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelInProgress.Visible = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(284, 244);
            this.Controls.Add(this.labelInProgress);
            this.Controls.Add(this.labelDB);
            this.Controls.Add(this.textBoxDB);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.buttonDBSettings);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wypożyczalnia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonDBSettings;
        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.TextBox textBoxDB;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label labelInProgress;
    }
}
