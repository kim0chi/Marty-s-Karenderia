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
            if (decimal.TryParse(txtAmountPaid.Text, out decimal amountPaid))
            {
                // Extract only the numeric value from lblTotalAmount.Text
                string totalText = lblTotalAmount.Text.Replace("₱", "").Replace("Total: ", "").Trim();

                // Safely parse the extracted value
                if (!decimal.TryParse(totalText, out decimal totalAmount))
                {
                    MessageBox.Show("Unable to parse the total amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal change = amountPaid - totalAmount;

                // Validate if payment is sufficient
                if (change < 0)
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

                // Set values for payment
                AmountPaid = amountPaid;
                Change = change;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid payment amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
