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

namespace POSWithInventorySystem {
    public partial class StocksForm : Form {
        // Database Connection
        string connectionString = DatabaseConnection.Connection;
        
        LoginFormData usersData;

        private int UserID;

        private bool _firstLoaded;
        public bool resultFromValidation = false;
        
        public StocksForm() {
            InitializeComponent();
            this.Load += StocksForm_Load1; ;
            dataGridViewStocksTab2.VisibleChanged += DataGridViewStocksTab2_VisibleChanged;
        }

        public StocksForm(LoginFormData data) {
            InitializeComponent();
            this.Load += StocksForm_Load1; ;
            dataGridViewStocksTab2.VisibleChanged += DataGridViewStocksTab2_VisibleChanged;
            this.UserID = Convert.ToInt32(data.UsersID);
            this.usersData = data;
        }

        private void StocksForm_Load1(object sender, EventArgs e) {
            _firstLoaded = true;
        }

        private void DataGridViewStocksTab2_VisibleChanged(object sender, EventArgs e) {
            if (_firstLoaded && dataGridViewStocksTab2.Visible) {
                _firstLoaded = false;
                SetTotalOrIndividualStocks();
                SetProductActiveOrNot();
            }
        }

        private void StocksForm_Load(object sender, EventArgs e) {
            comboBoxStocks.SelectedIndex = 0; 
            comboBoxStocksStatus.SelectedIndex = 0;
           
            comboBoxProductStatusActiveOrNot.SelectedIndex = 0; 
            SetProductActiveOrNot();    
            SetNumberOfItems();
            SetTotalOrIndividualStocks();
            SetNumberOfStocks();
            HidePanelStatus();
            panelTotalStocks.Show();
            DeleteStocksEmptyFromDatabase();

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

        private void txtSearchValue_OnValueChanged(object sender, EventArgs e) {
            SearchProductByColumn();
        }

        private void dataGridViewProducts_DoubleClick(object sender, EventArgs e) {
            ViewProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            AddProduct();
            SetNumberOfItems();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            UpdateProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            DeleteProduct();
            SetNumberOfItems();
        }

        private void bunifuSwitch_Click(object sender, EventArgs e) {
            BunifuSwitchDeleteButton();
        }

        private void comboBoxProductStatusActiveOrNot_SelectedIndexChanged(object sender, EventArgs e) {
            SetProductActiveOrNot();
        }

        private void dataGridViewProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            //For active products
            if (comboBoxProductStatusActiveOrNot.SelectedIndex == 0) {
                //Insert code here if you want to show something when the selected index is active
            }
            
            //For inactive/deactivated products
            else {
                SetRowColorIntoRedWhenNotActive(); //Set DatagridView Color When ColumnHeader is Click, Refresh Purpose                
            }
        }

        public void GridFillWithStocksActive() {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsActiveForView", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dataGridViewProducts.DataSource = dataTable;

                //dataGridViewUsers.Columns[2].Visible = false;

                //For the print button
                //The code here was disabled due to some bug when running
                /*try {
                    if (dataGridViewProducts.CurrentRow.Index != -1) {
                        btnPrint.Enabled = true;
                    }
                }
                
                catch (NullReferenceException ex) {
                    btnPrint.Enabled = false;
                }*/
            }
        }

