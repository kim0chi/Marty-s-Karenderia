using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class EmployeeForm : Form
    {
        private int CurrentStaffID;
        public EmployeeForm(int staffID)
        {
            InitializeComponent();
            CurrentStaffID = staffID;
        }

        private void LoadFormIntoPanel(Form form)
        {
            // Clear any existing content
            contentPanel.Controls.Clear();

            // Set form properties
            form.TopLevel = false; // Make the form behave like a control
            form.FormBorderStyle = FormBorderStyle.None; // Remove border
            form.Dock = DockStyle.Fill; // Ensure it fills the panel

            // Add the form to the panel
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            PosForm posForm = new PosForm(this); // Pass the current instance (AdminForm)
            this.Hide(); // Hide the AdminForm
            posForm.Show();
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new KitchenForm());
        }

        private void btnEmployeeAccount_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new EmployeeAccForm(CurrentStaffID));
        }
    }
}
