using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using DrawingImage = System.Drawing.Image;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ReaLTaiizor.Forms;



namespace Marty_s_Karenderia
{
    public partial class PosForm : Form
    {
        private DataTable cartTable;
        private Form parentForm;

        public PosForm(Form parent)
        {
            InitializeComponent();
            InitializeCartTable();
            LoadCategories();
            LoadProducts();
            ConfigureCartGridView();
            ConfigureCartGrid();
            LoadAllCategories();
            this.FormClosed += new FormClosedEventHandler(PosForm_FormClosed);
            parentForm = parent;

        }
        private void PosForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the parent form when POSForm is closed
            parentForm.Show();
        }

        // Initializes the cart DataTable
        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ProductID", typeof(int));
            cartTable.Columns.Add("ProductName", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Subtotal", typeof(decimal)).DefaultValue = 0m; // Default value set to 0
            dgvCart.DataSource = cartTable;
        }


        private void LoadProducts(int? categoryID = null)
        {
            flowProducts.Controls.Clear();

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "SELECT MenuItemID AS ProductID, ItemName AS ProductName, Price, ItemImage, CategoryID FROM MenuItems";
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
                                    ? DrawingImage.FromStream(new MemoryStream((byte[])reader["ItemImage"]))
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

            // Add "All Categories" button
            Button btnAllCategories = new Button
            {
                Text = "All Categories",
                Width = 100,
                Height = 50,
                Margin = new Padding(5)
            };
            btnAllCategories.Click += (s, e) => LoadProducts(); // Load all products
            panelCategories.Controls.Add(btnAllCategories);

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

                        panelCategories.Controls.Add(btnCategory); // Add category button
                    }
                }
            }

            panelCategories.Refresh(); // Ensure UI updates
        }



        private void AddToCart(ProductTile productTile)
        {
            // Check if the product already exists in the cart
            var existingRow = cartTable.AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("ProductID") == productTile.ProductID);

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
            decimal subtotal = cartTable.AsEnumerable()
    .Where(row => row["Subtotal"] != DBNull.Value)
    .Sum(row => row.Field<decimal>("Subtotal"))
