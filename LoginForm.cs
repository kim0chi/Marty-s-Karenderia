using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Ensure the password is masked when the form loads
            txtPassword.UseSystemPasswordChar = false;

            // Ensure the checkbox reflects the initial state (unchecked)
            cboxShowPassword.Checked = false;
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
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        var role = command.ExecuteScalar();
                        if (role != null)
                        {
                            // Navigate to the respective form based on the role
                            if (role.ToString() == "Admin")
                            {
                                MessageBox.Show($"Welcome, Admin {username}!");
                                AdminForm adminForm = new AdminForm(); // Ensure AdminForm exists
                                this.Hide();
                                adminForm.Show();
                            }
                            else if (role.ToString() == "Employee")
                            {
                                MessageBox.Show($"Welcome, Employee {username}!");
                                EmployeeForm employeeForm = new EmployeeForm(); // Ensure EmployeeForm exists
                                this.Hide();
                                employeeForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid credentials! Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
