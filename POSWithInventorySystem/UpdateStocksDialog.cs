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
    public partial class UpdateStocksDialog : Form
    {
        // Database Connection
        string connectionString = DatabaseConnection.Connection;

        public UpdateStocksDialog()
        {
            InitializeComponent();
        }

        public UpdateStocksDialog(UpdateStocksInfo info, LoginFormData data)
        {
            InitializeComponent();
            StocksInfo = info;
            this.usersData = data;
        }

        UpdateStocksInfo StocksInfo;
        LoginFormData usersData;

        private void UpdateStocksDialog_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        private void txtQuantity_Enter(object sender, EventArgs e)
        {
            lblQuantityStocksError.Text = "";
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetMaximumLength(txtQuantity, 11);
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UpdateStocks();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateControls()
        {
            lblStocksIDValue.Text = StocksInfo.StocksID.ToString();
            lblProductIDValue.Text = StocksInfo.ProductID.ToString();
            lblProductNameValue.Text = StocksInfo.ProductName;
            txtQuantity.Text = StocksInfo.Quantity.ToString();
            lblDateAddedValue.Text = StocksInfo.DateAdded;
            lblExpirationDateValue.Text = StocksInfo.ExpirationDate;
            lblStatusValue.Text = StocksInfo.Status;
            lblQuantityStocksError.Text = "";
            GetAndSetProductPicture(StocksInfo.ProductID); //Set PictureBox pic
        }

        private void GetAndSetProductPicture(int productID)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductPictureByID", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_ProductID", productID);
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);

                byte[] image = (byte[])dataTable.Rows[0]["Image"];

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

        private bool checkFieldIfEmpty()
        {
            bool result = false;

            if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                lblQuantityStocksError.Text = "❌";
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

        private void UpdateStocks()
        {
            if (!checkFieldIfEmpty())
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    int Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    int StocksID = StocksInfo.StocksID;

                    //Insert Into stocks Table in Database
                    mysqlCon.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("UpdateStocksQuantityByID", mysqlCon);
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    mySqlCommand.Parameters.AddWithValue("_StocksID", StocksID);
                    mySqlCommand.Parameters.AddWithValue("_Quantity", Quantity);
                    mySqlCommand.ExecuteNonQuery();

                    //Insert Into stocksindividual table in Database
                    string DateAddedLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                    MySqlCommand mySqlCommand2 = new MySqlCommand("InsertIndividualStocksLog", mysqlCon);
                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                    mySqlCommand2.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                    mySqlCommand2.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                    mySqlCommand2.Parameters.AddWithValue("_StocksID", StocksID);
                    mySqlCommand2.Parameters.AddWithValue("_ProductID", StocksInfo.ProductID);
                    mySqlCommand2.Parameters.AddWithValue("_ProductName", StocksInfo.ProductName);
                    mySqlCommand2.Parameters.AddWithValue("_DateAndTime", DateAddedLog);
                    mySqlCommand2.Parameters.AddWithValue("_Action", "Update");
                    mySqlCommand2.ExecuteNonQuery();

                    /*---------------------------------------------------------*/
                    MessageBox.Show("Updated Stocks Succesfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ((StocksForm)this.Owner).GridFillIndividualStocksTab2();//Fill StocksForm(Parent Form) Gridview stocks 
                    ((StocksForm)this.Owner).SetExpirationDateForIndividual();//Set Expiration For Individual Stocks in StocksForm(Parent Form) Gridview stocks 
                    ((StocksForm)this.Owner).SetNumberOfStocks();//Fill StocksForm(Parent Form) Total stocks 
                }
            }
        }
    }
}
