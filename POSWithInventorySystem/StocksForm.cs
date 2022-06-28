using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSWithInventorySystem
{
    public partial class StocksForm : Form
    {
        public StocksForm()
        {
            InitializeComponent();
            this.Load += StocksForm_Load1; ;
            dataGridViewStocksTab2.VisibleChanged += DataGridViewStocksTab2_VisibleChanged;
        }

        public StocksForm(LoginFormData data)
        {
            InitializeComponent();
            this.Load += StocksForm_Load1; ;
            dataGridViewStocksTab2.VisibleChanged += DataGridViewStocksTab2_VisibleChanged;
            this.UserID = Convert.ToInt32(data.UsersID);
            this.usersData = data;
        }

        LoginFormData usersData;

        private int UserID;

        private bool _firstLoaded;

        private void StocksForm_Load1(object sender, EventArgs e)
        {
            _firstLoaded = true;
            

        }

        private void DataGridViewStocksTab2_VisibleChanged(object sender, EventArgs e)
        {
            if (_firstLoaded && dataGridViewStocksTab2.Visible)
            {
                _firstLoaded = false;
                SetTotalOrIndividualStocks();
                SetProductActiveOrNot();
            }
        }

        // Database Connection
        string connectionString = DatabaseConnection.Connection;

        private void StocksForm_Load(object sender, EventArgs e)
        {
            comboBoxStocks.SelectedIndex = 0; //For Individual and Total Stocks
            comboBoxStocksStatus.SelectedIndex = 0; //For Individual for Expired and Good
           
            comboBoxProductStatusActiveOrNot.SelectedIndex = 0; //Set Combobox Status To Default Active in Tab1
            SetProductActiveOrNot(); //Set Product Active Or Not in Tab1   
            SetNumberOfItems();
            SetTotalOrIndividualStocks(); //Set Stocks Mode in Gridview
            SetNumberOfStocks();
            HidePanelStatus(); //Hide Panel for both parties
            panelTotalStocks.Show();
            DeleteStocksEmptyFromDatabase(); //Delete Empty Stocks Within 10 Days of Period From Database

            bunifuSwitch.Value = true;
            bunifuSwitchbtnDeleteProductInDB.Value = true;
            bunifuSwitchDeleteTotalStocks.Value = true;
            bunifuSwitchStocks.Value = true;
            bunifuSwitch.Hide();
            bunifuSwitchbtnDeleteProductInDB.Hide();
            bunifuSwitchDeleteTotalStocks.Hide();
            bunifuSwitchStocks.Hide();
            btnDelete.Enabled = true;
            btnDeleteProductInDB.Enabled = true;
            btnDeleteStocks.Enabled = true;
            btnDeleteTotalStocks.Enabled = true;
            btnPrint.Hide();
            btnPrintStocks.Hide();
        }

        private void txtSearchValue_OnValueChanged(object sender, EventArgs e)
        {
            SearchProductByColumn();
        }

        private void dataGridViewProducts_DoubleClick(object sender, EventArgs e)
        {
            ViewProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
            SetNumberOfItems();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct();
            SetNumberOfItems();
        }

        private void bunifuSwitch_Click(object sender, EventArgs e)
        {
            BunifuSwitchDeleteButton();
        }

        private void comboBoxProductStatusActiveOrNot_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetProductActiveOrNot();
        }

        private void dataGridViewProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //If Active Products
            if (comboBoxProductStatusActiveOrNot.SelectedIndex == 0)
            {
                //Do Nothing
            }
            //IF Not Active Products
            else
            {
                SetRowColorIntoRedWhenNotActive(); //Set DatagridView Color When ColumnHeader is Click, Refresh Purpose                
            }
        }

        public void GridFillWithStocksActive()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsActiveForView", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dataGridViewProducts.DataSource = dataTable;

                //dataGridViewUsers.Columns[2].Visible = false;

                //For Print Button
                /*try
                {
                    if (dataGridViewProducts.CurrentRow.Index != -1)
                    {
                        btnPrint.Enabled = true;
                    }
                }
                catch (NullReferenceException ex)
                {
                    btnPrint.Enabled = false;
                }*/
            }
        }

        private void GridFillWithStocksNotActive()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsNotActiveForView", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dataGridViewProducts.DataSource = dataTable;

                //dataGridViewUsers.Columns[2].Visible = false;
            }
        }

        private void dataGridDesign()
        {
            dataGridViewProducts.EnableHeadersVisualStyles = false;
            dataGridViewProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void AddProduct()
        {
            ValidateAdminPassword(); //Invoke PasswordDialog
            //If true
            if (resultFromValidation)
            {
                AddProductsDialog addProductsDialog = new AddProductsDialog(usersData);
                addProductsDialog.Owner = this;
                addProductsDialog.ShowDialog();
            }

            resultFromValidation = false; //Reset True to False
        }

        private void UpdateProduct()
        {
            try
            {
                ValidateAdminPassword(); //Invoke PasswordDialog
                //If true
                if (resultFromValidation)
                {
                    if (dataGridViewProducts.CurrentRow.Index != -1)
                    {
                        int ProductIDForViewProduct = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);

                        DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Update This Product?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            using (UpdateProductDialog updateProductDialog = new UpdateProductDialog(ProductIDForViewProduct, usersData))
                            {
                                updateProductDialog.Owner = this;
                                updateProductDialog.ShowDialog();
                            }
                        }
                        else
                        {
                            return;
                        }

                    }
                }
                resultFromValidation = false; //Reset True to False
            }
            catch (Exception ex)
            {
                MessageBox.Show("Products is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteProduct()
        {
            try
            {
                ValidateAdminPassword(); //Invoke PasswordDialog
                //If true
                if (resultFromValidation)
                {
                    if (dataGridViewProducts.CurrentRow.Index != -1)
                    {

                        int ProductID = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);
                        string ProductName = dataGridViewProducts.CurrentRow.Cells[2].Value.ToString();

                        //If Combobox Selected Index is Equal To Active
                        if (comboBoxProductStatusActiveOrNot.SelectedIndex == 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Deactivate This Product?", "Deactivate Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                                {
                                    //Delete Stocks Corresponding of this Product
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand2 = new MySqlCommand("DeleteTotalStocksByID", mysqlCon);
                                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand2.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand2.ExecuteNonQuery();

                                    //Delete Product
                                    MySqlCommand mySqlCommand = new MySqlCommand("UpdateProductStatustoNotActive", mysqlCon);
                                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand.ExecuteNonQuery();
                                    GridFillWithStocksActive();
                                    SetNumberOfItems();
                                    SetTotalOrIndividualStocks(); //Invoke Method From Tab2

                                    //Insert Into ProductsLog Table in Database
                                    string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                                    MySqlCommand mySqlCommand3 = new MySqlCommand("InsertProductLog", mysqlCon);
                                    mySqlCommand3.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand3.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                                    mySqlCommand3.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                                    mySqlCommand3.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand3.Parameters.AddWithValue("_ProductName", ProductName);
                                    mySqlCommand3.Parameters.AddWithValue("_DateAndTime", DateAdded);
                                    mySqlCommand3.Parameters.AddWithValue("_Action", "Deactivate");
                                    mySqlCommand3.ExecuteNonQuery();

                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Activate This Product?", "Activate Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                                {
                                    //Activate Product
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand = new MySqlCommand("UpdateProductStatustoActive", mysqlCon);
                                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand.ExecuteNonQuery();
                                    GridFillWithStocksNotActive();
                                    SetRowColorIntoRedWhenNotActive();
                                    SetNumberOfItems();
                                    SetTotalOrIndividualStocks(); //Invoke Method From Tab2

                                    //Insert Into ProductsLog Table in Database
                                    string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                                    MySqlCommand mySqlCommand3 = new MySqlCommand("InsertProductLog", mysqlCon);
                                    mySqlCommand3.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand3.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                                    mySqlCommand3.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                                    mySqlCommand3.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand3.Parameters.AddWithValue("_ProductName", ProductName);
                                    mySqlCommand3.Parameters.AddWithValue("_DateAndTime", DateAdded);
                                    mySqlCommand3.Parameters.AddWithValue("_Action", "Activate");
                                    mySqlCommand3.ExecuteNonQuery();

                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                resultFromValidation = false; //Reset True to False
            }
            catch (Exception ex)
            {
                resultFromValidation = false; //Reset True to False
                MessageBox.Show("Products is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ViewProduct()
        {
            try
            {
                if (dataGridViewProducts.CurrentRow.Index != -1)
                {
                    int ProductIDForViewProduct = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);

                    ViewProductDialog viewProductDialog = new ViewProductDialog(ProductIDForViewProduct);
                    viewProductDialog.Owner = this;
                    viewProductDialog.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Products is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SearchProductByColumn()
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewProducts.DataSource;
                bs.Filter = "Convert([ProductID], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR [BarCode] LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR [ProductName] LIKE '%" + txtSearchValue.Text + "%'";

                dataGridViewProducts.DataSource = bs;
            }
            catch(EvaluateException ex)
            {
                //Do Nothing...
            }

            //If Active Products
            if (comboBoxProductStatusActiveOrNot.SelectedIndex == 0)
            {
                //Do Nothing
            }
            //IF Not Active Products
            else
            {
                SetRowColorIntoRedWhenNotActive(); //Set DatagridView Color When ColumnHeader is Click, Refresh Purpose                
            }
            SetNumberOfItems();

            //For Print Button
            try
            {
                if (dataGridViewProducts.CurrentRow.Index != -1)
                {
                    btnPrint.Enabled = true;
                }
            }
            catch(NullReferenceException ex)
            {
                btnPrint.Enabled = false;
            }
        }

        private void BunifuSwitchDeleteButton()
        {
            if (bunifuSwitch.Value == true)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        public void SetNumberOfItems()
        {
            lblNumberOfItemsValue.Text = dataGridViewProducts.Rows.Count.ToString();
        }

        private void dataGridViewWithActivateAndNotActive()
        {
            //Width
            dataGridViewProducts.Columns[0].Width = 104;
            dataGridViewProducts.Columns[1].Width = 120;
            dataGridViewProducts.Columns[2].Width = dataGridViewProducts.Width 
                - dataGridViewProducts.Columns[0].Width 
                - dataGridViewProducts.Columns[1].Width 
                - dataGridViewProducts.Columns[3].Width 
                - dataGridViewProducts.Columns[4].Width 
                - dataGridViewProducts.Columns[5].Width
                - 190;
            dataGridViewProducts.Columns[3].Width = 217;
            dataGridViewProducts.Columns[4].Width = 150;
            dataGridViewProducts.Columns[5].Width = 150;
        }

        private void SetProductActiveOrNot()
        {
            //If Active Products
            if(comboBoxProductStatusActiveOrNot.SelectedIndex == 0)
            {
                dataGridViewProducts.DataSource = null;
                dataGridDesign();
                GridFillWithStocksActive();
                dataGridViewWithActivateAndNotActive();
                SetNumberOfItems();
                btnDelete.Text = "Deactivate";
                //Set Location of Delete Button In Right Point
                btnDelete.Location = new Point(739, 624);
                btnDelete.Size = new Size(298, 48);
                //Set Location of BunifuSwitch In Right Point
                bunifuSwitch.Location = new Point(717, 634);
                //Hide Button For Deactivate Products Controls
                btnDeleteProductInDB.Hide(); bunifuSwitchbtnDeleteProductInDB.Hide();
                //Show Button For Active Products Controls
                btnAdd.Show(); btnUpdate.Show(); btnDelete.Show();
                btnPrint.Hide();

            }
            //IF Not Active Products
            else
            {
                dataGridViewProducts.DataSource = null;
                dataGridDesign();
                GridFillWithStocksNotActive();
                dataGridViewWithActivateAndNotActive();
                SetRowColorIntoRedWhenNotActive();
                SetNumberOfItems();
                //Set Location of Delete Button in Middle Point
                btnDelete.Text = "Activate";
                btnDelete.Location = new Point(34, 624);
                btnDelete.Size = new Size(469, 48);
            
                //Set Location of BunifuSwitch in Middle Point
                bunifuSwitch.Location = new Point(366, 633);
                bunifuSwitch.Hide();
                //Hide Button For Active Products Controls
                btnAdd.Hide(); btnUpdate.Hide();
                //Show Button For Deactivate Products Controls
                btnDeleteProductInDB.Show();
                btnPrint.Hide(); //Hide Print Button For Not Active
            }
        }

        private void SetRowColorIntoRedWhenNotActive()
        {
            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void bunifuSwitchbtnDeleteProductInDB_Click(object sender, EventArgs e)
        {
            if (bunifuSwitchbtnDeleteProductInDB.Value == true)
            {
                btnDeleteProductInDB.Enabled = true;
            }
            else
            {
                btnDeleteProductInDB.Enabled = false;
            }
        }

        private void btnDeleteProductInDB_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Invoke PasswordDialog
                //If true
                if (resultFromValidation)
                {
                    if (dataGridViewProducts.CurrentRow.Index != -1)
                    {

                        int ProductID = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);
                        string ProductName = dataGridViewProducts.CurrentRow.Cells[2].Value.ToString();

                        //If Combobox Selected Index is Equal To Deactivate
                        if (comboBoxProductStatusActiveOrNot.SelectedIndex == 1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Delete This Product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                                {
                                    //Delete Stocks Corresponding of this Product
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand2 = new MySqlCommand("DeleteTotalStocksByID", mysqlCon);
                                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand2.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand2.ExecuteNonQuery();

                                    //Delete Product
                                    MySqlCommand mySqlCommand = new MySqlCommand("DeleteProduct", mysqlCon);
                                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand.ExecuteNonQuery();
                                    GridFillWithStocksNotActive(); 
                                    SetRowColorIntoRedWhenNotActive();
                                    SetNumberOfItems();
                                    SetTotalOrIndividualStocks(); //Invoke Method From Tab2

                                    //Insert Into ProductsLog Table in Database
                                    string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                                    MySqlCommand mySqlCommand3 = new MySqlCommand("InsertProductLog", mysqlCon);
                                    mySqlCommand3.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand3.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                                    mySqlCommand3.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                                    mySqlCommand3.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand3.Parameters.AddWithValue("_ProductName", ProductName);
                                    mySqlCommand3.Parameters.AddWithValue("_DateAndTime", DateAdded);
                                    mySqlCommand3.Parameters.AddWithValue("_Action", "Delete");
                                    mySqlCommand3.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                resultFromValidation = false; //Reset True to False
            }
            catch (Exception ex)
            {
                resultFromValidation = false; //Reset True to False
                MessageBox.Show("Products is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Set DataTable To Fill Datagrid Data into DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductID", typeof(string));
            dataTable.Columns.Add("Barcode", typeof(string));
            dataTable.Columns.Add("ProductName", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("PurchasePrice", typeof(string));
            dataTable.Columns.Add("SellingPrice", typeof(string));

            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
            {
                dataTable.Rows.Add(row.Cells[0].Value, 
                    row.Cells[1].Value, 
                    row.Cells[2].Value, 
                    row.Cells[3].Value, 
                    row.Cells[4].Value, 
                    row.Cells[5].Value);
            }

            string Date = DateTime.Now.ToString("MM-dd-yyyy");

            ProductsInformation products = new ProductsInformation();
            products.ProductsInformations = dataTable;
            products.Date = Date;
            products.NumberOfProducts = dataGridViewProducts.Rows.Count.ToString();

            SalesReportForm salesReportForm = new SalesReportForm(products, "ProductsInformation");
            salesReportForm.Show();
        }

        /*-------------------------Sharing Codes Both Side----------------*/

        private void HidePanelStatus()
        {
            panelIndividualStocks.Hide();
            panelTotalStocks.Hide();
        }

        private void dataGridViewStocksTab2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Total Products
            if (comboBoxStocks.SelectedIndex == 0)
            {
                SetStocksQuantity();
            }
            //Individual Products
            else
            {
                SetExpirationDateForIndividual();
            }
        }

        /*----------------Sharing Codes For All Within StocksForm----*/

        public bool resultFromValidation = false;

        private void ValidateAdminPassword()
        {
            ValidateAdminPasswordDialog  validateAdminPassword = new ValidateAdminPasswordDialog(UserID, "StocksForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }   

        private void btnPrintStocks_Click(object sender, EventArgs e)
        {
            //Total Products
            if (comboBoxStocks.SelectedIndex == 0)
            {
                //Set DataTable To Fill Datagrid Data into DataTable
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ProductID", typeof(string));
                dataTable.Columns.Add("ProductName", typeof(string));
                dataTable.Columns.Add("TotalQuantity", typeof(string));
               

                foreach (DataGridViewRow row in dataGridViewStocksTab2.Rows)
                {
                    dataTable.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value);
                }

                string Date = DateTime.Now.ToString("MM-dd-yyyy");

                TotalStocksInformation totalStocksInformation = new TotalStocksInformation();
                totalStocksInformation.TotalStocks = dataTable;
                totalStocksInformation.NumberOfTotalStocks = dataGridViewStocksTab2.Rows.Count.ToString();
                totalStocksInformation.Date = Date;

                SalesReportForm salesReportForm = new SalesReportForm(totalStocksInformation, "TotalStocksInformation");
                salesReportForm.Show();
            }
            //Individual Products
            else
            {
                //Set DataTable To Fill Datagrid Data into DataTable
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("StocksID", typeof(string));
                dataTable.Columns.Add("ProductID", typeof(string));
                dataTable.Columns.Add("ProductName", typeof(string));
                dataTable.Columns.Add("Quantity", typeof(string));
                dataTable.Columns.Add("Date_Added", typeof(string));
                dataTable.Columns.Add("Expiration_Date", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));


                foreach (DataGridViewRow row in dataGridViewStocksTab2.Rows)
                {
                    dataTable.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value,
                        row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value);
                }

                string Date = DateTime.Now.ToString("MM-dd-yyyy");

                IndividualStocksInformation individualStocks = new IndividualStocksInformation();
                individualStocks.IndividualStocks = dataTable;
                individualStocks.NumberOfIndividualStocks = dataGridViewStocksTab2.Rows.Count.ToString();
                individualStocks.Date = Date;

                SalesReportForm salesReportForm = new SalesReportForm(individualStocks, "IndividualStocksInformation");
                salesReportForm.Show();
            }
        }

        /*---------------------------Stocsk Tab---------------------------*/

        /*-------------------For Individual Section------------------*/

        public void GridFillIndividualStocksTab2()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewAllStocks", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dataGridViewStocksTab2.DataSource = dataTable;

                //For Print Button
                /*try
                {
                    if (dataGridViewStocksTab2.CurrentRow.Index != -1)
                    {
                        btnPrintStocks.Enabled = true;
                    }
                }
                catch (NullReferenceException ex)
                {
                    btnPrintStocks.Enabled = false;
                }*/
            }
        }

        public void GridFillTotalStocksTab2()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewTotalPerProductQuantity", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dataGridViewStocksTab2.DataSource = dataTable;

                //For Print Button
                /*try
                {
                    if (dataGridViewStocksTab2.CurrentRow.Index != -1)
                    {
                        btnPrintStocks.Enabled = true;
                    }
                }
                catch (NullReferenceException ex)
                {
                    btnPrintStocks.Enabled = false;
                }*/

            }
        }

        private void dataGridStocksIndividualTab2DesignAndWidth()
        {
            //Design
            dataGridViewStocksTab2.EnableHeadersVisualStyles = false;
            dataGridViewStocksTab2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewStocksTab2.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewStocksTab2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewStocksTab2.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dataGridViewStocksTab2.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            //Width
            dataGridViewStocksTab2.Columns[0].Width = 92;
            dataGridViewStocksTab2.Columns[1].Width = 99;
            dataGridViewStocksTab2.Columns[2].Width = 250;
            dataGridViewStocksTab2.Columns[3].Width = 140;
            dataGridViewStocksTab2.Columns[4].Width = 250;
            dataGridViewStocksTab2.Columns[5].Width = 160;
            dataGridViewStocksTab2.Columns[6].Width = 104;

        }

        private void dataGridStocksTotalTab2DesignAndWidth()
        {
            //Design
            dataGridViewStocksTab2.EnableHeadersVisualStyles = false;
            dataGridViewStocksTab2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewStocksTab2.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewStocksTab2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewStocksTab2.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridViewStocksTab2.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

            //Width
            dataGridViewStocksTab2.Columns[0].Width = 240;
            dataGridViewStocksTab2.Columns[1].Width = dataGridViewStocksTab2.Width
                - dataGridViewStocksTab2.Columns[0].Width
                - dataGridViewStocksTab2.Columns[2].Width - 143;
            dataGridViewStocksTab2.Columns[2].Width = 240;




        }

        private void btnAddStocks_Click(object sender, EventArgs e)
        {
            AddStocks();
        }

        private void AddStocks()
        {
            ValidateAdminPassword(); //Invoke PasswordDialog
            //If true
            if (resultFromValidation)
            {
                AddStocksDialog addStocksDialog = new AddStocksDialog(usersData);
                addStocksDialog.Owner = this;
                addStocksDialog.ShowDialog();
            }
            resultFromValidation = false;
        }

        private void btnUpdateStocks_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Invoke PasswordDialog
                //If true
                if (resultFromValidation)
                {
                    if (dataGridViewProducts.CurrentRow.Index != -1)
                    {
                        UpdateStocksInfo stocksInfo = new UpdateStocksInfo();

                        stocksInfo.StocksID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[0].Value);
                        stocksInfo.ProductID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[1].Value);
                        stocksInfo.ProductName = dataGridViewStocksTab2.CurrentRow.Cells[2].Value.ToString();
                        stocksInfo.Quantity = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[3].Value);
                        stocksInfo.DateAdded = dataGridViewStocksTab2.CurrentRow.Cells[4].Value.ToString();
                        stocksInfo.ExpirationDate = dataGridViewStocksTab2.CurrentRow.Cells[5].Value.ToString();
                        stocksInfo.Status = dataGridViewStocksTab2.CurrentRow.Cells[6].Value.ToString();

                        DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Update This Stocks?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            using (UpdateStocksDialog updateStocksDialog = new UpdateStocksDialog(stocksInfo, usersData))
                            {
                                updateStocksDialog.Owner = this;
                                updateStocksDialog.ShowDialog();
                            }
                        }
                        else
                        {
                            return;
                        }

                    }
                }
                resultFromValidation = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Products is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 

        private void btnDeleteStocks_Click(object sender, EventArgs e)
        {
            DeleteStocks();
        }

        private void bunifuSwitchStocks_Click(object sender, EventArgs e)
        {
            if (bunifuSwitchStocks.Value == true)
            {
                btnDeleteStocks.Enabled = true;
            }
            else
            {
                btnDeleteStocks.Enabled = false;
            }
        }

        private void comboBoxStocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTotalOrIndividualStocks();
        }

        private void comboBoxStocksStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGoodExpired();
        }

        private void DeleteStocks()
        {
            //For Individual Stocks
            if (comboBoxStocks.SelectedIndex == 1)
            {
                ValidateAdminPassword(); //Invoke PasswordDialog
                //If true
                if (resultFromValidation)
                {
                    try
                    {
                        if (dataGridViewStocksTab2.CurrentRow.Index != -1)
                        {
                            int StocksID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[0].Value);
                            int ProductID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[1].Value);
                            string ProductName = dataGridViewStocksTab2.CurrentRow.Cells[2].Value.ToString();

                            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Delete This Stocks?", "Delete Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                                {
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand = new MySqlCommand("DeleteStocksByID", mysqlCon);
                                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand.Parameters.AddWithValue("_StocksID", StocksID);
                                    mySqlCommand.ExecuteNonQuery();
                                    GridFillIndividualStocksTab2();
                                    SetExpirationDateForIndividual();
                                    SetNumberOfStocks();

                                    
                                    //Insert Into stocksindividual_log table in Database
                                    string DateAddedLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                                    MySqlCommand mySqlCommand2 = new MySqlCommand("InsertIndividualStocksLog", mysqlCon);
                                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand2.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                                    mySqlCommand2.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                                    mySqlCommand2.Parameters.AddWithValue("_StocksID", StocksID);
                                    mySqlCommand2.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand2.Parameters.AddWithValue("_ProductName", ProductName);
                                    mySqlCommand2.Parameters.AddWithValue("_DateAndTime", DateAddedLog);
                                    mySqlCommand2.Parameters.AddWithValue("_Action", "Delete");
                                    mySqlCommand2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Individual Stocks is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + " " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                resultFromValidation = false;
            }
        }

        public void SetNumberOfStocks()
        {
            //Total Products
            if (comboBoxStocks.SelectedIndex == 0)
            {
                lblTotalNumberOFStocks.Hide(); lblTotalNumberOfStocksValue.Hide();
                lblNumberOfProducts.Show(); lblNumberOfProductsValue.Show();
                lblNumberOfProductsValue.Text = dataGridViewStocksTab2.Rows.Count.ToString();
            }
            //Individual Stocks
            else
            {
                lblNumberOfProducts.Hide(); lblNumberOfProductsValue.Hide();
                lblTotalNumberOFStocks.Show(); lblTotalNumberOfStocksValue.Show();
                lblTotalNumberOfStocksValue.Text = dataGridViewStocksTab2.Rows.Count.ToString();
            }
        }

        private void txtSearchTab2_OnValueChanged(object sender, EventArgs e)
        {
            comboBoxStocksStatus.SelectedIndex = 0;

            try
            {
                if (comboBoxStocks.SelectedIndex == 0)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridViewStocksTab2.DataSource;
                    bs.Filter = "Convert([ProductID], 'System.String') LIKE '%" + txtSearchTab2.Text + "%'"
                                + "OR [ProductName] LIKE '%" + txtSearchTab2.Text + "%'";

                    dataGridViewStocksTab2.DataSource = bs;
                    SetStocksQuantity();
                    SetNumberOfStocks();

                }
                else
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridViewStocksTab2.DataSource;
                    bs.Filter = "Convert([StocksID], 'System.String') LIKE '%" + txtSearchTab2.Text + "%'"
                                + "OR Convert([ProductID], 'System.String') LIKE '%" + txtSearchTab2.Text + "%'"
                                + "OR [ProductName] LIKE '%" + txtSearchTab2.Text + "%'"
                                + "OR [Status] LIKE '%" + txtSearchTab2.Text + "%'";


                    dataGridViewStocksTab2.DataSource = bs;
                    SetExpirationDateForIndividual();
                    SetNumberOfStocks();
                }
            }
            catch(EvaluateException ex)
            {
                //Do Nothing...
            }

            //For Print Button Stocks
            try
            {
                if (dataGridViewStocksTab2.CurrentRow.Index != -1)
                {
                    btnPrintStocks.Enabled = true;
                }
            }
            catch (NullReferenceException ex)
            {
                btnPrintStocks.Enabled = false;
            }
        }

        public void SetTotalOrIndividualStocks()
        {
            //Total Products
            if (comboBoxStocks.SelectedIndex == 0)
            {
                dataGridViewStocksTab2.DataSource = null;
                GridFillTotalStocksTab2();
                dataGridStocksTotalTab2DesignAndWidth();
                btnUpdateStocks.Hide(); btnAddStocks.Hide(); btnDeleteStocks.Hide(); bunifuSwitchStocks.Hide();
                lblStatus.Hide(); comboBoxStocksStatus.Hide();
                panelIndividualStocks.Hide();
                panelTotalStocks.Show();
                btnDeleteTotalStocks.Show();
                SetStocksQuantity();
            }
            //Individual Products
            else
            {
                dataGridViewStocksTab2.DataSource = null;
                GridFillIndividualStocksTab2();
                dataGridStocksIndividualTab2DesignAndWidth();
                btnUpdateStocks.Show(); btnAddStocks.Show(); btnDeleteStocks.Show();
                lblStatus.Show(); comboBoxStocksStatus.Show();
                panelTotalStocks.Hide();
                btnDeleteTotalStocks.Hide(); bunifuSwitchDeleteTotalStocks.Hide();
                panelIndividualStocks.Show();
                SetExpirationDateForIndividual();
            }

            SetNumberOfStocks();
        }

        public void SetExpirationDateForIndividual()
        {
            int NearlyExpired = 0;
            int Expired = 0;

            foreach (DataGridViewRow row in dataGridViewStocksTab2.Rows)
            {
                DateTime today = DateTime.Today;
                DateTime ExpirationDate = DateTime.ParseExact(row.Cells[5].Value.ToString(), "MM-dd-yyyy", CultureInfo.InvariantCulture);
                DateTime ThreeDaysBefore = ExpirationDate.AddDays(-3); //Three Days Before Expired

                //Nearly Expired
                if (today > ThreeDaysBefore && today < ExpirationDate)
                {
                    NearlyExpired++;
                    row.DefaultCellStyle.BackColor = Color.Gold;
                }
                //Expired
                else if (today >= ExpirationDate)
                {
                    Expired++;
                    row.DefaultCellStyle.BackColor = Color.Red;
                    UpdateStatusToExpired(Convert.ToInt32(row.Cells[0].Value)); //Update Good To Expired
                }
            }

            lblIndividualNearlyExpiredValue.Text = NearlyExpired.ToString();
            lblIndividualExpiredValue.Text = Expired.ToString();
        }

        private void FilterGoodExpired()
        {
            txtSearchTab2.Text = "";
            if (comboBoxStocksStatus.SelectedIndex == 1)
            {
                GridFillIndividualStocksTab2();
                SetExpirationDateForIndividual();
                SetNumberOfStocks();
            }
            else if (comboBoxStocksStatus.SelectedIndex == 2)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewStocksTab2.DataSource;
                bs.Filter = "[Status] LIKE '%Good%'";


                dataGridViewStocksTab2.DataSource = bs;
                SetExpirationDateForIndividual();
                SetNumberOfStocks();
            }
            else if (comboBoxStocksStatus.SelectedIndex == 3)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewStocksTab2.DataSource;
                bs.Filter = "[Status] LIKE '%Expired%'";


                dataGridViewStocksTab2.DataSource = bs;
                SetExpirationDateForIndividual();
                SetNumberOfStocks();
            }
            else
            {
                //Nothing
            }
        }

        private void UpdateStatusToExpired(int stocksID)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("UpdateStatusToExpiredByID", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_StocksID", stocksID);
                mySqlCommand.ExecuteNonQuery();
            }
        }

        private void DeleteStocksEmptyFromDatabase()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                //Delete Empty Stocks Within 10 Days of Period From Database
                mysqlCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("DeleteStocksEmptyByDate", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.ExecuteNonQuery();
            }
        }

        /*-------------------For Total Section------------------*/

        private void SetStocksQuantity()
        {
            int LowInStocks = 0;
            int OutOfStocks = 0;

            foreach (DataGridViewRow row in dataGridViewStocksTab2.Rows)
            {
                int Quantity = Convert.ToInt32(row.Cells[2].Value);

                if (Quantity <= 30 && Quantity > 0)
                {
                    LowInStocks++;
                    row.DefaultCellStyle.BackColor = Color.Gold;
                    row.ReadOnly = true;
                }
                else if (Quantity <= 0)
                {
                    OutOfStocks++;
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.ReadOnly = true;
                }
            }

            lblTotalLowinStocksValue.Text = LowInStocks.ToString();
            lblTotalOutOfStocksValue.Text = OutOfStocks.ToString();

        }

        private void bunifuSwitchDeleteTotalStocks_Click(object sender, EventArgs e)
        {
            if (bunifuSwitchDeleteTotalStocks.Value == true)
            {
                btnDeleteTotalStocks.Enabled = true;
            }
            else
            {
                btnDeleteTotalStocks.Enabled = false;
            }
        }

        private void btnDeleteTotalStocks_Click(object sender, EventArgs e)
        {
            DeleteTotalStocks();
        }

        private void DeleteTotalStocks()
        {
            //For Individual Stocks
            ValidateAdminPassword(); //Invoke PasswordDialog
            //If true
            if (resultFromValidation)
            {
                try
                {
                    if (dataGridViewStocksTab2.CurrentRow.Index != -1)
                    {
                        int ProductID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[0].Value);
                        string ProductName = dataGridViewStocksTab2.CurrentRow.Cells[1].Value.ToString();

                        DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Delete This Total Stocks? Deleting This Will Delete All Stocks Of This Product.", "Delete Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                            {
                                //Delete Total Stocks By ID   
                                mysqlCon.Open();
                                MySqlCommand mySqlCommand = new MySqlCommand("DeleteTotalStocksByID", mysqlCon);
                                mySqlCommand.CommandType = CommandType.StoredProcedure;
                                mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                                mySqlCommand.ExecuteNonQuery();
                                GridFillTotalStocksTab2();
                                SetStocksQuantity();
                                SetNumberOfStocks();
                                
                                //Insert Into stockstotal_log Table in Database
                                string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                                MySqlCommand mySqlCommand3 = new MySqlCommand("InsertTotalStocksLog", mysqlCon);
                                mySqlCommand3.CommandType = CommandType.StoredProcedure;
                                mySqlCommand3.Parameters.AddWithValue("_UsersID", usersData.UsersID);
                                mySqlCommand3.Parameters.AddWithValue("_UsersName", usersData.UsersName);
                                mySqlCommand3.Parameters.AddWithValue("_ProductID", ProductID);
                                mySqlCommand3.Parameters.AddWithValue("_ProductName", ProductName);
                                mySqlCommand3.Parameters.AddWithValue("_DateAndTime", DateAdded);
                                mySqlCommand3.Parameters.AddWithValue("_Action", "Deleted");
                                mySqlCommand3.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Total Stocks is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + " " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            resultFromValidation = false;
        }

    }

    public class UpdateStocksInfo
    {
        public int StocksID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string DateAdded { get; set; }
        public string ExpirationDate { get; set; }
        public string Status { get; set; }
    }

    public class ProductsInformation
    {
        public DataTable ProductsInformations { get; set; }
        public string Date { get; set; }
        public string NumberOfProducts { get; set; }
    }

    public class TotalStocksInformation
    {
        public DataTable TotalStocks { get; set; }
        public string Date { get; set; }
        public string NumberOfTotalStocks { get; set; }
    }
    public class IndividualStocksInformation
    {
        public DataTable IndividualStocks { get; set; }
        public string Date { get; set; }
        public string NumberOfIndividualStocks { get; set; }
    }
}
