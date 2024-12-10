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
    public partial class ViewKitchen : Form
    {
        public ViewKitchen()
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
    }
}
