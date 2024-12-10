using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class PaymentForm : Form
    {
        public decimal AmountPaid { get; private set; }
        public decimal Change { get; private set; }
        public string PaymentMethod { get; private set; }

        public PaymentForm(decimal totalAmount)
        {
            InitializeComponent();
            lblTotalAmount.Text = $"Total: ₱{totalAmount:F2}";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Try to parse the entered amount paid
            if (decimal.TryParse(txtAmountPaid.Text.Trim(), out decimal amountPaid))
            {
                AmountPaid = amountPaid;

                // Extract the numeric value from lblTotalAmount.Text
                string totalText = lblTotalAmount.Text.Replace("₱", "").Replace("Total: ", "").Trim();

                // Try parsing the cleaned-up total amount
                if (decimal.TryParse(totalText, out decimal totalAmount))
                {
                    Change = AmountPaid - totalAmount;

                    if (Change < 0)
                    {
                        MessageBox.Show("Insufficient payment amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Get selected payment method
                    if (rbCash.Checked) PaymentMethod = "Cash";
                    else if (rbCreditCard.Checked) PaymentMethod = "Credit Card";
                    else if (rbMobilePayment.Checked) PaymentMethod = "Mobile Payment";
                    else
                    {
                        MessageBox.Show("Please select a payment method.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Close the form and pass the payment details back to the parent form
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid total amount format.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid payment amount entered.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
