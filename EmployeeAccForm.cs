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
    public partial class EmployeeAccForm : Form
    {

        private int CurrentStaffID;

        public EmployeeAccForm(int staffID)
        {
            InitializeComponent();
            CurrentStaffID = staffID;
            ConfigureEmployeePayrollGridView(); // Setup dgvEmployeePayroll
            ConfigurePayHistoryGridView();     // Setup dgvPayHistory

            LoadCurrentPayroll();              // Load current payroll details
            LoadPaymentHistory();              // Load payment history
            this.FormClosed += new FormClosedEventHandler(EmployeeForm_FormClosed);

        }
        private void ConfigureEmployeePayrollGridView()
        {
            dgvEmployeePayroll.AutoGenerateColumns = true;
            dgvEmployeePayroll.AllowUserToAddRows = false;
            dgvEmployeePayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployeePayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigurePayHistoryGridView()
        {
            dgvPayHistory.AutoGenerateColumns = true;
            dgvPayHistory.AllowUserToAddRows = false;
            dgvPayHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                // Check if the staff member has already clocked in
                var checkQuery = "SELECT COUNT(*) FROM Payroll WHERE StaffID = @StaffID AND ClockOut IS NULL";
                using (var checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@StaffID", CurrentStaffID);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("You are already clocked in! Please clock out before clocking in again.", "Clock In Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Clock in the staff member
                var query = "INSERT INTO Payroll (StaffID, ClockIn) VALUES (@StaffID, @ClockIn)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", CurrentStaffID);
                    command.Parameters.AddWithValue("@ClockIn", DateTime.Now);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Clock In Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btnClockOut_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                // Check if there is an active clock-in entry
                var checkQuery = "SELECT COUNT(*) FROM Payroll WHERE StaffID = @StaffID AND ClockOut IS NULL";
                using (var checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@StaffID", CurrentStaffID);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("You have not clocked in yet!", "Clock Out Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Clock out the staff member
                var query = "UPDATE Payroll SET ClockOut = @ClockOut WHERE StaffID = @StaffID AND ClockOut IS NULL";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", CurrentStaffID);
                    command.Parameters.AddWithValue("@ClockOut", DateTime.Now);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Clock Out Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadCurrentPayroll()
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                string query = @"
                SELECT 
                    ISNULL(SUM(DATEDIFF(HOUR, ClockIn, ClockOut)), 0) AS TotalHoursWorked,
                    ISNULL(SUM(DATEDIFF(HOUR, ClockIn, ClockOut) * 50), 0) AS TotalPay, -- Assuming hourly rate is 50
                    MAX(ClockIn) AS LastClockIn,
                    MAX(ClockOut) AS LastClockOut
                FROM 
                    Payroll
                WHERE 
                    StaffID = @StaffID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", CurrentStaffID); // Pass the logged-in staff's ID

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var table = new DataTable();
                            table.Columns.Add("Total Hours Worked", typeof(string));
                            table.Columns.Add("Total Pay", typeof(string));
                            table.Columns.Add("Last Clock In", typeof(string));
                            table.Columns.Add("Last Clock Out", typeof(string));

                            table.Rows.Add(
                                reader["TotalHoursWorked"].ToString(),
                                $"₱{Convert.ToDecimal(reader["TotalPay"]):F2}",
                                reader["LastClockIn"] == DBNull.Value ? "N/A" : Convert.ToDateTime(reader["LastClockIn"]).ToString("MM/dd/yyyy HH:mm"),
                                reader["LastClockOut"] == DBNull.Value ? "N/A" : Convert.ToDateTime(reader["LastClockOut"]).ToString("MM/dd/yyyy HH:mm")
                            );

                            dgvEmployeePayroll.DataSource = table;
                        }
                    }
                }
            }
        }

        private void LoadPaymentHistory()
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                string query = @"
                SELECT 
                    PayDate AS DatePaid,
                    ISNULL(SUM(DATEDIFF(HOUR, ClockIn, ClockOut)), 0) AS HoursWorked,
                    ISNULL(SUM(DATEDIFF(HOUR, ClockIn, ClockOut) * 50), 0) AS TotalPay -- Assuming hourly rate is 50
                FROM 
                    Payroll
                WHERE 
                    StaffID = @StaffID AND PayDate IS NOT NULL
                GROUP BY 
                    PayDate
                ORDER BY 
                    PayDate DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", CurrentStaffID); // Pass the logged-in staff's ID

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        dgvPayHistory.DataSource = table;
                    }
                }
            }
        }
        private void btnExportPayrollHistory_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV File|*.csv",
                Title = "Export Payroll History"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    // Write header
                    foreach (DataGridViewColumn column in dgvPayHistory.Columns)
                    {
                        writer.Write(column.HeaderText + ",");
                    }
                    writer.WriteLine();

                    // Write rows
                    foreach (DataGridViewRow row in dgvPayHistory.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            writer.Write(cell.Value?.ToString() + ",");
                        }
                        writer.WriteLine();
                    }
                }

                MessageBox.Show("Payroll history exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the LoginForm when the AdminForm is closed
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