;
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

            // Example default values (replace with actual logic if needed)
            decimal amountPaid = 0m;
            decimal change = 0m;
            string paymentMethod = "Unspecified";

            // Save transaction to the database
            SaveTransaction(amountPaid, change, paymentMethod);

            // Generate receipt
            GenerateReceiptPDF(amountPaid, change);

            // Clear the order
            btnClearOrder_Click(null, null);
        }




        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            dgvCart.AllowUserToAddRows = false;
      
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvCart.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                // Check if the Quantity cell is not null and contains a valid integer
                if (dgvCart.Rows[e.RowIndex].Cells["Quantity"].Value != null &&
                    int.TryParse(dgvCart.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out int quantity))
                {
                    string quantityString = quantity.ToString(); // Convert to string
                    string newQuantityInput = Prompt.ShowDialog("Edit Quantity", "Enter new quantity:", quantityString);

                    // Validate the new input for quantity
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
                else
                {
                    MessageBox.Show("The current quantity value is invalid or missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    ? DrawingImage.FromStream(new MemoryStream((byte[])reader["ItemImage"]))
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

        private void SaveTransaction(decimal amountPaid, decimal change, string paymentMethod)
        {
            RemoveEmptyRows();

            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add items to the cart before finalizing.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                // Calculate subtotal, tax, and total
                decimal subtotal = cartTable.AsEnumerable()
                    .Where(row => row["Subtotal"] != DBNull.Value)
                    .Sum(row => row.Field<decimal>("Subtotal"));
                decimal tax = subtotal * 0.12m; // Example 12% tax rate
                decimal total = subtotal + tax;

                // Save the main order
                var query = @"
                INSERT INTO Orders (OrderDate, TotalAmount, OrderType, TaxAmount, ChangeAmount)
                OUTPUT INSERTED.OrderID
                VALUES (@Date, @TotalAmount, @OrderType, @TaxAmount, @ChangeAmount)";

                int orderID;

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.AddWithValue("@TotalAmount", total);
                    command.Parameters.AddWithValue("@OrderType", rbDineIn.Checked ? "Dine-In" : "Takeout");
                    command.Parameters.AddWithValue("@TaxAmount", tax);
                    command.Parameters.AddWithValue("@ChangeAmount", change);

                    orderID = (int)command.ExecuteScalar();
                }

                // Save order details
                foreach (DataRow row in cartTable.Rows)
                {
                    var itemQuery = @"
    INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal)
    VALUES (@OrderID, @MenuID, @Quantity, @Subtotal)";

                    using (var itemCommand = new SqlCommand(itemQuery, connection))
                    {
                        itemCommand.Parameters.AddWithValue("@OrderID", orderID);
                        itemCommand.Parameters.AddWithValue("@MenuID", row["ProductID"]);
                        itemCommand.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        itemCommand.Parameters.AddWithValue("@Subtotal", row["Subtotal"]);

                        itemCommand.ExecuteNonQuery();
                    }
                }

                // Save payment details
                SavePaymentDetails(connection, orderID, amountPaid, change, paymentMethod, tax);
            }
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

        private void RemoveEmptyRows()
        {
            foreach (DataRow row in cartTable.Rows.Cast<DataRow>().ToList())
            {
                if (row["Subtotal"] == DBNull.Value || Convert.ToDecimal(row["Subtotal"]) <= 0)
                {
                    cartTable.Rows.Remove(row);
                }
            }
        }

        private void LoadAllCategories()
        {
            Button btnAllCategories = new Button
            {
                Text = "All Categories",
                Width = 100,
                Height = 50,
                Margin = new Padding(5)
            };

            btnAllCategories.Click += (s, e) => LoadProducts();

            panelCategories.Controls.Add(btnAllCategories);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            // Validate if the cart has items
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add items to the cart before proceeding to payment.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate if an order type is selected (Dine-In or Takeout)
            if (!ValidateOrderType()) return;

            // Calculate totals
            decimal subtotal = cartTable.AsEnumerable()
                .Where(row => row["Subtotal"] != DBNull.Value)
                .Sum(row => row.Field<decimal>("Subtotal"));
            decimal tax = subtotal * 0.12m; // Example 12% tax
            decimal total = subtotal + tax;

            // Open the payment form
            using (var paymentForm = new PaymentForm(total))
            {
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve payment details
                    decimal amountPaid = paymentForm.AmountPaid;
                    decimal change = paymentForm.Change;
                    string paymentMethod = paymentForm.PaymentMethod;

                    MessageBox.Show($"Payment Successful!\nChange: ₱{change:F2}\nMethod: {paymentMethod}", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Save transaction and payment details
                    SaveTransaction(amountPaid, change, paymentMethod);

                    // Generate the receipt with payment details
                    GenerateReceiptPDF(amountPaid, change);

                    // Clear the cart after payment
                    btnClearOrder_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Payment canceled. The transaction was not completed.", "Payment Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void GenerateReceiptPDF(decimal amountPaid, decimal change)
        {
            string fileName = $"Receipt_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Marty's Karenderia Receipt";

            // Add a page
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Define fonts
            XFont titleFont = new XFont("Verdana", 16);
            XFont regularFont = new XFont("Verdana", 12);
            XFont italicFont = new XFont("Verdana", 10);

            // Draw title
            gfx.DrawString("Marty's Karenderia Receipt", titleFont, XBrushes.Black,
                new XRect(0, 20, page.Width, 40), XStringFormats.TopCenter);

            // Draw date and time
            gfx.DrawString($"Date: {DateTime.Now:MM/dd/yyyy HH:mm}", regularFont, XBrushes.Black,
                new XRect(40, 60, page.Width, 20), XStringFormats.TopLeft);

            // Draw column headers
            int yPoint = 100;
            gfx.DrawString("Product Name", regularFont, XBrushes.Black, new XRect(40, yPoint, 200, 20), XStringFormats.TopLeft);
            gfx.DrawString("Qty", regularFont, XBrushes.Black, new XRect(240, yPoint, 50, 20), XStringFormats.TopLeft);
            gfx.DrawString("Price", regularFont, XBrushes.Black, new XRect(290, yPoint, 70, 20), XStringFormats.TopLeft);
            gfx.DrawString("Subtotal", regularFont, XBrushes.Black, new XRect(360, yPoint, 80, 20), XStringFormats.TopLeft);

            yPoint += 20;

            // Loop through cart items and add them to the receipt
            foreach (DataRow row in cartTable.Rows)
            {
                gfx.DrawString(row["ProductName"].ToString(), regularFont, XBrushes.Black, new XRect(40, yPoint, 200, 20), XStringFormats.TopLeft);
                gfx.DrawString(row["Quantity"].ToString(), regularFont, XBrushes.Black, new XRect(240, yPoint, 50, 20), XStringFormats.TopLeft);
                gfx.DrawString($"₱{Convert.ToDecimal(row["Price"]):F2}", regularFont, XBrushes.Black, new XRect(290, yPoint, 70, 20), XStringFormats.TopLeft);
                gfx.DrawString($"₱{Convert.ToDecimal(row["Subtotal"]):F2}", regularFont, XBrushes.Black, new XRect(360, yPoint, 80, 20), XStringFormats.TopLeft);
                yPoint += 20;
            }

            // Calculate totals
            decimal subtotal = cartTable.AsEnumerable()
                .Where(row => row["Subtotal"] != DBNull.Value)
                .Sum(row => row.Field<decimal>("Subtotal"));
            decimal tax = subtotal * 0.12m; // 12% tax
            decimal total = subtotal + tax;

            // Draw totals
            yPoint += 20;
            gfx.DrawString($"Subtotal: ₱{subtotal:F2}", regularFont, XBrushes.Black,
                new XRect(360, yPoint, 200, 20), XStringFormats.TopLeft);
            yPoint += 20;
            gfx.DrawString($"Tax (12%): ₱{tax:F2}", regularFont, XBrushes.Black,
                new XRect(360, yPoint, 200, 20), XStringFormats.TopLeft);
            yPoint += 20;
            gfx.DrawString($"Total: ₱{total:F2}", titleFont, XBrushes.Black,
                new XRect(360, yPoint, 200, 20), XStringFormats.TopLeft);

            // Include amount paid and change 
            yPoint += 20;
            gfx.DrawString($"Amount Paid: ₱{amountPaid:F2}", regularFont, XBrushes.Black,
                new XRect(360, yPoint, 200, 20), XStringFormats.TopLeft);
            yPoint += 20;
            gfx.DrawString($"Change: ₱{change:F2}", regularFont, XBrushes.Black,
                new XRect(360, yPoint, 200, 20), XStringFormats.TopLeft);

            // Add a thank-you note
            yPoint += 40;
            gfx.DrawString("Thank you for dining with us!", italicFont, XBrushes.Black,
                new XRect(0, yPoint, page.Width, 20), XStringFormats.TopCenter);

            // Save the document
            document.Save(filePath);

            // Automatically open the PDF
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true // Ensures it opens with the default PDF viewer
            });
        }

        private void SavePaymentDetails(SqlConnection connection, int orderID, decimal amountPaid, decimal change, string paymentMethod, decimal tax)
        {
            var query = @"
            INSERT INTO Payments (OrderID, PaymentAmount, PaymentMethod, ChangeAmount, PaymentDate, TaxAmount)
            VALUES (@OrderID, @PaymentAmount, @PaymentMethod, @ChangeAmount, @PaymentDate, @TaxAmount)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderID", orderID);
                command.Parameters.AddWithValue("@PaymentAmount", amountPaid);
                command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                command.Parameters.AddWithValue("@ChangeAmount", change);
                command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                command.Parameters.AddWithValue("@TaxAmount", tax);

                command.ExecuteNonQuery();
            }
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            using (var kitchenForm = new ViewKitchen())
            {
                kitchenForm.ShowDialog();
            }
        }
    }
}
