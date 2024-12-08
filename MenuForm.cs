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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            ConfigureDataGridView(); // Set up the DataGridView columns
            LoadCategories();        // Load categories into the ComboBox
        }

        private void ConfigureDataGridView()
        {
            dgvMenuItems.RowTemplate.Height = 100;

            dgvMenuItems.AutoGenerateColumns = false;
            dgvMenuItems.AllowUserToAddRows = false;
            dgvMenuItems.AllowUserToOrderColumns = true;
            dgvMenuItems.ReadOnly = true;

            // Add hidden MenuItemID column
            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MenuItemID",
                HeaderText = "ID",
                DataPropertyName = "MenuItemID",
                Visible = false // Hide this column
            });

            // Add Image column
            dgvMenuItems.Columns.Add(new DataGridViewImageColumn
            {
                Name = "DisplayImage",
                HeaderText = "Image",
                DataPropertyName = "DisplayImage",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            });

            // Add other columns (ItemName, CategoryName, etc.)
            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemName",
                HeaderText = "Item Name",
                DataPropertyName = "ItemName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Category",
                DataPropertyName = "CategoryName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvMenuItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockQuantity",
                HeaderText = "Stock Quantity",
                DataPropertyName = "StockQuantity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add Edit button column
            dgvMenuItems.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Add Delete button column
            dgvMenuItems.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }





        private void LoadCategories()
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "SELECT CategoryID, CategoryName FROM Categories";
                using (var command = new SqlCommand(query, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    var table = new DataTable();
                    adapter.Fill(table);

                    // Add an "All Categories" option
                    var allRow = table.NewRow();
                    allRow["CategoryID"] = DBNull.Value;
                    allRow["CategoryName"] = "All Categories";
                    table.Rows.InsertAt(allRow, 0);

                    cmbCategories.DisplayMember = "CategoryName";
                    cmbCategories.ValueMember = "CategoryID";
                    cmbCategories.DataSource = table;
                }
            }
        }

        private void LoadMenuItems(string searchQuery = "", object categoryID = null)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                // Base query
                var query = @"SELECT m.MenuItemID, m.ItemName, c.CategoryName, m.Price, m.StockQuantity, m.ItemImage
                      FROM MenuItems m
                      INNER JOIN Categories c ON m.CategoryID = c.CategoryID";

                // Add filters
                var filters = new List<string>();
                if (categoryID != null && categoryID != DBNull.Value)
                {
                    filters.Add("m.CategoryID = @CategoryID");
                }
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    filters.Add("m.ItemName LIKE @SearchQuery");
                }
                if (filters.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", filters);
                }

                using (var command = new SqlCommand(query, connection))
                {
                    if (categoryID != null && categoryID != DBNull.Value)
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                    }
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    }

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);

                        // Add DisplayImage column
                        table.Columns.Add("DisplayImage", typeof(Image));

                        foreach (DataRow row in table.Rows)
                        {
                            if (row["ItemImage"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])row["ItemImage"];
                                using (var ms = new MemoryStream(imageData))
                                {
                                    row["DisplayImage"] = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                row["DisplayImage"] = null;
                            }
                        }

                        dgvMenuItems.DataSource = table;
                    }
                }
            }
        }




        private void btnAddMenuItem_Click(object sender, EventArgs e)
        {
            using (var addMenuItemForm = new AddMenuItemForm())
            {
                if (addMenuItemForm.ShowDialog() == DialogResult.OK)
                {
                    // Save the returned data to the database
                    SaveMenuItemToDatabase(addMenuItemForm.ItemName, addMenuItemForm.Price, addMenuItemForm.StockQuantity, addMenuItemForm.CategoryID, addMenuItemForm.ItemImage);

                    // Refresh the DataGridView to show the new menu item
                    LoadMenuItems();
                }
            }
        }
        private void SaveMenuItemToDatabase(string itemName, decimal price, int stockQuantity, int categoryID, byte[] itemImage)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "INSERT INTO MenuItems (ItemName, CategoryID, Price, StockQuantity, ItemImage) VALUES (@ItemName, @CategoryID, @Price, @StockQuantity, @ItemImage)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemName", itemName);
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@StockQuantity", stockQuantity);

                    if (itemImage != null)
                    {
                        command.Parameters.AddWithValue("@ItemImage", itemImage);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ItemImage", DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            LoadMenuItems(searchQuery, cmbCategories.SelectedValue);
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenuItems(txtSearch.Text.Trim(), cmbCategories.SelectedValue);
        }


        private void dgvMenuItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvMenuItems.Columns[e.ColumnIndex].Name;
            int menuItemID = Convert.ToInt32(dgvMenuItems.Rows[e.RowIndex].Cells["MenuItemID"].Value);

            if (columnName == "Edit")
            {
                EditMenuItem(menuItemID);
            }
            else if (columnName == "Delete")
            {
                DeleteMenuItem(menuItemID);
            }
        }

        private void EditMenuItem(int menuItemID)
        {
            using (AddMenuItemForm addMenuItemForm = new AddMenuItemForm(menuItemID))
            {
                if (addMenuItemForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateMenuItem(menuItemID, addMenuItemForm);
                }
            }
        }

        private void UpdateMenuItem(int menuItemID, AddMenuItemForm form)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                var query = @"UPDATE MenuItems 
                      SET ItemName = @ItemName, 
                          CategoryID = @CategoryID, 
                          Price = @Price, 
                          StockQuantity = @StockQuantity, 
                          ItemImage = @ItemImage 
                      WHERE MenuItemID = @MenuItemID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MenuItemID", menuItemID);
                    command.Parameters.AddWithValue("@ItemName", form.ItemName);
                    command.Parameters.AddWithValue("@CategoryID", form.CategoryID);
                    command.Parameters.AddWithValue("@Price", form.Price);
                    command.Parameters.AddWithValue("@StockQuantity", form.StockQuantity);

                    if (form.ItemImage != null)
                    {
                        command.Parameters.AddWithValue("@ItemImage", form.ItemImage);
                    }
                    else
                    {
                        command.Parameters.Add("@ItemImage", SqlDbType.VarBinary).Value = DBNull.Value;
                    }

                    command.ExecuteNonQuery();
                }
            }

            LoadMenuItems(); // Refresh the DataGridView
            MessageBox.Show("Menu item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteMenuItem(int menuItemID)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this menu item?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
                {
                    connection.Open();

                    var query = "DELETE FROM MenuItems WHERE MenuItemID = @MenuItemID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MenuItemID", menuItemID);
                        command.ExecuteNonQuery();
                    }
                }

                // Refresh the DataGridView
                LoadMenuItems();
                MessageBox.Show("Menu item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
