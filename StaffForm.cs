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
            dgvStaff.CellValueChanged += dgvStaff_CellValueChanged;
            dgvStaff.CellEndEdit += dgvStaff_CellEndEdit;

        }

        private void ConfigureDataGridView()
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.AllowUserToAddRows = false;

            // StaffID (hidden)
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StaffID",
                HeaderText = "ID",
                DataPropertyName = "StaffID",
                Visible = false
            });

            // Full Name
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Role
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Contact Number
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ContactNumber",
                HeaderText = "Contact Number",
                DataPropertyName = "ContactNumber",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Username
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                DataPropertyName = "Username",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add "Can Login" checkbox column
            dgvStaff.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "CanLogin",
                HeaderText = "Can Login",
                DataPropertyName = "CanLogin",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = false // Editable
            });



            // Edit button
            dgvStaff.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Delete button
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
            dgvStaff.CellValueChanged -= dgvStaff_CellValueChanged; // Temporarily unsubscribe

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = @"
        SELECT StaffID, FullName, Role, ContactNumber, Username, CanLogin
        FROM Staff
        WHERE Role != 'Admin'";

                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    query += " AND (FullName LIKE @SearchQuery OR Role LIKE @SearchQuery)";
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

            dgvStaff.CellValueChanged += dgvStaff_CellValueChanged; // Re-subscribe
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

        private void DgvStaff_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvStaff.IsCurrentCellDirty)
            {
                dgvStaff.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvStaff_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvStaff.Columns[e.ColumnIndex].Name == "CanLogin")
            {
                int staffID = Convert.ToInt32(dgvStaff.Rows[e.RowIndex].Cells["StaffID"].Value);
                bool canLogin = Convert.ToBoolean(dgvStaff.Rows[e.RowIndex].Cells["CanLogin"].Value);

                UpdateCanLoginStatus(staffID, canLogin);
            }
        }
        private void UpdateCanLoginStatus(int staffID, bool canLogin)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "UPDATE Staff SET CanLogin = @CanLogin WHERE StaffID = @StaffID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CanLogin", canLogin);
                    command.Parameters.AddWithValue("@StaffID", staffID);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void dgvStaff_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStaff.Columns[e.ColumnIndex].Name == "CanLogin")
            {
                int staffID = Convert.ToInt32(dgvStaff.Rows[e.RowIndex].Cells["StaffID"].Value);
                bool canLogin = Convert.ToBoolean(dgvStaff.Rows[e.RowIndex].Cells["CanLogin"].Value);

                UpdateCanLoginStatus(staffID, canLogin);
            }
        }

    }
}
