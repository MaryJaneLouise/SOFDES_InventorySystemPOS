using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSWithInventorySystem
{
    public partial class POSTransactionForm : Form
    {
        public POSTransactionForm()
        {
            InitializeComponent();
        }

        public POSTransactionForm(int userID, string username)
        {
            InitializeComponent();
            //Get UserID or Cashier
            this.UserID = userID;
            this.UserName = username;
        }
        List<int> ListProductID = new List<int>();

        // Database Connection
        string connectionString = DatabaseConnection.Connection;

        int UserID;
        string UserName;
        double subtotal = 0;
        double discount = 0; //For Discount Purpose.
        public string Userdiscounted = "None"; 
        double discountAmount = 0;
        double Vat = 0;
        double SubTotalMinusVat = 0;
        double TotalAmount;
        public bool result = false;
        public double AmountTendered = 0;
        public bool validateAmount = true;
        public bool resultFromPasswordValidationDiscount = false; //For Admin Validation Discount
        MainForm mainForm;

        private void POSTransactionForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSearch; //For TextBox Focus When Form Load
            AutoComplete(); //For Sugggestion When Typing in TextBox
            dataGridWidth(); //With of Grid
            HideAndDisablePaymentScenarioControls();
            panelNewTransaction.Hide();
            mainForm = (MainForm)this.Owner;
        }

        private void POSTransactionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && btnPayment.Enabled == true)
            {
                Payment();
            }
            if (e.KeyCode == Keys.F8 && btnDiscount.Enabled == true)
            {
                btnDiscountTrigger();
            }
            if(e.KeyCode == Keys.F9 && btnAddQuantity.Enabled == true)
            {
                btnAddQuantityTrigger();
            }
            if(e.KeyCode == Keys.F10 && btnVoid.Enabled == true)
            {
                btnVoidTrigger();
            }
            if (e.KeyCode == Keys.F12 && btnCancelTransaction.Enabled == true)
            {
                btnCancelTransactionTrigger();
                mainForm.ShowAndHideButtonMenus("Show"); //Set Mainforms Button to Show
            }
            if (e.KeyCode == Keys.Escape && btnNewTransaction.Enabled == true)
            {
                StartNewTransaction();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectProduct();
            }
        }

        private void AutoComplete()
        {
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsForView", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    string name = row["BarCode"].ToString();
                    coll.Add(name);
                }
            }

            txtSearch.AutoCompleteCustomSource = coll;

        }

        private void dataGridWidth()
        {
            //Width
            dataGridViewItems.Columns[0].Width = 70;
            dataGridViewItems.Columns[1].Width = dataGridViewItems.Width - dataGridViewItems.Columns[0].Width - dataGridViewItems.Columns[2].Width - dataGridViewItems.Columns[3].Width - dataGridViewItems.Columns[3].Width - 72;
            dataGridViewItems.Columns[2].Width = 45;
            dataGridViewItems.Columns[3].Width = 70;
            dataGridViewItems.Columns[4].Width = 130;
        
            //Design
            dataGridViewItems.EnableHeadersVisualStyles = false;
            dataGridViewItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewItems.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; //Color.FromArgb(20, 25, 72);
            dataGridViewItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void SelectProduct()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter("SelectProductByBarCode", mysqlCon);
                mySqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySqlDa.SelectCommand.Parameters.AddWithValue("_BarCode", txtSearch.Text.Trim());
                DataTable dataTable = new DataTable();
                mySqlDa.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    ShowButtonControls(); //Show Payment, Discount, Add Qty, CancelTransaction, btnNewTransaction Button 

                    string BarCodeForValidateQty = dataTable.Rows[0]["BarCode"].ToString();
                    string PriceForValidteQty = dataTable.Rows[0]["Price"].ToString();

                    //Validate if there have enough stocks
                    if (!ValidateProductQuantity(BarCodeForValidateQty, PriceForValidteQty, 1))
                    {
                        mainForm.ShowAndHideButtonMenus("Hide"); //Hide MenusButton
                        bool found = false;
                        if (dataGridViewItems.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dataGridViewItems.Rows)
                            {
                                //If Barcode have the same product Code and Price Update Quantity...
                                if (Convert.ToString(row.Cells[0].Value) == txtSearch.Text.Trim() && Convert.ToString(row.Cells[3].Value) == PriceForValidteQty.Trim())
                                {
                                    if (!ValidateProductQuantity(BarCodeForValidateQty, PriceForValidteQty, (Convert.ToInt32(row.Cells[2].Value)) + 1))
                                    {
                                        row.Cells[2].Value = Convert.ToString(1 + Convert.ToInt16(row.Cells[2].Value));
                                    }
                                    else
                                    {
                                        MessageBox.Show("Out of Stocks", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    found = true;
                                }
                            }
                            //If not existing product in datagridview, insert that item...
                            if (!found)
                            {
                                string BarCode = dataTable.Rows[0]["BarCode"].ToString();
                                string ProductName = dataTable.Rows[0]["ProductName"].ToString();
                                int Quantity = 1;
                                string Price = dataTable.Rows[0]["Price"].ToString();
                                int ProductID = Convert.ToInt32(dataTable.Rows[0]["ProductID"]);

                                dataGridViewItems.Rows.Add(BarCode, ProductName, Quantity.ToString().Trim(), Price);
                                ListProductID.Add(ProductID); //List For ProductID, Stocks Decrease Purpose
                            }
                        }
                        else
                        {
                            string BarCode = dataTable.Rows[0]["BarCode"].ToString();
                            string ProductName = dataTable.Rows[0]["ProductName"].ToString();
                            int Quantity = 1;
                            string Price = dataTable.Rows[0]["Price"].ToString();
                            int ProductID = Convert.ToInt32(dataTable.Rows[0]["ProductID"]);

                            dataGridViewItems.Rows.Add(BarCode, ProductName, Quantity.ToString().Trim(), Price);
                            ListProductID.Add(ProductID); //List For ProductID, Stocks Decrease Purpose
                        }

                        ComputeTotalSubtotalAndVat(); //Compute Total Subtotal and Vat From Ui
                        SetDiscountedTotalSubtotalAndVat(); //Set Discounted Total, Subtotal and Vat If Discount Amount Is not 0

                    }
                    else
                    {
                        MessageBox.Show("Out Of Stack", "Stock out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This Product Are Not Available", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                txtSearch.Text = "";
            }
        }

        private void ComputeTotalSubtotalAndVat()
        {
            //Compute and Fill Amount Column in  datagridView...
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                double price = Convert.ToDouble(row.Cells[dataGridViewItems.Columns["Price"].Index].Value);
                double quantity = Convert.ToDouble(row.Cells[dataGridViewItems.Columns["Quantity"].Index].Value);
                row.Cells[dataGridViewItems.Columns["Amount"].Index].Value = String.Format("{0:n}",(price * quantity));
            }

            //Get SubTotal
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                subtotal = subtotal + Convert.ToDouble(row.Cells[dataGridViewItems.Columns["Amount"].Index].Value);
            }

            //Get and Print VAT
            Vat = Math.Round(((subtotal / 1.12) * .12), 2);
            lblVatValue.Text = String.Format("{0:n}", Vat);

            //Get and Print SubTotal
            SubTotalMinusVat = Math.Round((subtotal - Vat), 2);
            lblSubTotalValue.Text = String.Format("{0:n}", SubTotalMinusVat);

            //Get and Set TotalAmount
            TotalAmount = Vat + SubTotalMinusVat;
            lblTotalAmountValue.Text = String.Format("{0:n}", TotalAmount);

            subtotal = 0; //Reset Subtotal to 0
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            btnVoidTrigger();
        }

        public int QuantityFromUpdateCart { get; set; }
        private void btnVoidTrigger()
        {
            try
            {
                ProductVoidDialog productVoidDialog = new ProductVoidDialog();
                productVoidDialog.Owner = this;
                productVoidDialog.ShowDialog();

                //If true
                if (result)
                {
                    foreach (DataGridViewRow row in dataGridViewItems.SelectedRows)
                    {
                        string Barcode = row.Cells[dataGridViewItems.Columns["Code"].Index].Value.ToString();
                        string ProductName = row.Cells[dataGridViewItems.Columns["ProductName"].Index].Value.ToString();
                        string Price = row.Cells[dataGridViewItems.Columns["Price"].Index].Value.ToString();
                        int Quantity = Convert.ToInt32(row.Cells[dataGridViewItems.Columns["Quantity"].Index].Value);

                        //If Quantity is Zero Delete Immediately
                        if (Quantity <= 1)
                        {
                            ListProductID.RemoveAt(row.Index);

                            dataGridViewItems.Rows.RemoveAt(row.Index);
                            ComputeTotalSubtotalAndVat(); //Compute Total, Subtotal and Vat Not Discounted
                            SetDiscountedTotalSubtotalAndVat(); //Set Discounted Total, Subtotal and Vat If Discount Amount Is not 0
                        }
                        //If Quantity is Greatet Than Zero
                        else
                        {
                            UpdateCartQuanitity updateCartQuanitity = new UpdateCartQuanitity(Barcode, ProductName, Price, Quantity);
                            updateCartQuanitity.Owner = this;
                            updateCartQuanitity.ShowDialog();

                            //Update Quantity Set Current Quantity Minus Input Value
                            if (row.Cells["Quantity"].Value.ToString() == QuantityFromUpdateCart.ToString()) //If Remaining is Zero Delete Row in Gridview
                            {
                                ListProductID.RemoveAt(row.Index);
                                dataGridViewItems.Rows.RemoveAt(row.Index);
                            }
                            else
                            {
                                row.Cells["Quantity"].Value = Convert.ToString(Convert.ToInt32(row.Cells["Quantity"].Value) - QuantityFromUpdateCart);
                            }

                            ComputeTotalSubtotalAndVat(); //Compute Total, Subtotal and Vat Not Discounted
                            SetDiscountedTotalSubtotalAndVat(); //Set Discounted Total, Subtotal and Vat If Discount Amount Is not 0
                        }
                    }

                    QuantityFromUpdateCart = 0;
                }

                result = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("List<T>: " + ex);
            }
        }

        private bool ValidateProductQuantity(string barcode, string price, int quantityInCart)
        {
            //If true Means Not enough stocks
            bool resultQuantity = false;

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter("SelectCurrentProductQuantity", mysqlCon);
                mySqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySqlDa.SelectCommand.Parameters.AddWithValue("_BarCode", barcode);
                mySqlDa.SelectCommand.Parameters.AddWithValue("_Price", price);
                DataTable dataTable = new DataTable();
                mySqlDa.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    double CurrentQuantity = Convert.ToDouble(dataTable.Rows[0]["Quantity"].ToString());
                    if (CurrentQuantity < quantityInCart)
                    {
                        resultQuantity = true;
                    }
                }
            }

            return resultQuantity;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment();
        }

        private void Payment()
        {
            //Hide Vat and subtotal Controls From Ui
            lblVat.Hide(); lblVatValue.Hide();
            lblSubTotal.Hide(); lblSubTotalValue.Hide();
                   
            //Show Change and PictureBox From Ui
            
            lblAmountPayment.Show(); bunifuTransition3.ShowSync(lblAmountPaymentValue);
            lblChange.Show(); bunifuTransition3.ShowSync(lblChangeValue);

            ProductPaymentDialog productPaymentDialog = new ProductPaymentDialog(Convert.ToDouble(lblTotalAmountValue.Text.Trim()));
            productPaymentDialog.Owner = this;
            productPaymentDialog.ShowDialog();

            //IF Payment is Filled
            if (!validateAmount)
            {
                if (dataGridViewItems.Rows.Count > 0)
                {
                    lblChangeValue.Text = String.Format("{0:n}", Math.Round((Convert.ToDouble(lblAmountPaymentValue.Text.Trim()) - Convert.ToDouble(lblTotalAmountValue.Text.Trim())), 2));
                    FinalTransaction();
                }
                else
                {
                    MessageBox.Show("No Item in Cart", "Item Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblAmountPaymentValue.Text = "0";
                }

                validateAmount = true;
            }
            else
            {
                lblAmountPaymentValue.Text = "0";
            }
        }

        private void FinalTransaction()
        {
            //Decrease Quantity From Database and Insert Transaction Data
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                string Barcode = row.Cells[dataGridViewItems.Columns["Code"].Index].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells[dataGridViewItems.Columns["Quantity"].Index].Value);

                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SelectStocksByBarcode", mysqlCon);
                    mySqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    mySqlDataAdapter.SelectCommand.Parameters.AddWithValue("_Barcode", Barcode);
                    DataTable dataTable = new DataTable();
                    mySqlDataAdapter.Fill(dataTable);

                    foreach (DataRow dtrow in dataTable.Rows)
                    {
                        int StocksID = Convert.ToInt32(dtrow["StocksID"]);
                        int NewQuantity = Convert.ToInt32(dtrow["Quantity"]) - quantity;

                        if (NewQuantity >= 0)
                        {
                            MySqlCommand mySqlCommand = new MySqlCommand("UpdateStocksQuantitySoldByID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_StocksID", StocksID);
                            mySqlCommand.Parameters.AddWithValue("_Quantity", NewQuantity);
                            mySqlCommand.ExecuteNonQuery();
                            break;
                        }
                        else
                        {
                            quantity = quantity - Convert.ToInt32(dtrow["Quantity"]);
                            MySqlCommand mySqlCommand = new MySqlCommand("UpdateStocksEmptyQtyToArchiveZero", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_StocksID", StocksID);
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }

            //Insert Transaction Data into Transaction Table in Database
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                MySqlCommand mySqlCommand = new MySqlCommand("AddTransactionData", mysqlCon);
                mysqlCon.Open();
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_Username", UserName);
                mySqlCommand.Parameters.AddWithValue("_TotalAmount", Convert.ToDouble(lblTotalAmountValue.Text.Trim()));
                mySqlCommand.Parameters.AddWithValue("_AmounTendered", Convert.ToDouble(lblAmountPaymentValue.Text.Trim()));
                mySqlCommand.Parameters.AddWithValue("_TotalChange", Convert.ToDouble(lblChangeValue.Text.Trim()));
                mySqlCommand.Parameters.AddWithValue("_Vat", Convert.ToDouble(lblVatValue.Text.Trim()));
                mySqlCommand.Parameters.AddWithValue("_Discount", discountAmount);
                mySqlCommand.Parameters.AddWithValue("_UserDiscounted", Userdiscounted);
                mySqlCommand.Parameters.AddWithValue("_Date", DateTime.Now.ToString("yyyy-MM-dd H:mm "));
                mySqlCommand.ExecuteNonQuery();
            }

            //Insert Product Transaction Data into Product_Transaction Table in Database
            try
            {
                foreach (DataGridViewRow row in dataGridViewItems.Rows)
                {

                    double PurchasePrice;

                    // Select PurchasePrice of Product by ProductID
                    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                    {
                        mysqlCon.Open();
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductPurchasePriceById", mysqlCon);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("_ProductID", ListProductID[row.Index]);
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);

                        PurchasePrice =  Convert.ToDouble(dataTable.Rows[0]["PurchasePrice"]);
                    }

                    // Insert into product transaction
                    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                    {
                        MySqlCommand mySqlCommand = new MySqlCommand("AddProductTransaction", mysqlCon);
                        mysqlCon.Open();
                        mySqlCommand.CommandType = CommandType.StoredProcedure;
                        mySqlCommand.Parameters.AddWithValue("_ProductID", ListProductID[row.Index]);
                        mySqlCommand.Parameters.AddWithValue("_PurchasePrice", PurchasePrice);
                        mySqlCommand.Parameters.AddWithValue("_SoldPrice", Convert.ToDouble(row.Cells[3].Value.ToString()));
                        mySqlCommand.Parameters.AddWithValue("_Quantity", Convert.ToInt32(row.Cells[2].Value.ToString()));
                        mySqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("List: " + ex);
            }


            HideButtonControls(); //Hide Payment, Discount, CancelTransaction, and Void Buttons
            txtSearch.Enabled = false; //Unable To in TextBox For Product
            //Receipt(); //Show Receipt
            //Clear Datagridview and List<T>
            dataGridViewItems.Rows.Clear(); //Clear Data in Grid
            ListProductID.Clear(); //Clear Data in List<T>
            AmountTendered = 0; //Set Amount Tendered By 0
            timerNewTransaction.Start();
            btnNewTransaction.Enabled = true; //Set To True;   
            discount = 0; //Set Discount To False or Zero After Transaction
            Userdiscounted = "None";
            discountAmount = 0; //Set To Zero
            btnDiscount.Text = "     Discount [F8]  %"; //Set Default Name For Btn Discount
            comboBoxDiscount.SelectedIndex = -1; //Set To Default...
            mainForm.ShowAndHideButtonMenus("Show"); //Set Mainforms Button to Show
        }

        private void HideAndDisablePaymentScenarioControls()
        {
            //Hide AmountPayment, Change, Error label and picture Box From Ui
            lblAmountPaymentValue.Text = "0"; lblAmountPayment.Hide(); lblAmountPaymentValue.Hide();
            lblChangeValue.Text = "0"; lblChange.Hide(); lblChangeValue.Hide();
            btnPayment.Enabled = false;
            btnDiscount.Enabled = false; panelDiscount.Hide();
            btnAddQuantity.Enabled = false;
            btnCancelTransaction.Enabled = false;
            btnVoid.Enabled = false;
            btnNewTransaction.Enabled = false;
        }

        private void ShowTransactionScenarioControls()
        {
            //Show Vat and subtotal Controls From Ui
            lblVat.Show(); lblVatValue.Show(); lblVatValue.Text = "0";
            lblSubTotal.Show(); lblSubTotalValue.Show(); lblSubTotalValue.Text = "0";
            txtSearch.Enabled = false;
        }

        private void ShowButtonControls()
        {
            //Show Button Controls
            btnPayment.Enabled = true;
            btnDiscount.Enabled = true;
            btnAddQuantity.Enabled = true;
            btnCancelTransaction.Enabled = true;
            btnVoid.Enabled = true;
        }

        private void HideButtonControls()
        {
            //Hide Button Controls
            btnPayment.Enabled = false;
            btnDiscount.Enabled = false;
            btnAddQuantity.Enabled = false;
            btnCancelTransaction.Enabled = false;
            btnVoid.Enabled = false;
        }

        int recursion = 0;
        private void timerNewTransaction_Tick(object sender, EventArgs e)
        {
            this.recursion += 1;
            if ((recursion % 2) == 0) 
            {
                panelNewTransaction.Show();
            }
            else
            {
                panelNewTransaction.Hide();
            }
            if (recursion == 16)
            {
                timerNewTransaction.Stop();
            }
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            StartNewTransaction();
        }

        private void StartNewTransaction()
        {
            HideAndDisablePaymentScenarioControls(); //Hide Controls in Payment Secenario
            ShowTransactionScenarioControls(); //Show Controls in Transaction Scenario
            dataGridViewItems.Rows.Clear(); //Clear Datagridview Items
            txtSearch.Enabled = true;
            lblTotalAmountValue.Text = "0";
            this.ActiveControl = txtSearch;
            timerNewTransaction.Stop();
            panelNewTransaction.Hide();
        }

        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
            btnCancelTransactionTrigger();
        }

        private void btnCancelTransactionTrigger()
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Cancel This Transaction?", "Cancel Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                //Clear Datagridview and List<T>
                dataGridViewItems.Rows.Clear(); //Clear Data in Grid
                ListProductID.Clear(); //Clear Data in List<T>
                StartNewTransaction();
                mainForm.ShowAndHideButtonMenus("Show"); //Set Mainforms Button to Show

                //Cancel Discount
                btnDiscount.Text = "     Discount [F8]  %";
                comboBoxDiscount.SelectedIndex = -1;
                discount = 0;
                discountAmount = 0; //Set To Zero
                Userdiscounted = "None";

            }
            else
            {
                return;
            }         
        }

        private void Receipt()
        {
            
            //Set DataTable To Fill Datagrid Data into DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Code", typeof(string));
            dataTable.Columns.Add("ProductName", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("Price", typeof(string));
            dataTable.Columns.Add("Amount", typeof(double));

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                dataTable.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value);
            }

            int LastTransactionID;
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter("SelectTransactionLastID", mysqlCon);
                mySqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtLastTransactionID = new DataTable();
                mySqlDa.Fill(dtLastTransactionID);

                LastTransactionID = Convert.ToInt32(dtLastTransactionID.Rows[0]["TransactionID"]);             
            }

            //Set Transaction Information and Throw in Receipt Form
            TransactionInformation transactionInformation = new TransactionInformation();
            transactionInformation.ProductSoldInformation = dataTable;
            transactionInformation.userID = UserID.ToString();
            transactionInformation.userName = UserName;
            transactionInformation.VAT = Convert.ToDouble(lblVatValue.Text.Trim());
            transactionInformation.SubTotal = Convert.ToDouble(lblSubTotalValue.Text.Trim());
            transactionInformation.TotalAmount = Convert.ToDouble(lblTotalAmountValue.Text.Trim());
            transactionInformation.DiscountAmount = discountAmount;
            transactionInformation.Amount = Convert.ToDouble(lblAmountPaymentValue.Text.Trim());
            transactionInformation.Change = Convert.ToDouble(lblChangeValue.Text.Trim());
            transactionInformation.DateAndTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            transactionInformation.TotalOfItem = dataGridViewItems.Rows.Count.ToString();
            transactionInformation.TransactionID = LastTransactionID.ToString();

            ReceiptForm crystalReportForReceipt = new ReceiptForm(transactionInformation);
            crystalReportForReceipt.Show();
        }

        /*--------------DiscountBtn Section with Sub Panel Inside---------------*/

        private void btnDiscountOk_Click(object sender, EventArgs e)
        {
            DiscountOk();
        }

        private void btnDiscountClose_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(panelDiscount);
            btnPayment.Enabled = true; btnVoid.Enabled = true; txtSearch.Enabled = true;
            HideAndShowPanel = false;
        }

        private void btnDiscountCancel_Click(object sender, EventArgs e)
        {
            btnDiscountCancelTrigger();
        }

        private void btnDiscountCancelTrigger()
        {
            bunifuTransition2.HideSync(panelDiscount);
            btnPayment.Enabled = true; btnVoid.Enabled = true; txtSearch.Enabled = true;
            btnDiscount.Text = "     Discount [F8]  %";
            comboBoxDiscount.SelectedIndex = -1;
            HideAndShowPanel = false;
            discount = 0;
            discountAmount = 0; //Set To Zero
            Userdiscounted = "None";

            /*----------------------------------Cancel Discount Setter-------------------------------------*/

            lblTotalAmountValue.Text = String.Format("{0:n}", TotalAmount);
            lblVatValue.Text = String.Format("{0:n}", Vat);
            lblSubTotalValue.Text = String.Format("{0:n}", SubTotalMinusVat);

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            btnDiscountTrigger();   
        }

        private bool HideAndShowPanel = false;

        private void btnDiscountTrigger()
        {
            //Show Panel
            if (HideAndShowPanel == false)
            {
                ValidateAdminPassword(); //Show Form For Admin Validation
                if (resultFromPasswordValidationDiscount == true)
                {
                    HideAndShowPanel = true;
                    btnPayment.Enabled = false; btnVoid.Enabled = false; txtSearch.Enabled = false;
                    bunifuTransition1.ShowSync(panelDiscount);
                }
                resultFromPasswordValidationDiscount = false; //Set To Default
            }
            //Hide Panel
            else
            {
                bunifuTransition1.HideSync(panelDiscount);
                HideAndShowPanel = false;
                btnPayment.Enabled = true; btnVoid.Enabled = true; txtSearch.Enabled = true;
            }
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

        private void DiscountOk()
        {
            int discountValue = 0;

            if(comboBoxDiscount.SelectedIndex == 0)
            {
                discountValue = 20; //For senior citizens & pwd
            }
            else if(comboBoxDiscount.SelectedIndex == 1)
            {
                discountValue = 30;
            }
            else if(comboBoxDiscount.SelectedIndex == 2)
            {
                discountValue = 40;
            }
            else if(comboBoxDiscount.SelectedIndex == 3)
            {
                discountValue = 50;
            }
            else if(comboBoxDiscount.SelectedIndex == -1)
            {
                Userdiscounted = "None";
            }
            else
            {
                //Do nothing....
            }

            discount = discountValue;
            btnDiscount.Text = "         Discount [F8]" + "  " + discount + "%";
            bunifuTransition2.HideSync(panelDiscount);
            HideAndShowPanel = false;
            btnPayment.Enabled = true; btnVoid.Enabled = true; txtSearch.Enabled = true;
            SetDiscountedTotalSubtotalAndVat(); //Set Discounted Total SubTotal and Vat To Ui
            
        }

        private void SetDiscountedTotalSubtotalAndVat()
        {
            if (discount != 0)
            {

                //Set DiscountAmount
                discountAmount = TotalAmount * (discount / 100);

                //Set New TotalAmountValue
                double NewTotalAmount = TotalAmount - (TotalAmount * (discount / 100));
                lblTotalAmountValue.Text = String.Format("{0:n}", Math.Round(NewTotalAmount));

                //Set New Vat
                double NewVat = ((NewTotalAmount / 1.12) * .12);
                lblVatValue.Text = String.Format("{0:n}", Math.Round(NewVat, 2));

                //Set New SubTotal
                double NewSubTotalMinusVat = (NewTotalAmount - NewVat);
                lblSubTotalValue.Text = String.Format("{0:n}", Math.Round(NewSubTotalMinusVat, 2));

            } 
        }

        private void ValidateAdminPassword()
        {
            ValidateAdminPasswordDialog validateAdminPassword = new ValidateAdminPasswordDialog(UserID, "POSTransactionForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }

        /*--------------Add Quantity Section-------------------*/
        private void btnAddQuantity_Click(object sender, EventArgs e)
        {
            btnAddQuantityTrigger();
        }

        public int NewQuantityAddedToitems = 0;
        private void btnAddQuantityTrigger()
        {
            try
            {
                if (dataGridViewItems.CurrentRow.Index != -1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Add Quantity of this Product?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:

                            string Barcode = Convert.ToString(dataGridViewItems.CurrentRow.Cells[0].Value);
                            string ProductName = Convert.ToString(dataGridViewItems.CurrentRow.Cells[1].Value);
                            string Price = Convert.ToString(dataGridViewItems.CurrentRow.Cells[3].Value);
                            int Quantity = Convert.ToInt32(dataGridViewItems.CurrentRow.Cells[2].Value);

                            AddQuantityInCart addQuantityInCart = new AddQuantityInCart(Barcode, ProductName, Price, Quantity);
                            addQuantityInCart.Owner = this;
                            addQuantityInCart.ShowDialog();

                            //Update New Quantity
                            dataGridViewItems.CurrentRow.Cells[2].Value = Convert.ToInt32(dataGridViewItems.CurrentRow.Cells[2].Value) + NewQuantityAddedToitems;
                            ComputeTotalSubtotalAndVat(); //Compute Total, Subtotal and Vat Not Discounted
                            SetDiscountedTotalSubtotalAndVat(); //Set Discounted Total, Subtotal and Vat If Discount Amount Is not 0

                            break;

                        case DialogResult.No:
                            break;

                        default:
                            break;
                    }

                    NewQuantityAddedToitems = 0; //Set To Zero, Default
                }
            }
            catch
            {
                MessageBox.Show("Testing Update Quantity", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class TransactionInformation
    {
        public DataTable ProductSoldInformation { get; set; }
        public string userID { get; set; }
        public string userName { get; set; }
        public double VAT { get; set; }
        public double SubTotal { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double Amount { get; set; }
        public double Change { get; set; }
        public string DateAndTime { get; set; }
        public string TotalOfItem { get; set; }
        public string TransactionID { get; set; }
       

    }
}
