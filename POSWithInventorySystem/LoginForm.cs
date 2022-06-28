using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POSWithInventorySystem
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;

        private MySqlConnection mysqlCon;
     
        private bool db_connection()
        {
            bool result = true;

            try
            {
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show("The system cannot be started because it is not connected to MySQL server. Please contact your administrator and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return result;
        }

        private DataTable Validate_User(string username, string password)
        {
            using (mysqlCon)
            {
                db_connection();
                MySqlCommand mySqlCommand = new MySqlCommand("SearchUsers", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_Username", username.Trim());
                mySqlCommand.Parameters.AddWithValue("_Password", Hash(password.Trim()));
                MySqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                mysqlCon.Close();
                
                return dt;
            }
        }

        private void lblFormClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void lblMinimizeForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerFormLoad.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += .10;
            if (this.Opacity == 100)
            {
                timerFormLoad.Stop();
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
            lblValidaton.Text = "";
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Text = "Username";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
            txtPassword.isPassword = true;
            lblValidaton.Text = "";
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.isPassword = false;
                txtPassword.Text = "Password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
            
        }

        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            lblValidaton.Text = "";
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            lblValidaton.Text = "";
        }

        public void login()
        {
            //Checking the connection if it still open
            if (db_connection())
            {
                if ((txtUsername.Text == "Username" && txtPassword.Text == "") || (txtPassword.Text == "Password" && txtUsername.Text == ""))
                {
                    MessageBox.Show("One of the text fields is empty. Please check them and try again.", "Invalid fields!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    DataTable result = Validate_User(txtUsername.Text, txtPassword.Text);
                    if (result.Rows.Count == 1 && result.Rows[0]["Status"].ToString() == "Active")
                    {
                        string role = result.Rows[0]["UsersType"].ToString();
                        string username = result.Rows[0]["Username"].ToString();
                        string UserID = result.Rows[0]["UsersID"].ToString();

                        //Get Data From UsersInformation Table Using UsersID
                        DataTable resultInUsersInformation = GetUsersInformation(UserID);
                        LoginFormData UsersData = new LoginFormData();
                        UsersData.UsersID = resultInUsersInformation.Rows[0]["UsersID"].ToString();
                        UsersData.UsersName = resultInUsersInformation.Rows[0]["FirstName"].ToString();
                        UsersData.UserType = role;
                        UsersData.Image = (byte[])resultInUsersInformation.Rows[0]["Image"];

                        switch (role)
                        {
                            case "Admin":
                                this.Hide();
                                MainForm adminForm = new MainForm(UsersData);
                                adminForm.Show();

                                break;

                            case "Employee":
                                this.Hide();
                                MainForm employeeForm = new MainForm(UsersData);
                                employeeForm.Show();

                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (result.Rows.Count == 1 && result.Rows[0]["Status"].ToString() == "Not Active")
                        {
                            MessageBox.Show("This account has been deactivated. Please contact your manager and try again.", "Deactivated Account", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MessageBox.Show("Your username or password is invalid. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
        }

        private DataTable GetUsersInformation(string userID)
        {
            using (mysqlCon)
            {
                db_connection();
                MySqlCommand mySqlCommand = new MySqlCommand("SearchUsersInfoByUsersID", mysqlCon);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_UsersID", userID);
                MySqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                mysqlCon.Close();

                return dt;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Enter)
            {
                login();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            return Convert.ToBase64String(hashBytes);
        }
    }

    public class LoginFormData
    {
        public string UsersID { get; set; }
        public string UsersName { get; set; }
        public string UserType { get; set; }
        public byte[] Image { get; set; }
    }
}
