namespace Marty_s_Karenderia
{
    partial class PosForm
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
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCategories = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFinalizeSale = new ReaLTaiizor.Controls.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new ReaLTaiizor.Controls.AloneTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new ReaLTaiizor.Controls.Button();
            this.btnTransactionHistory = new ReaLTaiizor.Controls.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearOrder = new ReaLTaiizor.Controls.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rbDineIn = new ReaLTaiizor.Controls.AloneRadioButton();
            this.rbTakeout = new ReaLTaiizor.Controls.AloneRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(576, 106);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(562, 417);
            this.dgvCart.TabIndex = 4;
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellContentClick);
            // 
            // flowProducts
            // 
            this.flowProducts.Location = new System.Drawing.Point(188, 79);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Size = new System.Drawing.Size(382, 540);
            this.flowProducts.TabIndex = 5;
            // 
            // panelCategories
            // 
            this.panelCategories.Location = new System.Drawing.Point(12, 79);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.Size = new System.Drawing.Size(170, 540);
            this.panelCategories.TabIndex = 6;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(925, 541);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(41, 25);
            this.lblSubtotal.TabIndex = 7;
            this.lblSubtotal.Text = ":     ";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(925, 566);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(41, 25);
            this.lblTax.TabIndex = 8;
            this.lblTax.Text = ":     ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(925, 591);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 25);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = ":     ";
            // 
            // btnFinalizeSale
            // 
            this.btnFinalizeSale.BackColor = System.Drawing.Color.Transparent;
            this.btnFinalizeSale.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnFinalizeSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizeSale.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnFinalizeSale.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnFinalizeSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFinalizeSale.Image = null;
            this.btnFinalizeSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizeSale.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnFinalizeSale.Location = new System.Drawing.Point(1017, 28);
            this.btnFinalizeSale.Name = "btnFinalizeSale";
            this.btnFinalizeSale.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnFinalizeSale.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnFinalizeSale.Size = new System.Drawing.Size(120, 40);
            this.btnFinalizeSale.TabIndex = 10;
            this.btnFinalizeSale.Text = "Finalize Sale";
            this.btnFinalizeSale.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnFinalizeSale.Click += new System.EventHandler(this.btnFinalizeSale_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.btnClearOrder);
            this.panel1.Controls.Add(this.btnTransactionHistory);
            this.panel1.Controls.Add(this.btnFinalizeSale);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 639);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 100);
            this.panel1.TabIndex = 11;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.EnabledCalc = true;
            this.txtSearch.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(27, 33);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.MultiLine = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.Size = new System.Drawing.Size(263, 40);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Search";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExit.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExit.Image = null;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnExit.Location = new System.Drawing.Point(1080, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExit.Size = new System.Drawing.Size(65, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTransactionHistory
            // 
            this.btnTransactionHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnTransactionHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTransactionHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransactionHistory.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTransactionHistory.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTransactionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTransactionHistory.Image = null;
            this.btnTransactionHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactionHistory.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTransactionHistory.Location = new System.Drawing.Point(27, 28);
            this.btnTransactionHistory.Name = "btnTransactionHistory";
            this.btnTransactionHistory.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTransactionHistory.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTransactionHistory.Size = new System.Drawing.Size(154, 40);
            this.btnTransactionHistory.TabIndex = 12;
            this.btnTransactionHistory.Text = "Transaction History";
            this.btnTransactionHistory.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnTransactionHistory.Click += new System.EventHandler(this.btnTransactionHistory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(803, 591);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(803, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(803, 541);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Subtotal";
            // 
            // btnClearOrder
            // 
            this.btnClearOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnClearOrder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClearOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearOrder.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClearOrder.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClearOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClearOrder.Image = null;
            this.btnClearOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearOrder.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClearOrder.Location = new System.Drawing.Point(891, 28);
            this.btnClearOrder.Name = "btnClearOrder";
            this.btnClearOrder.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClearOrder.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClearOrder.Size = new System.Drawing.Size(120, 40);
            this.btnClearOrder.TabIndex = 13;
            this.btnClearOrder.Text = "Clear";
            this.btnClearOrder.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnClearOrder.Click += new System.EventHandler(this.btnClearOrder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(576, 541);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Transaction Summary:";
            // 
            // rbDineIn
            // 
            this.rbDineIn.BackColor = System.Drawing.Color.Transparent;
            this.rbDineIn.Checked = false;
            this.rbDineIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDineIn.EnabledCalc = true;
            this.rbDineIn.ForeColor = System.Drawing.Color.Black;
            this.rbDineIn.Location = new System.Drawing.Point(581, 83);
            this.rbDineIn.Name = "rbDineIn";
            this.rbDineIn.Size = new System.Drawing.Size(83, 17);
            this.rbDineIn.TabIndex = 19;
            this.rbDineIn.Text = "Dine In";
            // 
            // rbTakeout
            // 
            this.rbTakeout.BackColor = System.Drawing.Color.Transparent;
            this.rbTakeout.Checked = false;
            this.rbTakeout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbTakeout.EnabledCalc = true;
            this.rbTakeout.ForeColor = System.Drawing.Color.Black;
            this.rbTakeout.Location = new System.Drawing.Point(670, 83);
            this.rbTakeout.Name = "rbTakeout";
            this.rbTakeout.Size = new System.Drawing.Size(83, 17);
            this.rbTakeout.TabIndex = 20;
            this.rbTakeout.Text = "Takeout";
            // 
            // PosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1150, 739);
            this.Controls.Add(this.rbTakeout);
            this.Controls.Add(this.rbDineIn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panelCategories);
            this.Controls.Add(this.flowProducts);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.lblSubtotal);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PosForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;
        private System.Windows.Forms.Panel panelCategories;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTotal;
        private ReaLTaiizor.Controls.Button btnFinalizeSale;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.Button btnTransactionHistory;
        private ReaLTaiizor.Controls.AloneTextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.Button btnExit;
        private ReaLTaiizor.Controls.Button btnClearOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ReaLTaiizor.Controls.AloneRadioButton rbDineIn;
        private ReaLTaiizor.Controls.AloneRadioButton rbTakeout;
    }
}