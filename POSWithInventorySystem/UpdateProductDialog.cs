﻿using MySql.Data.MySqlClient;
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
    public partial class UpdateProductDialog : Form
    {
        public UpdateProductDialog()
        {
            InitializeComponent();
        }

        public UpdateProductDialog(int productID, LoginFormData data)
        {
            InitializeComponent();
            this.ProductID = productID; //Get The Product ID in Parent Form
            this.usersData = data;
        }

        int ProductID;
        LoginFormData usersData;
        MemoryStream memoryStreamForViewImage;
    
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;

        private void UpdateProductDialog_Load(object sender, EventArgs e)
        {
            clearLabelErrorField();
            FillProductInformation();
        }

        private void UpdateProductDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            memoryStreamForViewImage.Dispose();
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            lblBarcodeError.Text = "";
        }

        private void txtProductName_Enter(object sender, EventArgs e)
        {
            lblProductNameError.Text = "";
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            lblDescriptionError.Text = "";
        }

        private void txtPurchasePrice_Enter(object sender, EventArgs e)
        {
            lblPurchasePriceError.Text = "";
        }

        private void txtPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetMaximumLength(txtPurchasePrice, 18);

            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.');

            // only allow one decimal point
            if ((e.KeyChar == '.') && (txtPurchasePrice.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Allow only two decimal places
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtPurchasePrice);
            if ((convertedTextBox.Text.IndexOf('.')) > 0 &&
                (convertedTextBox.Text.Length - convertedTextBox.Text.IndexOf('.')) > 2 &&
                (convertedTextBox.SelectionStart == convertedTextBox.Text.Length) &&
                (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.Delete)
                )
            {
                e.Handled = true;
            }
        }

        private void txtPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtPurchasePrice);
            int i = convertedTextBox.SelectionStart;

            if (i > 0)
            {
                if (e.KeyData == Keys.Back)
                {
                    if (convertedTextBox.Text[i - 1] == ',')
                    {
                        convertedTextBox.SelectionStart -= 1;
                    }
                }
            }

            if (i < (convertedTextBox.Text.Length))
            {
                if (e.KeyData == Keys.Delete)
                {
                    if (convertedTextBox.Text[i] == ',')
                    {
                        convertedTextBox.SelectionStart += 1;
                    }
                }
            }

            e.Handled = false;
        }

        private void txtPurchasePrice_OnValueChanged(object sender, EventArgs e)
        {
            string txtAmountDummy = txtPurchasePrice.Text;

            try
            {
                TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtPurchasePrice);
                int selectionStart = convertedTextBox.SelectionStart - 1;

                for (int i = selectionStart; i > 0; i--)
                {
                    if (txtPurchasePrice.Text[i] == ',')
                    {
                        selectionStart -= 1;
                    }
                }

                txtAmountDummy = String.Format("{0:n}", Convert.ToDouble(txtAmountDummy.Replace(",", "")));

                for (int i = 0; i <= selectionStart; i++)
                {
                    if (txtAmountDummy[i] == ',')
                    {
                        selectionStart += 1;
                    }
                }

                convertedTextBox.Text = txtAmountDummy;
                convertedTextBox.SelectionStart = selectionStart + 1;

            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(txtPurchasePrice.Text.Trim()))
                {
                    // Do Nothing...
                }
                else
                {
                    MessageBox.Show("Something went wrong in purchase price field: " + ex, "Purchase price error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSellingPrice_Enter(object sender, EventArgs e)
        {
            lblSellingPriceError.Text = "";
        }

        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetMaximumLength(txtSellingPrice, 18);

            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.');

            // only allow one decimal point
            if ((e.KeyChar == '.') && (txtSellingPrice.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Allow only two decimal places
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtSellingPrice);
            if ((convertedTextBox.Text.IndexOf('.')) > 0 &&
                (convertedTextBox.Text.Length - convertedTextBox.Text.IndexOf('.')) > 2 &&
                (convertedTextBox.SelectionStart == convertedTextBox.Text.Length) &&
                (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.Delete)
                )
            {
                e.Handled = true;
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtSellingPrice);
            int i = convertedTextBox.SelectionStart;

            if (i > 0)
            {
                if (e.KeyData == Keys.Back)
                {
                    if (convertedTextBox.Text[i - 1] == ',')
                    {
                        convertedTextBox.SelectionStart -= 1;
                    }
                }
            }

            if (i < (convertedTextBox.Text.Length))
            {
                if (e.KeyData == Keys.Delete)
                {
                    if (convertedTextBox.Text[i] == ',')
                    {
                        convertedTextBox.SelectionStart += 1;
                    }
                }
            }

            e.Handled = false;
        }

        private void txtSellingPrice_OnValueChanged(object sender, EventArgs e)
        {
            string txtAmountDummy = txtSellingPrice.Text;

            try
            {
                TextBox convertedTextBox = getConvertedTextBoxBunifuToWindowsControl(txtSellingPrice);
                int selectionStart = convertedTextBox.SelectionStart - 1;

                for (int i = selectionStart; i > 0; i--)
                {
                    if (txtSellingPrice.Text[i] == ',')
                    {
                        selectionStart -= 1;
                    }
                }

                txtAmountDummy = String.Format("{0:n}", Convert.ToDouble(txtAmountDummy.Replace(",", "")));

                for (int i = 0; i <= selectionStart; i++)
                {
                    if (txtAmountDummy[i] == ',')
                    {
                        selectionStart += 1;
                    }
                }

                convertedTextBox.Text = txtAmountDummy;
                convertedTextBox.SelectionStart = selectionStart + 1;

            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(txtSellingPrice.Text.Trim()))
                {
                    // Do Nothing...
                }
                else
                {
                    MessageBox.Show("Something went wrong in selling price field: " + ex, "Selling price error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //IF All Field is Not Empty and Barcode doesn't exist
            if (!checkFieldIfEmptyAndBarcodeExist())
            {
                using(MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    int ProductID = Convert.ToInt32(lblProductIDValue.Text.Trim());
                    string Barcode = txtBarcode.Text.Trim();
                    string ProductName = txtProductName.Text.Trim();
                    string Description = txtDescription.Text.Trim();
                    double PurchasePrice = Convert.ToDouble(txtPurchasePrice.Text.Trim());
                    double SellingPrice = Convert.ToDouble(txtSellingPrice.Text.Trim());
                    byte[] Image = getImage();

                    //Insert Updated Info Into Products Table in Database
                    mysqlCon.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("UpdateProduct", mysqlCon);
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                    mySqlCommand.Parameters.AddWithValue("_Barcode", Barcode);
                    mySqlCommand.Parameters.AddWithValue("_ProductName", ProductName);
                    mySqlCommand.Parameters.AddWithValue("_Description", Description);
                    mySqlCommand.Parameters.AddWithValue("_PurchasePrice", PurchasePrice);
                    mySqlCommand.Parameters.AddWithValue("_SellingPrice", SellingPrice);
                    mySqlCommand.Parameters.AddWithValue("_Image", Image);
                    mySqlCommand.ExecuteNonQuery();

                    //Insert Into ProductsLog Table in Database
                    string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                    MySqlCommand mySqlCommand2 = new MySqlCommand("InsertProductLog", mysqlCon);
                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                    mySqlCommand2.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                    mySqlCommand2.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                    mySqlCommand2.Parameters.AddWithValue("_ProductID", ProductID);
                    mySqlCommand2.Parameters.AddWithValue("_ProductName", ProductName);
                    mySqlCommand2.Parameters.AddWithValue("_DateAndTime", DateAdded);
                    mySqlCommand2.Parameters.AddWithValue("_Action", "Update");
                    mySqlCommand2.ExecuteNonQuery();

                    /*----------------------------------------------------------------*/
                    MessageBox.Show("Updated Product Succesfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((StocksForm)this.Owner).GridFillWithStocksActive();//Fill StocksForm(Parent Form) Gridview stocks 

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillProductInformation()
        {
           
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("ViewSelectedProduct", mysqlCon);
                mySqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySqlDataAdapter.SelectCommand.Parameters.AddWithValue("_ProductID", ProductID);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                lblProductIDValue.Text = dataTable.Rows[0]["ProductID"].ToString();
                txtBarcode.Text = dataTable.Rows[0]["BarCode"].ToString();
                txtProductName.Text = dataTable.Rows[0]["ProductName"].ToString();
                txtDescription.Text = dataTable.Rows[0]["Description"].ToString();
                txtPurchasePrice.Text = dataTable.Rows[0]["PurchasePrice"].ToString();
                txtSellingPrice.Text = dataTable.Rows[0]["SellingPrice"].ToString();
                byte[] image = (byte[])dataTable.Rows[0]["Image"];
                FillProductPic(image);

            }      
        }

        private void FillProductPic(byte[] image)
        {
            if (image == null)
            {
                pictureBoxProductPic.Image = POSWithInventorySystem.Properties.Resources.computerbox;
            }
            else
            {
                memoryStreamForViewImage = new MemoryStream(image);   //Conversion of byte to Stream, Should Be Dispose...
                pictureBoxProductPic.Image = Image.FromStream(memoryStreamForViewImage); //Fill PictureBox...
            }
        }

        private void clearLabelErrorField()
        {
            lblBarcodeError.Text = "";
            lblProductNameError.Text = "";
            lblDescriptionError.Text = "";
            lblPurchasePriceError.Text = "";
            lblSellingPriceError.Text = "";
        }

        private bool checkFieldIfEmptyAndBarcodeExist()
        {
            bool result = false;

            if (string.IsNullOrEmpty(txtBarcode.Text.Trim()))
            {
                lblBarcodeError.Text = "Barcode Field is Empty";
                result = true;
            }
            else
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectIfProductBarcodeExistOnUpdate", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDa.SelectCommand.Parameters.AddWithValue("_ProductID", lblProductIDValue.Text.Trim());
                    sqlDa.SelectCommand.Parameters.AddWithValue("_BarCode", txtBarcode.Text.Trim());
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        lblBarcodeError.Text = "Barcode is Already Exist";
                        result = true;
                    }
                }
            }

            if (string.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                lblProductNameError.Text = "Product Name Field is Empty";
                result = true;
            }
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                lblDescriptionError.Text = "Description Field is Empty";
                result = true;
            }
            if (string.IsNullOrEmpty(txtPurchasePrice.Text.Trim()))
            {
                lblPurchasePriceError.Text = "Purchase Price Field is Empty";
                result = true;
            }
            if (string.IsNullOrEmpty(txtSellingPrice.Text.Trim()))
            {
                lblSellingPriceError.Text = "Selling Price Field is Empty";
                result = true;
            }

            return result;
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

        private TextBox getConvertedTextBoxBunifuToWindowsControl(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox)
        {
            TextBox txtBox = new TextBox();

            foreach (Control ctl in metroTextbox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    txtBox = (TextBox)ctl;

                }
            }

            return txtBox;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                opf.Filter = "Choose Image(*.jpg; *.png; *.gif| *.jpg; *.png; *.gif)";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxProductPic.Image = Image.FromFile(opf.FileName);
                }
            }
        }

        private byte[] getImage()
        {
            // This gives "A generic error occurred in GDI+" in some images, so I use the code below of comment to remove the error.
            /*
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBoxProductPic.Image.Save(ms, pictureBoxProductPic.Image.RawFormat);
                byte[] image = ms.ToArray();

                 return image;                 
            }
            */

            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(pictureBoxProductPic.Image);
                bmp.Save(ms, pictureBoxProductPic.Image.RawFormat);

                return ms.ToArray();
            }
        }

        
    }
}
