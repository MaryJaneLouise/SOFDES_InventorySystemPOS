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
    public partial class ReceiptForm : Form {
        TransactionInformation transaction;
        public ReceiptForm() {
            InitializeComponent();
        }

        public ReceiptForm(TransactionInformation information) {
            InitializeComponent();
            this.transaction = information;
        }

        private void ReceiptForm_Load(object sender, EventArgs e) {
            crReceipt crystalReportReceipt = new crReceipt();

            crystalReportReceipt.Database.Tables["Product"].SetDataSource(transaction.ProductSoldInformation);

            SystemSettings systemSettings = new SystemSettings();
            crystalReportReceipt.SetParameterValue("SystemName", systemSettings.name);
            crystalReportReceipt.SetParameterValue("SystemAddress", systemSettings.address);
            crystalReportReceipt.SetParameterValue("SystemContact", systemSettings.contact);
            crystalReportReceipt.SetParameterValue("SystemEmail", systemSettings.email);

            crystalReportReceipt.SetParameterValue("Cashiere", transaction.userName);
            crystalReportReceipt.SetParameterValue("UserID", transaction.userID);
            crystalReportReceipt.SetParameterValue("DateAndTime", transaction.DateAndTime);
            crystalReportReceipt.SetParameterValue("Number", transaction.TransactionID);
            crystalReportReceipt.SetParameterValue("VAT", transaction.VAT);
            crystalReportReceipt.SetParameterValue("SubTotal", transaction.SubTotal);
            crystalReportReceipt.SetParameterValue("TotalAmount", transaction.TotalAmount);
            crystalReportReceipt.SetParameterValue("Discount", transaction.DiscountAmount);
            crystalReportReceipt.SetParameterValue("Amount", transaction.Amount);
            crystalReportReceipt.SetParameterValue("Change", transaction.Change);
            crystalReportReceipt.SetParameterValue("NumberItem", transaction.TotalOfItem);

            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = crystalReportReceipt;
        }

        private void ReceiptForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Close();
            }
            
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }
    }
}
