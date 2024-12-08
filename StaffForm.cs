using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadStaff(); // Initialize staff list
        }

        private void ConfigureDataGridView()
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.AllowUserToAddRows = false;

            // Add StaffID column (hidden)
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StaffID",
                HeaderText = "ID",
                DataPropertyName = "StaffID",
                Visible = false
            });

            // Add Full Name column
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Add Role column
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add Contact Number column
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ContactNumber",
                HeaderText = "Contact Number",
                DataPropertyName = "ContactNumber",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add Username column
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                DataPropertyName = "Username",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add Edit button
            dgvStaff.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add Delete button
            dgvStaff.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void LoadStaff(string searchQuery = "")
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "SELECT StaffID, FullName, Role, ContactNumber, Username FROM Staff";

                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    query += " WHERE FullName LIKE @SearchQuery OR Role LIKE @SearchQuery";
                }

                using (var command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    }

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        dgvStaff.DataSource = table;
                    }
                }
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            using (var addStaffForm = new AddStaffForm())
            {
                if (addStaffForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStaff(); // Refresh DataGridView after adding new staff
                }
            }
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvStaff.Columns[e.ColumnIndex].Name;
            int staffID = Convert.ToInt32(dgvStaff.Rows[e.RowIndex].Cells["StaffID"].Value);

            if (columnName == "Edit")
            {
                EditStaff(staffID);
            }
            else if (columnName == "Delete")
            {
                DeleteStaff(staffID);
            }
        }

        private void EditStaff(int staffID)
        {
            using (var editStaffForm = new AddStaffForm(staffID))
            {
                if (editStaffForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStaff(); // Refresh the DataGridView
                }
            }
        }


        private void DeleteStaff(int staffID)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this staff member?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
                {
                    connection.Open();
                    var query = "DELETE FROM Staff WHERE StaffID = @StaffID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StaffID", staffID);
                        command.ExecuteNonQuery();
                    }
                }

                LoadStaff(); // Refresh DataGridView after deleting staff
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            LoadStaff(searchQuery);
        }
    }
}
