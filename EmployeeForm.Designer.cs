namespace Marty_s_Karenderia
{
    partial class EmployeeForm
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
            this.btnClose = new ReaLTaiizor.Controls.ForeverClose();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.panel1 = new ReaLTaiizor.Controls.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btnEmployeeAccount = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKitchen = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.hopePictureBox1 = new ReaLTaiizor.Controls.HopePictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultLocation = true;
            this.btnClose.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnClose.Font = new System.Drawing.Font("Marlett", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnClose.Location = new System.Drawing.Point(1029, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.OverColor = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "foreverClose2";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Wheat;
            this.panel2.Controls.Add(this.btnEmployeeAccount);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lblRole);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnKitchen);
            this.panel2.Controls.Add(this.btnPOS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 600);
            this.panel2.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(214, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(845, 600);
            this.panel4.TabIndex = 0;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(53, 79);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(96, 25);
            this.lblRole.TabIndex = 22;
            this.lblRole.Text = "Employee";
            this.lblRole.Click += new System.EventHandler(this.lblRole_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.hopePictureBox1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1059, 59);
            this.panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panel1.TabIndex = 24;
            this.panel1.Text = "panel1";
            // 
            // contentPanel
            // 
            this.contentPanel.Location = new System.Drawing.Point(214, 59);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(845, 600);
            this.contentPanel.TabIndex = 26;
            // 
            // btnEmployeeAccount
            // 
            this.btnEmployeeAccount.BackColor = System.Drawing.Color.Wheat;
            this.btnEmployeeAccount.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEmployeeAccount.FlatAppearance.BorderSize = 0;
            this.btnEmployeeAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeAccount.Image = global::Marty_s_Karenderia.Properties.Resources.accountant;
            this.btnEmployeeAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeAccount.Location = new System.Drawing.Point(17, 313);
            this.btnEmployeeAccount.Name = "btnEmployeeAccount";
            this.btnEmployeeAccount.Size = new System.Drawing.Size(200, 46);
            this.btnEmployeeAccount.TabIndex = 23;
            this.btnEmployeeAccount.Text = "          Account";
            this.btnEmployeeAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeAccount.UseVisualStyleBackColor = false;
            this.btnEmployeeAccount.Click += new System.EventHandler(this.btnEmployeeAccount_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Wheat;
            this.pictureBox1.Image = global::Marty_s_Karenderia.Properties.Resources.employees;
            this.pictureBox1.Location = new System.Drawing.Point(58, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnKitchen
            // 
            this.btnKitchen.BackColor = System.Drawing.Color.Wheat;
            this.btnKitchen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnKitchen.FlatAppearance.BorderSize = 0;
            this.btnKitchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitchen.Image = global::Marty_s_Karenderia.Properties.Resources.chef;
            this.btnKitchen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKitchen.Location = new System.Drawing.Point(17, 261);
            this.btnKitchen.Name = "btnKitchen";
            this.btnKitchen.Size = new System.Drawing.Size(200, 46);
            this.btnKitchen.TabIndex = 20;
            this.btnKitchen.Text = "          Kitchen";
            this.btnKitchen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKitchen.UseVisualStyleBackColor = false;
            this.btnKitchen.Click += new System.EventHandler(this.btnKitchen_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.BackColor = System.Drawing.Color.Wheat;
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Image = global::Marty_s_Karenderia.Properties.Resources.point_of_sale;
            this.btnPOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.Location = new System.Drawing.Point(17, 209);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(200, 46);
            this.btnPOS.TabIndex = 19;
            this.btnPOS.Text = "          POS";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.UseVisualStyleBackColor = false;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // hopePictureBox1
            // 
            this.hopePictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.hopePictureBox1.Image = global::Marty_s_Karenderia.Properties.Resources.Screenshot_2024_12_06_153747;
            this.hopePictureBox1.Location = new System.Drawing.Point(6, 5);
            this.hopePictureBox1.Name = "hopePictureBox1";
            this.hopePictureBox1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.hopePictureBox1.Size = new System.Drawing.Size(372, 51);
            this.hopePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hopePictureBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.hopePictureBox1.TabIndex = 15;
            this.hopePictureBox1.TabStop = false;
            this.hopePictureBox1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1059, 659);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contentPanel);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.ForeverClose btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEmployeeAccount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnKitchen;
        private System.Windows.Forms.Button btnPOS;
        private ReaLTaiizor.Controls.Panel panel1;
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox1;
        private System.Windows.Forms.Panel contentPanel;
    }
}