        private void GridFillWithStocksNotActive() {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsNotActiveForView", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dataGridViewProducts.DataSource = dataTable;

                //dataGridViewUsers.Columns[2].Visible = false;
            }
        }

        private void dataGridDesign() {
            dataGridViewProducts.EnableHeadersVisualStyles = false;
            dataGridViewProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void AddProduct() {
            ValidateAdminPassword();
            
            if (resultFromValidation) {
                AddProductsDialog addProductsDialog = new AddProductsDialog(usersData);
                addProductsDialog.Owner = this;
                addProductsDialog.ShowDialog();
            }

            resultFromValidation = false;
        }

        private void UpdateProduct() {
            try {
                ValidateAdminPassword(); 
                
                if (resultFromValidation) {
                    if (dataGridViewProducts.CurrentRow.Index != -1) {
                        int ProductIDForViewProduct = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);

                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this product?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes) {
                            using (UpdateProductDialog updateProductDialog = new UpdateProductDialog(ProductIDForViewProduct, usersData)) {
                                updateProductDialog.Owner = this;
                                updateProductDialog.ShowDialog();
                            }
                        }
                        
                        else {
                            return;
                        }
                    }
                }
                resultFromValidation = false;
            }
            
            catch (Exception ex) {
                MessageBox.Show("The products' list is empty. Please add products first.", "Empty product list", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteProduct() {
            try {
                ValidateAdminPassword();
                
                if (resultFromValidation) {
                    if (dataGridViewProducts.CurrentRow.Index != -1) {

                        int ProductID = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);
                        string ProductName = dataGridViewProducts.CurrentRow.Cells[2].Value.ToString();

                        //If the combobox index is set to "Active"
                        if (comboBoxProductStatusActiveOrNot.SelectedIndex == 0) {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to deactivate this product?", "Deactivate Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            
                            if (dialogResult == DialogResult.Yes) {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                                    //Delete the stocks of selected ProductID
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand2 = new MySqlCommand("DeleteTotalStocksByID", mysqlCon);
                                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand2.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand2.ExecuteNonQuery();

                                    //Delete the product from the list
                                    MySqlCommand mySqlCommand = new MySqlCommand("UpdateProductStatustoNotActive", mysqlCon);
                                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand.ExecuteNonQuery();
                                    GridFillWithStocksActive();
                                    SetNumberOfItems();
                                    SetTotalOrIndividualStocks();

                                    //Insert to Products' History
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
                            
                            else return;
                        }
                        
                        else {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to activate this product?", "Activate Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            
                            if (dialogResult == DialogResult.Yes) {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                                    //Activating the product
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand = new MySqlCommand("UpdateProductStatustoActive", mysqlCon);
                                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand.ExecuteNonQuery();
                                    GridFillWithStocksNotActive();
                                    SetRowColorIntoRedWhenNotActive();
                                    SetNumberOfItems();
                                    SetTotalOrIndividualStocks();

                                    //Insert to Products' History
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
                            
                            else return;
                        }
                    }
                }
                resultFromValidation = false;
            }
            
            catch (Exception ex) {
                resultFromValidation = false; //Reset True to False
                MessageBox.Show("The products' list is empty. Please add products first.", "Empty product list", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ViewProduct() {
            try {
                if (dataGridViewProducts.CurrentRow.Index != -1) {
                    int ProductIDForViewProduct = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);

                    ViewProductDialog viewProductDialog = new ViewProductDialog(ProductIDForViewProduct);
                    viewProductDialog.Owner = this;
                    viewProductDialog.ShowDialog();
                }
            }
            
            catch {
               MessageBox.Show("The products' list is empty. Please add products first.", "Empty product list", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SearchProductByColumn() {
            try {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewProducts.DataSource;
                bs.Filter = "Convert([ProductID], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR [BarCode] LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR [ProductName] LIKE '%" + txtSearchValue.Text + "%'";

                dataGridViewProducts.DataSource = bs;
            }
            catch(EvaluateException ex) {
                //Insert code here if you want to show error or something
            }

            //For active products
            if (comboBoxProductStatusActiveOrNot.SelectedIndex == 0) {
                //Insert code here if you want to show something
            }
            
            //For inactive/deactivated products
            else {
                SetRowColorIntoRedWhenNotActive();          
            }
            SetNumberOfItems();
            
            //For the print button
            //The current programmer's IDE cannot produce report so the btnPrint will be disabled
            try {
                if (dataGridViewProducts.CurrentRow.Index != -1) {
                    btnPrint.Enabled = false;
                }
            }
            
            catch(NullReferenceException ex) {
                btnPrint.Enabled = false;
            }
        }
        
        //Since we want to click directly the buttons, this switch has been partially disabled and returns true always
        private void BunifuSwitchDeleteButton() {
            if (bunifuSwitch.Value == true) {
                btnDelete.Enabled = true;
            }
            
            else {
                btnDelete.Enabled = false;
            }
        }

        public void SetNumberOfItems() {
            lblNumberOfItemsValue.Text = dataGridViewProducts.Rows.Count.ToString();
        }

        private void dataGridViewWithActivateAndNotActive() {
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

        private void SetProductActiveOrNot() {
            //For active products
            if(comboBoxProductStatusActiveOrNot.SelectedIndex == 0) {
                dataGridViewProducts.DataSource = null;
                dataGridDesign();
                GridFillWithStocksActive();
                dataGridViewWithActivateAndNotActive();
                SetNumberOfItems();
                
                //Sets the new location and size for delete button
                btnDelete.Text = "Deactivate";
                btnDelete.Location = new Point(739, 624);
                btnDelete.Size = new Size(298, 48);
                
                //Sets the new location and size for BunifuSwitch
                bunifuSwitch.Location = new Point(717, 634);
                
                btnDeleteProductInDB.Hide(); bunifuSwitchbtnDeleteProductInDB.Hide();
                
                btnAdd.Show(); btnUpdate.Show(); btnDelete.Show();
                btnPrint.Hide();
            }
            
            //For inactive/deactivated products
            else {
                dataGridViewProducts.DataSource = null;
                dataGridDesign();
                GridFillWithStocksNotActive();
                dataGridViewWithActivateAndNotActive();
                SetRowColorIntoRedWhenNotActive();
                SetNumberOfItems();
                
                //Sets the new location and size for delete button
                btnDelete.Text = "Activate";
                btnDelete.Location = new Point(34, 624);
                btnDelete.Size = new Size(469, 48);
            
                //Sets the new location and size for BunifuSwitch
                bunifuSwitch.Location = new Point(366, 633);
                bunifuSwitch.Hide();
                
                btnAdd.Hide(); btnUpdate.Hide();
               
                btnDeleteProductInDB.Show();
                btnPrint.Hide();
            }
        }

        private void SetRowColorIntoRedWhenNotActive() {
            foreach (DataGridViewRow row in dataGridViewProducts.Rows) {
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void bunifuSwitchbtnDeleteProductInDB_Click(object sender, EventArgs e) {
            if (bunifuSwitchbtnDeleteProductInDB.Value == true) {
                btnDeleteProductInDB.Enabled = true;
            }
            else {
                btnDeleteProductInDB.Enabled = false;
            }
        }

        private void btnDeleteProductInDB_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword();
                
                if (resultFromValidation) {
                    if (dataGridViewProducts.CurrentRow.Index != -1) {
                        int ProductID = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);
                        string ProductName = dataGridViewProducts.CurrentRow.Cells[2].Value.ToString();

                        //If the combobox was set to "Deactivate"
                        if (comboBoxProductStatusActiveOrNot.SelectedIndex == 1) {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this product? This cannot be undone.", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            
                            if (dialogResult == DialogResult.Yes) {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                                    //Delete the stocks of the selected ProductID
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand2 = new MySqlCommand("DeleteTotalStocksByID", mysqlCon);
                                    mySqlCommand2.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand2.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand2.ExecuteNonQuery();

                                    //Delete the product
                                    MySqlCommand mySqlCommand = new MySqlCommand("DeleteProduct", mysqlCon);
                                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                                    mySqlCommand.ExecuteNonQuery();
                                    GridFillWithStocksNotActive(); 
                                    SetRowColorIntoRedWhenNotActive();
                                    SetNumberOfItems();
                                    SetTotalOrIndividualStocks();

                                    //Insert to Products' History
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
                            else {
                                return;
                            }
                        }
                    }
                }
                resultFromValidation = false;
            }
            
            catch (Exception ex) {
                resultFromValidation = false; //Reset True to False
                MessageBox.Show("The products' list is empty. Please add products first.", "Empty product list", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductID", typeof(string));
            dataTable.Columns.Add("Barcode", typeof(string));
            dataTable.Columns.Add("ProductName", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("PurchasePrice", typeof(string));
            dataTable.Columns.Add("SellingPrice", typeof(string));

            foreach (DataGridViewRow row in dataGridViewProducts.Rows) {
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

        private void HidePanelStatus() {
            panelIndividualStocks.Hide();
            panelTotalStocks.Hide();
        }

        private void dataGridViewStocksTab2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            //Total Products
            if (comboBoxStocks.SelectedIndex == 0) {
                SetStocksQuantity();
            }
            
            //Individual Products
            else {
                SetExpirationDateForIndividual();
            }
        }

        private void ValidateAdminPassword() {
            ValidateAdminPasswordDialog  validateAdminPassword = new ValidateAdminPasswordDialog(UserID, "StocksForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }   

        private void btnPrintStocks_Click(object sender, EventArgs e) {
            //Total Products
            if (comboBoxStocks.SelectedIndex == 0) {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ProductID", typeof(string));
                dataTable.Columns.Add("ProductName", typeof(string));
                dataTable.Columns.Add("TotalQuantity", typeof(string));

                foreach (DataGridViewRow row in dataGridViewStocksTab2.Rows) {
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
            else {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("StocksID", typeof(string));
                dataTable.Columns.Add("ProductID", typeof(string));
                dataTable.Columns.Add("ProductName", typeof(string));
                dataTable.Columns.Add("Quantity", typeof(string));
                dataTable.Columns.Add("Date_Added", typeof(string));
                dataTable.Columns.Add("Expiration_Date", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));

                foreach (DataGridViewRow row in dataGridViewStocksTab2.Rows) {
                    dataTable.Rows.Add(row.Cells[0].Value, 
                                       row.Cells[1].Value, 
                                       row.Cells[2].Value, 
                                       row.Cells[3].Value,
                                       row.Cells[4].Value, 
                                       row.Cells[5].Value, 
                                       row.Cells[6].Value);
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

        //Stocks Tab
        public void GridFillIndividualStocksTab2() {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewAllStocks", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dataGridViewStocksTab2.DataSource = dataTable;

                //For Print Button
                //Once again, it has been disabled due to a bug
                /*try {
                    if (dataGridViewStocksTab2.CurrentRow.Index != -1) {
                        btnPrintStocks.Enabled = true;
                    }
                }
                
                catch (NullReferenceException ex) {
                    btnPrintStocks.Enabled = false;
                }*/
            }
        }

        public void GridFillTotalStocksTab2() {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewTotalPerProductQuantity", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dataGridViewStocksTab2.DataSource = dataTable;

                //For Print Button
                //Once again, it has been disabled due to a bug
                /*try {
                    if (dataGridViewStocksTab2.CurrentRow.Index != -1) {
                        btnPrintStocks.Enabled = true;
                    }
                }
                catch (NullReferenceException ex) {
                    btnPrintStocks.Enabled = false;
                }*/
            }
        }

        private void dataGridStocksIndividualTab2DesignAndWidth() {
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

        private void dataGridStocksTotalTab2DesignAndWidth() {
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

        private void btnAddStocks_Click(object sender, EventArgs e) {
            AddStocks();
        }

        private void AddStocks() {
            ValidateAdminPassword();

            if (resultFromValidation) {
                AddStocksDialog addStocksDialog = new AddStocksDialog(usersData);
                addStocksDialog.Owner = this;
                addStocksDialog.ShowDialog();
            }
            resultFromValidation = false;
        }

        private void btnUpdateStocks_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword();
                
                if (resultFromValidation) {
                    if (dataGridViewProducts.CurrentRow.Index != -1) {
                        UpdateStocksInfo stocksInfo = new UpdateStocksInfo();

                        stocksInfo.StocksID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[0].Value);
                        stocksInfo.ProductID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[1].Value);
                        stocksInfo.ProductName = dataGridViewStocksTab2.CurrentRow.Cells[2].Value.ToString();
                        stocksInfo.Quantity = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[3].Value);
                        stocksInfo.DateAdded = dataGridViewStocksTab2.CurrentRow.Cells[4].Value.ToString();
                        stocksInfo.ExpirationDate = dataGridViewStocksTab2.CurrentRow.Cells[5].Value.ToString();
                        stocksInfo.Status = dataGridViewStocksTab2.CurrentRow.Cells[6].Value.ToString();

                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to update the stocks of the selected product?", "Update stocks of selected product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes) {
                            using (UpdateStocksDialog updateStocksDialog = new UpdateStocksDialog(stocksInfo, usersData)) {
                                updateStocksDialog.Owner = this;
                                updateStocksDialog.ShowDialog();
                            }
                        }
                        else return;
                    }
                }
                resultFromValidation = false;
            }
            
            catch (Exception ex) {
                MessageBox.Show("The products' list is empty. Please add product first.", "Empty product list", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 

        private void btnDeleteStocks_Click(object sender, EventArgs e) {
            DeleteStocks();
        }

        private void bunifuSwitchStocks_Click(object sender, EventArgs e) {
            if (bunifuSwitchStocks.Value == true) {
                btnDeleteStocks.Enabled = true;
            }
            
            else {
                btnDeleteStocks.Enabled = false;
            }
        }

        private void comboBoxStocks_SelectedIndexChanged(object sender, EventArgs e) {
            SetTotalOrIndividualStocks();
        }

        private void comboBoxStocksStatus_SelectedIndexChanged(object sender, EventArgs e) {
            FilterGoodExpired();
        }

        private void DeleteStocks() {
            //Individual Stocks
            if (comboBoxStocks.SelectedIndex == 1) {
                ValidateAdminPassword();

                if (resultFromValidation) {
                    try {
                        if (dataGridViewStocksTab2.CurrentRow.Index != -1) {
                            int StocksID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[0].Value);
                            int ProductID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[1].Value);
                            string ProductName = dataGridViewStocksTab2.CurrentRow.Cells[2].Value.ToString();

                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the stocks of the selected product?", "Delete product's stock", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            
                            if (dialogResult == DialogResult.Yes) {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand = new MySqlCommand("DeleteStocksByID", mysqlCon);
                                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand.Parameters.AddWithValue("_StocksID", StocksID);
                                    mySqlCommand.ExecuteNonQuery();
                                    GridFillIndividualStocksTab2();
                                    SetExpirationDateForIndividual();
                                    SetNumberOfStocks();

                                    //Insert to Stocks History
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
                            
                            else return;
                        }
                    }
                    
                    catch (NullReferenceException) {
                        MessageBox.Show("The individual stocks list is empty.", "Empty individual stocks", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    catch(Exception ex) {
                        MessageBox.Show("There was an error in executing the code: " + " " + ex, "Error in system", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                resultFromValidation = false;
            }
        }

        public void SetNumberOfStocks() {
            //Total Products
            if (comboBoxStocks.SelectedIndex == 0) {
                lblTotalNumberOFStocks.Hide(); lblTotalNumberOfStocksValue.Hide();
                lblNumberOfProducts.Show(); lblNumberOfProductsValue.Show();
                lblNumberOfProductsValue.Text = dataGridViewStocksTab2.Rows.Count.ToString();
            }
            
            //Individual Stocks
            else {
                lblNumberOfProducts.Hide(); lblNumberOfProductsValue.Hide();
                lblTotalNumberOFStocks.Show(); lblTotalNumberOfStocksValue.Show();
                lblTotalNumberOfStocksValue.Text = dataGridViewStocksTab2.Rows.Count.ToString();
            }
        }

        private void txtSearchTab2_OnValueChanged(object sender, EventArgs e) {
            comboBoxStocksStatus.SelectedIndex = 0;

            try {
                if (comboBoxStocks.SelectedIndex == 0) {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridViewStocksTab2.DataSource;
                    bs.Filter = "Convert([ProductID], 'System.String') LIKE '%" + txtSearchTab2.Text + "%'"
                                + "OR [ProductName] LIKE '%" + txtSearchTab2.Text + "%'";

                    dataGridViewStocksTab2.DataSource = bs;
                    SetStocksQuantity();
                    SetNumberOfStocks();
                }
                
                else {
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
                //Insert code here if you want to show error or something
            }

            //For Print Button Stocks
            try {
                if (dataGridViewStocksTab2.CurrentRow.Index != -1) {
                    btnPrintStocks.Enabled = true;
                }
            }
            
            catch (NullReferenceException ex) {
                btnPrintStocks.Enabled = false;
            }
        }

        public void SetTotalOrIndividualStocks() {
            //Total Products
            if (comboBoxStocks.SelectedIndex == 0) {
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
            else {
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

        public void SetExpirationDateForIndividual() {
            int NearlyExpired = 0;
            int Expired = 0;

            foreach (DataGridViewRow row in dataGridViewStocksTab2.Rows) {
                DateTime today = DateTime.Today;
                DateTime ExpirationDate = DateTime.ParseExact(row.Cells[5].Value.ToString(), "MM-dd-yyyy", CultureInfo.InvariantCulture);
                
                //Warning for three days before expiration date
                DateTime ThreeDaysBefore = ExpirationDate.AddDays(-3);

                //Nearly Expired
                if (today > ThreeDaysBefore && today < ExpirationDate) {
                    NearlyExpired++;
                    row.DefaultCellStyle.BackColor = Color.Gold;
                }
                
                //Expired
                else if (today >= ExpirationDate) {
                    Expired++;
                    row.DefaultCellStyle.BackColor = Color.Red;
                    UpdateStatusToExpired(Convert.ToInt32(row.Cells[0].Value)); //Update Good To Expired
                }
            }

            lblIndividualNearlyExpiredValue.Text = NearlyExpired.ToString();
            lblIndividualExpiredValue.Text = Expired.ToString();
        }

        private void FilterGoodExpired() {
            txtSearchTab2.Text = "";
            
            if (comboBoxStocksStatus.SelectedIndex == 1) {
                GridFillIndividualStocksTab2();
                SetExpirationDateForIndividual();
                SetNumberOfStocks();
            }
            
            else if (comboBoxStocksStatus.SelectedIndex == 2) {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewStocksTab2.DataSource;
                bs.Filter = "[Status] LIKE '%Good%'";


                dataGridViewStocksTab2.DataSource = bs;
                SetExpirationDateForIndividual();
                SetNumberOfStocks();
            }
            
            else if (comboBoxStocksStatus.SelectedIndex == 3) {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewStocksTab2.DataSource;
                bs.Filter = "[Status] LIKE '%Expired%'";


                dataGridViewStocksTab2.DataSource = bs;
                SetExpirationDateForIndividual();
                SetNumberOfStocks();
            }
            
            else {
                //Insert code here if you want to show something
            }
        }

        private void UpdateStatusToExpired(int stocksID) {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("UpdateStatusToExpiredByID", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_StocksID", stocksID);
                mySqlCommand.ExecuteNonQuery();
            }
        }

        private void DeleteStocksEmptyFromDatabase() {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                //Automatically delete stocks when the stocks reaches 10 days without interaction
                mysqlCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("DeleteStocksEmptyByDate", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.ExecuteNonQuery();
            }
        }

        //Total Stocks
        private void SetStocksQuantity() {
            int LowInStocks = 0;
            int OutOfStocks = 0;

            foreach (DataGridViewRow row in dataGridViewStocksTab2.Rows) {
                int Quantity = Convert.ToInt32(row.Cells[2].Value);

                if (Quantity <= 30 && Quantity > 0) {
                    LowInStocks++;
                    row.DefaultCellStyle.BackColor = Color.Gold;
                    row.ReadOnly = true;
                }
                
                else if (Quantity <= 0) {
                    OutOfStocks++;
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.ReadOnly = true;
                }
            }

            lblTotalLowinStocksValue.Text = LowInStocks.ToString();
            lblTotalOutOfStocksValue.Text = OutOfStocks.ToString();
        }

        private void bunifuSwitchDeleteTotalStocks_Click(object sender, EventArgs e) {
            if (bunifuSwitchDeleteTotalStocks.Value == true) {
                btnDeleteTotalStocks.Enabled = true;
            }
            
            else {
                btnDeleteTotalStocks.Enabled = false;
            }
        }

        private void btnDeleteTotalStocks_Click(object sender, EventArgs e) {
            DeleteTotalStocks();
        }

        private void DeleteTotalStocks() {
            //For Individual Stocks
            ValidateAdminPassword();
            
            if (resultFromValidation) {
                try {
                    if (dataGridViewStocksTab2.CurrentRow.Index != -1) {
                        int ProductID = Convert.ToInt32(dataGridViewStocksTab2.CurrentRow.Cells[0].Value);
                        string ProductName = dataGridViewStocksTab2.CurrentRow.Cells[1].Value.ToString();

                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all stocks? This cannot be undone.", "Delete all stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        
                        if (dialogResult == DialogResult.Yes) {
                            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                                //Delete total stocks for selected ProductID   
                                mysqlCon.Open();
                                MySqlCommand mySqlCommand = new MySqlCommand("DeleteTotalStocksByID", mysqlCon);
                                mySqlCommand.CommandType = CommandType.StoredProcedure;
                                mySqlCommand.Parameters.AddWithValue("_ProductID", ProductID);
                                mySqlCommand.ExecuteNonQuery();
                                GridFillTotalStocksTab2();
                                SetStocksQuantity();
                                SetNumberOfStocks();
                                
                                //Insert to Stocks' History
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
                        
                        else return;
                    }
                }
                catch (NullReferenceException) {
                    MessageBox.Show("The total stocks is empty", "Empty total stocks", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                catch(Exception ex) {
                    MessageBox.Show("There was an error while executing the command: " + " " + ex, "Error in System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            resultFromValidation = false;
        }

    }

    public class UpdateStocksInfo {
        public int StocksID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string DateAdded { get; set; }
        public string ExpirationDate { get; set; }
        public string Status { get; set; }
    }

    public class ProductsInformation {
        public DataTable ProductsInformations { get; set; }
        public string Date { get; set; }
        public string NumberOfProducts { get; set; }
    }

    public class TotalStocksInformation {
        public DataTable TotalStocks { get; set; }
        public string Date { get; set; }
        public string NumberOfTotalStocks { get; set; }
    }
    
    public class IndividualStocksInformation {
        public DataTable IndividualStocks { get; set; }
        public string Date { get; set; }
        public string NumberOfIndividualStocks { get; set; }
    }
}
