using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSWithInventorySystem {
    public partial class MainForm : Form {
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none ";
        string connectionString = DatabaseConnection.Connection;

        LoginFormData LoginFormData;

        private bool LeavePOSTransactionMenu = false;
        private bool LeaveStocksMenu = false;
        private bool LeaveUsersMenu = false;
        private bool LeaveSalesMenu = false;
        private bool LeaveHistoryMenu = false;
        private bool LeaveBackup = false;


        public bool resultFromPasswordValidation = false; 

        string UserTimeIn;
        string UserTimeOut;
        int counter = 0;

        BackupForm backupForm;
        private bool MaximizeForm = true;

        public MainForm() {
            InitializeComponent();
        }

        public MainForm(LoginFormData loginFormData) {
            InitializeComponent();
            this.LoginFormData = loginFormData;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            POSTransaction();
            timerFormLoad.Start();
            
            lblNameValue.Text = LoginFormData.UsersName;
            lblUserTypeValue.Text = LoginFormData.UserType;
            
            ProvideUserFormByUserType(LoginFormData.UserType.Trim());
            timerDateNTime.Start();
            ViewUserImage(LoginFormData.Image);
            UserTimeIn = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt"); //UserTimeIN
            ShowAndHideButtonMenus("Show"); //Show Menus Button
        }

        

        private void btnClose_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit?", "Exit System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            switch (dialogResult) {
                case DialogResult.Yes:
                    UserTimeInNOutLog();
                    timerDateNTime.Stop();
                    Application.Exit();
                    break;

                case DialogResult.No:
                    break;

                default:
                    break;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e) {
            //Expand the custom NavBar Menu
            if(panelSideMenu.Width == 75) {
                panelMenusForm.Location = new Point(262, 43);

                //For Backup Form Password Validation Location Change
                if (LeaveBackup == true) {
                    backupForm.Maximize = true;
                    MaximizeForm = true;
                }
                    
                panelSideMenu.Visible = false;
                panelSideMenu.Width = 262;
                lblTodayAndTime.Visible = true;
                lblDateAndTime.Visible = true;
                transitionPanel2.ShowSync(panelSideMenu);
                transitionLogo.ShowSync(pictureBoxUsers);
                transitionLogo.ShowSync(lblNameValue);
                transitionLogo.ShowSync(lblUserTypeValue);
                transitionLogo.ShowSync(btnSignOut);
            }

            //Minimize the custom NavBar Menu
            else {
                panelMenusForm.Location = new Point(170, 43);

                //For Backup Form Password Validation Location Change
                if (LeaveBackup == true) {
                    backupForm.Maximize = false;
                    MaximizeForm = false;
                }
                    
                transitionLogo.Hide(pictureBoxUsers);
                lblNameValue.Visible = false;
                lblUserTypeValue.Visible = false;
                lblTodayAndTime.Visible = false;
                lblDateAndTime.Visible = false;
                btnSignOut.Visible = false;
                panelSideMenu.Visible = false;
                panelSideMenu.Width = 75;
                transitionPanel.ShowSync(panelSideMenu);

                counter++;
            }
        }

        private void timerDateNTime_Tick(object sender, EventArgs e) {
            DateTime now = DateTime.Now;

            string Month = now.ToString("MM");
            string Day = now.ToString("dd");
            string Year = now.ToString("yyyy");
            string Today = DateTime.Today.DayOfWeek.ToString();
            string Hrs = now.ToString("hh");
            string Minutes = now.ToString("mm");
            string AMorPm = now.ToString("tt");

            lblDateAndTime.Text = Month + "/" + Day + "/" + Year;
            lblTodayAndTime.Text = Today + ", " + Hrs + ":" + Minutes + " " + AMorPm;
        }

        private void btnMinimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timerFormLoad_Tick(object sender, EventArgs e) {
            this.Opacity += .20;
            if (this.Opacity == 100) {
                timerFormLoad.Stop();
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e) {
            if (btnSignOut.Enabled == false) return;

            DialogResult dialogResult = MessageBox.Show("Do you want to sign out? Any unsaved changes will be discarded.", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (dialogResult) {
                case DialogResult.Yes:
                    UserTimeInNOutLog();
                    this.Close();
                    LogInForm logInForm = new LogInForm();
                    logInForm.Show();
                    break;

                case DialogResult.No:
                    break;

                default:
                    break;
            } 
        }

        private void btnUsers_Click(object sender, EventArgs e) {
            if (btnUsers.Enabled == false) return;

            if (LeaveUsersMenu == false) {
                panelMenusForm.Controls.Clear();

                POSForm usersForm = new POSForm(Convert.ToInt32(LoginFormData.UsersID.Trim()), LoginFormData);
                usersForm.TopLevel = false;
                panelMenusForm.Controls.Add(usersForm);
                usersForm.FormBorderStyle = FormBorderStyle.None;
                usersForm.Dock = DockStyle.Fill;
                usersForm.Show();

                btnUsers.Activecolor = Color.Gold;
                LeaveUsersMenu = true;
            }

            btnTransaction.Normalcolor = Color.Orange;

            LeavePOSTransactionMenu = false;
            LeaveStocksMenu = false;
            LeaveSalesMenu = false;
            LeaveHistoryMenu = false;
            LeaveBackup = false;
        }

        private void btnHistoryLog_Click(object sender, EventArgs e) {
            if (btnHistoryLog.Enabled == false) return;

            if (LeaveHistoryMenu == false) {
                panelMenusForm.Controls.Clear(); 

                HistoryForm historyForm = new HistoryForm(LoginFormData);
                historyForm.TopLevel = false;
                panelMenusForm.Controls.Add(historyForm);
                historyForm.FormBorderStyle = FormBorderStyle.None; 
                historyForm.Dock = DockStyle.Fill; 
                historyForm.Show();

                btnHistoryLog.Activecolor = Color.Gold;
                LeaveHistoryMenu = true;
            }

            btnTransaction.Normalcolor = Color.Orange;

            LeavePOSTransactionMenu = false;
            LeaveStocksMenu = false;
            LeaveSalesMenu = false;
            LeaveUsersMenu = false;
            LeaveBackup = false;

        }

        private void BtnSales_Click(object sender, EventArgs e) {
            if (BtnSales.Enabled == false) return;

            if (LeaveSalesMenu == false) {
                panelMenusForm.Controls.Clear();

                SalesForm salesForm = new SalesForm();
                salesForm.TopLevel = false;
                panelMenusForm.Controls.Add(salesForm);
                salesForm.FormBorderStyle = FormBorderStyle.None;
                salesForm.Dock = DockStyle.Fill;
                salesForm.Show();

                BtnSales.Activecolor = Color.Gold;
                LeaveSalesMenu = true;
            }

            btnTransaction.Normalcolor = Color.Orange;
           
            LeavePOSTransactionMenu = false;
            LeaveStocksMenu = false;
            LeaveHistoryMenu = false;
            LeaveUsersMenu = false;
            LeaveBackup = false;
        }

        private void btnStocks_Click(object sender, EventArgs e) {
            if (btnStocks.Enabled == false) return;

            if (LeaveStocksMenu == false) {
                panelMenusForm.Controls.Clear();

                StocksForm stocksForm = new StocksForm(LoginFormData);
                stocksForm.TopLevel = false;
                panelMenusForm.Controls.Add(stocksForm);
                stocksForm.FormBorderStyle = FormBorderStyle.None;
                stocksForm.Dock = DockStyle.Fill;
                stocksForm.Show();

                btnStocks.Activecolor = Color.Gold;

                LeaveStocksMenu = true;
            }

            btnTransaction.Normalcolor = Color.Orange;

            LeavePOSTransactionMenu = false;
            LeaveSalesMenu = false;
            LeaveHistoryMenu = false;
            LeaveUsersMenu = false;
            LeaveBackup = false;
        }

        

        private void btnBackup_Click(object sender, EventArgs e) {
            if (btnBackup.Enabled == false)
                return;

            if (LeaveBackup == false) {
                if(counter == 1) {
                    MaximizeForm = false;
                }

                panelMenusForm.Controls.Clear();

                backupForm = new BackupForm(LoginFormData, MaximizeForm);
                backupForm.TopLevel = false;
                panelMenusForm.Controls.Add(backupForm);
                backupForm.FormBorderStyle = FormBorderStyle.None;
                backupForm.Dock = DockStyle.Fill;
                backupForm.Show();

                btnBackup.Activecolor = Color.Gold;

                LeaveBackup = true;
            }

            btnTransaction.Normalcolor = Color.Orange;

            LeavePOSTransactionMenu = false;
            LeaveSalesMenu = false;
            LeaveHistoryMenu = false;
            LeaveUsersMenu = false;
            LeaveStocksMenu = false;
        }

        private void btnTransaction_Click(object sender, EventArgs e) {
            POSTransaction();          
        }

        private void POSTransaction() {
            if (LeavePOSTransactionMenu == false) {
                panelMenusForm.Controls.Clear(); 

                POSTransactionForm transactionForm = new POSTransactionForm(Convert.ToInt32(LoginFormData.UsersID.Trim()), LoginFormData.UsersName);
                transactionForm.Owner = this;
                transactionForm.TopLevel = false;
                panelMenusForm.Controls.Add(transactionForm);
                transactionForm.FormBorderStyle = FormBorderStyle.None;
                transactionForm.Dock = DockStyle.Fill;
                transactionForm.Show();

                btnTransaction.Activecolor = Color.Gold;
                btnTransaction.Normalcolor = Color.Gold;
                LeavePOSTransactionMenu = true;
            }

            LeaveStocksMenu = false;
            LeaveSalesMenu = false;
            LeaveHistoryMenu = false;
            LeaveUsersMenu = false;
            LeaveBackup = false;
        }

        public void ViewUserImage(byte[] bytes) {
            if (LoginFormData.Image == null) {
                pictureBoxUsers.Image = POSWithInventorySystem.Properties.Resources.placeholder;
            }

            else {
                MemoryStream ms = new MemoryStream(bytes);
                pictureBoxUsers.Image = Image.FromStream(ms);
            }
        }

        private void btnMyAccount_Click(object sender, EventArgs e) {
            if (btnMyAccount.Enabled == false) return;

            ValidateAdminPassword(); 
            if (resultFromPasswordValidation == true) {
                UsersAccountDialog usersAccountDialog = new UsersAccountDialog(LoginFormData.UsersID);
                usersAccountDialog.ShowDialog();
            }

            resultFromPasswordValidation = false; 
        }

        private void ProvideUserFormByUserType(string userType) {
            //For employee
            if (userType == "Employee") {
                
                btnStocks.Visible = false;
                BtnSales.Visible = false;
                btnHistoryLog.Visible = false;
                btnUsers.Visible = false;
                btnBackup.Visible = false;
                bunifuSeparator3.Visible = false;
                bunifuSeparator5.Visible = false;
                bunifuSeparator6.Visible = false;
                bunifuSeparator7.Visible = false;
                bunifuSeparator8.Visible = false;
            }

            //For admin
            else {
               //No controls will be hidden or disabled
            }
        }

        private void UserTimeInNOutLog() {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                UserTimeOut = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                //Insert UserTimeInOut in database
                mysqlCon.Open();
                MySqlCommand mySqlCommand2 = new MySqlCommand("InsertUserLog", mysqlCon);
                mySqlCommand2.CommandType = CommandType.StoredProcedure;
                mySqlCommand2.Parameters.AddWithValue("_UserID", LoginFormData.UsersID);
                mySqlCommand2.Parameters.AddWithValue("_UserName", LoginFormData.UsersName);
                mySqlCommand2.Parameters.AddWithValue("_TimeIn", UserTimeIn);
                mySqlCommand2.Parameters.AddWithValue("_TimeOut", UserTimeOut);
                mySqlCommand2.ExecuteNonQuery();
            }
        }

        private void ValidateAdminPassword() {
            ValidateAdminPasswordDialog validateAdminPassword = new ValidateAdminPasswordDialog(Convert.ToInt32(LoginFormData.UsersID), "MainForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }

        public void ShowAndHideButtonMenus(string status) {
            //Show Button
            if (status == "Show") { 
                btnStocks.Enabled = true;
                BtnSales.Enabled = true;
                btnHistoryLog.Enabled = true;
                btnUsers.Enabled = true;
                btnBackup.Enabled = true;
                btnMyAccount.Enabled = true;
                btnSignOut.Enabled = true;
            }

            //Hide Button
            else {
                btnStocks.Enabled = false;
                BtnSales.Enabled = false;
                btnHistoryLog.Enabled = false;
                btnUsers.Enabled = false;
                btnBackup.Enabled = false;
                btnMyAccount.Enabled = false;
                btnSignOut.Enabled = false;
            }
        }
    }
}
