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
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }

        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none ";
        string connectionString = DatabaseConnection.Connection;
        string DateReportModes;

        private void SalesForm_Load(object sender, EventArgs e)
        {
            /*-------Transaction Sales Declaration-------*/
            dvgProductsTransaction.Hide();
            lblNumberOfProductsTransactions.Hide(); lblNumberOfProductsTransactionsValue.Hide(); 
            PopulateTransactionDataGridview();
            /*-------Products Transactions Sales Declaration-------*/
            dvgTransactionDesignAndWidth();
            PopulateProductTransctionDataGridview();
            dvgProductsTransactionDesignAndWidth();
            /*----------------All------------------*/
            comboBoxTransactionOrProducts.SelectedIndex = 0; //Set Default To Transaction Sales
            btnPrint.Hide();
        }

        private void bunifuSwitchToDatepicker_Click(object sender, EventArgs e)
        {
            if (bunifuSwitchToDatepicker.Value == true)
            {
                bunifuDatepickerToSales2.Enabled = true;
            }
            else
            {
                bunifuDatepickerToSales2.Enabled = false;
            }

            PopulateTransactionDataGridview();
            PopulateProductTransctionDataGridview();
        }

        private void bunifuDatepickerFromSales1_onValueChanged(object sender, EventArgs e)
        { 
            PopulateTransactionDataGridview();
            PopulateProductTransctionDataGridview();
        }

        private void bunifuDatepickerToSales2_onValueChanged(object sender, EventArgs e)
        {
            PopulateTransactionDataGridview();
            PopulateProductTransctionDataGridview();
        }

        private void SetTotalSalesAndRowsNumbers()
        {
            lblNumberOFTransactionValue.Text = dvgTransactions.Rows.Count.ToString();
            lblNumberOfProductsTransactionsValue.Text = dvgProductsTransaction.Rows.Count.ToString();

            double TotalSales = 0;
            double TotalDiscount = 0;
            double TotalProfitSales = 0;

            foreach(DataGridViewRow row in dvgTransactions.Rows)
            {
                TotalSales += Convert.ToDouble(row.Cells[dvgTransactions.Columns["TotalAmount"].Index].Value);
                TotalDiscount += Convert.ToDouble(row.Cells[dvgTransactions.Columns["Discount"].Index].Value);
            }

            foreach (DataGridViewRow row in dvgProductsTransaction.Rows)
            {
                TotalProfitSales += Convert.ToDouble(row.Cells[dvgProductsTransaction.Columns["TotalSales"].Index].Value);
            }

            TotalProfitSales -= TotalDiscount;

            lblTotalSalesValue.Text = string.Format("{0:n}", Math.Round(TotalSales, 2));
            lblTotalDiscountValue.Text = string.Format("{0:n}", Math.Round(TotalDiscount, 2));
            lblTotalProfitSalesValue.Text = string.Format("{0:n}", Math.Round(TotalProfitSales, 2));
        }

        private void comboBoxTransactionOrProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //For Transaction Sales
            if (comboBoxTransactionOrProducts.SelectedIndex == 0)
            {
                //Hide Products transactions Controls
                dvgProductsTransaction.Hide();
                lblNumberOfProductsTransactions.Hide(); lblNumberOfProductsTransactionsValue.Hide();
                //Show Transactions Controls
                lblNumberOfTransaction.Show(); lblNumberOFTransactionValue.Show();
                dvgTransactions.Show();
            }
            //For Product Transaction Sales 
            else
            {
                //Hide Transactions Controls
                dvgTransactions.Hide();
                lblNumberOfTransaction.Hide(); lblNumberOFTransactionValue.Hide();
                //Show ProductsTransactions Controls
                dvgProductsTransaction.Show();
                lblNumberOfProductsTransactions.Show(); lblNumberOfProductsTransactionsValue.Show();
            }
        }

        private void btnDailySales_Click(object sender, EventArgs e)
        {
            //Transactions Section
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionDaily", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgTransactions.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }
            //Products Transactions Section
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionDaily", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgProductsTransaction.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }

            btnPrint.Enabled = true;
            DateReportModes = "Daily Sales";
        }

        private void btnWeeklySales_Click(object sender, EventArgs e)
        {
            //Transactions Section
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionWeekly", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgTransactions.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }
            //Products Transactions Section
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionWeekly", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgProductsTransaction.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }

            btnPrint.Enabled = true;
            DateReportModes = "Weekly Sales";
        }

        private void btnMonthlySales_Click(object sender, EventArgs e)
        {
            //Transactions Section
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionMonthly", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgTransactions.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }
            //Products Transactions Section
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionMonthly", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgProductsTransaction.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }

            btnPrint.Enabled = true;
            DateReportModes = "Monthly Sales";
        }

        private void btnAnuallySales_Click(object sender, EventArgs e)
        {
            //Transactions Section
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionAnually", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgTransactions.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }
            //Products Transactions Section
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionAnually", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgProductsTransaction.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }

            btnPrint.Enabled = true;
            DateReportModes = "Anually Sales";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString("MM-dd-yyyy");
            string BusinessDate = "Error";

            string DateFrom = bunifuDatepickerFromSales1.Value.ToString("yyyy-MM-dd"); //For Manully Date
            string DateTo = bunifuDatepickerToSales2.Value.ToString("yyyy-MM-dd"); //For Manually Date

            string ManualInputDatesMode = ""; // Used to Revert DateReportModes Variable Original Value

            if (DateReportModes == "Daily Sales" || DateReportModes == "Weekly Sales")
            {
                BusinessDate = DateTime.Now.ToString("MM-dd-yyyy");
            }
            else if (DateReportModes == "Monthly Sales")
            {
                BusinessDate = DateTime.Now.ToString("MM-yyyy");
            }
            else if (DateReportModes == "Anually Sales")
            {
                BusinessDate = DateTime.Now.ToString("yyyy");
            }
            else if (DateReportModes == "FromAndTo")
            {
                ManualInputDatesMode = DateReportModes;

                BusinessDate = DateFrom + " / " + DateTo;
                DateReportModes = ""; //Set Empty Because of Manually Input Date, to Show Empty String in Print Header title
            }
            else if (DateReportModes == "From")
            {
                ManualInputDatesMode = DateReportModes;

                BusinessDate = DateFrom;
                DateReportModes = ""; //Set to Empty Because of Manually Input Date, to Show Empty String in Print Header title
            }
            else
            {
                //Do Nothing ........
            }

            SalesReportInformation salesReport = new SalesReportInformation();

            salesReport.DateReportMode = DateReportModes;
            salesReport.Date = Date;
            salesReport.BusinessDate = BusinessDate;
            salesReport.TransactionsTotal = lblNumberOFTransactionValue.Text;
            salesReport.TotalSales = lblTotalSalesValue.Text;
            salesReport.TotalDiscount = lblTotalDiscountValue.Text;
            salesReport.TotalProfitSales = lblTotalProfitSalesValue.Text;
            salesReport.NumberOfProducts = dvgProductsTransaction.Rows.Count.ToString();

            // Used for From and To Modes. Set Back Variable to Original Value
            if (ManualInputDatesMode == "FromAndTo")
            {
                DateReportModes = ManualInputDatesMode; // Revert to original date report mode
            }
            else if (ManualInputDatesMode == "From")
            {
                DateReportModes = ManualInputDatesMode; // Revert to original date report mode
            }
            else
            {
                //Do Nothing.....Maybe Some Error Occurs 
            }

            //For Transaction Sales
            if (comboBoxTransactionOrProducts.SelectedIndex == 0)
            {
                SalesReportForm salesReportForm = new SalesReportForm(salesReport, "Transactions");
                salesReportForm.Show();
            }
            //For Product Transaction Sales 
            else
            {
                //Set DataTable To Fill Datagrid Data into DataTable
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ProductID", typeof(string));
                dataTable.Columns.Add("ProductName", typeof(string));
                dataTable.Columns.Add("PurchasePrice", typeof(string));
                dataTable.Columns.Add("SoldPrice", typeof(string));
                dataTable.Columns.Add("Quantity", typeof(string));
                dataTable.Columns.Add("TotalPrice", typeof(string));
                dataTable.Columns.Add("TotalSales", typeof(string));

                foreach (DataGridViewRow row in dvgProductsTransaction.Rows)
                {
                    dataTable.Rows.Add(row.Cells[0].Value, 
                        row.Cells[1].Value, 
                        row.Cells[2].Value, 
                        row.Cells[3].Value, 
                        row.Cells[4].Value, 
                        row.Cells[5].Value,
                        row.Cells[6].Value);
                }
                salesReport.dtProductSoldInformation = dataTable;

                SalesReportForm salesReportForm = new SalesReportForm(salesReport, "ProductsTransaction");
                salesReportForm.Show();
            }
        }

        /*--------------------------Transaction Section--------------------------*/

        private void PopulateTransactionDataGridview()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    string DateFrom = bunifuDatepickerFromSales1.Value.ToString("yyyy-MM-dd");
                    string DateTo = bunifuDatepickerToSales2.Value.ToString("yyyy-MM-dd");

                    mysqlCon.Open();

                    //Retrieve Date From And To Date
                    if (bunifuDatepickerToSales2.Enabled == true)
                    {
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionByDate", mysqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateFrom", DateFrom);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateTo", DateTo);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);
                        dvgTransactions.DataSource = dataTable;
                        DateReportModes = "FromAndTo"; //For Printing Sales Report

                        if (bunifuDatepickerFromSales1.Value >= bunifuDatepickerToSales2.Value)
                        {
                            btnPrint.Enabled = false;
                        }
                        else
                        {
                            btnPrint.Enabled = true;
                        }                                                    
                    }
                    //Retrieve Only From Date Which is Only One Value
                    else
                    {
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionByOneDate", mysqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateToAndFrom", DateFrom);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);
                        dvgTransactions.DataSource = dataTable;
                        DateReportModes = "From";
                        btnPrint.Enabled = true;
                    }

                    SetTotalSalesAndRowsNumbers(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }   
        }

        private void dvgTransactionDesignAndWidth()
        {
            //Design
            dvgTransactions.EnableHeadersVisualStyles = false;
            dvgTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dvgTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dvgTransactions.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dvgTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

            //Width

            dvgTransactions.Columns[0].Width = 220;
            dvgTransactions.Columns[1].Width = dvgTransactions.Width
                - dvgTransactions.Columns[0].Width
                - dvgTransactions.Columns[2].Width
                - dvgTransactions.Columns[3].Width
                - 230;
            dvgTransactions.Columns[2].Width = 220;
            dvgTransactions.Columns[3].Width = 220;
        }

        /*-----------------------Product Transactions Sale------------------------*/

        private void PopulateProductTransctionDataGridview()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    string DateFrom = bunifuDatepickerFromSales1.Value.ToString("yyyy-MM-dd");
                    string DateTo = bunifuDatepickerToSales2.Value.ToString("yyyy-MM-dd");

                    mysqlCon.Open();

                    //Retrieve Date From And To Date
                    if (bunifuDatepickerToSales2.Enabled == true)
                    {
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionByDate", mysqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateFrom", DateFrom);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateTo", DateTo);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);
                        dvgProductsTransaction.DataSource = dataTable;
                    }
                    //Retrieve Only From Date Which is Only One Value
                    else
                    {
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionByOneDate", mysqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateToAndFrom", DateFrom);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);
                        dvgProductsTransaction.DataSource = dataTable;
                    }

                    SetTotalSalesAndRowsNumbers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }
        }

        private void dvgProductsTransactionDesignAndWidth()
        {
            //Design
            dvgProductsTransaction.EnableHeadersVisualStyles = false;
            dvgProductsTransaction.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgProductsTransaction.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
            dvgProductsTransaction.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dvgProductsTransaction.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dvgProductsTransaction.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

            //Width

            dvgProductsTransaction.Columns[0].Width = 170;
            dvgProductsTransaction.Columns[1].Width = dvgTransactions.Width
                - dvgProductsTransaction.Columns[0].Width
                - dvgProductsTransaction.Columns[2].Width
                - dvgProductsTransaction.Columns[3].Width
                - dvgProductsTransaction.Columns[4].Width
                - dvgProductsTransaction.Columns[5].Width
                - dvgProductsTransaction.Columns[6].Width;
            dvgProductsTransaction.Columns[2].Width = 170;
            dvgProductsTransaction.Columns[3].Width = 170;
            dvgProductsTransaction.Columns[4].Width = 170;
            dvgProductsTransaction.Columns[5].Width = 170;
            dvgProductsTransaction.Columns[6].Width = 170;
        }

        private void txtSearchBy_Click(object sender, EventArgs e)
        {

        }
    }

    /*----------------Sales Report For Print-------------------------------*/
    public class SalesReportInformation
    {
        public DataTable dtProductSoldInformation { get; set; } //For Products Transactions Reports
        public string DateReportMode { get; set; }
        public string Date { get; set; }
        public string BusinessDate { get; set; }
        public string TransactionsTotal { get; set; }
        public string TotalSales { get; set; }
        public string TotalDiscount { get; set; }
        public string TotalProfitSales { get; set; }
        public string NumberOfProducts { get; set; }
    }
}
