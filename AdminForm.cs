using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace Marty_s_Karenderia
{
    public partial class AdminForm : Form
    {
        public AdminForm(string v)
        {
            InitializeComponent();
        }

        public AdminForm()
        {
            InitializeComponent();
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

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new HomeForm()); // Load the HomeForm
        }

        private void btnCategories_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new CategoryForm()); // Load the CategoriesForm
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new MenuForm()); // Load the MenuForm
        }

        private void btnStaff_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new StaffForm()); // Load the StaffForm
        }

        private void btnPOS_Click_1(object sender, EventArgs e)
        {
            PosForm posform = new PosForm();
            this.Close();
            posform.Show();     
        }

        private void btnKitchen_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new KitchenForm()); // Load the KitchenForm
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new AdminAccountForm());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
