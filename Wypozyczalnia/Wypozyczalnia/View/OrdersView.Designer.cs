namespace Wypozyczalnia.View
{
    partial class OrdersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.filterOrderDate = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.buttonShowParts = new System.Windows.Forms.Button();
            this.buttonOrderDelivery = new System.Windows.Forms.Button();
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
            this.filterOrderDate,
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
            this.toolStripLabel1.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel1.Text = "Data zamówienia:";
            // 
            // filterOrderDate
            // 
            this.filterOrderDate.Name = "filterOrderDate";
            this.filterOrderDate.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Szukaj";
            this.toolStripButton1.Click += new System.EventHandler(this.ActionSearchByOrderDate);
            // 
            // buttonShowParts
            // 
            this.buttonShowParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowParts.Location = new System.Drawing.Point(156, 464);
            this.buttonShowParts.Name = "buttonShowParts";
            this.buttonShowParts.Size = new System.Drawing.Size(137, 23);
            this.buttonShowParts.TabIndex = 8;
            this.buttonShowParts.Text = "Pokaż części";
            this.buttonShowParts.UseVisualStyleBackColor = true;
            this.buttonShowParts.Click += new System.EventHandler(this.ActionShowParts);
            // 
            // buttonOrderDelivery
            // 
            this.buttonOrderDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOrderDelivery.Location = new System.Drawing.Point(13, 464);
            this.buttonOrderDelivery.Name = "buttonOrderDelivery";
            this.buttonOrderDelivery.Size = new System.Drawing.Size(137, 23);
            this.buttonOrderDelivery.TabIndex = 9;
            this.buttonOrderDelivery.Text = "Odebrano zamówienie";
            this.buttonOrderDelivery.UseVisualStyleBackColor = true;
            this.buttonOrderDelivery.Click += new System.EventHandler(this.ActionOrderDelivered);
            // 
            // OrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.buttonOrderDelivery);
            this.Controls.Add(this.buttonShowParts);
            this.Controls.Add(this.toolStrip1);
            this.Name = "OrdersView";
            this.SizeChanged += new System.EventHandler(this.ActionResized);
            this.Controls.SetChildIndex(this.buttonAdd, 0);
            this.Controls.SetChildIndex(this.buttonEdit, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.buttonShowParts, 0);
            this.Controls.SetChildIndex(this.buttonOrderDelivery, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox filterOrderDate;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button buttonShowParts;
        private System.Windows.Forms.Button buttonOrderDelivery;
    }
}