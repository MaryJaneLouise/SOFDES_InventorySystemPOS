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

namespace POSWithInventorySystem
{
    public partial class UsersAccountDialog : Form
    {
        public UsersAccountDialog()
        {
            InitializeComponent();
        }

        string UsersID;
        MemoryStream memoryStreamForViewImage;

        public UsersAccountDialog(string userID)
        {
            InitializeComponent();
            this.UsersID = userID;
        }

        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;
        int UsernameSwitch = 0;
        int PasswordSwitch = 0;
        string Usernames;

        private void UsersAccountDialog_Load(object sender, EventArgs e)
        {
            ClearLabelError();
            ValidateNFillDataControl();

            //Hide Username Controls From Ui
            /*lblUsername.Hide(); txtUsername.Hide();

            //Hide Passwords Controls From Ui
            lblOldPassword.Hide(); txtOldPassword.Hide();
            lblNewPassword.Hide(); txtNewPassword.Hide();
            lblConfirmPassword.Hide(); txtConfirmPassword.Hide();*/
            UsernameSwitch = 1;
            PasswordSwitch = 1;
            btnUsernameSettings.Hide();
            btnPasswordSettings.Hide();
            //btnUpdateAccount.Enabled = false;
        }

        private void UsersAccountDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            memoryStreamForViewImage.Dispose();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            lblErrorUsername.Text = "";
        }

        private void txtOldPassword_Enter(object sender, EventArgs e)
        {
            lblOldPasswordError.Text = "";
        }

        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            lblNewPasswordError.Text = "";
            lblPasswordNotMatch.Text = "";
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            lblConfirmPasswordError.Text = "";
            lblPasswordNotMatch.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearAllText()
        {
            txtUsername.Text = "";
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
        }

        private void ClearLabelError()
        {
            lblErrorUsername.Text = "";
            lblOldPasswordError.Text = "";
            lblNewPasswordError.Text = "";
            lblConfirmPasswordError.Text = "";
            lblPasswordNotMatch.Text = "";
        }

