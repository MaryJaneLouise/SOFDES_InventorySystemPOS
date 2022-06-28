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
    public partial class ViewProductDialog : Form
    {
        public ViewProductDialog()
        {
            InitializeComponent();
        }


        public ViewProductDialog(int productID)
        {
            InitializeComponent();
            this.ProductID = productID; //Get The Product ID in Parent Form
        }

        // Database Connection
        string connectionString = DatabaseConnection.Connection;

        int ProductID;

        private void ViewProductDialog_Load(object sender, EventArgs e)
        {
            FillProductInformation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillProductInformation()
        {
            using(MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("ViewSelectedProduct", mysqlCon);
                mySqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySqlDataAdapter.SelectCommand.Parameters.AddWithValue("_ProductID", ProductID);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                btnProductIDValue.Text = dataTable.Rows[0]["ProductID"].ToString();
                lblBarcodeValue.Text = dataTable.Rows[0]["BarCode"].ToString();
                lblProductNameValue.Text = dataTable.Rows[0]["ProductName"].ToString();
                lblDescriptionValue.Text = dataTable.Rows[0]["Description"].ToString();
                lblPurchasePriceValue.Text = dataTable.Rows[0]["PurchasePrice"].ToString();
                lblSellingPriceValue.Text = dataTable.Rows[0]["SellingPrice"].ToString();
                byte[] image = (byte[])dataTable.Rows[0]["Image"];
                FillProductPic(image);

            }
        }

        private void FillProductPic(byte[] image)
        {
            if (image == null)
            {
                pictureBoxProductPic.Image = POSWithInventorySystem.Properties.Resources.aw;
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(image))   //Conversion of byte to Stream
                {
                    pictureBoxProductPic.Image = Image.FromStream(ms); //Fill PictureBox...
                }
            }
        }

    }
}
