using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class SwitchUserForm : Form
    {
        public SwitchUserForm()
        {
            InitializeComponent();
        }

        private void cboxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on the checkbox state
            txtPassword.UseSystemPasswordChar = !cboxShowPassword.Checked;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                try
                {
                    connection.Open();

                    // Check for Admin login
                    string adminQuery = "SELECT AdminName FROM Admin WHERE AdminName = @Username AND AdminPassword = @Password";
                    using (var adminCommand = new SqlCommand(adminQuery, connection))
                    {
                        adminCommand.Parameters.AddWithValue("@Username", username);
                        adminCommand.Parameters.AddWithValue("@Password", password);

                        var adminResult = adminCommand.ExecuteScalar();
                        if (adminResult != null)
                        {
                            MessageBox.Show($"Welcome, Admin {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AdminForm adminForm = new AdminForm();
                            this.Hide();
                            adminForm.FormClosed += (s, ev) => this.Show(); // Show LoginForm when AdminForm closes
                            adminForm.Show();
                            return;
                        }
                    }

                    // Check for Staff login
                    string staffQuery = "SELECT StaffID, Role, CanLogin FROM Staff WHERE Username = @Username AND Password = @Password";
                    using (var staffCommand = new SqlCommand(staffQuery, connection))
                    {
                        staffCommand.Parameters.AddWithValue("@Username", username);
                        staffCommand.Parameters.AddWithValue("@Password", password);

                        using (var reader = staffCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool canLogin = reader.GetBoolean(reader.GetOrdinal("CanLogin"));
                                string role = reader.GetString(reader.GetOrdinal("Role"));
                                int staffID = reader.GetInt32(reader.GetOrdinal("StaffID"));

                                if (!canLogin)
                                {
                                    MessageBox.Show("Your account is disabled. Please contact the administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                MessageBox.Show($"Welcome, {role} {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Redirect based on role
                                EmployeeForm employeeForm = new EmployeeForm(staffID); // Pass StaffID to EmployeeForm
                                this.Hide();
                                employeeForm.FormClosed += (s, ev) => this.Show(); // Show LoginForm when EmployeeForm closes
                                employeeForm.Show();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