        private void UpdateAccount()
        {
            string UserID = lblUserIDValue.Text;
            string UserType = lblUserTypeValue.Text;
            string OldPassword = txtOldPassword.Text;
            string NewPassword = txtNewPassword.Text;

            //For Username Only
            if (UsernameSwitch == 1 && PasswordSwitch == 0)
            {
                if (!CheckUsernameControlslIfEmpty() && (Usernames != txtUsername.Text))
                {
                    using(MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                    {
                        mysqlCon.Open();
                        MySqlCommand mySqlCmd = new MySqlCommand("UpdateUsername", mysqlCon);
                        mySqlCmd.CommandType = CommandType.StoredProcedure;
                        mySqlCmd.Parameters.AddWithValue("_UsersID", UserID);
                        mySqlCmd.Parameters.AddWithValue("_Username", txtUsername.Text.Trim());
                        mySqlCmd.ExecuteNonQuery();

                        MessageBox.Show("Account Updated Succesfuly", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Usernames = txtUsername.Text;
                    lblErrorUsername.Text = "";
                    ValidateNFillDataControl();
                }
            }
            //For Password Only
            if (PasswordSwitch == 1 & UsernameSwitch == 0)
            {
                if (!CheckPasswordControlsIfEmpty())
                {
                    //If True Authenticated
                    if (ValidateUserPasswordByID(UserID, OldPassword))
                    {
                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            mysqlCon.Open();
                            MySqlCommand mySqlCmd = new MySqlCommand("UpdatePassword", mysqlCon);
                            mySqlCmd.CommandType = CommandType.StoredProcedure;
                            mySqlCmd.Parameters.AddWithValue("_UsersID", UserID);
                            mySqlCmd.Parameters.AddWithValue("_Password", Hash(txtNewPassword.Text.Trim()));
                            mySqlCmd.ExecuteNonQuery();

                            MessageBox.Show("Password Updated Succesfuly", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        lblOldPasswordError.Text = ""; lblNewPasswordError.Text = ""; lblConfirmPasswordError.Text = ""; lblPasswordNotMatch.Text = "";
                        txtOldPassword.Text = ""; txtNewPassword.Text = ""; txtConfirmPassword.Text = "";
                    }
                    else
                    {
                        lblOldPasswordError.Text = "❌";
                    }
                }
            }
            if (UsernameSwitch == 1 && PasswordSwitch == 1)
            {
                //IF All Field is Filled
                if (!CheckUsernameControlslIfEmpty() && !CheckPasswordControlsIfEmpty())
                {
                    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                    {
                        //If True Authenticated
                        if (ValidateUserPasswordByID(UserID, OldPassword))
                        {
                                mysqlCon.Open();
                                MySqlCommand mySqlCmd = new MySqlCommand("UpdateUserAccount", mysqlCon);
                                mySqlCmd.CommandType = CommandType.StoredProcedure;
                                mySqlCmd.Parameters.AddWithValue("_UsersID", UserID);
                                mySqlCmd.Parameters.AddWithValue("_Username", txtUsername.Text.Trim());
                                mySqlCmd.Parameters.AddWithValue("_Password", Hash(txtNewPassword.Text.Trim()));
                                mySqlCmd.ExecuteNonQuery();
                                MessageBox.Show("Account Updated Successfuly!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtOldPassword.Text = "";
                                txtNewPassword.Text = "";
                                txtConfirmPassword.Text = "";
                                ClearLabelError();
                                ValidateNFillDataControl();
                        }
                        else
                        {
                            lblOldPasswordError.Text = "❌";
                        }
                    }
                }
            }
        }

        private DataTable getUsersInfoFromDB()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("GetUsersAccountNInformationByID", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_UsersID", Convert.ToInt32(UsersID.Trim()));
                MySqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                mysqlCon.Close();

                return dt;
            }
        }

        private void ValidateNFillDataControl()
        {
            DataTable result = getUsersInfoFromDB();

            //If User Data Fetch is true;
            if(result.Rows.Count == 1)
            {
                string UsersID = result.Rows[0]["UsersID"].ToString();
                string UserType = result.Rows[0]["UsersType"].ToString();
                Usernames = result.Rows[0]["Username"].ToString();
                byte[] Image = (byte[])result.Rows[0]["Image"];

                //Fill Controls
                lblUserIDValue.Text = UsersID;
                lblUserTypeValue.Text = UserType;
                txtUsername.Text = Usernames;
                ViewUserImage(Image); //For User Image
            }
            else
            {
                MessageBox.Show("No Data Retrieved! or Two Users Exist!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewUserImage(byte[] bytes)
        {
            memoryStreamForViewImage = new MemoryStream(bytes);
            pictureBoxUserPic.Image = Image.FromStream(memoryStreamForViewImage);           
        }

        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            return Convert.ToBase64String(hashBytes);
        } //For Password Hash

        private bool ValidateUserPasswordByID(string Usersid, string password)
        {
            bool isTrue = false;

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("ValidateUserPasswordByID", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_UsersID", Usersid.Trim());
                mySqlCmd.Parameters.AddWithValue("_Password", Hash(password.Trim()));
                MySqlDataReader dr = mySqlCmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(dr);

                if(dt.Rows.Count == 1)
                {
                    isTrue = true;
                }
            }

            return isTrue;
        }

        private byte[] getImage()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBoxUserPic.Image.Save(ms, pictureBoxUserPic.Image.RawFormat);
                byte[] image = ms.ToArray();

                return image;
            }           
        }

        private void btnUsernameSettings_Click(object sender, EventArgs e)
        {
            //Username Settings
            /*if (UsernameSwitch == 1)
            {
                lblUsername.Hide(); txtUsername.Hide();
                lblChangeUsernameSettings.Show(); btnUsernameSettings.Location = new Point(326, 36);
                lblErrorUsername.Text = "";
                if (PasswordSwitch == 1)
                    btnUpdateAccount.Enabled = true;
                else
                    btnUpdateAccount.Enabled = false;
                UsernameSwitch = 0;
            }
            //Change Username Settings
            else
            {
                lblChangeUsernameSettings.Hide();
                bunifuTransition1.ShowSync(lblUsername); txtUsername.Show(); btnUsernameSettings.Location = new Point(536, 34);
                ValidateNFillDataControl();
                btnUpdateAccount.Enabled = true;
                UsernameSwitch = 1;
            }*/
        }

        private void btnChangePasswordSettings_Click(object sender, EventArgs e)
        {
            /*if (PasswordSwitch == 1)
            {
                lblOldPassword.Hide(); txtOldPassword.Hide(); 
                lblNewPassword.Hide(); txtNewPassword.Hide();
                lblConfirmPassword.Hide(); txtConfirmPassword.Hide();
                lblChangeUsernameSettings.Show(); btnUsernameSettings.Location = new Point(202, 132);
                lblErrorUsername.Text = "";
                if (PasswordSwitch == 1)
                    btnUpdateAccount.Enabled = true;
                else
                    btnUpdateAccount.Enabled = false;
                PasswordSwitch = 0;
            }
            //Change Username Settings
            else
            {
                lblChangeUsernameSettings.Hide();
                bunifuTransition1.ShowSync(lblUsername); txtUsername.Show(); btnUsernameSettings.Location = new Point(590, 146);
                ValidateNFillDataControl();
                btnUpdateAccount.Enabled = true;
                PasswordSwitch = 1;
            }*/
        }

        private bool CheckUsernameControlslIfEmpty()
        {
            bool isTrueUsername = false;

            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                lblErrorUsername.Text = "❌";
                isTrueUsername = true;
            }

            return isTrueUsername;
        }

        private bool CheckPasswordControlsIfEmpty()
        {
            bool isTruePassword = false;

            if (string.IsNullOrEmpty(txtOldPassword.Text.Trim()))
            {
                lblOldPasswordError.Text = "❌";
                isTruePassword = true;
            }
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                lblNewPasswordError.Text = "❌";
                isTruePassword = true;
            }
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                lblConfirmPasswordError.Text = "❌";
            }
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                lblPasswordNotMatch.Text = "❌";
                isTruePassword = true;
            }        

            return isTruePassword;
        }
    }
}
