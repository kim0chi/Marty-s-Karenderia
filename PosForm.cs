using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class PosForm : Form
    {
        private DataTable cartTable;

        public PosForm()
        {
            InitializeComponent();
            InitializeCartTable();
            LoadCategories();
            LoadProducts();
            ConfigureCartGridView();
            ConfigureCartGrid();
        }

        // Initializes the cart DataTable
        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ProductID", typeof(int));
            cartTable.Columns.Add("ProductName", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Subtotal", typeof(decimal));
            dgvCart.DataSource = cartTable;
        }

        private void LoadProducts(int? categoryID = null)
        {
            flowProducts.Controls.Clear();

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "SELECT MenuItemID AS ProductID, ItemName AS ProductName, Price, ItemImage FROM MenuItems";
                if (categoryID.HasValue)
                {
                    query += " WHERE CategoryID = @CategoryID";
                }

                using (var command = new SqlCommand(query, connection))
                {
                    if (categoryID.HasValue)
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID.Value);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productTile = new ProductTile
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductName = reader["ProductName"].ToString(),
                                Price = (decimal)reader["Price"],
                                ProductImage = reader["ItemImage"] != DBNull.Value
                                    ? Image.FromStream(new MemoryStream((byte[])reader["ItemImage"]))
                                    : null
                            };

                            productTile.ProductClicked += (s, e) => AddToCart(productTile);
                            flowProducts.Controls.Add(productTile);
                        }
                    }
                }
            }
        }
        private void ConfigureCartGrid()
        {
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductID",
                HeaderText = "Product ID",
                DataPropertyName = "ProductID",
                Visible = false
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product Name",
                DataPropertyName = "ProductName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Quantity",
                DataPropertyName = "Quantity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            });

            dgvCart.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });
        }



        private void LoadCategories()
        {
            panelCategories.Controls.Clear(); // Clear existing buttons

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "SELECT CategoryID, CategoryName FROM Categories";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Button btnCategory = new Button
                        {
                            Text = reader["CategoryName"].ToString(),
                            Tag = reader["CategoryID"],
                            Width = 100,
                            Height = 50,
                            Margin = new Padding(5)
                        };

                        btnCategory.Click += (s, e) =>
                        {
                            int categoryID = (int)((Button)s).Tag;
                            LoadProducts(categoryID); // Load products for the selected category
                        };

                        panelCategories.Controls.Add(btnCategory); // Add button to the panel
                    }
                }
            }
        }


        private void AddToCart(ProductTile productTile)
        {
            // Check if the product already exists in the cart
            var existingRow = cartTable.AsEnumerable()
                .FirstOrDefault(row => row.Field<int?>("ProductID") == productTile.ProductID);

            if (existingRow != null)
            {
                // Update quantity and subtotal
                int currentQuantity = existingRow.Field<int>("Quantity");
                int newQuantity = currentQuantity + 1;
                existingRow["Quantity"] = newQuantity;
                existingRow["Subtotal"] = newQuantity * productTile.Price;
            }
            else
            {
                // Add new product to the cart
                cartTable.Rows.Add(productTile.ProductID, productTile.ProductName, 1, productTile.Price, productTile.Price);
            }

            UpdateSummary();
        }


        private void UpdateSummary()
        {
            decimal subtotal = cartTable.AsEnumerable().Sum(row => row.Field<decimal>("Subtotal"));
            decimal tax = subtotal * 0.12m; // Example tax rate
            decimal total = subtotal + tax;

            lblSubtotal.Text = $"Subtotal: {subtotal:C2}";
            lblTax.Text = $"Tax: {tax:C2}";
            lblTotal.Text = $"Total: {total:C2}";
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            cartTable.Clear();
            UpdateSummary();
        }

        private void btnFinalizeSale_Click(object sender, EventArgs e)
        {
            if (!ValidateOrderType()) return;

            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add items to the cart before finalizing.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save transaction to the database
            SaveTransaction();

            // Print receipt
            PrintReceipt();

            // Clear the order
            btnClearOrder_Click(null, null);
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminAccountForm admin = new AdminAccountForm(); // Replace with Admin or Employee form logic
            admin.Show();
        }


        private bool ValidateOrderType()
        {
            if (!rbDineIn.Checked && !rbTakeout.Checked)
            {
                MessageBox.Show("Please select either Dine-In or Takeout.", "Order Type Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvCart.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                // Edit functionality
                int quantity = int.Parse(dgvCart.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                string quantityString = quantity.ToString(); // Convert to string
                string newQuantityInput = Prompt.ShowDialog("Edit Quantity", "Enter new quantity:", quantityString);

                if (int.TryParse(newQuantityInput, out int newQuantity) && newQuantity > 0)
                {
                    dgvCart.Rows[e.RowIndex].Cells["Quantity"].Value = newQuantity;
                    UpdateCart();
                }
                else
                {
                    MessageBox.Show("Invalid quantity entered. Please enter a valid number greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (columnName == "Delete")
            {
                // Delete functionality
                dgvCart.Rows.RemoveAt(e.RowIndex);
                UpdateCart();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvCart.Rows.Clear();
            rbDineIn.Checked = false;
            rbTakeout.Checked = false;
            UpdateSummary();
        }

        private void txtSearch_TextChanged(object sender, EventArgs args)
        {
            string searchQuery = txtSearch.Text.Trim();

            flowProducts.Controls.Clear();

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "SELECT MenuItemID AS ProductID, ItemName AS ProductName, Price, ItemImage FROM MenuItems WHERE ItemName LIKE @SearchQuery";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productTile = new ProductTile
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductName = reader["ProductName"].ToString(),
                                Price = (decimal)reader["Price"],
                                ProductImage = reader["ItemImage"] != DBNull.Value
                                    ? Image.FromStream(new MemoryStream((byte[])reader["ItemImage"]))
                                    : null
                            };

                            productTile.ProductClicked += (s, e) => AddToCart(productTile);
                            flowProducts.Controls.Add(productTile);
                        }
                    }
                }
            }
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            using (var historyForm = new TransactionHistoryForm())
            {
                historyForm.ShowDialog();
            }
        }
        private void ConfigureCartGridView()
        {
            dgvCart.AutoGenerateColumns = false;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductID",
                DataPropertyName = "ProductID",
                HeaderText = "ID",
                Visible = false
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                DataPropertyName = "ProductName",
                HeaderText = "Product Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                DataPropertyName = "Quantity",
                HeaderText = "Quantity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                DataPropertyName = "Price",
                HeaderText = "Price",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                DataPropertyName = "Subtotal",
                HeaderText = "Subtotal",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            });

            dgvCart.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });
        }

        private void SaveTransaction()
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                // Save the main order
                var query = @"
            INSERT INTO Orders (OrderDate, TotalAmount, OrderType)
            OUTPUT INSERTED.OrderID
            VALUES (@Date, @TotalAmount, @OrderType)";

                int orderID;

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.AddWithValue("@TotalAmount", cartTable.AsEnumerable().Sum(row => row.Field<decimal>("Subtotal")));
                    command.Parameters.AddWithValue("@OrderType", rbDineIn.Checked ? "Dine-In" : "Takeout");

                    // Retrieve the generated OrderID
                    orderID = (int)command.ExecuteScalar();
                }

                // Save order details
                foreach (DataRow row in cartTable.Rows)
                {
                    int menuID = Convert.ToInt32(row["ProductID"]);

                    // Debugging: Ensure the MenuID exists
                    var checkQuery = "SELECT COUNT(*) FROM Menu WHERE MenuID = @MenuID";
                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MenuID", menuID);
                        int exists = (int)checkCommand.ExecuteScalar();

                        if (exists == 0)
                        {
                            MessageBox.Show($"Invalid MenuID: {menuID}. Ensure it exists in the Menu table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }

                    var itemQuery = @"
                INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal)
                VALUES (@OrderID, @MenuID, @Quantity, @Subtotal)";

                    using (var itemCommand = new SqlCommand(itemQuery, connection))
                    {
                        itemCommand.Parameters.AddWithValue("@OrderID", orderID);
                        itemCommand.Parameters.AddWithValue("@MenuID", menuID);
                        itemCommand.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        itemCommand.Parameters.AddWithValue("@Subtotal", row["Subtotal"]);

                        itemCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private void PrintReceipt()
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("Receipt");
            receipt.AppendLine("---------------------------");
            foreach (DataRow row in cartTable.Rows)
            {
                receipt.AppendLine($"{row["ProductName"]} x{row["Quantity"]} @ {row["Price"]:C2} = {row["Subtotal"]:C2}");
            }
            receipt.AppendLine("---------------------------");
            receipt.AppendLine($"Subtotal: {lblSubtotal.Text}");
            receipt.AppendLine($"Tax: {lblTax.Text}");
            receipt.AppendLine($"Total: {lblTotal.Text}");

            MessageBox.Show("Receipt Printed!", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show(receipt.ToString(), "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void UpdateCart()
        {
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["Quantity"].Value != null && row.Cells["Price"].Value != null)
                {
                    int quantity = row.Cells["Quantity"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["Quantity"].Value) : 0;
                    decimal price = row.Cells["Price"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Price"].Value) : 0;

                    row.Cells["Subtotal"].Value = quantity * price;
                }
            }
            UpdateSummary();
        }


    }
}
