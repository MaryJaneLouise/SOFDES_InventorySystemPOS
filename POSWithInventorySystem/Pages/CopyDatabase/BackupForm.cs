using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using MySql.Data.MySqlClient;

namespace POSWithInventorySystem {
    public partial class BackupForm : Form {
        string connectionString = DatabaseConnection.Connection;

        private bool resultValidation = false;
        public bool resultFromPasswordValidation = false;
        public bool Maximize;

        LoginFormData usersData;
        ValidateAdminPasswordDialog validateAdminPassword;

        public BackupForm() {
            InitializeComponent();
        }

        public BackupForm(LoginFormData loginFormData, bool maximize) {
            InitializeComponent();
            this.usersData = loginFormData;
            this.Maximize = maximize;
            
        }

        private void BackupForm_Load(object sender, EventArgs e) {
            RestrictTxtLocationControls(txtLocation);
            RestrictTxtDatabaseNameControls(txtDatabaseName);
            
            txtLocation.Enabled = false;
            lblLocationError.Text = "";
            lblFileNameError.Text = "";
            
            txtLocation.Text = "Choose an existing location";
            txtDatabaseName.Text = "SOFDES_InventorySystemPOS";
            
            HideControlsForBackup();
           
        }

        private void txtDatabaseName_KeyPress(object sender, KeyPressEventArgs e) {
            //Validating whether the input text is real or not
            if (Regex.IsMatch(e.KeyChar.ToString(), "^[a-zA-Z0-9_-].*?$") || Regex.IsMatch(e.KeyChar.ToString(), "[\b]")
                || Regex.IsMatch(e.KeyChar.ToString(), "[\\s*]") ) {
                //Stops the character from being entered into the control
                e.Handled = false;
            }

            else {
                e.Handled = true;
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            lblLocationError.Text = "";

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                txtLocation.Text = dialog.FileName;
            }
        }

        private void txtDatabaseName_OnValueChanged(object sender, EventArgs e) {
            lblFileNameError.Text = "";
        }

        private void btnBackUp_Click(object sender, EventArgs e) {
            try {

                if (txtLocation.Text == "Choose an existing location") {
                    lblLocationError.Text = "❌";
                    resultValidation = true;

                }
                
                if (string.IsNullOrEmpty(txtDatabaseName.Text.Trim())) {
                    lblFileNameError.Text = "❌";
                    resultValidation = true;
                }

                if (resultValidation == false) {
                    using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                        using (MySqlCommand cmd = new MySqlCommand()) {
                            using (MySqlBackup mb = new MySqlBackup(cmd)) {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ExportToFile(txtLocation.Text + "//" + txtDatabaseName.Text + ".sql");
                                conn.Close();
                            }

                            MessageBox.Show("Backup creation successful.", "Backup Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtLocation.Text = "Choose an existing location";
                            txtDatabaseName.Text = "SOFDES_InventorySystemPOS";
                            lblLocationError.Text = "";
                            lblFileNameError.Text = "";
                        }
                    }
                }

                resultValidation = false;
            }
            
            catch (UnauthorizedAccessException ex) {
                lblLocationError.Text = "❌";
            }
            
            catch(ArgumentException ex) {
                lblFileNameError.Text = "❌";
            }
            
            catch(Exception ex) {
                MessageBox.Show("There was an error in making backup of the database. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e) {
            ValidateAdminPassword();
            
            if (resultFromPasswordValidation) {
                bunifuTransitionBackUp.HideSync(PanelLocked);
                ShowControlsForBackup();
            }
            resultFromPasswordValidation = false;
        }

        private void btnLockMe_Click(object sender, EventArgs e) {
            lblFileNameError.Text = "";
            lblLocationError.Text = "";
            txtLocation.Text = "Choose an existing location";
            txtDatabaseName.Text = "SOFDES_InventorySystemPOS";
            btnLockMe.Hide();
            HideControlsForBackup();
            bunifuTransitionBackUp.ShowSync(PanelLocked);
        }

        private void RestrictTxtLocationControls(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox) {
            foreach (Control ctl in metroTextbox.Controls) {
                if (ctl.GetType() == typeof(TextBox)) {
                    var txt = (TextBox)ctl;
                    txt.ReadOnly = true;
                    txt.ShortcutsEnabled = false;
                }
            }
        }

        private void RestrictTxtDatabaseNameControls(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox) {
            foreach (Control ctl in metroTextbox.Controls) {
                if (ctl.GetType() == typeof(TextBox)) {
                    var txt = (TextBox)ctl;
                    txt.ShortcutsEnabled = false;
                    txt.MaxLength = 40;
                }
            }
        }

        private void HideControlsForBackup() {
            lblLocation.Hide(); txtLocation.Hide(); btnBrowse.Hide();
            
            lblDatabaseName.Hide(); txtDatabaseName.Hide(); btnBackUp.Hide();
            
            btnLockMe.Hide();
        }

        private void ShowControlsForBackup() {
            btnLockMe.Show();
            
            lblLocation.Show(); txtLocation.Show(); btnBrowse.Show();
            
            lblDatabaseName.Show(); txtDatabaseName.Show(); btnBackUp.Show();
        }

        

        private void ValidateAdminPassword() {
            validateAdminPassword = new ValidateAdminPasswordDialog(Convert.ToInt32(usersData.UsersID), "BackupForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.StartPosition = FormStartPosition.Manual;
            MinimizeNMaximizeInMainForm();
            validateAdminPassword.ShowDialog();
        }

        public void MinimizeNMaximizeInMainForm() {
            if (Maximize == true) {
                validateAdminPassword.Location = new Point(650, 320);
            }
            
            else {
                validateAdminPassword.Location = new Point(580, 320);
            }
        }

       
    }
}
