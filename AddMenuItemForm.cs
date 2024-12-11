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
    public partial class AddMenuItemForm : Form
    {
        public string ItemName { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public int CategoryID { get; private set; }
        public byte[] ItemImage { get; private set; }
        public int? MenuItemID { get; private set; } // Nullable to indicate add vs edit


        public AddMenuItemForm(int? menuItemID = null)
        {
            InitializeComponent();

            LoadCategories(); // Load categories into the ComboBox

            if (menuItemID.HasValue)
            {
                LoadMenuItemDetails(menuItemID.Value); // Load data for editing if MenuItemID is provided
            }
        }

        private void LoadMenuItemDetails(int menuItemID)
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();
                var query = "SELECT ItemName, CategoryID, Price, StockQuantity, ItemImage FROM MenuItems WHERE MenuItemID = @MenuItemID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MenuItemID", menuItemID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtItemName.Text = reader["ItemName"].ToString();
                            cmbCategories.SelectedValue = reader["CategoryID"];
                            numPrice.Value = Convert.ToDecimal(reader["Price"]);
                            numStockQuantity.Value = Convert.ToInt32(reader["StockQuantity"]);

                            if (reader["ItemImage"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["ItemImage"];
                                using (var ms = new MemoryStream(imageData))
                                {
                                    picItemImage.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

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

                    MessageBox.Show($"Categories Loaded: {table.Rows.Count}"); // Debug message

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("No categories available. Please add categories first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    cmbCategories.DisplayMember = "CategoryName";
                    cmbCategories.ValueMember = "CategoryID";
                    cmbCategories.DataSource = table;
                }
            }
        }




        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the image into memory
                        using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            var img = Image.FromStream(fs);
                            picItemImage.Image = new Bitmap(img);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter the item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategories.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Capture inputs
            ItemName = txtItemName.Text.Trim();
            Price = numPrice.Value;
            StockQuantity = (int)numStockQuantity.Value;
            CategoryID = (int)cmbCategories.SelectedValue;

            if (picItemImage.Image != null)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        // Create a copy of the image in memory
                        Bitmap bmp = new Bitmap(picItemImage.Image);
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Save as JPEG or desired format
                        ItemImage = ms.ToArray(); // Convert to byte array
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            DialogResult = DialogResult.OK; // Close the form and return to parent form
            Close();
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Close the form without saving
            Close();
        }

        private void numPrice_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
