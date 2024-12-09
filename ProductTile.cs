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
    public partial class ProductTile : UserControl
    {
        public int ProductID { get; set; }
        public string ProductName
        {
            get => lblProductName.Text;
            set => lblProductName.Text = value;
        }
        public decimal Price
        {
            get => decimal.Parse(lblPrice.Text, System.Globalization.NumberStyles.Currency);
            set => lblPrice.Text = value.ToString("C");
        }
        public Image ProductImage
        {
            get => picProduct.Image;
            set => picProduct.Image = value;
        }

        public event EventHandler ProductClicked;

        public ProductTile()
        {
            InitializeComponent();
            this.Click += (s, e) => ProductClicked?.Invoke(this, e);
            picProduct.Click += (s, e) => ProductClicked?.Invoke(this, e);
            lblProductName.Click += (s, e) => ProductClicked?.Invoke(this, e);
            lblPrice.Click += (s, e) => ProductClicked?.Invoke(this, e);
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }
    }

}
