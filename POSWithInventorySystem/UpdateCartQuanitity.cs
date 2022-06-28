using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSWithInventorySystem
{
    public partial class UpdateCartQuanitity : Form
    {
        public UpdateCartQuanitity()
        {
            InitializeComponent();
        }

        public UpdateCartQuanitity(string barcode, string productName, string price, int quantity)
        {
            InitializeComponent();
            this.Barcode = barcode;
            this.ProductNameVoid = productName;
            this.Price = price;
            this.Quantity = quantity;
        }

        // Database Connection
        string connectionString = DatabaseConnection.Connection;

        public string Barcode { get; set; }
        public string ProductNameVoid { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        MemoryStream memoryStreamForViewImage;

        private void UpdateCartQuanitity_Load(object sender, EventArgs e)
        {
            lblBarcodeValue.Text = Barcode;
            lblProductNameValue.Text = ProductNameVoid;
            lblPriceValue.Text = Price;
            lblCurrentQuantityValue.Text = Quantity.ToString();
            lblQuantityError.Hide();
            ValidateNFillProductImage();
        }

        private void UpdateCartQuanitity_FormClosed(object sender, FormClosedEventArgs e)
        {
            memoryStreamForViewImage.Dispose();
        }

        private void UpdateCartQuanitity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOkTrigger();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnDecreaseAll_Click(object sender, EventArgs e)
        {
            txtNewQuantityValue.Text = Quantity.ToString();
        }

        private void SetMaximumLength(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox, int maxlength)
        {
            foreach (Control ctl in metroTextbox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = maxlength;
                }
            }
        }

        private void txtQuantityValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetMaximumLength(txtNewQuantityValue, 11);
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void txtQuantityValue_OnValueChanged(object sender, EventArgs e)
        {
            lblQuantityError.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOkTrigger();
        }

        private void btnOkTrigger()
        {
            if (string.IsNullOrEmpty(txtNewQuantityValue.Text.Trim()))
            {
                lblQuantityError.Show(); //Show Error
            }
            else
            {
                if (Convert.ToInt32(txtNewQuantityValue.Text.Trim()) > Quantity)
                {
                    MessageBox.Show("Your Input is Greater than Quantity in Cart", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    POSTransactionForm pOSTransactionForm = (POSTransactionForm)this.Owner;
                    pOSTransactionForm.QuantityFromUpdateCart = Convert.ToInt32(txtNewQuantityValue.Text.Trim());
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataTable getProductImageFromDB()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SelectProductImageByCodeNPrice", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_BarCode", Barcode.Trim());
                mySqlCommand.Parameters.AddWithValue("_Price", Price);
                MySqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                mysqlCon.Close();

                return dt;
            }
        }

        private void ValidateNFillProductImage()
        {
            DataTable result = getProductImageFromDB();

            //If User Data Fetch is true;
            if (result.Rows.Count == 1)
            {
                byte[] Image = (byte[])result.Rows[0]["Image"];
                ViewProductImage(Image); //For Product Image
            }
            else
            {
                MessageBox.Show("No Data Retrieved! or Two Products Exist!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewProductImage(byte[] bytes)
        {
            if (bytes == null)
            {
                pictureBoxProductPicVoid.Image = POSWithInventorySystem.Properties.Resources.aw;
            }
            else
            {
                memoryStreamForViewImage = new MemoryStream(bytes);
                pictureBoxProductPicVoid.Image = Image.FromStream(memoryStreamForViewImage);
            }
        }
    }
}
