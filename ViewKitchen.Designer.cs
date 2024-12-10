namespace Marty_s_Karenderia
{
    partial class ViewKitchen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewKitchen));
            this.dgvKitchenOrders = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new ReaLTaiizor.Controls.ForeverClose();
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
            this.dgvKitchenOrders.Location = new System.Drawing.Point(12, 59);
            this.dgvKitchenOrders.Name = "dgvKitchenOrders";
            this.dgvKitchenOrders.Size = new System.Drawing.Size(776, 379);
            this.dgvKitchenOrders.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Kitchen Orders";
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
            this.btnClose.Location = new System.Drawing.Point(770, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.OverColor = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "foreverClose2";
            this.btnClose.TextColor = System.Drawing.Color.White;
            // 
            // ViewKitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvKitchenOrders);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewKitchen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewKitchen";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKitchenOrders;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.ForeverClose btnClose;
    }
}