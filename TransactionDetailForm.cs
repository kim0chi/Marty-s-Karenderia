using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class TransactionDetailForm : Form
    {
        private int transactionID;

        public TransactionDetailForm(int transactionID)
        {
            InitializeComponent();
            this.transactionID = transactionID;
            LoadTransactionDetails();
        }

        private void LoadTransactionDetails()
        {
            using (var connection = new SqlConnection("Data Source=DESKTOP-K6LHVL9\\SQLEXPRESS;Initial Catalog=\"Marty's_CarenderiaDB\";Integrated Security=True"))
            {
                connection.Open();

                // Query to get transaction details
                string queryOrderDetails = @"
                SELECT 
                    od.MenuID AS ProductID,
                    mi.ItemName AS ProductName,
                    od.Quantity,
                    od.Subtotal
                FROM 
                    OrderDetails od
                INNER JOIN 
                    MenuItems mi ON od.MenuID = mi.MenuItemID
                WHERE 
                    od.OrderID = @OrderID";

                using (var command = new SqlCommand(queryOrderDetails, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", transactionID);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);

                        dgvOrderDetails.DataSource = table;
                    }
                }

                // Query to get payment and transaction summary
                string queryTransactionSummary = @"
                SELECT 
                    o.TotalAmount,
                    o.OrderDate AS Date,
                CASE 
                    WHEN o.TableNumber IS NULL THEN 'Takeout'
                    ELSE 'Dine-In'
                    END AS OrderType,
                    ISNULL(p.PaymentAmount, 0) AS PaymentAmount,
                    ISNULL(p.PaymentMethod, 'N/A') AS PaymentMethod,
                    ISNULL(p.ChangeAmount, 0) AS ChangeAmount
                FROM 
                    Orders o
                LEFT JOIN 
                    Payments p ON o.OrderID = p.OrderID
                WHERE 
                    o.OrderID = @OrderID;";

                using (var command = new SqlCommand(queryTransactionSummary, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", transactionID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTotalAmount.Text = $"Total Amount: ₱{reader["TotalAmount"]}";
                            lblOrderDate.Text = $"Date: {Convert.ToDateTime(reader["Date"]).ToString("MM/dd/yyyy HH:mm")}";
                            lblOrderType.Text = $"Order Type: {reader["OrderType"].ToString()}";

                            // Handle nullable fields safely
                            lblPaymentAmount.Text = $"Payment Amount: ₱{(reader["PaymentAmount"] is DBNull ? 0 : reader["PaymentAmount"])}";
                            lblPaymentMethod.Text = $"Payment Method: {reader["PaymentMethod"].ToString() ?? "N/A"}";
                            lblChangeAmount.Text = $"Change Amount: ₱{(reader["ChangeAmount"] is DBNull ? 0 : reader["ChangeAmount"])}";
                        }
                    }
                }

            }
        }

        private void ConfigureDataGridView()
        {
            dgvOrderDetails.AutoGenerateColumns = true;
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvOrderDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvOrderDetails.DefaultCellStyle.Font = new Font("Arial", 9);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
