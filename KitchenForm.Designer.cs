namespace Marty_s_Karenderia
{
    partial class KitchenForm
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
            this.dgvKitchenOrders = new System.Windows.Forms.DataGridView();
            this.btnMarkComplete = new ReaLTaiizor.Controls.Button();
            this.btnMarkInProgress = new ReaLTaiizor.Controls.Button();
            this.btnClose = new ReaLTaiizor.Controls.ForeverClose();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKitchenOrders
            // 
            this.dgvKitchenOrders.AllowUserToOrderColumns = true;
            this.dgvKitchenOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKitchenOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKitchenOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvKitchenOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKitchenOrders.Location = new System.Drawing.Point(12, 97);
            this.dgvKitchenOrders.Name = "dgvKitchenOrders";
            this.dgvKitchenOrders.Size = new System.Drawing.Size(821, 479);
            this.dgvKitchenOrders.TabIndex = 1;
            // 
            // btnMarkComplete
            // 
            this.btnMarkComplete.BackColor = System.Drawing.Color.Transparent;
            this.btnMarkComplete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnMarkComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkComplete.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMarkComplete.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnMarkComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMarkComplete.Image = null;
            this.btnMarkComplete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarkComplete.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnMarkComplete.Location = new System.Drawing.Point(162, 51);
            this.btnMarkComplete.Name = "btnMarkComplete";
            this.btnMarkComplete.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMarkComplete.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMarkComplete.Size = new System.Drawing.Size(144, 40);
            this.btnMarkComplete.TabIndex = 2;
            this.btnMarkComplete.Text = "Mark Complete";
            this.btnMarkComplete.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);
            // 
            // btnMarkInProgress
            // 
            this.btnMarkInProgress.BackColor = System.Drawing.Color.Transparent;
            this.btnMarkInProgress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnMarkInProgress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkInProgress.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMarkInProgress.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnMarkInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMarkInProgress.Image = null;
            this.btnMarkInProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarkInProgress.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnMarkInProgress.Location = new System.Drawing.Point(12, 51);
            this.btnMarkInProgress.Name = "btnMarkInProgress";
            this.btnMarkInProgress.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMarkInProgress.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMarkInProgress.Size = new System.Drawing.Size(144, 40);
            this.btnMarkInProgress.TabIndex = 3;
            this.btnMarkInProgress.Text = "Mark In Progress";
            this.btnMarkInProgress.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnMarkInProgress.Click += new System.EventHandler(this.btnMarkInProgress_Click);
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
            this.btnClose.Location = new System.Drawing.Point(815, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.OverColor = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "foreverClose2";
            this.btnClose.TextColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Kitchen Orders";
            // 
            // KitchenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(845, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMarkInProgress);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.dgvKitchenOrders);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KitchenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KitchenForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKitchenOrders;
        private ReaLTaiizor.Controls.Button btnMarkComplete;
        private ReaLTaiizor.Controls.Button btnMarkInProgress;
        private ReaLTaiizor.Controls.ForeverClose btnClose;
        private System.Windows.Forms.Label label1;
    }
}