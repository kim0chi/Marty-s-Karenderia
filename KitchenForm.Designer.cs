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
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKitchenOrders
            // 
            this.dgvKitchenOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKitchenOrders.Location = new System.Drawing.Point(12, 130);
            this.dgvKitchenOrders.Name = "dgvKitchenOrders";
            this.dgvKitchenOrders.Size = new System.Drawing.Size(821, 446);
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
            this.btnMarkComplete.Location = new System.Drawing.Point(678, 75);
            this.btnMarkComplete.Name = "btnMarkComplete";
            this.btnMarkComplete.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMarkComplete.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMarkComplete.Size = new System.Drawing.Size(144, 40);
            this.btnMarkComplete.TabIndex = 2;
            this.btnMarkComplete.Text = "Mark Complete";
            this.btnMarkComplete.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);
            // 
            // KitchenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 600);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.dgvKitchenOrders);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KitchenForm";
            this.Text = "KitchenForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitchenOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKitchenOrders;
        private ReaLTaiizor.Controls.Button btnMarkComplete;
    }
}