namespace Marty_s_Karenderia
{
    partial class EmployeeAccForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeAccForm));
            this.dgvEmployeePayroll = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClockIn = new ReaLTaiizor.Controls.Button();
            this.btnClockOut = new ReaLTaiizor.Controls.Button();
            this.dgvPayHistory = new System.Windows.Forms.DataGridView();
            this.btnExportPayroll = new ReaLTaiizor.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeePayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployeePayroll
            // 
            this.dgvEmployeePayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeePayroll.Location = new System.Drawing.Point(12, 88);
            this.dgvEmployeePayroll.Name = "dgvEmployeePayroll";
            this.dgvEmployeePayroll.Size = new System.Drawing.Size(821, 254);
            this.dgvEmployeePayroll.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Staff Payroll";
            // 
            // btnClockIn
            // 
            this.btnClockIn.BackColor = System.Drawing.Color.Transparent;
            this.btnClockIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClockIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClockIn.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClockIn.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClockIn.Image = null;
            this.btnClockIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClockIn.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClockIn.Location = new System.Drawing.Point(17, 42);
            this.btnClockIn.Name = "btnClockIn";
            this.btnClockIn.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClockIn.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClockIn.Size = new System.Drawing.Size(132, 40);
            this.btnClockIn.TabIndex = 17;
            this.btnClockIn.Text = "Clock In";
            this.btnClockIn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnClockIn.Click += new System.EventHandler(this.btnClockIn_Click);
            // 
            // btnClockOut
            // 
            this.btnClockOut.BackColor = System.Drawing.Color.Transparent;
            this.btnClockOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClockOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClockOut.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClockOut.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClockOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClockOut.Image = null;
            this.btnClockOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClockOut.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnClockOut.Location = new System.Drawing.Point(155, 42);
            this.btnClockOut.Name = "btnClockOut";
            this.btnClockOut.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClockOut.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnClockOut.Size = new System.Drawing.Size(132, 40);
            this.btnClockOut.TabIndex = 18;
            this.btnClockOut.Text = "Clock Out";
            this.btnClockOut.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnClockOut.Click += new System.EventHandler(this.btnClockOut_Click);
            // 
            // dgvPayHistory
            // 
            this.dgvPayHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayHistory.Location = new System.Drawing.Point(12, 348);
            this.dgvPayHistory.Name = "dgvPayHistory";
            this.dgvPayHistory.Size = new System.Drawing.Size(821, 240);
            this.dgvPayHistory.TabIndex = 19;
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
            this.btnExportPayroll.Location = new System.Drawing.Point(701, 42);
            this.btnExportPayroll.Name = "btnExportPayroll";
            this.btnExportPayroll.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExportPayroll.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExportPayroll.Size = new System.Drawing.Size(132, 40);
            this.btnExportPayroll.TabIndex = 20;
            this.btnExportPayroll.Text = "Export Payroll";
            this.btnExportPayroll.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnExportPayroll.Click += new System.EventHandler(this.btnExportPayrollHistory_Click);
            // 
            // EmployeeAccForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 600);
            this.Controls.Add(this.btnExportPayroll);
            this.Controls.Add(this.dgvPayHistory);
            this.Controls.Add(this.btnClockOut);
            this.Controls.Add(this.btnClockIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEmployeePayroll);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeeAccForm";
            this.Text = "ShiftForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeePayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployeePayroll;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.Button btnClockIn;
        private ReaLTaiizor.Controls.Button btnClockOut;
        private System.Windows.Forms.DataGridView dgvPayHistory;
        private ReaLTaiizor.Controls.Button btnExportPayroll;
    }
}