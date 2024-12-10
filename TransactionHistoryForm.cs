using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class TransactionHistoryForm : Form
    {
        public TransactionHistoryForm()
        {
            InitializeComponent();
            LoadTransactionHistory();
            ConfigureDataGridView();
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

        private void ConfigureDataGridView()
        {
            dgvTransactionHistory.AutoGenerateColumns = true;
            dgvTransactionHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactionHistory.AllowUserToAddRows = false;
            dgvTransactionHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvTransactionHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvTransactionHistory.DefaultCellStyle.Font = new Font("Arial", 9);

            dgvTransactionHistory.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
            dgvTransactionHistory.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
            dgvTransactionHistory.Columns["PaymentAmount"].DefaultCellStyle.Format = "C2";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadTransactionHistory();
                return;
            }

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
                    Payments p ON o.OrderID = p.OrderID
                WHERE 
                    o.OrderID LIKE @Search OR
                    CAST(o.OrderDate AS NVARCHAR) LIKE @Search";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Search", $"%{searchText}%");

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);

                        dgvTransactionHistory.DataSource = table;
                    }
                }
            }
        }

        private void dgvTransactionHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int transactionID = Convert.ToInt32(dgvTransactionHistory.Rows[e.RowIndex].Cells["TransactionID"].Value);

                // Open details of the selected transaction
                using (var detailForm = new TransactionDetailForm(transactionID))
                {
                    detailForm.ShowDialog();
                }
            }
        }

        private void dgvTransactionHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int transactionID = Convert.ToInt32(dgvTransactionHistory.Rows[e.RowIndex].Cells["TransactionID"].Value);

                using (var detailForm = new TransactionDetailForm(transactionID))
                {
                    detailForm.ShowDialog();
                }
            }
        }
    }
}
