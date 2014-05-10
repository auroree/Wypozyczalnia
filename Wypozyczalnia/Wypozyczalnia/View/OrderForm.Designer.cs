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
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 412);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.buttonConfirm, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.title, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
    }
}