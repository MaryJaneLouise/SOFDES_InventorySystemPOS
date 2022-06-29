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

namespace POSWithInventorySystem {
    public partial class HistoryForm : Form {
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none ";
        string connectionString = DatabaseConnection.Connection;
        LoginFormData usersData;
        public bool resultFromPasswordValidation = false;

        public HistoryForm() {
            InitializeComponent();
        }

        public HistoryForm(LoginFormData data) {
            InitializeComponent();
            this.usersData = data;
        }

        private void HistoryForm_Load(object sender, EventArgs e) {
            //Insert code here for sharing all contents
            /* Insert code here */

            //Product History page
            GridFillProductsLogs();
            DataGridViewProductsLogWidthNDesign();

            //Stock History page
            comboboxIndividualOrTotalTab2.SelectedIndex = 0;

            //Stock History page > Individual Stocks
            dataGridViewStocksLog.Show();
            gridFillIndividualStocksLog();
            DataGridViewStocksIndividualWidthNDesign();
            GridIndividualStocksLogsRowNumbers();

            //Stock History page > Total Stocks
            gridFillTotalStocksLog();
            DataGridViewStocksTotalWidthNDesign();

            //User Time In / Out
            GridFillUserLog();
            DataGridViewUsersLogWidthNDesign();
            SetNumberOfUserLog();

            //User Account Update Information History
            GridFillUsersInformationLog();
            DataGridViewUsersInfoLogWidthNDesign();

            //Transaction History
            GridFillTransactionsLog();
            DataGridViewTransactionsLogWidthNDesign();
        }

        private void ValidateAdminPassword() {
            ValidateAdminPasswordDialog validateAdminPassword = new ValidateAdminPasswordDialog(Convert.ToInt32(usersData.UsersID), "HistoryForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }


        //Product History
        private void btnClearProductsLogs_Click(object sender, EventArgs e) {
            ClearProductsLogs();
        }

        private void btnClearAllProductsLogs_Click(object sender, EventArgs e) {
            ClearAllProductsLogs();
        }

        private void txtSearchValue_OnValueChanged(object sender, EventArgs e) {
            SearchProductsLogsByColumnOfDvg();
        }

        private void DataGridViewProductsLogWidthNDesign() {
            //Design
            dataGridViewProductsLog.EnableHeadersVisualStyles = false;
            dataGridViewProductsLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewProductsLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewProductsLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewProductsLog.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dataGridViewProductsLog.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            //Width
            dataGridViewProductsLog.Columns[2].Width = 230;
            dataGridViewProductsLog.Columns[3].Width = 120;
            dataGridViewProductsLog.Columns[4].Width = dataGridViewProductsLog.Width
                - dataGridViewProductsLog.Columns[2].Width
                - dataGridViewProductsLog.Columns[3].Width
                - dataGridViewProductsLog.Columns[5].Width
                - dataGridViewProductsLog.Columns[6].Width
                - 170;
            dataGridViewProductsLog.Columns[5].Width = 220;
            dataGridViewProductsLog.Columns[6].Width = 160;
        }

        private void GridFillProductsLogs() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsLogsForView", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewProductsLog.DataSource = dataTable;

                    DataGridProductslogRows(); //Compute and Set Total Rows
                    dataGridViewProductsLog.Columns[0].Visible = false;
                    dataGridViewProductsLog.Columns[1].Visible = false;
                }
            }
            
            catch(Exception ex) {
                MessageBox.Show("There was an error in database: " + ex + " Please contact your manager.", "Error in database");
            }
        }

        private void DataGridProductslogRows() {
            lblTotalLogsValueTab2.Text = dataGridViewProductsLog.Rows.Count.ToString();
        }

        private void SearchProductsLogsByColumnOfDvg() {
            try {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewProductsLog.DataSource;
                bs.Filter = "[UsersName] LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR Convert([ProductID], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR Convert([ProductName], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR [Date_and_Time] LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR [Action] LIKE '%" + txtSearchValue.Text + "%'";

                dataGridViewProductsLog.DataSource = bs;
            }
            
            catch(EvaluateException ex) {
                //Insert code here if you want to show error when inputting invalid inputs
            }

            DataGridProductslogRows();
        }

