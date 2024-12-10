using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class PayrollForm : Form
    {
        public PayrollForm()
        {
            InitializeComponent();
            LoadPayrollData();
        }

        private void btnPayEmployee_Click(object sender, EventArgs e)
        {
            if (dgvAdminPayroll.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select payroll records to mark as paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedPayrollIds = new List<int>();
            foreach (DataGridViewRow row in dgvAdminPayroll.SelectedRows)
            {
                selectedPayrollIds.Add(Convert.ToInt32(row.Cells["PayrollID"].Value));
            }

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                var query = @"
            UPDATE Payroll
            SET IsPaid = 1, PayDate = @PayDate
            WHERE PayrollID IN (" + string.Join(",", selectedPayrollIds) + ")";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PayDate", DateTime.Now);

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} record(s) marked as paid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            LoadPayrollData(); // Refresh payroll records
        }

        private void btnExportPayroll_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = "PayrollReport.csv" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Write headers
                        foreach (DataGridViewColumn column in dgvAdminPayroll.Columns)
                        {
                            writer.Write(column.HeaderText + ",");
                        }
                        writer.WriteLine();

                        // Write rows
                        foreach (DataGridViewRow row in dgvAdminPayroll.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                writer.Write(cell.Value?.ToString().Replace(",", ";") + ",");
                            }
                            writer.WriteLine();
                        }

                        MessageBox.Show("Payroll data exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void LoadPayrollData()
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                string query = @"
            SELECT 
                PayrollID, 
                StaffID, 
                (SELECT FullName FROM Staff WHERE Staff.StaffID = Payroll.StaffID) AS FullName,
                TotalHoursWorked, 
                TotalPay, 
                IsPaid, 
                PayDate 
            FROM Payroll";

                using (var command = new SqlCommand(query, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvAdminPayroll.DataSource = table;
                }
            }
        }

    }
}
