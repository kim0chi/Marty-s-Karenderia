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
    public partial class AddStaffForm : Form
    {
        public int? StaffID { get; private set; }
        public AddStaffForm(int? staffID = null)
        {
            InitializeComponent();

            StaffID = staffID; // Set the StaffID
            LoadRoles(); // Load roles into ComboBox

            if (staffID.HasValue)
            {
                LoadStaffDetails(staffID.Value); // Load data for editing
            }

            // Initialize password visibility
            txtPassword.UseSystemPasswordChar = true;
            cboxShowPassword.CheckedChanged += cboxShowPassword_CheckedChanged;
        }


        private void LoadRoles()
        {
            // Example roles, you can load these from a database if needed
            var roles = new List<string> { "Cashier", "Chef", "Waiter" };
            cmbRole.DataSource = roles;
        }

        private void LoadStaffDetails(int staffID)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "SELECT FullName, Role, ContactNumber, Username, Password FROM Staff WHERE StaffID = @StaffID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", staffID);

                    using (var reader = command.ExecuteReader())
                    { 
                        if (reader.Read())
                        {
                            txtFullName.Text = reader["FullName"].ToString();
                            cmbRole.SelectedItem = reader["Role"].ToString();
                            txtContactNumber.Text = reader["ContactNumber"].ToString();
                            txtUsername.Text = reader["Username"].ToString();

                            // Load the password (if storing plaintext; otherwise skip this step)
                            txtPassword.Text = reader["Password"].ToString();
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text) ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                string query;
                if (StaffID.HasValue)
                {
                    // Update existing staff
                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        query = "UPDATE Staff SET FullName = @FullName, Role = @Role, ContactNumber = @ContactNumber, Username = @Username WHERE StaffID = @StaffID";
                    }
                    else
                    {
                        query = "UPDATE Staff SET FullName = @FullName, Role = @Role, ContactNumber = @ContactNumber, Username = @Username, Password = @Password WHERE StaffID = @StaffID";
                    }
                }
                else
                {
                    // Add new staff
                    query = "INSERT INTO Staff (FullName, Role, ContactNumber, Username, Password) VALUES (@FullName, @Role, @ContactNumber, @Username, @Password)";
                }

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    command.Parameters.AddWithValue("@Role", cmbRole.Text);
                    command.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text.Trim());
                    command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());

                    if (StaffID.HasValue)
                    {
                        command.Parameters.AddWithValue("@StaffID", StaffID.Value);

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        }
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    }

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(StaffID.HasValue ? "Staff updated successfully!" : "Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Close the form without saving
            Close();
        }

        private void cboxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !cboxShowPassword.Checked;
        }

    }
}
