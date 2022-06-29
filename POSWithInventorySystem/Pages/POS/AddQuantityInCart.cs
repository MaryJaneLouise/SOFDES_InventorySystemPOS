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

namespace POSWithInventorySystem {
    public partial class AddQuantityInCart : Form {
        // Database Connection
        string connectionString = DatabaseConnection.Connection;

        private string Barcode { get; set; }
        private string ProductNameInCart { get; set; }
        private string Price { get; set; }
        private int Quantity { get; set; }

        MemoryStream memoryStreamForViewImage;

        public AddQuantityInCart() {
            InitializeComponent();
        }

        public AddQuantityInCart(string barcode, string productName, string price, int quantity) {
            InitializeComponent();

            this.Barcode = barcode;
            this.ProductNameInCart = productName;
            this.Price = price;
            this.Quantity = quantity;
        }

        private void AddQuantityInCart_Load(object sender, EventArgs e) {
            lblBarcodeValue.Text = Barcode;
            lblProductNameValue.Text = ProductNameInCart;
            lblPriceValue.Text = Price;
            lblCurrentQuantityValue.Text = Quantity.ToString();
            lblQuantityError.Text = "";

            ValidateNFillProductImage();

        }

        private void AddQuantityInCart_FormClosed(object sender, FormClosedEventArgs e) {
            memoryStreamForViewImage.Dispose();
        }

        private void AddQuantityInCart_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnOkTrigger();
            }

            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        private void txtAddedQuantityValue_KeyPress(object sender, KeyPressEventArgs e) {
            SetMaximumLength(txtAddedQuantityValue, 11);
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void txtAddedQuantityValue_OnValueChanged(object sender, EventArgs e) {
            lblQuantityError.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e) {
            btnOkTrigger();
        }

        private void btnAddQty_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtAddedQuantityValue.Text.Trim())) {
                txtAddedQuantityValue.Text = (Convert.ToInt32(txtAddedQuantityValue.Text) + 1).ToString();
            }
        }

        private void btnMinusQty_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtAddedQuantityValue.Text.Trim()) && Convert.ToInt32(txtAddedQuantityValue.Text) >= 1) {
                txtAddedQuantityValue.Text = (Convert.ToInt32(txtAddedQuantityValue.Text) - 1).ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnOkTrigger() {
            //Checking if the quantity textbox is empty
            if (string.IsNullOrEmpty(txtAddedQuantityValue.Text.Trim())) {
                lblQuantityError.Text = "❌";
            }

            else {
                bool result = ValidateProductQuantity(Barcode, Price, Quantity + Convert.ToInt32(txtAddedQuantityValue.Text));

                //Checking the quantity of the item in database if it will suffice the order or not
                if (!result) {
                    POSTransactionForm pOSTransactionForm = (POSTransactionForm)this.Owner;
                    pOSTransactionForm.NewQuantityAddedToitems = Convert.ToInt32(txtAddedQuantityValue.Text);
                    this.Close();
                }

                else {
                    MessageBox.Show("The item is currently out of stocks. Please contact your manager.", "Invalid Quantity Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool ValidateProductQuantity(string barcode, string price, int quantityInCart) {
            //If it returns true, there is no enough stocks in the system
            bool resultQuantity = false;

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter("SelectCurrentProductQuantity", mysqlCon);
                mySqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySqlDa.SelectCommand.Parameters.AddWithValue("_BarCode", barcode);
                mySqlDa.SelectCommand.Parameters.AddWithValue("_Price", price);
                DataTable dataTable = new DataTable();
                mySqlDa.Fill(dataTable);

                if (dataTable.Rows.Count > 0) {
                    double CurrentQuantity = Convert.ToDouble(dataTable.Rows[0]["Quantity"].ToString());
                    
                    if (CurrentQuantity < quantityInCart) {
                        resultQuantity = true;
                    }
                }
            }

            return resultQuantity;
        }

        private void SetMaximumLength(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox, int maxlength) {
            foreach (Control ctl in metroTextbox.Controls) {
                if (ctl.GetType() == typeof(TextBox)) {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = maxlength;
                }
            }
        }

        private DataTable getProductImageFromDB() {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SelectProductImageByCodeNPrice", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_BarCode", Barcode.Trim());
                mySqlCommand.Parameters.AddWithValue("_Price", Price.Trim());
                MySqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                mysqlCon.Close();

                return dt;
            }
        }

        private void ValidateNFillProductImage() {
            DataTable result = getProductImageFromDB();

            if (result.Rows.Count == 1) {

                byte[] Image = (byte[])result.Rows[0]["Image"];
                ViewProductImage(Image);
            }

            else {
                MessageBox.Show("There was an error in retrieving image of the product. Please try again.", "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewProductImage(byte[] bytes) {
            if (bytes == null) {
                pictureBoxProductPic.Image = POSWithInventorySystem.Properties.Resources.placeholder;
            }

            else {
                memoryStreamForViewImage = new MemoryStream(bytes);
                pictureBoxProductPic.Image = Image.FromStream(memoryStreamForViewImage);
            }
        }
    }
}