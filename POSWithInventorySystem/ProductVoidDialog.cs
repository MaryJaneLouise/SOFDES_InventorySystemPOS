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
    public partial class ProductVoidDialog : Form {
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;
        
        public ProductVoidDialog() {
            InitializeComponent();
        }
        
        private void ProductVoidDialog_Load(object sender, EventArgs e) {
            txtPassword.isPassword = true;
        }

        private void ProductVoidDialog_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                if (ValidateAdminPassword()) {
                    POSTransactionForm pOS = (POSTransactionForm)this.Owner;
                    pOS.result = true;
                    this.Close();
                }          
            }
            
            if(e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (ValidateAdminPassword()) {
                POSTransactionForm pOS = (POSTransactionForm)this.Owner;
                pOS.result = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private bool ValidateAdminPassword() {
            bool result = false;

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SelectAdminPassword", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;              
                mySqlCommand.Parameters.AddWithValue("_Password", Hash(txtPassword.Text.Trim()));
                MySqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                
                if(dt.Rows.Count >= 1) {
                   result = true;
                }
                
                else {
                    MessageBox.Show("You've entered the wrong admin's password. Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return result;
        }

        private string Hash(string password) {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            
            using (var algorithm = new System.Security.Cryptography.SHA512Managed()) {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            return Convert.ToBase64String(hashBytes);
        }
    }
}
