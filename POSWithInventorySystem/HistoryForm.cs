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
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        public HistoryForm(LoginFormData data)
        {
            InitializeComponent();
            this.usersData = data;
        }

        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none ";
        string connectionString = DatabaseConnection.Connection;

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            /*----------Shared By All-----------*/
                //codes.....

            /*----------Products Log Section-----------*/
            GridFillProductsLogs();
            DataGridViewProductsLogWidthNDesign();

            /*-----------Stocks Log Section------------*/
            comboboxIndividualOrTotalTab2.SelectedIndex = 0;

                /*--------------Individual Stocks-------------*/
            dataGridViewStocksLog.Show();
            gridFillIndividualStocksLog();
            DataGridViewStocksIndividualWidthNDesign();
            GridIndividualStocksLogsRowNumbers(); //Set Number Of rows Currently in GridView

                /*--------------Total Stocks-------------*/
            gridFillTotalStocksLog();
            DataGridViewStocksTotalWidthNDesign();

            /*-----------Users Log Section---------*/
            GridFillUserLog();
            DataGridViewUsersLogWidthNDesign();
            SetNumberOfUserLog();

            /*-----------Transaction Log Section------*/
            GridFillTransactionsLog();
            DataGridViewTransactionsLogWidthNDesign();

            /*--------UsersInformation Log Section--*/
            GridFillUsersInformationLog();
            DataGridViewUsersInfoLogWidthNDesign();


        }

        /*-------------------------------------Product Logs-----------------------------------*/

        private void btnClearProductsLogs_Click(object sender, EventArgs e)
        {
            ClearProductsLogs();
        }

        private void btnClearAllProductsLogs_Click(object sender, EventArgs e)
        {
            ClearAllProductsLogs();
        }

        private void txtSearchValue_OnValueChanged(object sender, EventArgs e)
        {
            SearchProductsLogsByColumnOfDvg();
        }

        private void DataGridViewProductsLogWidthNDesign()
        {
            //Design
            dataGridViewProductsLog.EnableHeadersVisualStyles = false;
            dataGridViewProductsLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewProductsLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewProductsLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewProductsLog.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridViewProductsLog.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

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

        private void GridFillProductsLogs()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
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
            catch(Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }
        }

        private void DataGridProductslogRows()
        {
            lblTotalLogsValueTab2.Text = dataGridViewProductsLog.Rows.Count.ToString();
        }

        private void SearchProductsLogsByColumnOfDvg()
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewProductsLog.DataSource;
                bs.Filter = "[UsersName] LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR Convert([ProductID], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR Convert([ProductName], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR [Date_and_Time] LIKE '%" + txtSearchValue.Text + "%'"
                            + "OR [Action] LIKE '%" + txtSearchValue.Text + "%'";

                dataGridViewProductsLog.DataSource = bs;
            }
            catch(EvaluateException ex)
            {
                //Do Nothing... For Invalid input characters
            }

            DataGridProductslogRows();
        }

        private void ClearProductsLogs()
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dataGridViewProductsLog.CurrentRow.Index != -1)
                    {

                        int StocksID = Convert.ToInt32(dataGridViewProductsLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Stocks Corresponding of this Product
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteProductsLogByID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_ProductsLogID", StocksID);
                            mySqlCommand.ExecuteNonQuery();

                            GridFillProductsLogs(); //Set New Value in Gridview And Set Number Row
                        }
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Products Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearAllProductsLogs()
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dataGridViewProductsLog.CurrentRow.Index != -1)
                    {
                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Stocks Corresponding of this Product
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteAllProductsLog", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();

                            GridFillProductsLogs(); //Set New Value in Gridview And Set Number Row
                        }
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Products Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /*------------------Shared By All--------------------*/

        LoginFormData usersData;
        public bool resultFromPasswordValidation = false;

        private void ValidateAdminPassword()
        {
            ValidateAdminPasswordDialog validateAdminPassword = new ValidateAdminPasswordDialog(Convert.ToInt32(usersData.UsersID), "HistoryForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }

        /*--------------------------Stocks Logs--------------------------------*/

        private void comboboxIndividualOrTotalTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetIndividualOrTotalStocksLog();
        }

        private void SetIndividualOrTotalStocksLog()
        {
            //For Individual Stocks
            if (comboboxIndividualOrTotalTab2.SelectedIndex == 0)
            {
                dataGridViewStocksTotalLog.Hide();
                dataGridViewStocksLog.Show();
                GridIndividualStocksLogsRowNumbers(); //Set Number Of rows Currently in GridView
            }
            //For Total Stocks
            else
            {
                dataGridViewStocksLog.Hide();
                dataGridViewStocksTotalLog.Show();
                GridTotalStocksLogsRowNumbers();
            }
        }

        private void btnClearStocksLogTab2_Click(object sender, EventArgs e)
        {
            btnClearStocksLogTab2Trigger();
        }

        private void btnClearStocksLogTab2Trigger()
        {
            //For Individual Stocks Log
            if (comboboxIndividualOrTotalTab2.SelectedIndex == 0)
            {
                ClearIndividualStocksLog(); //Clear Individual Stocks Log...
                gridFillIndividualStocksLog(); //Fill Grid Individual Stocks
                GridIndividualStocksLogsRowNumbers(); //Set New value for Total Count
            }
            //For Total Stocks Log
            else
            {
                ClearTotalStocksLog(); //Clear Total Stocks Log
                gridFillTotalStocksLog(); //Set New Value in Gridview And Set Number Row
                GridTotalStocksLogsRowNumbers(); //Set New value for Total Count
            }
        }

        private void btnClearAllLogTab2_Click(object sender, EventArgs e)
        {
            btnClearAllsStocksLogsTrigger();
        }

        private void btnClearAllsStocksLogsTrigger()
        {
            //For Individual Stocks Log
            if (comboboxIndividualOrTotalTab2.SelectedIndex == 0)
            {
                ClearAllStocksLog(); //Clear All Individual Stocks
                gridFillIndividualStocksLog(); //Set New Value in Gridview And Set Number Row
                GridIndividualStocksLogsRowNumbers(); //Fill New Values For Stocks Count
            }
            //For Total Stocks Log
            else
            {
                ClearAllTotalStocksLog(); //Clear All Total Stocks
                gridFillTotalStocksLog(); //Set New Value in Gridview And Set Number Row
                GridTotalStocksLogsRowNumbers(); // Fill New Values For Stocks Total Count
            }
        }

        private void txtSearchTab2Stocks_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                //For Individual
                if (comboboxIndividualOrTotalTab2.SelectedIndex == 0)
                {
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
                //For Total
                else
                {
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
                //Do nothing.. for invalid input characters
            }
        }

            /*---------------Individual Stocks LogsSection------------------*/

        private void gridFillIndividualStocksLog()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectStocksIndividualLogs", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewStocksLog.DataSource = dataTable;
                    dataGridViewStocksLog.Columns[0].Visible = false; //For StocksLogID
                    dataGridViewStocksLog.Columns[1].Visible = false; //For UsersID
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }
        }

        private void DataGridViewStocksIndividualWidthNDesign()
        {
            //Design
            dataGridViewStocksLog.EnableHeadersVisualStyles = false;
            dataGridViewStocksLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewStocksLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewStocksLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewStocksLog.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridViewStocksLog.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

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

        private void ClearIndividualStocksLog()
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dataGridViewStocksLog.CurrentRow.Index != -1)
                    {

                        int StocksLogID = Convert.ToInt32(dataGridViewStocksLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Stocks Corresponding of this Product
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteIndividualStocksLogBydID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_StocksLogID", StocksLogID);
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch(Exception ex)
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Stocks Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearAllStocksLog()
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dataGridViewStocksLog.CurrentRow.Index != -1)
                    {

                        int StocksLogID = Convert.ToInt32(dataGridViewStocksLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Total Stocks Log
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteTotalStocksLog", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Stocks Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GridIndividualStocksLogsRowNumbers()
        {
            lblTotalLogStocksValueTab2.Text = dataGridViewStocksLog.Rows.Count.ToString();
        }

                /*---------------Total Stocks Logs Section ---------------------*/

        private void gridFillTotalStocksLog()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectStocksTotalLogs", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewStocksTotalLog.DataSource = dataTable;
                    dataGridViewStocksTotalLog.Columns[0].Visible = false; //For StocksTotalLogID
                    dataGridViewStocksTotalLog.Columns[1].Visible = false; //For UsersID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }
        }

        private void DataGridViewStocksTotalWidthNDesign()
        {
            //Design
            dataGridViewStocksTotalLog.EnableHeadersVisualStyles = false;
            dataGridViewStocksTotalLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewStocksTotalLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewStocksTotalLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewStocksTotalLog.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridViewStocksTotalLog.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

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

        private void ClearTotalStocksLog()
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dataGridViewStocksTotalLog.CurrentRow.Index != -1)
                    {
                        int StocksTotalLogID = Convert.ToInt32(dataGridViewStocksTotalLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Stocks Corresponding of this Product
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteTotalStocksLogBydID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_StocksTotalLogID", StocksTotalLogID);
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch(Exception ex)
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Stocks Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearAllTotalStocksLog()
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dataGridViewStocksTotalLog.CurrentRow.Index != -1)
                    {
                        int StocksTotalLogID = Convert.ToInt32(dataGridViewStocksTotalLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Stocks Corresponding of this Product
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteAllTotalStocks", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch (Exception ex)
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Stocks Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GridTotalStocksLogsRowNumbers()
        {
            lblTotalLogStocksValueTab2.Text = dataGridViewStocksTotalLog.Rows.Count.ToString();
        }

        /*---------------------------Users Log Section--------------------------------*/

        private void GridFillUserLog()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectUsersLogForView", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewIUserLog.DataSource = dataTable;
                    dataGridViewIUserLog.Columns[0].Visible = false; //For StocksTotalLogID
                    dataGridViewIUserLog.Columns[1].Visible = false; //For UsersID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }
        }

        private void DataGridViewUsersLogWidthNDesign()
        {
            //Design
            dataGridViewIUserLog.EnableHeadersVisualStyles = false;
            dataGridViewIUserLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewIUserLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dataGridViewIUserLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewIUserLog.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridViewIUserLog.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

            //Width
            dataGridViewIUserLog.Columns[2].Width = 330;
            dataGridViewIUserLog.Columns[3].Width = 295;
            dataGridViewIUserLog.Columns[4].Width = 295;
           
        }

        private void txtSearchTabUserLog_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridViewIUserLog.DataSource;
                bs.Filter = "[UsersName] LIKE '%" + txtSearchTabUserLog.Text + "%'"
                             + "OR [TimeIn] LIKE '%" + txtSearchTabUserLog.Text + "%'"
                             + "OR [TimeOut] LIKE '%" + txtSearchTabUserLog.Text + "%'";

                dataGridViewIUserLog.DataSource = bs;
            }
            catch(EvaluateException ex)
            {
                //Do nothin... for invalid input characters 
            }

            SetNumberOfUserLog();
        }

        private void SetNumberOfUserLog()
        {
            lblTotalLogValue.Text = dataGridViewIUserLog.Rows.Count.ToString();
        }

        private void btnClearLogTa3_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dataGridViewIUserLog.CurrentRow.Index != -1)
                    {
                        int StocksTotalLogID = Convert.ToInt32(dataGridViewIUserLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Stocks Corresponding of this Product
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
                resultFromPasswordValidation = false; //Set To Default
            }
            catch (Exception ex)
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Stocks Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearAllLogTab3_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dataGridViewIUserLog.CurrentRow.Index != -1)
                    {
                        int StocksTotalLogID = Convert.ToInt32(dataGridViewIUserLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Stocks Corresponding of this Product
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteAllUsersLog", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();
                        }

                        GridFillUserLog();
                        SetNumberOfUserLog();
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch (Exception ex)
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Stocks Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /*-----------------------Transactions Log-----------------------------------*/

        private void GridFillTransactionsLog()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionsLogForView", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dvgTransactions.DataSource = dataTable;

                    SetNumberOfTransactionsLog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }
        }

        private void DataGridViewTransactionsLogWidthNDesign()
        {
            //Design
            dvgTransactions.EnableHeadersVisualStyles = false;
            dvgTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dvgTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dvgTransactions.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dvgTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

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

        private void SetNumberOfTransactionsLog()
        {
            lblTotalLogTransactionValue.Text = dvgTransactions.Rows.Count.ToString();
        }

        private void txtSearchTransaction_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dvgTransactions.DataSource;
                bs.Filter = "Convert([TransactionID], 'System.String') LIKE '%" + txtSearchTransaction.Text + "%'"
                             + "OR [Username] LIKE '%" + txtSearchTransaction.Text + "%'"
                             + "OR [Date] LIKE '%" + txtSearchTransaction.Text + "%'";

                dvgTransactions.DataSource = bs;
            }
            catch(EvaluateException ex)
            {
                //Do nothing... for invalid input characters
            }

            SetNumberOfTransactionsLog();
        }

        /*-----------------------Users Information Log------------------------------*/

        private void GridFillUsersInformationLog()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectUsersInfoLogForView", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dvgUsersInformationLog.DataSource = dataTable;
                    dvgUsersInformationLog.Columns[0].Visible = false; //For UsersInfoLogID
                    dvgUsersInformationLog.Columns[1].Visible = false; //For UsersID
                    dvgUsersInformationLog.Columns[3].Visible = false; //For Users Subject ID
                    SetNumberOfUsersInformationLog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }
        }

        private void DataGridViewUsersInfoLogWidthNDesign()
        {
            //Design
            dvgUsersInformationLog.EnableHeadersVisualStyles = false;
            dvgUsersInformationLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgUsersInformationLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dvgUsersInformationLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dvgUsersInformationLog.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dvgUsersInformationLog.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

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

        private void SetNumberOfUsersInformationLog()
        {
            lblTotalUsersInfoLogValue.Text = dvgUsersInformationLog.Rows.Count.ToString();
        }

        private void btnClearUsersInfLog_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dvgUsersInformationLog.CurrentRow.Index != -1)
                    {
                        int UsersInformationLogID = Convert.ToInt32(dvgUsersInformationLog.CurrentRow.Cells[0].Value);

                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete UsersInformation Log Corresponding of this UsersInfoID
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteUsersInformationLogByID", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.Parameters.AddWithValue("_UsersInformationID", UsersInformationLogID);
                            mySqlCommand.ExecuteNonQuery();
                        }

                        GridFillUsersInformationLog();
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch (Exception ex)
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Users Information Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearAllUsersInfoLog_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Show Form To Validate Password

                if (resultFromPasswordValidation == true)
                {
                    if (dvgUsersInformationLog.CurrentRow.Index != -1)
                    {
                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            //Delete Users Information Corresponding of this UsersInfo
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("DeleteAllUsersInformationLog", mysqlCon);
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            mySqlCommand.ExecuteNonQuery();
                        }

                        GridFillUsersInformationLog();
                    }
                }
                resultFromPasswordValidation = false; //Set To Default
            }
            catch (Exception ex)
            {
                resultFromPasswordValidation = false; //Set To Default
                MessageBox.Show("Users Information Log is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearchUserInfoLog_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dvgUsersInformationLog.DataSource;
                bs.Filter = "[UsersName] LIKE '%" + txtSearchUserInfoLog.Text + "%'"
                             + "OR [Subject_Name] LIKE '%" + txtSearchUserInfoLog.Text + "%'"
                             + "OR [Date_and_Time] LIKE '%" + txtSearchUserInfoLog.Text + "%'"
                             + "OR [Action] LIKE '%" + txtSearchUserInfoLog.Text + "%'";


                dvgUsersInformationLog.DataSource = bs;
            }
            catch(EvaluateException ex)
            {
                //Do nothing... for invalid input characters
            }

            SetNumberOfUsersInformationLog();
        }
    }
}
