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
    public partial class SalesForm : Form {
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none ";
        string connectionString = DatabaseConnection.Connection;
        string DateReportModes;
        
        public SalesForm() {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e) {
            //Transaction Sales
            dvgProductsTransaction.Hide();
            lblNumberOfProductsTransactions.Hide(); lblNumberOfProductsTransactionsValue.Hide(); 
            PopulateTransactionDataGridview();
            
            //Products Transaction Sales
            dvgTransactionDesignAndWidth();
            PopulateProductTransctionDataGridview();
            dvgProductsTransactionDesignAndWidth();
            
            //All Sales
            comboBoxTransactionOrProducts.SelectedIndex = 0;
            btnPrint.Hide();

            bunifuSwitchToDatepicker.Value = true;
            bunifuSwitchToDatepicker.Hide();
        }

        private void bunifuSwitchToDatepicker_Click(object sender, EventArgs e) {
            if (bunifuSwitchToDatepicker.Value == true) {
                bunifuDatepickerToSales2.Enabled = true;
            }
            
            else {
                bunifuDatepickerToSales2.Enabled = false;
            }

            PopulateTransactionDataGridview();
            PopulateProductTransctionDataGridview();
        }

        private void bunifuDatepickerFromSales1_onValueChanged(object sender, EventArgs e) { 
            PopulateTransactionDataGridview();
            PopulateProductTransctionDataGridview();
        }

        private void bunifuDatepickerToSales2_onValueChanged(object sender, EventArgs e) {
            PopulateTransactionDataGridview();
            PopulateProductTransctionDataGridview();
        }

        private void SetTotalSalesAndRowsNumbers() {
            lblNumberOFTransactionValue.Text = dvgTransactions.Rows.Count.ToString();
            lblNumberOfProductsTransactionsValue.Text = dvgProductsTransaction.Rows.Count.ToString();

            double TotalSales = 0;
            double TotalDiscount = 0;
            double TotalProfitSales = 0;

            foreach(DataGridViewRow row in dvgTransactions.Rows) {
                TotalSales += Convert.ToDouble(row.Cells[dvgTransactions.Columns["TotalAmount"].Index].Value);
                TotalDiscount += Convert.ToDouble(row.Cells[dvgTransactions.Columns["Discount"].Index].Value);
            }

            foreach (DataGridViewRow row in dvgProductsTransaction.Rows) {
                TotalProfitSales += Convert.ToDouble(row.Cells[dvgProductsTransaction.Columns["TotalSales"].Index].Value);
            }

            TotalProfitSales -= TotalDiscount;

            lblTotalSalesValue.Text = string.Format("{0:n}", Math.Round(TotalSales, 2));
            lblTotalDiscountValue.Text = string.Format("{0:n}", Math.Round(TotalDiscount, 2));
            lblTotalProfitSalesValue.Text = string.Format("{0:n}", Math.Round(TotalProfitSales, 2));
        }

        private void comboBoxTransactionOrProducts_SelectedIndexChanged(object sender, EventArgs e) {
            //Transaction Sales
            if (comboBoxTransactionOrProducts.SelectedIndex == 0) {
                dvgProductsTransaction.Hide();
                lblNumberOfProductsTransactions.Hide(); lblNumberOfProductsTransactionsValue.Hide();
                
                lblNumberOfTransaction.Show(); lblNumberOFTransactionValue.Show();
                dvgTransactions.Show();
            }
            
            //Product Transaction Sales 
            else {
                dvgTransactions.Hide();
                lblNumberOfTransaction.Hide(); lblNumberOFTransactionValue.Hide();
                
                dvgProductsTransaction.Show();
                lblNumberOfProductsTransactions.Show(); lblNumberOfProductsTransactionsValue.Show();
            }
        }

        private void btnDailySales_Click(object sender, EventArgs e) {
            //Transactions Sales
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionDaily", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgTransactions.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }
            
            //Products Transactions Sales
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionDaily", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgProductsTransaction.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }

            btnPrint.Enabled = false;
            DateReportModes = "Daily Sales";
        }

        private void btnWeeklySales_Click(object sender, EventArgs e) {
            //Transactions Sales
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionWeekly", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgTransactions.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }
            
            //Products Transactions Sales
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionWeekly", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgProductsTransaction.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }

            btnPrint.Enabled = false;
            DateReportModes = "Weekly Sales";
        }

        private void btnMonthlySales_Click(object sender, EventArgs e) {
            //Transactions Sales
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionMonthly", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgTransactions.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }
            
            //Products Transactions Sales
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
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

        private void btnAnuallySales_Click(object sender, EventArgs e) {
            //Transactions Sales
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionAnually", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgTransactions.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }
            
            //Products Transactions Sales
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionAnually", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);
                dvgProductsTransaction.DataSource = dataTable;

                SetTotalSalesAndRowsNumbers();
            }

            btnPrint.Enabled = false;
            DateReportModes = "Anually Sales";
        }
        
        //Since the current's programmer IDE cannot view reports, the button for printing report will be disabled.
        //However, if you wish to enable the print button, you can edit the properties for "btnPrint.Enabled" to "true".
        private void btnPrint_Click(object sender, EventArgs e) {
            string Date = DateTime.Now.ToString("MM-dd-yyyy");
            string BusinessDate = "Error";

            string DateFrom = bunifuDatepickerFromSales1.Value.ToString("yyyy-MM-dd"); 
            string DateTo = bunifuDatepickerToSales2.Value.ToString("yyyy-MM-dd");

            string ManualInputDatesMode = ""; // Used to Revert DateReportModes Variable Original Value

            if (DateReportModes == "Daily Sales" || DateReportModes == "Weekly Sales") {
                BusinessDate = DateTime.Now.ToString("MM-dd-yyyy");
            }
            
            else if (DateReportModes == "Monthly Sales") {
                BusinessDate = DateTime.Now.ToString("MM-yyyy");
            }
            
            else if (DateReportModes == "Anually Sales") {
                BusinessDate = DateTime.Now.ToString("yyyy");
            }
            
            else if (DateReportModes == "FromAndTo") {
                ManualInputDatesMode = DateReportModes;

                BusinessDate = DateFrom + " / " + DateTo;
                
                //For printing manual dates
                DateReportModes = ""; 
            }
            
            else if (DateReportModes == "From") {
                ManualInputDatesMode = DateReportModes;

                BusinessDate = DateFrom;
                
                //For printing manual dates
                DateReportModes = "";
            }
            
            else {
                //Insert code here if you want something to show error or something
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

            //If the user tend to use manual dates, making them to default values
            if (ManualInputDatesMode == "FromAndTo") {
                DateReportModes = ManualInputDatesMode;
            }
            
            else if (ManualInputDatesMode == "From") {
                DateReportModes = ManualInputDatesMode;
            }
            else
            {
                //Insert code here if you want something to show error or something
            }

            //For Transaction Sales
            if (comboBoxTransactionOrProducts.SelectedIndex == 0) {
                SalesReportForm salesReportForm = new SalesReportForm(salesReport, "Transactions");
                salesReportForm.Show();
            }
            
            //For Product Transaction Sales 
            else {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ProductID", typeof(string));
                dataTable.Columns.Add("ProductName", typeof(string));
                dataTable.Columns.Add("PurchasePrice", typeof(string));
                dataTable.Columns.Add("SoldPrice", typeof(string));
                dataTable.Columns.Add("Quantity", typeof(string));
                dataTable.Columns.Add("TotalPrice", typeof(string));
                dataTable.Columns.Add("TotalSales", typeof(string));

                foreach (DataGridViewRow row in dvgProductsTransaction.Rows) {
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
        
        //Transaction Sales
        private void PopulateTransactionDataGridview() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    string DateFrom = bunifuDatepickerFromSales1.Value.ToString("yyyy-MM-dd");
                    string DateTo = bunifuDatepickerToSales2.Value.ToString("yyyy-MM-dd");

                    mysqlCon.Open();

                    //Retrieve manual date, to and from
                    if (bunifuDatepickerToSales2.Enabled == true) {
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectTransactionByDate", mysqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateFrom", DateFrom);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateTo", DateTo);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);
                        dvgTransactions.DataSource = dataTable;
                        
                        //For printing report
                        DateReportModes = "FromAndTo"; 

                        if (bunifuDatepickerFromSales1.Value >= bunifuDatepickerToSales2.Value) {
                            btnPrint.Enabled = false;
                        }
                        
                        else {
                            btnPrint.Enabled = true;
                        }                                                    
                    }
                    
                    //Retrieve only date
                    else {
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
            catch (Exception ex) {
                MessageBox.Show("There was an error in database: " + ex + " Please inform your manager.", "Error");
            }   
        }

        private void dvgTransactionDesignAndWidth() {
            //Design
            dvgTransactions.EnableHeadersVisualStyles = false;
            dvgTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.Black; //Color.FromArgb(20, 25, 72);
            dvgTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvgTransactions.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dvgTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

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

        //Product Transaction Sales
        private void PopulateProductTransctionDataGridview() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    string DateFrom = bunifuDatepickerFromSales1.Value.ToString("yyyy-MM-dd");
                    string DateTo = bunifuDatepickerToSales2.Value.ToString("yyyy-MM-dd");

                    mysqlCon.Open();

                    //Retrieve manual date, to and from
                    if (bunifuDatepickerToSales2.Enabled == true) {
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectProductsTransactionByDate", mysqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateFrom", DateFrom);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_DateTo", DateTo);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);
                        dvgProductsTransaction.DataSource = dataTable;
                    }
                    
                    //Retrieve only date
                    else {
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
            catch (Exception ex) {
                MessageBox.Show("There was an error in database: " + ex + " Please inform your manager.", "Error");
            }
        }

        private void dvgProductsTransactionDesignAndWidth() {
            //Design
            dvgProductsTransaction.EnableHeadersVisualStyles = false;
            dvgProductsTransaction.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgProductsTransaction.ColumnHeadersDefaultCellStyle.BackColor = Color.Black; //Color.FromArgb(20, 25, 72);
            dvgProductsTransaction.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvgProductsTransaction.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            dvgProductsTransaction.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

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

        private void txtSearchBy_Click(object sender, EventArgs e) {
            //Insert code here but it is an accidental click tho :D
        }
    }

    //Printing sales report
    public class SalesReportInformation {
        //For Products Transactions Reports
        public DataTable dtProductSoldInformation { get; set; } 
        
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