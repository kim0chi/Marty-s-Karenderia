namespace Marty_s_Karenderia
{
    partial class PaymentForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtAmountPaid = new ReaLTaiizor.Controls.AloneTextBox();
            this.rbCash = new ReaLTaiizor.Controls.AloneRadioButton();
            this.rbCreditCard = new ReaLTaiizor.Controls.AloneRadioButton();
            this.rbMobilePayment = new ReaLTaiizor.Controls.AloneRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.bigLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 53);
            this.panel1.TabIndex = 16;
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.Color.White;
            this.bigLabel1.Location = new System.Drawing.Point(12, 16);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(88, 25);
            this.bigLabel1.TabIndex = 0;
            this.bigLabel1.Text = "Payment";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 330);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 53);
            this.panel2.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(42, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Location = new System.Drawing.Point(151, 8);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(98, 36);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Amount Paid";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(89, 77);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.lblTotalAmount.TabIndex = 18;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.BackColor = System.Drawing.Color.Transparent;
            this.txtAmountPaid.EnabledCalc = true;
            this.txtAmountPaid.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaid.ForeColor = System.Drawing.Color.Black;
            this.txtAmountPaid.Location = new System.Drawing.Point(42, 278);
            this.txtAmountPaid.MaxLength = 32767;
            this.txtAmountPaid.MultiLine = false;
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.ReadOnly = false;
            this.txtAmountPaid.Size = new System.Drawing.Size(204, 29);
            this.txtAmountPaid.TabIndex = 27;
            this.txtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAmountPaid.UseSystemPasswordChar = false;
            // 
            // rbCash
            // 
            this.rbCash.BackColor = System.Drawing.Color.Transparent;
            this.rbCash.Checked = false;
            this.rbCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbCash.EnabledCalc = true;
            this.rbCash.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCash.ForeColor = System.Drawing.Color.Black;
            this.rbCash.Location = new System.Drawing.Point(51, 169);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(138, 17);
            this.rbCash.TabIndex = 28;
            this.rbCash.Text = "Cash";
            // 
            // rbCreditCard
            // 
            this.rbCreditCard.BackColor = System.Drawing.Color.Transparent;
            this.rbCreditCard.Checked = false;
            this.rbCreditCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbCreditCard.EnabledCalc = true;
            this.rbCreditCard.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCreditCard.ForeColor = System.Drawing.Color.Black;
            this.rbCreditCard.Location = new System.Drawing.Point(51, 192);
            this.rbCreditCard.Name = "rbCreditCard";
            this.rbCreditCard.Size = new System.Drawing.Size(138, 17);
            this.rbCreditCard.TabIndex = 29;
            this.rbCreditCard.Text = "CreditCard";
            // 
            // rbMobilePayment
            // 
            this.rbMobilePayment.BackColor = System.Drawing.Color.Transparent;
            this.rbMobilePayment.Checked = false;
            this.rbMobilePayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbMobilePayment.EnabledCalc = true;
            this.rbMobilePayment.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMobilePayment.ForeColor = System.Drawing.Color.Black;
            this.rbMobilePayment.Location = new System.Drawing.Point(51, 215);
            this.rbMobilePayment.Name = "rbMobilePayment";
            this.rbMobilePayment.Size = new System.Drawing.Size(138, 17);
            this.rbMobilePayment.TabIndex = 30;
            this.rbMobilePayment.Text = "MobilePayment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Payment Method";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 383);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbMobilePayment);
            this.Controls.Add(this.rbCreditCard);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.txtAmountPaid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalAmount;
        public ReaLTaiizor.Controls.AloneTextBox txtAmountPaid;
        private System.Windows.Forms.Button btnCancel;
        private ReaLTaiizor.Controls.AloneRadioButton rbCash;
        private ReaLTaiizor.Controls.AloneRadioButton rbCreditCard;
        private ReaLTaiizor.Controls.AloneRadioButton rbMobilePayment;
        private System.Windows.Forms.Label label1;
    }
}