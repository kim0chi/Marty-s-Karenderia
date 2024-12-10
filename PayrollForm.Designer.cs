namespace Marty_s_Karenderia
{
    partial class PayrollForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayrollForm));
            this.btnPayEmployee = new ReaLTaiizor.Controls.Button();
            this.dgvAdminPayroll = new System.Windows.Forms.DataGridView();
            this.btnExportPayroll = new ReaLTaiizor.Controls.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminPayroll)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPayEmployee
            // 
            this.btnPayEmployee.BackColor = System.Drawing.Color.Transparent;
            this.btnPayEmployee.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnPayEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayEmployee.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnPayEmployee.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnPayEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPayEmployee.Image = null;
            this.btnPayEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayEmployee.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnPayEmployee.Location = new System.Drawing.Point(685, 21);
            this.btnPayEmployee.Name = "btnPayEmployee";
            this.btnPayEmployee.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnPayEmployee.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnPayEmployee.Size = new System.Drawing.Size(132, 40);
            this.btnPayEmployee.TabIndex = 11;
            this.btnPayEmployee.Text = "Pay Employee";
            this.btnPayEmployee.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnPayEmployee.Click += new System.EventHandler(this.btnPayEmployee_Click);
            // 
            // dgvAdminPayroll
            // 
            this.dgvAdminPayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminPayroll.Location = new System.Drawing.Point(12, 67);
            this.dgvAdminPayroll.Name = "dgvAdminPayroll";
            this.dgvAdminPayroll.Size = new System.Drawing.Size(805, 482);
            this.dgvAdminPayroll.TabIndex = 12;
            // 
            // btnExportPayroll
            // 
            this.btnExportPayroll.BackColor = System.Drawing.Color.Transparent;
            this.btnExportPayroll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnExportPayroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportPayroll.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExportPayroll.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnExportPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExportPayroll.Image = null;
            this.btnExportPayroll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportPayroll.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnExportPayroll.Location = new System.Drawing.Point(547, 21);
            this.btnExportPayroll.Name = "btnExportPayroll";
            this.btnExportPayroll.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExportPayroll.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExportPayroll.Size = new System.Drawing.Size(132, 40);
            this.btnExportPayroll.TabIndex = 13;
            this.btnExportPayroll.Text = "Export Payroll";
            this.btnExportPayroll.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnExportPayroll.Click += new System.EventHandler(this.btnExportPayroll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Staff Payroll";
            // 
            // PayrollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportPayroll);
            this.Controls.Add(this.dgvAdminPayroll);
            this.Controls.Add(this.btnPayEmployee);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PayrollForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PayrollForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminPayroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.Button btnPayEmployee;
        private System.Windows.Forms.DataGridView dgvAdminPayroll;
        private ReaLTaiizor.Controls.Button btnExportPayroll;
        private System.Windows.Forms.Label label1;
    }
}