        private void ClearProductsLogs() {
            try {
                ValidateAdminPassword(); 

                if (resultFromPasswordValidation == true) {
                    if (dataGridViewProductsLog.CurrentRow.Index != -1) {
                        int StocksID = Convert.ToInt32(dataGridViewProductsLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete the stocks of the selected product
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteProductsLogByID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_ProductsLogID", StocksID);
                            mySqlCommand.ExecuteNonQuery();

                            GridFillProductsLogs();
                        }
                    }
                }
                resultFromPasswordValidation = false; 
            }
            catch {
                resultFromPasswordValidation = false;
                MessageBox.Show("The product history has no items to show.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearAllProductsLogs() {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidation == true) {
                    if (dataGridViewProductsLog.CurrentRow.Index != -1) {
                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete the stocks of the all product
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteAllProductsLog", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();

                            GridFillProductsLogs(); 
                        }
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            
            catch {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("The product history has no items to show.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //Stock History
        private void comboboxIndividualOrTotalTab2_SelectedIndexChanged(object sender, EventArgs e) {
            SetIndividualOrTotalStocksLog();
        }

        private void SetIndividualOrTotalStocksLog() {
            //Stock History --> Individual Stocks
            if (comboboxIndividualOrTotalTab2.SelectedIndex == 0) {
                dataGridViewStocksTotalLog.Hide();
                dataGridViewStocksLog.Show();
                GridIndividualStocksLogsRowNumbers();
            }

            //Stock History --> Total Stocks
            else {
                dataGridViewStocksLog.Hide();
                dataGridViewStocksTotalLog.Show();
                GridTotalStocksLogsRowNumbers();
            }
        }

        private void btnClearStocksLogTab2_Click(object sender, EventArgs e) {
            btnClearStocksLogTab2Trigger();
        }

        private void btnClearStocksLogTab2Trigger() {
            //Stock History --> Individual Stocks
            if (comboboxIndividualOrTotalTab2.SelectedIndex == 0) {
                ClearIndividualStocksLog(); 
                gridFillIndividualStocksLog(); 
                GridIndividualStocksLogsRowNumbers(); 
            }

            //Stock History --> Total Stocks
            else {
                ClearTotalStocksLog(); 
                gridFillTotalStocksLog(); 
                GridTotalStocksLogsRowNumbers(); 
            }
        }

        private void btnClearAllLogTab2_Click(object sender, EventArgs e) {
            btnClearAllsStocksLogsTrigger();
        }

        private void btnClearAllsStocksLogsTrigger() {
            //Stock History --> Individual Stocks
            if (comboboxIndividualOrTotalTab2.SelectedIndex == 0) {
                ClearAllStocksLog(); 
                gridFillIndividualStocksLog(); 
                GridIndividualStocksLogsRowNumbers(); 
            }

            //Stock History --> Total Stocks
            else {
                ClearAllTotalStocksLog(); 
                gridFillTotalStocksLog(); 
                GridTotalStocksLogsRowNumbers();
            }
        }

        private void txtSearchTab2Stocks_OnValueChanged(object sender, EventArgs e) {
            try {
                //Stock History --> Individual Stocks
                if (comboboxIndividualOrTotalTab2.SelectedIndex == 0) {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridViewStocksLog.DataSource;
                    bs.Filter = "[UsersName] LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR Convert([StocksID], 'System.String') LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR Convert([ProductID], 'System.String') LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR [ProductName] LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR [Date_and_Time] LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR [Action] LIKE '%" + txtSearchTab2Stocks.Text + "%'";

                    dataGridViewStocksLog.DataSource = bs;
                    GridIndividualStocksLogsRowNumbers();

                }

                //Stock History --> Total Stocks
                else {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridViewStocksTotalLog.DataSource;
                    bs.Filter = "[UsersName] LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR Convert([ProductID], 'System.String') LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR [ProductName] LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR [Date_and_Time] LIKE '%" + txtSearchTab2Stocks.Text + "%'"
                                 + "OR [Action] LIKE '%" + txtSearchTab2Stocks.Text + "%'";

                    dataGridViewStocksTotalLog.DataSource = bs;
                    GridTotalStocksLogsRowNumbers();
                }
            }

            catch(EvaluateException ex)
            {
                //Insert code here if you want to show error when inputting invalid inputs
            }
        }

        //Stock History --> Individual Stocks
        private void gridFillIndividualStocksLog() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectStocksIndividualLogs", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewStocksLog.DataSource = dataTable;
                    dataGridViewStocksLog.Columns[0].Visible = false;
                    dataGridViewStocksLog.Columns[1].Visible = false;                }
            }

            catch(Exception ex) {
                MessageBox.Show("There was an error in database: " + ex + " Please contact your manager.", "Error in database");
            }
        }

        private void DataGridViewStocksIndividualWidthNDesign() {
            //Design
            dataGridViewStocksLog.EnableHeadersVisualStyles = false;
            dataGridViewStocksLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewStocksLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewStocksLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewStocksLog.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dataGridViewStocksLog.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            //Width
            dataGridViewStocksLog.Columns[2].Width = 220;
            dataGridViewStocksLog.Columns[3].Width = 120;
            dataGridViewStocksLog.Columns[4].Width = 120;
            dataGridViewStocksLog.Columns[5].Width = dataGridViewProductsLog.Width
                - dataGridViewStocksLog.Columns[2].Width
                - dataGridViewStocksLog.Columns[3].Width
                - dataGridViewStocksLog.Columns[4].Width
                - dataGridViewStocksLog.Columns[6].Width
                - dataGridViewStocksLog.Columns[7].Width
                - 80;
            dataGridViewStocksLog.Columns[6].Width = 180;
            dataGridViewStocksLog.Columns[7].Width = 130;
        }

        private void ClearIndividualStocksLog() {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidation == true) {
                    if (dataGridViewStocksLog.CurrentRow.Index != -1) {
                        int StocksLogID = Convert.ToInt32(dataGridViewStocksLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete the stocks of selected item
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteIndividualStocksLogBydID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_StocksLogID", StocksLogID);
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                resultFromPasswordValidation = false; 
            }

            catch(Exception ex) {
                resultFromPasswordValidation = false; 
                MessageBox.Show("The stock history has no items to show.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearAllStocksLog() {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidation == true) {
                    if (dataGridViewStocksLog.CurrentRow.Index != -1) {
                        int StocksLogID = Convert.ToInt32(dataGridViewStocksLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete the whole history
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteTotalStocksLog", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                resultFromPasswordValidation = false;
            }
            catch {
                resultFromPasswordValidation = false;
                MessageBox.Show("The stock history has no items to show.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GridIndividualStocksLogsRowNumbers() {
            lblTotalLogStocksValueTab2.Text = dataGridViewStocksLog.Rows.Count.ToString();
        }

        //Stock History --> Total Stocks
        private void gridFillTotalStocksLog() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectStocksTotalLogs", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewStocksTotalLog.DataSource = dataTable;
                    dataGridViewStocksTotalLog.Columns[0].Visible = false; 
                    dataGridViewStocksTotalLog.Columns[1].Visible = false;                
                }
            }

            catch (Exception ex) {
                MessageBox.Show("There was an error in database: " + ex + " Please contact your manager.", "Error in database");
            }
        }

        private void DataGridViewStocksTotalWidthNDesign() {
            //Design
            dataGridViewStocksTotalLog.EnableHeadersVisualStyles = false;
            dataGridViewStocksTotalLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewStocksTotalLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewStocksTotalLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewStocksTotalLog.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dataGridViewStocksTotalLog.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            //Width
            dataGridViewStocksTotalLog.Columns[2].Width = 225;
            dataGridViewStocksTotalLog.Columns[3].Width = 135;
            dataGridViewStocksTotalLog.Columns[4].Width = dataGridViewProductsLog.Width
                - dataGridViewStocksTotalLog.Columns[2].Width
                - dataGridViewStocksTotalLog.Columns[3].Width
                - dataGridViewStocksTotalLog.Columns[5].Width
                - dataGridViewStocksTotalLog.Columns[6].Width
                - 160;
            dataGridViewStocksTotalLog.Columns[5].Width = 235;
            dataGridViewStocksTotalLog.Columns[6].Width = 160;
        }

        private void ClearTotalStocksLog() {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidation == true) {
                    if (dataGridViewStocksTotalLog.CurrentRow.Index != -1) {
                        int StocksTotalLogID = Convert.ToInt32(dataGridViewStocksTotalLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete the stocks of the selected item
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteTotalStocksLogBydID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_StocksTotalLogID", StocksTotalLogID);
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                resultFromPasswordValidation = false;
            }
            
            catch(Exception ex) {
                resultFromPasswordValidation = false; 
                MessageBox.Show("The stock history has no items to show.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearAllTotalStocksLog() {
            try {
                ValidateAdminPassword(); 

                if (resultFromPasswordValidation == true) {
                    if (dataGridViewStocksTotalLog.CurrentRow.Index != -1) {
                        int StocksTotalLogID = Convert.ToInt32(dataGridViewStocksTotalLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete the stocks of the selected item
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteAllTotalStocks", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                resultFromPasswordValidation = false;
            }
            
            catch (Exception ex) {
                resultFromPasswordValidation = false;
                MessageBox.Show("The stock history has no items to show.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GridTotalStocksLogsRowNumbers() {
            lblTotalLogStocksValueTab2.Text = dataGridViewStocksTotalLog.Rows.Count.ToString();
        }


        //User Time In / Out
        private void GridFillUserLog() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectUsersLogForView", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewIUserLog.DataSource = dataTable;
                    dataGridViewIUserLog.Columns[0].Visible = false; 
                    dataGridViewIUserLog.Columns[1].Visible = false; 
                }
            }

            catch (Exception ex) {
                MessageBox.Show("There was an error in database: " + ex + " Please contact your manager.", "Error in database");
            }
        }

        private void DataGridViewUsersLogWidthNDesign() {
            //Design
            dataGridViewIUserLog.EnableHeadersVisualStyles = false;
            dataGridViewIUserLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewIUserLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewIUserLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewIUserLog.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dataGridViewIUserLog.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            //Width
            dataGridViewIUserLog.Columns[2].Width = 330;
            dataGridViewIUserLog.Columns[3].Width = 295;
            dataGridViewIUserLog.Columns[4].Width = 295;
        }

        private void txtSearchTabUserLog_OnValueChanged(object sender, EventArgs e) {
            try {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewIUserLog.DataSource;
                bs.Filter = "[UsersName] LIKE '%" + txtSearchTabUserLog.Text + "%'"
                             + "OR [TimeIn] LIKE '%" + txtSearchTabUserLog.Text + "%'"
                             + "OR [TimeOut] LIKE '%" + txtSearchTabUserLog.Text + "%'";

                dataGridViewIUserLog.DataSource = bs;
            }

            catch(EvaluateException ex) {
                //Insert code here if you want to show error when inputting invalid inputs
            }

            SetNumberOfUserLog();
        }

        private void SetNumberOfUserLog() {
            lblTotalLogValue.Text = dataGridViewIUserLog.Rows.Count.ToString();
        }

        private void btnClearLogTa3_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidation == true) {
                    if (dataGridViewIUserLog.CurrentRow.Index != -1) {
                        int StocksTotalLogID = Convert.ToInt32(dataGridViewIUserLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)){
                            //Delete selected UserID History
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteUsersLogByID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_UsersLogID", StocksTotalLogID);
                            mySqlCommand.ExecuteNonQuery();
                        }

                        GridFillUserLog();
                        SetNumberOfUserLog();
                    }
                }
                resultFromPasswordValidation = false; 
            }

            catch (Exception ex) {
                resultFromPasswordValidation = false; 
                MessageBox.Show("The user time in / out has no items to show.", "Empty Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearAllLogTab3_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidation == true) {
                    if (dataGridViewIUserLog.CurrentRow.Index != -1) {
                        int StocksTotalLogID = Convert.ToInt32(dataGridViewIUserLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete all UserID History
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteAllUsersLog", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();
                        }

                        GridFillUserLog();
                        SetNumberOfUserLog();
                    }
                }
                resultFromPasswordValidation = false;
            }

            catch (Exception ex) {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("The user time in / out has no items to show.", "Empty Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Transaction History
        private void GridFillTransactionsLog() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionsLogForView", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dvgTransactions.DataSource = dataTable;

                    SetNumberOfTransactionsLog();
                }
            }

            catch (Exception ex) {
                MessageBox.Show("There was an error in database: " + ex + " Please contact your manager.", "Error in database");
            }
        }

        private void DataGridViewTransactionsLogWidthNDesign() {
            //Design
            dvgTransactions.EnableHeadersVisualStyles = false;
            dvgTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dvgTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dvgTransactions.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dvgTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            //Width
            dvgTransactions.Columns[0].Width = 130;
            dvgTransactions.Columns[1].Width = 170;
            dvgTransactions.Columns[2].Width = dvgTransactions.Width
                - dvgTransactions.Columns[0].Width
                - dvgTransactions.Columns[1].Width
                - dvgTransactions.Columns[3].Width
                - dvgTransactions.Columns[4].Width
                - dvgTransactions.Columns[5].Width
                - dvgTransactions.Columns[6].Width
                - dvgTransactions.Columns[7].Width
                - 100;
            dvgTransactions.Columns[3].Width = 105;
            dvgTransactions.Columns[4].Width = 150;
            dvgTransactions.Columns[5].Width = 105;
            dvgTransactions.Columns[6].Width = 145;
            dvgTransactions.Columns[7].Width = 170;
            dvgTransactions.Columns[8].Width = 150;
        }

        private void SetNumberOfTransactionsLog() {
            lblTotalLogTransactionValue.Text = dvgTransactions.Rows.Count.ToString();
        }

        private void txtSearchTransaction_OnValueChanged(object sender, EventArgs e) {
            try {
                BindingSource bs = new BindingSource();
                bs.DataSource = dvgTransactions.DataSource;
                bs.Filter = "Convert([TransactionID], 'System.String') LIKE '%" + txtSearchTransaction.Text + "%'"
                             + "OR [Username] LIKE '%" + txtSearchTransaction.Text + "%'"
                             + "OR [Date] LIKE '%" + txtSearchTransaction.Text + "%'";

                dvgTransactions.DataSource = bs;
            }

            catch(EvaluateException ex) {
                //Insert code here if you want to show error when inputting invalid inputs
            }

            SetNumberOfTransactionsLog();
        }

        //User Information Update History
        private void GridFillUsersInformationLog() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectUsersInfoLogForView", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dvgUsersInformationLog.DataSource = dataTable;

                    dvgUsersInformationLog.Columns[0].Visible = false; 
                    dvgUsersInformationLog.Columns[1].Visible = false; 
                    dvgUsersInformationLog.Columns[3].Visible = false; 

                    SetNumberOfUsersInformationLog();
                }
            }

            catch (Exception ex) {
                MessageBox.Show("There was an error in database: " + ex + " Please contact your manager.", "Error in database");
            }
        }

        private void DataGridViewUsersInfoLogWidthNDesign() {
            //Design
            dvgUsersInformationLog.EnableHeadersVisualStyles = false;
            dvgUsersInformationLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgUsersInformationLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dvgUsersInformationLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dvgUsersInformationLog.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dvgUsersInformationLog.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            //Width
            dvgUsersInformationLog.Columns[2].Width = 275;
            dvgUsersInformationLog.Columns[4].Width = 275;
            dvgUsersInformationLog.Columns[5].Width = dvgUsersInformationLog.Width
                - dvgUsersInformationLog.Columns[2].Width
                - dvgUsersInformationLog.Columns[4].Width
                - dvgUsersInformationLog.Columns[6].Width
                - 30;
            dvgUsersInformationLog.Columns[6].Width = 145;
        }

        private void SetNumberOfUsersInformationLog() {
            lblTotalUsersInfoLogValue.Text = dvgUsersInformationLog.Rows.Count.ToString();
        }

        private void btnClearUsersInfLog_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidation == true) {
                    if (dvgUsersInformationLog.CurrentRow.Index != -1) {
                        int UsersInformationLogID = Convert.ToInt32(dvgUsersInformationLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete selected UserIDInfo history
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteUsersInformationLogByID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_UsersInformationID", UsersInformationLogID);
                            mySqlCommand.ExecuteNonQuery();
                        }

                        GridFillUsersInformationLog();
                    }
                }
                resultFromPasswordValidation = false;
            }

            catch (Exception ex) {
                resultFromPasswordValidation = false;
                MessageBox.Show("The user information update history has no items to show.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearAllUsersInfoLog_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidation == true) {
                    if (dvgUsersInformationLog.CurrentRow.Index != -1) {
                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                            //Delete all UserIDInfo History
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteAllUsersInformationLog", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();
                        }

                        GridFillUsersInformationLog();
                    }
                }
                resultFromPasswordValidation = false;
            }
            
            catch (Exception ex) {
                resultFromPasswordValidation = false;
                MessageBox.Show("The user information update history has no items to show.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearchUserInfoLog_OnValueChanged(object sender, EventArgs e) {
            try {
                BindingSource bs = new BindingSource();
                bs.DataSource = dvgUsersInformationLog.DataSource;
                bs.Filter = "[UsersName] LIKE '%" + txtSearchUserInfoLog.Text + "%'"
                             + "OR [Subject_Name] LIKE '%" + txtSearchUserInfoLog.Text + "%'"
                             + "OR [Date_and_Time] LIKE '%" + txtSearchUserInfoLog.Text + "%'"
                             + "OR [Action] LIKE '%" + txtSearchUserInfoLog.Text + "%'";


                dvgUsersInformationLog.DataSource = bs;
            }

            catch(EvaluateException ex) {
                //Insert code here if you want to show error when inputting invalid inputs
            }

            SetNumberOfUsersInformationLog();
        }
    }
}
