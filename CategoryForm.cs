using Microsoft.Identity.Client;
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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
            ConfigureDataGridView(); // Set up columns
            LoadCategories();        // Load data into DataGridView
        }

        private void ConfigureDataGridView()
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.AllowUserToAddRows = false; // Disable adding rows directly in the DataGridView

            // Add CategoryID column (Hidden)
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryID",
                HeaderText = "ID",
                DataPropertyName = "CategoryID",
                Visible = false
            });

            // Add CategoryName column
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Category Name",
                DataPropertyName = "CategoryName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Add DateAdded column
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateAdded",
                HeaderText = "Date Added",
                DataPropertyName = "DateAdded",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add Edit button column
            dgvCategories.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add Delete button column
            dgvCategories.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void LoadCategories(string searchQuery = "")
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                // SQL query to retrieve categories with DateAdded
                var query = "SELECT CategoryID, CategoryName, DateAdded FROM Categories";

                // Add search filtering
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    query += " WHERE CategoryName LIKE @SearchQuery";
                }

                using (var command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    }

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count == 0 && !string.IsNullOrEmpty(searchQuery))
                        {
                            MessageBox.Show("No matching categories found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        dgvCategories.DataSource = table; // Bind data
                    }
                }
            }
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is within valid range
            if (e.RowIndex < 0) return;

            string action = dgvCategories.Columns[e.ColumnIndex].Name; // Get the clicked column name
            int categoryId = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["CategoryID"].Value);

            if (action == "Edit")
            {
                // Handle Edit action
                string currentName = dgvCategories.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                string newName = Prompt.ShowDialog("Edit Category", "Enter new category name:", currentName);

                if (!string.IsNullOrWhiteSpace(newName) && newName != currentName)
                {
                    UpdateCategory(categoryId, newName);
                }
            }
            else if (action == "Delete")
            {
                // Handle Delete action
                var confirmResult = MessageBox.Show("Are you sure you want to delete this category?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    DeleteCategory(categoryId);
                }
            }
        }

        private void UpdateCategory(int categoryId, string newName)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", newName);
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    command.ExecuteNonQuery();
                }
            }

            // Refresh DataGridView
            LoadCategories();
        }

        private void DeleteCategory(int categoryId)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    command.ExecuteNonQuery();
                }
            }

            // Refresh DataGridView
            LoadCategories();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            // Prompt the user for a category name
            string categoryName = Prompt.ShowDialog("Add Category", "Enter new category name:");

            // Validate the input
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Category name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the category to the database
            AddCategoryToDatabase(categoryName);
        }

        private void AddCategoryToDatabase(string categoryName)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                // Check if the category already exists
                var checkQuery = "SELECT COUNT(*) FROM Categories WHERE CategoryName = @CategoryName";
                using (var checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@CategoryName", categoryName);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Category already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Insert the new category with DateAdded
                var insertQuery = "INSERT INTO Categories (CategoryName, DateAdded) VALUES (@CategoryName, GETDATE())";
                using (var insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@CategoryName", categoryName);
                    insertCommand.ExecuteNonQuery();
                }
            }

            // Refresh the DataGridView to show the new category
            LoadCategories();
            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvCategories_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvCategories.Columns[e.ColumnIndex].DataPropertyName; // Get column name
            var dataSource = (DataTable)dgvCategories.DataSource;

            if (dataSource != null)
            {
                // Toggle sorting direction
                string sortDirection = "ASC";
                if (dgvCategories.Tag?.ToString() == columnName + " ASC")
                {
                    sortDirection = "DESC";
                }

                // Apply sorting
                dataSource.DefaultView.Sort = $"{columnName} {sortDirection}";
                dgvCategories.Tag = columnName + " " + sortDirection; // Store the last sort direction
            }
        }

        private void aloneTextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            LoadCategories(searchQuery); // Call the method with the search term
        }
    }
}
