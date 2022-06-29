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
    public partial class AddProductsDialog : Form {
        // Database Connection
        string connectionString = DatabaseConnection.Connection;

        LoginFormData usersData;

        public AddProductsDialog() {
            InitializeComponent();
        }

        public AddProductsDialog(LoginFormData data) {
            InitializeComponent();
            usersData = data;
        }

        private void AddProductsDialog_Load(object sender, EventArgs e) {
            clearLabelErrorField();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void txtBarcode_Enter(object sender, EventArgs e) {
            lblBarcodeError.Text = "";
        }

        private void txtProductName_Enter(object sender, EventArgs e) {
            lblProductNameError.Text = "";
        }

        private void txtDescription_Enter(object sender, EventArgs e) {
            lblDescriptionError.Text = "";
        }

        private void txtPurchasePrice_Enter(object sender, EventArgs e) {
            lblPurchasePriceError.Text = "";
        }

        private void txtPurchasePrice_KeyPress(object sender, KeyPressEventArgs e) {
            SetMaximumLength(txtPurchasePrice, 18);

            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.');

            //This will make the textbox allow one decimal only
            if ((e.KeyChar == '.') && (txtPurchasePrice.Text.IndexOf('.') > -1)) {
                e.Handled = true;
            }

            //This will make the textbox only two decimal places
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtPurchasePrice);
            if ((convertedTextBox.Text.IndexOf('.')) > 0 &&
                (convertedTextBox.Text.Length - convertedTextBox.Text.IndexOf('.')) > 2 &&
                (convertedTextBox.SelectionStart == convertedTextBox.Text.Length) &&
                (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.Delete)) {
                e.Handled = true;
            }
        }

        private void txtPurchasePrice_KeyDown(object sender, KeyEventArgs e) {
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtPurchasePrice);
            int i = convertedTextBox.SelectionStart;

            if (i > 0) {
                if (e.KeyData == Keys.Back) {
                    if (convertedTextBox.Text[i - 1] == ',') {
                        convertedTextBox.SelectionStart -= 1;
                    }
                }
            }

            if (i < (convertedTextBox.Text.Length)) {
                if (e.KeyData == Keys.Delete) {
                    if (convertedTextBox.Text[i] == ',') {
                        convertedTextBox.SelectionStart += 1;
                    }
                }
            }

            e.Handled = false;
        }

        private void txtPurchasePrice_OnValueChanged(object sender, EventArgs e) {
            string txtAmountDummy = txtPurchasePrice.Text;

            try {
                TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtPurchasePrice);
                int selectionStart = convertedTextBox.SelectionStart - 1;

                for (int i = selectionStart; i > 0; i--) {
                    if (txtPurchasePrice.Text[i] == ',') {
                        selectionStart -= 1;
                    }
                }

                txtAmountDummy = String.Format("{0:n}", Convert.ToDouble(txtAmountDummy.Replace(",", "")));

                for (int i = 0; i <= selectionStart; i++) {
                    if (txtAmountDummy[i] == ',') {
                        selectionStart += 1;
                    }
                }

                convertedTextBox.Text = txtAmountDummy;
                convertedTextBox.SelectionStart = selectionStart + 1;
            }

            catch (Exception ex) {
                if (string.IsNullOrEmpty(txtPurchasePrice.Text.Trim())) {
                    //Insert code here
                    //But since the textbox is empty, there will be no response
                }
                else {
                    MessageBox.Show("Something went wrong in purchase price field: " + ex + " Please contact your manager to fix the error.", 
                        "Error in Purchase Price", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSellingPrice_Enter(object sender, EventArgs e) {
            lblSellingPriceError.Text = "";
        }

        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e) {
            SetMaximumLength(txtSellingPrice, 18);

            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.');

            //This will make the textbox allow one decimal only
            if ((e.KeyChar == '.') && (txtSellingPrice.Text.IndexOf('.') > -1)) {
                e.Handled = true;
            }

            //This will make the textbox allow two decimals only
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtSellingPrice);
            if ((convertedTextBox.Text.IndexOf('.')) > 0 &&
                (convertedTextBox.Text.Length - convertedTextBox.Text.IndexOf('.')) > 2 &&
                (convertedTextBox.SelectionStart == convertedTextBox.Text.Length) &&
                (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.Delete)) {
                e.Handled = true;
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e) {
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtSellingPrice);
            int i = convertedTextBox.SelectionStart;

            if (i > 0) {
                if (e.KeyData == Keys.Back) {
                    if (convertedTextBox.Text[i - 1] == ',') {
                        convertedTextBox.SelectionStart -= 1;
                    }
                }
            }

            if (i < (convertedTextBox.Text.Length)) {
                if (e.KeyData == Keys.Delete) {
                    if (convertedTextBox.Text[i] == ',') {
                        convertedTextBox.SelectionStart += 1;
                    }
                }
            }

            e.Handled = false;
        }

        private void txtSellingPrice_OnValueChanged(object sender, EventArgs e) {
            string txtAmountDummy = txtSellingPrice.Text;

            try {
                TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtSellingPrice);
                int selectionStart = convertedTextBox.SelectionStart - 1;

                for (int i = selectionStart; i > 0; i--) {
                    if (txtSellingPrice.Text[i] == ',') {
                        selectionStart -= 1;
                    }
                }

                txtAmountDummy = String.Format("{0:n}", Convert.ToDouble(txtAmountDummy.Replace(",", "")));

                for (int i = 0; i <= selectionStart; i++) {
                    if (txtAmountDummy[i] == ',') {
                        selectionStart += 1;
                    }
                }

                convertedTextBox.Text = txtAmountDummy;
                convertedTextBox.SelectionStart = selectionStart + 1;
            }
            
            catch (Exception ex) {
                if (string.IsNullOrEmpty(txtSellingPrice.Text.Trim())) {
                    //Insert code here
                    //But since the textbox is empty, there will be no response
                }
                else {
                   MessageBox.Show("Something went wrong in selling price field: " + ex + " Please contact your manager to fix the error.", 
                       "Error in Selling Price", 
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            //Checking if all of the fields are not empty and barcode doesn't currently exist
            if (!checkFieldIfEmptyAndBarcodeExist()) {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    string Barcode = txtBarcode.Text.Trim();
                    string ProductName = txtProductName.Text.Trim();
                    string Description = txtDescription.Text.Trim();
                    double PurchasePrice = Convert.ToDouble(txtPurchasePrice.Text.Trim());
                    double SellingPrice = Convert.ToDouble(txtSellingPrice.Text.Trim());
                    byte[] Image = getImage();

                    //Insert the added product to the database
                    mysqlCon.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("AddProduct", mysqlCon);
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    mySqlCommand.Parameters.AddWithValue("_Barcode", Barcode);
                    mySqlCommand.Parameters.AddWithValue("_ProductName", ProductName);
                    mySqlCommand.Parameters.AddWithValue("_Description", Description);
                    mySqlCommand.Parameters.AddWithValue("_PurchasePrice", PurchasePrice);
                    mySqlCommand.Parameters.AddWithValue("_SellingPrice", SellingPrice);
                    mySqlCommand.Parameters.AddWithValue("_Image", Image);
                    mySqlCommand.ExecuteNonQuery();

                    //Getting the last inserted ProductID
                    int LastProductInsertedID;
                    
                    MySqlDataAdapter mySqlDa = new MySqlDataAdapter("SelectProductLastInsertedID", mysqlCon);
                    mySqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dtLastProductInsertedID = new DataTable();
                    mySqlDa.Fill(dtLastProductInsertedID);

                    //Insert the action from adding the product to the ProductLog
                    LastProductInsertedID = Convert.ToInt32(dtLastProductInsertedID.Rows[0]["ProductID"]);
                    string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                    MySqlCommand mySqlCommand2 = new MySqlCommand("InsertProductLog", mysqlCon);
                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                    mySqlCommand2.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                    mySqlCommand2.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                    mySqlCommand2.Parameters.AddWithValue("_ProductID", LastProductInsertedID);
                    mySqlCommand2.Parameters.AddWithValue("_ProductName", ProductName);
                    mySqlCommand2.Parameters.AddWithValue("_DateAndTime", DateAdded);
                    mySqlCommand2.Parameters.AddWithValue("_Action", "Add");
                    mySqlCommand2.ExecuteNonQuery();

                    //Showing that the adding of product is success
                    MessageBox.Show("The product has been successfully added to the database.", "Add item in database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFieldControls();
                    pictureBoxProductPic.Image = POSWithInventorySystem.Properties.Resources.placeholder;

                    //Filling the datatable StocksForm(Parent Form)
                    ((StocksForm)this.Owner).GridFillWithStocksActive();

                    //Set NumberOfItems Fields in Stocks Form(Parent Form)
                    ((StocksForm)this.Owner).SetNumberOfItems(); 
                }
            }
            
            else {
                MessageBox.Show("Some of the fields are empty. Make sure that you have completed all necessary details in adding product.", 
                    "Invalid fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e) {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif| *.jpg; *.png; *.gif)";
            
            if (opf.ShowDialog() == DialogResult.OK) {
                pictureBoxProductPic.Image = Image.FromFile(opf.FileName);
            }
        }

        private bool checkFieldIfEmptyAndBarcodeExist() {
            bool result = false;

            if (string.IsNullOrEmpty(txtBarcode.Text.Trim())) {
                lblBarcodeError.Text = "❌";
                result = true;
            }
            
            else {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectIfProductBarcodeExist", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDa.SelectCommand.Parameters.AddWithValue("_BarCode", txtBarcode.Text.Trim());
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);

                    if (dataTable.Rows.Count > 0) {
                        lblBarcodeError.Text = "❌";
                        result = true;
                    }
                }
            }

            if (string.IsNullOrEmpty(txtProductName.Text.Trim())) {
                lblProductNameError.Text = "❌";
                result = true;
            }

            if (string.IsNullOrEmpty(txtDescription.Text.Trim())) {
                lblDescriptionError.Text = "❌";
                result = true;
            }

            if (string.IsNullOrEmpty(txtPurchasePrice.Text.Trim())) {
                lblPurchasePriceError.Text = "❌";
                result = true;
            }

            if (string.IsNullOrEmpty(txtSellingPrice.Text.Trim())) {
                lblSellingPriceError.Text = "❌";
                result = true;
            }

            return result;
        }

        private void clearLabelErrorField() {
            lblBarcodeError.Text = "";
            lblProductNameError.Text = "";
            lblPurchasePriceError.Text = "";
            lblSellingPriceError.Text = "";
            lblDescriptionError.Text = "";
        }

        private void ClearFieldControls() {
            //Since we are using other library for the textboxes, .Clear() cannot be used
            txtBarcode.Text = "";
            txtProductName.Text = "";
            txtDescription.Text = "";
            txtPurchasePrice.Text = "";
            txtSellingPrice.Text = "";
        }

        private void SetMaximumLength(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox, int maxlength) {
            foreach (Control ctl in metroTextbox.Controls) {
                if (ctl.GetType() == typeof(TextBox)) {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = maxlength;
                }
            }
        }

        private TextBox getConvertedTextBoxBunifuToWindowsControl(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox) {
            TextBox txtBox = new TextBox();

            foreach (Control ctl in metroTextbox.Controls) {
                if (ctl.GetType() == typeof(TextBox)) {
                    txtBox = (TextBox)ctl;
                }
            }

            return txtBox;
        }

        private byte[] getImage() {
            using (MemoryStream ms = new MemoryStream()) {
                Bitmap bmp = new Bitmap(pictureBoxProductPic.Image);
                bmp.Save(ms, pictureBoxProductPic.Image.RawFormat);

                return ms.ToArray();
            }
        }
    }
}
