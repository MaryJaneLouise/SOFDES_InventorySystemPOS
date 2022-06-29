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

namespace POSWithInventorySystem
{
    public partial class BackupForm : Form
    {
        public BackupForm()
        {
            InitializeComponent();
        }

        public BackupForm(LoginFormData loginFormData, bool maximize)
        {
            InitializeComponent();
            this.usersData = loginFormData;
            this.Maximize = maximize;
            
        }

        LoginFormData usersData;

        string connectionString = DatabaseConnection.Connection;

        private bool resultValidation = false;
        public bool resultFromPasswordValidation = false;
        public bool Maximize;
       
        private void BackupForm_Load(object sender, EventArgs e)
        {
            RestrictTxtLocationControls(txtLocation);
            RestrictTxtDatabaseNameControls(txtDatabaseName);
            txtLocation.Enabled = false;
            lblLocationError.Text = "";
            lblFileNameError.Text = "";
            txtLocation.Text = "Choose Location";
            txtDatabaseName.Text = "POSInventorysystem-Backup";
            HideControlsForBackup(); //Hide Controls For Backup
           
        }

        private void txtDatabaseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a naughty character in the KeyPress event.
            if (Regex.IsMatch(e.KeyChar.ToString(), "^[a-zA-Z0-9_-].*?$") || Regex.IsMatch(e.KeyChar.ToString(), "[\b]")
                || Regex.IsMatch(e.KeyChar.ToString(), "[\\s*]") )
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            lblLocationError.Text = "";

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtLocation.Text = dialog.FileName;
            }
        }

        private void txtDatabaseName_OnValueChanged(object sender, EventArgs e)
        {
            lblFileNameError.Text = "";
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtLocation.Text == "Choose Location")
                {
                    lblLocationError.Text = "Please Choose Location Path";
                    resultValidation = true;

                }
                if (string.IsNullOrEmpty(txtDatabaseName.Text.Trim()))
                {
                    lblFileNameError.Text = "File Name is Empty";
                    resultValidation = true;
                }

                if (resultValidation == false)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ExportToFile(txtLocation.Text + "//" + txtDatabaseName.Text + ".sql");
                                conn.Close();
                            }

                            MessageBox.Show("Buckup Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtLocation.Text = "Choose Location";
                            txtDatabaseName.Text = "POSInventorysystem-Backup";
                            lblLocationError.Text = "";
                            lblFileNameError.Text = "";
                        }
                    }
                }

                resultValidation = false;
            }
            catch (UnauthorizedAccessException ex)
            {
                lblLocationError.Text = "Invalid Location Path";
            }
            catch(ArgumentException ex)
            {
                lblFileNameError.Text = "Invalid File Name";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            ValidateAdminPassword();
            //If True
            if (resultFromPasswordValidation)
            {
                bunifuTransitionBackUp.HideSync(PanelLocked);
                ShowControlsForBackup();
            }
            resultFromPasswordValidation = false;
        }

        private void btnLockMe_Click(object sender, EventArgs e)
        {
            lblFileNameError.Text = "";
            lblLocationError.Text = "";
            txtLocation.Text = "Choose Location";
            txtDatabaseName.Text = "POSInventorysystem-Backup";
            btnLockMe.Hide();
            HideControlsForBackup();
            bunifuTransitionBackUp.ShowSync(PanelLocked);
        }

        private void RestrictTxtLocationControls(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox)
        {
            foreach (Control ctl in metroTextbox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.ReadOnly = true;
                    txt.ShortcutsEnabled = false;
                }
            }
        }

        private void RestrictTxtDatabaseNameControls(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox)
        {
            foreach (Control ctl in metroTextbox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.ShortcutsEnabled = false;
                    txt.MaxLength = 40;
                }
            }
        }

        private void HideControlsForBackup()
        {
            lblLocation.Hide(); txtLocation.Hide();
            btnBrowse.Hide();
            lblDatabaseName.Hide(); txtDatabaseName.Hide();
            btnBackUp.Hide();
            btnLockMe.Hide();
        }

        private void ShowControlsForBackup()
        {
            btnLockMe.Show();
            lblLocation.Show(); txtLocation.Show(); btnBrowse.Show();
            lblDatabaseName.Show(); txtDatabaseName.Show();
            btnBackUp.Show();
        }

        ValidateAdminPasswordDialog validateAdminPassword;

        private void ValidateAdminPassword()
        {
            validateAdminPassword = new ValidateAdminPasswordDialog(Convert.ToInt32(usersData.UsersID), "BackupForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.StartPosition = FormStartPosition.Manual;
            MinimizeNMaximizeInMainForm();
            validateAdminPassword.ShowDialog();
        }

        public void MinimizeNMaximizeInMainForm()
        {
            if (Maximize == true)
            {
                validateAdminPassword.Location = new Point(650, 320);
            }
            else
            {
                validateAdminPassword.Location = new Point(580, 320);
            }
        }

       
    }
}
