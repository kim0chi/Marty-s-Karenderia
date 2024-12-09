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
    public partial class TransactionHistoryForm : Form
    {
        public TransactionHistoryForm()
        {
            InitializeComponent();
            LoadTransactionHistory();
        }

        private void LoadTransactionHistory()
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                string query = @"
            SELECT 
                o.OrderID AS TransactionID,
                o.OrderDate AS Date,
                o.TotalAmount,
                CASE 
                    WHEN o.TableNumber IS NULL THEN 'Takeout'
                    ELSE 'Dine-In'
                END AS OrderType,
                p.PaymentAmount,
                p.PaymentMethod
            FROM 
                Orders o
            LEFT JOIN 
                Payments p ON o.OrderID = p.OrderID";

                using (var command = new SqlCommand(query, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    var table = new DataTable();
                    adapter.Fill(table);

                    dgvTransactionHistory.DataSource = table;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
