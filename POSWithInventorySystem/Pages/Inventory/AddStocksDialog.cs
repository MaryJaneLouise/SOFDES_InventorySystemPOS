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
    public partial class AddStocksDialog : Form {
        string connectionString = DatabaseConnection.Connection;

        LoginFormData usersData;

        public AddStocksDialog() {
            InitializeComponent();
        }

        public AddStocksDialog(LoginFormData data) {
            InitializeComponent();
            this.usersData = data;
        }

        private void AddStocksDialog_Load(object sender, EventArgs e) {
            PopulateComboBoxValues();
            ClearControlsValue();
            SetMinDatePicker(bunifuDatepickerExpiration);
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            AddStocks();
        }

        private void comboBoxProductName_SelectedIndexChanged(object sender, EventArgs e) {
            txtQuantity.Enabled = true;
            bunifuDatepickerExpiration.Enabled = true;
            btnAdd.Enabled = true;

            comboBox1ProductID.Text = "";
            txtQuantity.Text = "";
            bunifuDatepickerExpiration.Value = DateTime.Now;

            ValidateProductByID(Convert.ToInt32(comboBox1ProductID.Items[comboBoxProductName.SelectedIndex]));
        }

        private void comboBox1ProductID_SelectedIndexChanged(object sender, EventArgs e) {
            txtQuantity.Enabled = true;
            bunifuDatepickerExpiration.Enabled = true;
            btnAdd.Enabled = true;

            txtQuantity.Enabled = true;
            comboBoxProductName.Text = "";
            txtQuantity.Text = "";
            bunifuDatepickerExpiration.Value = DateTime.Now;

            ValidateProductByID(Convert.ToInt32(comboBox1ProductID.SelectedItem));
        }

        private void comboBox1ProductID_KeyPress(object sender, KeyPressEventArgs e) {
            comboBoxProductName.Text = "";
        }

        private void comboBoxProductName_KeyPress(object sender, KeyPressEventArgs e) {
            comboBox1ProductID.Text = "";
        }

        private void comboBox1ProductID_Enter(object sender, EventArgs e) {
            comboBoxProductName.Text = "";
        }

        private void comboBoxProductName_Enter(object sender, EventArgs e) {
            comboBox1ProductID.Text = "";
        }

        private void bunifuDatepickerExpiration_Enter(object sender, EventArgs e) {
            lblExpirationDateError.Text = "";
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e) {
            SetMaximumLength(txtQuantity, 11);
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void txtQuantity_Enter(object sender, EventArgs e) {
            lblQuantityStocksError.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void bunifuDatepickerExpiration_Enter_1(object sender, EventArgs e) {
            lblExpirationDateError.Text = "";
        }

        private void bunifuDatepickerExpiration_onValueChanged(object sender, EventArgs e) {
            lblExpirationDateError.Text = "";
        }

        private void PopulateComboBoxValues() {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsActiveForView", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);

                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    comboBox1ProductID.Items.Add(dataTable.Rows[i]["ProductID"]);
                    comboBoxProductName.Items.Add(dataTable.Rows[i]["ProductName"]);
                }
            }
        }

        private void ClearControlsValue() {
            lblPrductIDValue.Text = "";
            lblProductNameValue.Text = "";
            txtQuantity.Text = "";

            txtQuantity.Enabled = false;
            bunifuDatepickerExpiration.Enabled = false;
            btnAdd.Enabled = false;

            lblQuantityStocksError.Text = "";
            lblExpirationDateError.Text = "";
            comboBox1ProductID.Text = "";
            comboBoxProductName.Text = "";

            bunifuDatepickerExpiration.Value = DateTime.Now;
        }

        private void ValidateProductByID(int id) {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductByID", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_ProductID", id);
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);

                if (dataTable.Rows.Count == 1) {
                    lblPrductIDValue.Text = dataTable.Rows[0]["ProductID"].ToString();
                    lblProductNameValue.Text = dataTable.Rows[0]["ProductName"].ToString();
                    FillProductPic((byte[])dataTable.Rows[0]["Image"]);
                }
            }
        }

        private void FillProductPic(byte[] image) {
            if (image == null) {
                pictureBoxProductPic.Image = POSWithInventorySystem.Properties.Resources.aw;
            }

            else {
                using (MemoryStream ms = new MemoryStream(image)) {
                    pictureBoxProductPic.Image = Image.FromStream(ms);
                }
            }
        }

        private bool checkFieldIfEmpty() {
            bool result = false;

            if (string.IsNullOrEmpty(txtQuantity.Text.Trim())) {
                lblQuantityStocksError.Text = "❌";
                result = true;
            }

            if (bunifuDatepickerExpiration.Value.Date == DateTime.Today) {
                lblExpirationDateError.Text = "❌";
                result = true;
            }

            return result;
        }

        private void SetMaximumLength(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox, int maxlength) {
            foreach (Control ctl in metroTextbox.Controls) {
                if (ctl.GetType() == typeof(TextBox)) {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = maxlength;
                }
            }
        }

        private void SetMinDatePicker(Bunifu.Framework.UI.BunifuDatepicker datepicker) {
            foreach (Control ctl in datepicker.Controls) {
                if (ctl.GetType() == typeof(DateTimePicker)) {
                    var date = (DateTimePicker)ctl;
                    date.MinDate = DateTime.Now;
                }
            }
        }

        private void AddStocks() {
            //Checking if the quantity field is not empty
            if (!checkFieldIfEmpty()) {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    int ProductID = Convert.ToInt32(lblPrductIDValue.Text);
                    int Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");
                    string ExpirationDate = bunifuDatepickerExpiration.Value.ToString("yyyy-MM-dd");
                    string Status = "Good";

                    //Insert the stocks in database
                    mysqlCon.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("AddStocks", mysqlCon);
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                    mySqlCommand.Parameters.AddWithValue("_Quantity", Quantity);
                    mySqlCommand.Parameters.AddWithValue("_DateAdded", DateAdded);
                    mySqlCommand.Parameters.AddWithValue("_ExpirationDate", ExpirationDate);
                    mySqlCommand.Parameters.AddWithValue("_Status", Status);
                    mySqlCommand.ExecuteNonQuery();

                    //Geting the lasst inserted StockID
                    int LastStocksInsertedID;

                    MySqlDataAdapter mySqlDa = new MySqlDataAdapter("SelectStocksLastID", mysqlCon);
                    mySqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dtLastStocksInsertedID = new DataTable();
                    mySqlDa.Fill(dtLastStocksInsertedID);

                    //Insert the update in the stocks in the history log of database
                    LastStocksInsertedID = Convert.ToInt32(dtLastStocksInsertedID.Rows[0]["StocksID"]);
                    string ProductName = lblProductNameValue.Text;
                    string DateAddedLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                    MySqlCommand mySqlCommand2 = new MySqlCommand("InsertIndividualStocksLog", mysqlCon);
                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                    mySqlCommand2.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                    mySqlCommand2.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                    mySqlCommand2.Parameters.AddWithValue("_StocksID", LastStocksInsertedID);
                    mySqlCommand2.Parameters.AddWithValue("_ProductID", ProductID);
                    mySqlCommand2.Parameters.AddWithValue("_ProductName", ProductName);
                    mySqlCommand2.Parameters.AddWithValue("_DateAndTime", DateAddedLog);
                    mySqlCommand2.Parameters.AddWithValue("_Action", "Add");
                    mySqlCommand2.ExecuteNonQuery();

                    MessageBox.Show("The stocks for the product has been successfully added.", "Add stock in selected item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControlsValue();
                    pictureBoxProductPic.Image = POSWithInventorySystem.Properties.Resources.placeholder;
                    this.Close();

                    //Fill the datatable StocksForm(Parent Form)
                    ((StocksForm)this.Owner).GridFillIndividualStocksTab2();

                    //Set expiration date for individual products in datatable StocksForm(Parent Form)
                    ((StocksForm)this.Owner).SetExpirationDateForIndividual();

                    //Fill the datatable StocksForm(Parent Form)
                    ((StocksForm)this.Owner).SetNumberOfStocks();
                }
            }
        }

        private void lblQuantityStocksError_Click(object sender, EventArgs e) {
            return;
        }
    }
}