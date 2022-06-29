using POSWithInventorySystem.ReportGenerator.CrystalReport;
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
    public partial class SalesReportForm : Form {
        SalesReportInformation ReportInformation;
        ProductsInformation ProductsInformation1;
        TotalStocksInformation stocksInformation;
        IndividualStocksInformation IndividualStocksInformation;

        public string CallerOfForm { get; set; }
        
        public SalesReportForm() {
            InitializeComponent();
        }

        //Sales Report
        public SalesReportForm(SalesReportInformation salesReportInformation, string callerOfForm) {
            InitializeComponent();
            this.ReportInformation = salesReportInformation;
            this.CallerOfForm = callerOfForm;
        }

        //Products' Information Report
        public SalesReportForm(ProductsInformation productsInformation, string callerOfForm) {
            InitializeComponent();
            this.ProductsInformation1 = productsInformation;
            this.CallerOfForm = callerOfForm;
        }

        //Total Stocks Information Report
        public SalesReportForm(TotalStocksInformation totalStocksInformation, string callerOfForm) {
            InitializeComponent();
            this.stocksInformation = totalStocksInformation;
            this.CallerOfForm = callerOfForm;
        }

        //Individual Stocks Information Report
        public SalesReportForm(IndividualStocksInformation individualStocksInformation, string callerOfForm) {
            InitializeComponent();
            this.IndividualStocksInformation = individualStocksInformation;
            this.CallerOfForm = callerOfForm;
        }

        private void SalesReportForm_Load(object sender, EventArgs e) {
            SystemSettings systemSettings = new SystemSettings();

            //Transactions Page
            if (CallerOfForm == "Transactions") {
                crSalesReport salesReport = new crSalesReport();

                salesReport.SetParameterValue("SystemName", systemSettings.name);
                salesReport.SetParameterValue("SystemAddress", systemSettings.address);
                salesReport.SetParameterValue("SystemContact", systemSettings.contact);

                salesReport.SetParameterValue("DateReportMode", ReportInformation.DateReportMode);
                salesReport.SetParameterValue("Date", ReportInformation.Date);
                salesReport.SetParameterValue("BusinessDate", ReportInformation.BusinessDate);
                salesReport.SetParameterValue("Transactions", ReportInformation.TransactionsTotal);
                salesReport.SetParameterValue("Total Sales", ReportInformation.TotalSales);
                salesReport.SetParameterValue("Total Discount", ReportInformation.TotalDiscount);
                salesReport.SetParameterValue("Total Profit Sales", ReportInformation.TotalProfitSales);

                crvSalesReport.ReportSource = null;
                crvSalesReport.ReportSource = salesReport;
            }
            
            //Products Transactions Page
            else if(CallerOfForm == "ProductsTransaction") {
                crProductsSalesReport crProducts = new crProductsSalesReport();

                crProducts.Database.Tables["ProductsSold"].SetDataSource(ReportInformation.dtProductSoldInformation);

                crProducts.SetParameterValue("SystemName", systemSettings.name);
                crProducts.SetParameterValue("SystemAddress", systemSettings.address);
                crProducts.SetParameterValue("SystemContact", systemSettings.contact);

                crProducts.SetParameterValue("DateReportMode", ReportInformation.DateReportMode);
                crProducts.SetParameterValue("Date", ReportInformation.Date);
                crProducts.SetParameterValue("BusinessDate", ReportInformation.BusinessDate);
                crProducts.SetParameterValue("Transactions", ReportInformation.TransactionsTotal);
                crProducts.SetParameterValue("TotalSales", ReportInformation.TotalSales);
                crProducts.SetParameterValue("TotalDiscount", ReportInformation.TotalDiscount);
                crProducts.SetParameterValue("TotalProfitSales", ReportInformation.TotalProfitSales);
                crProducts.SetParameterValue("NumberOfProducts", ReportInformation.NumberOfProducts);

                crvSalesReport.ReportSource = null;
                crvSalesReport.ReportSource = crProducts;
            }
            
            //Products' Information Report
            else if (CallerOfForm == "ProductsInformation") {
                ProductsInventory productsInventory = new ProductsInventory();
                productsInventory.Database.Tables["ProductsInformation"].SetDataSource(ProductsInformation1.ProductsInformations);

                productsInventory.SetParameterValue("SystemName", systemSettings.name);
                productsInventory.SetParameterValue("SystemAddress", systemSettings.address);
                productsInventory.SetParameterValue("SystemContact", systemSettings.contact);

                productsInventory.SetParameterValue("Date", ProductsInformation1.Date);
                productsInventory.SetParameterValue("NumberOfProducts", ProductsInformation1.NumberOfProducts);

                crvSalesReport.ReportSource = null;
                crvSalesReport.ReportSource = productsInventory;
            }
            
            //Total Stocks information Report
            else if(CallerOfForm == "TotalStocksInformation") {
                crStocksTotalInventory crStocksTotal = new crStocksTotalInventory();
                crStocksTotal.Database.Tables["TotalStocks"].SetDataSource(stocksInformation.TotalStocks);

                crStocksTotal.SetParameterValue("SystemName", systemSettings.name);
                crStocksTotal.SetParameterValue("SystemAddress", systemSettings.address);
                crStocksTotal.SetParameterValue("SystemContact", systemSettings.contact);

                crStocksTotal.SetParameterValue("Date", stocksInformation.Date);
                crStocksTotal.SetParameterValue("NumberOfProducts", stocksInformation.NumberOfTotalStocks);

                crvSalesReport.ReportSource = null;
                crvSalesReport.ReportSource = crStocksTotal;
            }
            
            //Individual Stocks Information Report
            else if(CallerOfForm == "IndividualStocksInformation") {
                crStocksIndividualInventory crStocksIndividual = new crStocksIndividualInventory();
                crStocksIndividual.Database.Tables["IndividualStocks"].SetDataSource(IndividualStocksInformation.IndividualStocks);

                crStocksIndividual.SetParameterValue("SystemName", systemSettings.name);
                crStocksIndividual.SetParameterValue("SystemAddress", systemSettings.address);
                crStocksIndividual.SetParameterValue("SystemContact", systemSettings.contact);

                crStocksIndividual.SetParameterValue("Date", IndividualStocksInformation.Date);
                crStocksIndividual.SetParameterValue("NumberOfProducts", IndividualStocksInformation.NumberOfIndividualStocks);

                crvSalesReport.ReportSource = null;
                crvSalesReport.ReportSource = crStocksIndividual;
            }
            
            else {
               //Insert code here for errors or something
            }
        }
    }
}
