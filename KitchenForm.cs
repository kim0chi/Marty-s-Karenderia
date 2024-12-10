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
    public partial class KitchenForm : Form
    {
        public KitchenForm()
        {
            InitializeComponent();
            LoadKitchenOrders();
        }
        private void LoadKitchenOrders()
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT OrderID, OrderDate, OrderStatus FROM Orders WHERE OrderStatus IN ('Pending', 'In Progress')";

                using (var command = new SqlCommand(query, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvKitchenOrders.DataSource = table;
                }
            }
        }


        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (dgvKitchenOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to mark as completed.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = (int)dgvKitchenOrders.SelectedRows[0].Cells["OrderID"].Value;

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                string query = "UPDATE Orders SET OrderStatus = 'Completed' WHERE OrderID = @OrderID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Order marked as completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadKitchenOrders(); // Refresh the order list
        }
        private void btnMarkInProgress_Click(object sender, EventArgs e)
        {
            if (dgvKitchenOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to mark as in progress.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = (int)dgvKitchenOrders.SelectedRows[0].Cells["OrderID"].Value;

            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                string query = "UPDATE Orders SET OrderStatus = 'In Progress' WHERE OrderID = @OrderID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderId);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Order marked as in progress!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKitchenOrders(); // Refresh the order list
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
