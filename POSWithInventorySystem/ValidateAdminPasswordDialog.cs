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
    public partial class ValidateAdminPasswordDialog : Form {
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;
        
        int UserID;
        string CallerOfForm;
        string UserDiscountedValidate = "None";

        public ValidateAdminPasswordDialog() {
            InitializeComponent();
        }

        public ValidateAdminPasswordDialog(int userID, string caller) {
            InitializeComponent();
            this.UserID = userID;
            this.CallerOfForm = caller;
        }

        private void ValidateAdminPasswordDialog_Load(object sender, EventArgs e) {
            txtPassword.isPassword = true;
        }

        private void ValidateAdminPasswordDialog_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (CallerOfForm == "POSTransactionForm") {
                    if (ValidateAdminPasswordForDiscount()) {
                        POSTransactionForm pOSTransactionForm = (POSTransactionForm)this.Owner;
                        pOSTransactionForm.resultFromPasswordValidationDiscount = true;
                        pOSTransactionForm.Userdiscounted = UserDiscountedValidate;
                        
                        UserDiscountedValidate = "None";
                        this.Close();
                    }
                }

                else {
                    if (ValidateAdminPassword()) {
                        if (CallerOfForm == "StocksForm") {
                            StocksForm pOS = (StocksForm)this.Owner;
                            pOS.resultFromValidation = true;
                            this.Close();
                        }

                        else if (CallerOfForm == "HistoryForm") {
                            HistoryForm historyForm = (HistoryForm)this.Owner;
                            historyForm.resultFromPasswordValidation = true;
                            this.Close();
                        }

                        else if (CallerOfForm == "MainForm") {
                            MainForm mainForm = (MainForm)this.Owner;
                            mainForm.resultFromPasswordValidation = true;
                            this.Close();
                        }

                        else if (CallerOfForm == "UsersForm") {
                            //Coding bug but a stable one
                            //It should be UsersForm but it does not show up in the list
                            POSForm usersForm = (POSForm)this.Owner;
                            usersForm.resultFromPasswordValidationUsersForm = true;
                            this.Close();
                        }

                        else if (CallerOfForm == "BackupForm") {
                            BackupForm backupForm = (BackupForm)this.Owner;
                            backupForm.resultFromPasswordValidation = true;
                            this.Close();
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (CallerOfForm == "POSTransactionForm") {
                if (ValidateAdminPasswordForDiscount()) {
                    POSTransactionForm pOSTransactionForm = (POSTransactionForm)this.Owner;
                    pOSTransactionForm.resultFromPasswordValidationDiscount = true;
                    pOSTransactionForm.Userdiscounted = UserDiscountedValidate;
                    UserDiscountedValidate = "None";
                    this.Close();
                }
            }

            else {
                if (ValidateAdminPassword()) {
                    if (CallerOfForm == "StocksForm") {
                        StocksForm pOS = (StocksForm)this.Owner;
                        pOS.resultFromValidation = true;
                        this.Close();
                    }

                    else if (CallerOfForm == "HistoryForm") {
                        HistoryForm historyForm = (HistoryForm)this.Owner;
                        historyForm.resultFromPasswordValidation = true;
                        this.Close();
                    }

                    else if (CallerOfForm == "MainForm") {
                        MainForm mainForm = (MainForm)this.Owner;
                        mainForm.resultFromPasswordValidation = true;
                        this.Close();
                    }

                    else if (CallerOfForm == "UsersForm") {
                        //Coding bug but a stable one
                        //It should be UsersForm but it does not show up in the list
                        POSForm usersForm = (POSForm)this.Owner;
                        usersForm.resultFromPasswordValidationUsersForm = true;
                        this.Close();
                    }

                    else if(CallerOfForm == "BackupForm") {
                        BackupForm backupForm = (BackupForm)this.Owner;
                        backupForm.resultFromPasswordValidation = true;
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private bool ValidateAdminPassword() {
            bool result = false;

            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectAdminPasswordByID", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDa.SelectCommand.Parameters.AddWithValue("_UsersID", UserID);
                    sqlDa.SelectCommand.Parameters.AddWithValue("_Password", Hash(txtPassword.Text.Trim()));
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);

                    if (dataTable.Rows.Count == 1) {
                        result = true;
                    }

                    else {
                        if (CallerOfForm == "BackupForm") {
                            using (new MessageBoxChangeLocation(this)) {
                                MessageBox.Show("Invalid Password! Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        else {
                            MessageBox.Show("Invalid Password! Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            catch(Exception ex) {
                MessageBox.Show("Invalid Password! Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        //Exclusive for All Admin
        private bool ValidateAdminPasswordForDiscount() {
            bool result = false;
     
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectAdminPasswordByIDForDiscount", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDa.SelectCommand.Parameters.AddWithValue("_Password", Hash(txtPassword.Text.Trim()));
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);

                    if (dataTable.Rows.Count >= 1) {
                        result = true;
                        UserDiscountedValidate = dataTable.Rows[0]["FirstName"].ToString();
                    }

                    else {
                        MessageBox.Show("Invalid Password! Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

            catch (Exception ex) {
                MessageBox.Show("Error:" + ex);
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
