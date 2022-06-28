using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSWithInventorySystem
{
    public partial class POSForm : Form
    {
        public POSForm()
        {
            InitializeComponent();
        }

        public POSForm(int userID, LoginFormData usersData)
        {
            InitializeComponent();
            this.UserID = userID;
            this.UsersData = usersData;
        }
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;
        int UserID;
        LoginFormData UsersData;
        public bool resultFromPasswordValidationUsersForm = false;

        /*-----------------------------This Section is For Registration Tab--------------------------------------*/
        private void UsersForm_Load(object sender, EventArgs e)
        {
            comboBoxActiveOrNotUsers.SelectedIndex = 0;
            SetActiveOrNotUsers(); //Combobox For Active and Not Active Users

            /*----------------------------*/
            lblErrorUsername.Text = "";
            lblPasswordError.Text = "";
            lblPasswordConfirmError.Text = "";
            lblPasswordNotMatch.Text = "";
            lblFirstNameError.Text = "";
            lblLastNameError.Text = "";
            lblAddressError.Text = "";
            lblContactError.Text = "";
            lblBirthdayError.Text = "";
            comboBoxUserType.SelectedIndex = 0;
            btnDeleteUsers.Enabled = false;
            btnDeactivateUsers.Enabled = false;
            btnActivateUsers.Enabled = false;
            DatepickerlBirthDay.Value = DateTime.Today;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ValidateAdminPassword(); //Show Form For Admin Password Validation
            //IF True From Password Validation
            if (resultFromPasswordValidationUsersForm == true)
            {

                bool isTrue = false;

                if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
                {
                    lblErrorUsername.Text = "Username Field is Empty";
                    isTrue = true;
                }
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    lblPasswordError.Text = "Password Field is Empty";
                    isTrue = true;
                }
                if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
                {
                    lblPasswordConfirmError.Text = "Password Field is Empty";
                    isTrue = true;
                }
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    lblPasswordNotMatch.Text = "Password Do Not Match";
                    isTrue = true;
                }
                if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
                {
                    lblFirstNameError.Text = "Firstname Field is Empty";
                    isTrue = true;
                }
                if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
                {
                    lblLastNameError.Text = "Lastname Field is Empty";
                    isTrue = true;
                }
                if (string.IsNullOrEmpty(txtlAddress.Text.Trim()))
                {
                    lblAddressError.Text = "Address Field is Empty";
                    isTrue = true;
                }
                if(!string.IsNullOrEmpty(txtContact.Text.Trim()) && txtContact.Text.Length < 11)
                {
                    lblContactError.Text = "Contact Number is Short";
                    isTrue = true;
                }
                if (DatepickerlBirthDay.Value.Date == DateTime.Today)
                {
                    lblBirthdayError.Text = "Choose Birthday";
                    isTrue = true;
                }

                //IF All Field is Filled
                if (!isTrue)
                {
                    if (!CheckUsernameIfAlreadyExist(txtUsername.Text.Trim()))
                    {
                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            string UserType = getUserType();
                            string Username = txtUsername.Text.Trim();
                            string Password = Hash(txtPassword.Text.Trim());

                            string FirstName = txtFirstName.Text.Trim();
                            string LastName = txtLastName.Text.Trim();
                            string MiddleName = txtMiddleName.Text.Trim();
                            string BirthDay = DatepickerlBirthDay.Value.ToString("yyyyMMdd");
                            int Age = getAge();
                            string Address = txtlAddress.Text.Trim();
                            string Contact = txtContact.Text;
                            string Sex = getSex();
                            byte[] image = getImage();

                            //Insert into users table in database   
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand1 = new MySqlCommand("AddUsersAccount", mysqlCon);
                            mySqlCommand1.CommandType = CommandType.StoredProcedure;
                            mySqlCommand1.Parameters.AddWithValue("_UsersType", UserType);
                            mySqlCommand1.Parameters.AddWithValue("_Username", Username);
                            mySqlCommand1.Parameters.AddWithValue("_Password", Password);
                            mySqlCommand1.Parameters.AddWithValue("_Status", "Active");
                            mySqlCommand1.ExecuteNonQuery();

                            //Insert into users_information table in database
                            MySqlCommand mySqlCommand2 = new MySqlCommand("AddUsersPersonalInfo", mysqlCon);
                            mySqlCommand2.CommandType = CommandType.StoredProcedure;
                            mySqlCommand2.Parameters.AddWithValue("_FirstName", FirstName);
                            mySqlCommand2.Parameters.AddWithValue("_LastName", LastName);
                            mySqlCommand2.Parameters.AddWithValue("_MiddleName", MiddleName);
                            mySqlCommand2.Parameters.AddWithValue("_BirthDay", BirthDay);
                            mySqlCommand2.Parameters.AddWithValue("_Age", Age);
                            mySqlCommand2.Parameters.AddWithValue("_Address", Address);
                            mySqlCommand2.Parameters.AddWithValue("_Contact", Contact);
                            mySqlCommand2.Parameters.AddWithValue("_Sex", Sex);
                            mySqlCommand2.Parameters.AddWithValue("_Image", image);
                            mySqlCommand2.ExecuteNonQuery();

                            //Get Last Inserted Product ID
                            int LastUsersInsertedID;

                            MySqlDataAdapter mySqlDa = new MySqlDataAdapter("SelectUsersLastInsertedID", mysqlCon);
                            mySqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                            DataTable dtLastUsersInsertedID = new DataTable();
                            mySqlDa.Fill(dtLastUsersInsertedID);

                            LastUsersInsertedID = Convert.ToInt32(dtLastUsersInsertedID.Rows[0]["UsersID"]);

                            //Insert Into UsersInformation Log Table in Database
                            string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                            MySqlCommand mySqlCommand3 = new MySqlCommand("InsertUsersinformationLog", mysqlCon);
                            mySqlCommand3.CommandType = CommandType.StoredProcedure;
                            mySqlCommand3.Parameters.AddWithValue("_UsersID", UsersData.UsersID);
                            mySqlCommand3.Parameters.AddWithValue("_UsersName", UsersData.UsersName);
                            mySqlCommand3.Parameters.AddWithValue("_UsersSubjectID", LastUsersInsertedID);
                            mySqlCommand3.Parameters.AddWithValue("_UsersSubjectName", FirstName);
                            mySqlCommand3.Parameters.AddWithValue("_DateAndTime", DateAdded);
                            mySqlCommand3.Parameters.AddWithValue("_Action", "Add");
                            mySqlCommand3.ExecuteNonQuery();

                            /*---------------------------------------------------------------------------*/
                            MessageBox.Show("Registered Succesfully", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pictureBoxUserPic.Image = POSWithInventorySystem.Properties.Resources._666201__1_;
                            ClearAllText();

                            GridFill(); //For Active Users;
                            SetNumberOfUsers();

                            if (comboBoxActiveOrNotUsers.SelectedIndex == 1)
                            {
                                comboBoxActiveOrNotUsers.SelectedIndex = 0; //Set Combobox to Active Users In Tab1;
                            }
                        }
                    }
                    else
                    {
                        lblErrorUsername.Text = "Username Was Already Exist";
                    }
                }
            }

            resultFromPasswordValidationUsersForm = false;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            lblErrorUsername.Text = "";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            lblPasswordError.Text = "";
            lblPasswordNotMatch.Text = "";

        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            lblFirstNameError.Text = "";
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            lblLastNameError.Text = "";
        }

        private void txtlAddress_Enter(object sender, EventArgs e)
        {
            lblAddressError.Text = "";
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            lblPasswordConfirmError.Text = "";
            lblPasswordNotMatch.Text = "";
        }

        private void txtContact_Enter(object sender, EventArgs e)
        {
            lblContactError.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtAge.Text = "";
            txtlAddress.Text = "";
            txtContact.Text = "";

            lblErrorUsername.Text = "";
            lblPasswordError.Text = "";
            lblPasswordConfirmError.Text = "";
            lblPasswordNotMatch.Text = "";
            lblFirstNameError.Text = "";
            lblLastNameError.Text = "";
            lblAddressError.Text = "";
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar); //IsDigit(e.KeyChar) for digit
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar); //IsDigit(e.KeyChar) for digit
        }

        private void txtMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar); //IsDigit(e.KeyChar) for digit
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblContactError.Text = "";
            SetMaximumLength(txtContact, 11);
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);

        }

        private void DatepickerlBirthDay_onValueChanged(object sender, EventArgs e)
        {
            if (getAge() < 0)
                txtAge.Text = "Invalid Age";
            else
                txtAge.Text = getAge().ToString();

            lblBirthdayError.Text = "";
        }

        private void DatepickerlBirthDay_Enter(object sender, EventArgs e)
        {
            lblBirthdayError.Text = "";
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif| *.jpg; *.png; *.gif)";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxUserPic.Image = Image.FromFile(opf.FileName);
            }
        }

        private void SetMaximumLength(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox, int maxlength)
        {
            foreach (Control ctl in metroTextbox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = maxlength;
                }
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

        public int getAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DatepickerlBirthDay.Value.Year;
            if (DatepickerlBirthDay.Value > today.AddYears(-age))
                age--;
            if (age < 1)
                age = 0;

            return age;
        }

        public string getSex()
        {
            string sex = "";

            if (radioButtonMale.Checked)
                sex = "Male";
            else
                sex = "Female";

            return sex;
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

        private string getUserType()
        {
            string type = comboBoxUserType.Items[comboBoxUserType.SelectedIndex].ToString();

            return type.Trim();
        }

        public void ClearAllText()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtAge.Text = "";
            txtlAddress.Text = "";
            txtContact.Text = "";
        }

        private bool CheckUsernameIfAlreadyExist(string userName)
        {
            bool isTrue = false;

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("ValidateUsernameIfAlreadyExist", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_Username", userName.Trim());
                MySqlDataReader dr = mySqlCmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(dr);

                if (dt.Rows.Count == 1)
                {
                    isTrue = true;
                }
            }

            return isTrue;
        }

        /*-----------------------END LINE OF REGISTRATION TAB----------------------------*/

        private void GridFill()
        {
            try{
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewActiveUsersInformation", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewUsers.DataSource = dataTable;
                    dataGridViewUsers.Columns[0].Visible = false; 
                    dataGridViewUsers.Columns[10].Visible = false;

                    /*
                    dataGridViewUsers.Columns[4].Visible = false;
                    dataGridViewUsers.Columns[5].Visible = false;
                    dataGridViewUsers.Columns[14].Visible = false;
                    */
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        } // For Active Users

        private void GridFillNotActiveUsers()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewNotActiveUsersInformation", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    dataGridViewNotActiveUsers.DataSource = dataTable;
                    dataGridViewNotActiveUsers.Columns[0].Visible = false;
                    dataGridViewNotActiveUsers.Columns[10].Visible = false;

                    /*
                    dataGridViewUsers.Columns[3].Visible = false;
                    dataGridViewUsers.Columns[4].Visible = false;
                    dataGridViewUsers.Columns[5].Visible = false;
                    dataGridViewUsers.Columns[14].Visible = false;
                    */
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SetRowColorIntoRedWhenNotActive()
        {
            foreach (DataGridViewRow row in dataGridViewNotActiveUsers.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dataGridDesign()
        {
            //If Active Users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 0)
            {
                dataGridViewUsers.EnableHeadersVisualStyles = false;
                dataGridViewUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridViewUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
                dataGridViewUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }
            //If Not Active users
            else
            {
                dataGridViewNotActiveUsers.EnableHeadersVisualStyles = false;
                dataGridViewNotActiveUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridViewNotActiveUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
                dataGridViewNotActiveUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }

        }

        private void dataGridWidth()
        {
            //If Active Users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 0)
            {
                //Width
                dataGridViewUsers.Columns[1].Width = 110;
                dataGridViewUsers.Columns[2].Width = 155;
                dataGridViewUsers.Columns[3].Width = 155;
                dataGridViewUsers.Columns[4].Width = 155;
                dataGridViewUsers.Columns[5].Width = 110;
                dataGridViewUsers.Columns[6].Width = 60;
                dataGridViewUsers.Columns[7].Width = 190;
                dataGridViewUsers.Columns[8].Width = 120;
                dataGridViewUsers.Columns[9].Width = 99;
            }
            //If Not Active Users
            else
            {
                //Width
                dataGridViewNotActiveUsers.Columns[1].Width = 110;
                dataGridViewNotActiveUsers.Columns[2].Width = 155;
                dataGridViewNotActiveUsers.Columns[3].Width = 155;
                dataGridViewNotActiveUsers.Columns[4].Width = 155;
                dataGridViewNotActiveUsers.Columns[5].Width = 110;
                dataGridViewNotActiveUsers.Columns[6].Width = 60;
                dataGridViewNotActiveUsers.Columns[7].Width = 190;
                dataGridViewNotActiveUsers.Columns[8].Width = 120;
                dataGridViewNotActiveUsers.Columns[9].Width = 99;
            }
        }

        private void SetNumberOfUsers()
        {
            //If Active Users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 0)
            {
                lblNumberOfUsersValue.Text = dataGridViewUsers.Rows.Count.ToString();
            }
            //If Not Active Users
            else
            {
                lblNumberOfUsersValue.Text = dataGridViewNotActiveUsers.Rows.Count.ToString();
            }
        }

        private void dataGridViewUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //If Not Active Users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 1)
            {
                SetRowColorIntoRedWhenNotActive(); // Change row to red
            }
        }

        private void bunifuSwitch_Click(object sender, EventArgs e)
        {
            if(bunifuSwitch.Value == true)
            {
                btnDeleteUsers.Enabled = true;
            }
            else
            {
                btnDeleteUsers.Enabled = false;
            }
        }

        private void bunifuSwitchActivateUsers_Click(object sender, EventArgs e)
        {
            if(bunifuSwitchActivateUsers.Value == true)
            {
                btnActivateUsers.Enabled = true;
            }
            else
            {
                btnActivateUsers.Enabled = false;
            }
        }

        private void bunifuSwitchbtnDeactivateUsers_Click(object sender, EventArgs e)
        {
            if (bunifuSwitchbtnDeactivateUsers.Value == true)
            {
                btnDeactivateUsers.Enabled = true;
            }
            else
            {
                btnDeactivateUsers.Enabled = false;
            }
        }

        private void btnDeleteUsers_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Show Form For Admin Password Validation
                //IF True From Password Validation
                if (resultFromPasswordValidationUsersForm == true)
                {
                    resultFromPasswordValidationUsersForm = false;//Set To Default Due To Using it Again Inside Inner IF

                    if (dataGridViewNotActiveUsers.CurrentRow.Index != -1)
                    {
                        int ID = Convert.ToInt32(dataGridViewNotActiveUsers.CurrentRow.Cells[0].Value);
                        string UserSubjectName = dataGridViewNotActiveUsers.CurrentRow.Cells[2].Value.ToString().Trim();
                        string Type = dataGridViewNotActiveUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                           DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Delete This Users Permanently?", "Delete Users", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //Delete Selected User In dvg
                            DeleteUsersInfo(ID);
                            //Insert UsersinformationLog in Database
                            InsertUsersinformationDeleteLog(ID, UserSubjectName);
                            //Fill New Value in dvg
                            GridFillNotActiveUsers();
                            SetRowColorIntoRedWhenNotActive();
                            SetNumberOfUsers();
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                resultFromPasswordValidationUsersForm = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Users is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewUsers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsers.CurrentRow.Index != -1)
                {
                    int ID = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value);
                    string Type = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                    ViewUserInformation viewUserInformation = new ViewUserInformation(ID);
                    viewUserInformation.ShowDialog();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewNotActiveUsers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewNotActiveUsers.CurrentRow.Index != -1)
                {
                    int ID = Convert.ToInt32(dataGridViewNotActiveUsers.CurrentRow.Cells[0].Value);
                    string Type = dataGridViewNotActiveUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                    ViewUserInformation viewUserInformation = new ViewUserInformation(ID);
                    viewUserInformation.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteUsersInfo(int id)
        {
            using(MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("DeleteUsersAccount", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;
                mysqlCmd.Parameters.AddWithValue("_UsersID", id);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        private void InsertUsersinformationDeleteLog(int userSubjectID, string userSubjectName)
        {
            //Insert Into UsersInformation Log Table in Database
            string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCommand3 = new MySqlCommand("InsertUsersinformationLog", mysqlCon);
                mySqlCommand3.CommandType = CommandType.StoredProcedure;
                mySqlCommand3.Parameters.AddWithValue("_UsersID", UsersData.UsersID);
                mySqlCommand3.Parameters.AddWithValue("_UsersName", UsersData.UsersName);
                mySqlCommand3.Parameters.AddWithValue("_UsersSubjectID", userSubjectID);
                mySqlCommand3.Parameters.AddWithValue("_UsersSubjectName", userSubjectName);
                mySqlCommand3.Parameters.AddWithValue("_DateAndTime", DateAdded);
                mySqlCommand3.Parameters.AddWithValue("_Action", "Delete");
                mySqlCommand3.ExecuteNonQuery();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void txtSearchValue_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                //If Active Users
                if (comboBoxActiveOrNotUsers.SelectedIndex == 0)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridViewUsers.DataSource;
                    bs.Filter = "Convert([UsersID], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [UsersType] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [FirstName] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [LastName] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [MiddleName] LIKE '%" + txtSearchValue.Text + "%'";

                    dataGridViewUsers.DataSource = bs;
                }
                //If Not Active Users
                else
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridViewNotActiveUsers.DataSource;
                    bs.Filter = "Convert([UsersID], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [UsersType] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [FirstName] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [LastName] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [MiddleName] LIKE '%" + txtSearchValue.Text + "%'";

                    dataGridViewNotActiveUsers.DataSource = bs;

                    SetRowColorIntoRedWhenNotActive(); // Change row to red
                }

                SetNumberOfUsers();
            }
            catch (EvaluateException ex)
            {
                //Do Nothing... for invalid input characters.
            }
        }

        private void comboBoxActiveOrNotUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveOrNotUsers();
        }

        private void SetActiveOrNotUsers()
        {
            //If Active Users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 0)
            {
                dataGridDesign(); //Design For Grid
                GridFill(); //For Active Users
                dataGridWidth(); //Width Of Grid
                SetNumberOfUsers();
                //Hide
                dataGridViewNotActiveUsers.Hide();
                btnDeleteUsers.Hide(); bunifuSwitch.Hide();
                btnActivateUsers.Hide(); bunifuSwitchActivateUsers.Hide();
                //Show
                dataGridViewUsers.Show();
                btnUpdateUsers.Show();
                btnDeactivateUsers.Show(); bunifuSwitchbtnDeactivateUsers.Show();
            }
            //For Not Active Users
            else
            {
                dataGridDesign(); //Design For Grid
                GridFillNotActiveUsers();
                dataGridWidth(); //Width Of Grid
                SetRowColorIntoRedWhenNotActive();
                SetNumberOfUsers();
                //Hide
                dataGridViewUsers.Hide();
                btnUpdateUsers.Hide();
                btnDeactivateUsers.Hide(); bunifuSwitchbtnDeactivateUsers.Hide();
                //Show
                dataGridViewNotActiveUsers.Show();
                btnDeleteUsers.Show(); bunifuSwitch.Show();
                btnActivateUsers.Show(); bunifuSwitchActivateUsers.Show();
            }
        }

        //For Currently Users
        private void ValidateAdminPassword()
        {
            ValidateAdminPasswordDialog validateAdminPassword = new ValidateAdminPasswordDialog(UserID, "UsersForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }
        //For Admin Password For Deletion Purposes
        private void ValidateAdminPassword(int userID)
        {
            ValidateAdminPasswordDialog validateAdminPassword = new ValidateAdminPasswordDialog(userID, "UsersForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }

        /*---------------- Update User Section-------------------*/
        private void btnUpdateUsers_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Show Form For Admin Password Validation
                //IF True From Password Validation
                if (resultFromPasswordValidationUsersForm == true)
                {
                    resultFromPasswordValidationUsersForm = false;//Set To Default Due To Using it Again Inside Inner IF

                    if (dataGridViewUsers.CurrentRow.Index != -1)
                    {
                        int ID = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value);
                        string UserSubjectNameUpdate = dataGridViewUsers.CurrentRow.Cells[2].Value.ToString().Trim();
                        string Type = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                        //IF employee
                        if (Type == "Employee")
                        {
                            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Update This Employee Information?", "Update Users", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                UpdateUserAccountAndInfo updateUserAccountAndInfo = new UpdateUserAccountAndInfo(ID.ToString(), UserSubjectNameUpdate, UsersData);
                                updateUserAccountAndInfo.ShowDialog();
                                GridFill();
                            }
                            else
                            {
                                return;
                            }
                        }
                        //If Admin
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Update This Admin Information? If Yes, You Will Prompt To Enter The Password Of This Admin User.", "Update Users", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                ValidateAdminPassword(ID); //Show Form For Admin Password Validation
                                if (resultFromPasswordValidationUsersForm == true)
                                {
                                    UpdateUserAccountAndInfo updateUserAccountAndInfos = new UpdateUserAccountAndInfo(ID.ToString(), UserSubjectNameUpdate, UsersData);
                                    updateUserAccountAndInfos.ShowDialog();
                                    GridFill();
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                resultFromPasswordValidationUsersForm = false;
            }
            catch(Exception ex)
            {
                resultFromPasswordValidationUsersForm = false;
                MessageBox.Show("Users is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        /*---------------------Deactivate Users---------------------------*/
        private void btnDeactivateUsers_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Show Form For Admin Password Validation
                //IF True From Password Validation
                if (resultFromPasswordValidationUsersForm == true)
                {
                    resultFromPasswordValidationUsersForm = false;//Set To Default Due To Using it Again Inside Inner IF

                    if (dataGridViewUsers.CurrentRow.Index != -1)
                    {
                        int ID = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value);
                        string UserSubjectName = dataGridViewUsers.CurrentRow.Cells[2].Value.ToString().Trim();
                        string Type = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                        //IF employee
                        if (Type == "Employee")
                        {
                            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Deactivate This Employee's Account & Information?", "Deactivate Users", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                                {
                                    //Update Users Status To Deactivate   
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand1 = new MySqlCommand("UpdateUsersAccountStatusByID", mysqlCon);
                                    mySqlCommand1.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand1.Parameters.AddWithValue("_UsersID", ID);
                                    mySqlCommand1.Parameters.AddWithValue("_Status", "Not Active");
                                    mySqlCommand1.ExecuteNonQuery();

                                    //Insert into users Log
                                    InsertIntoUsersLogs(ID, UserSubjectName, "Deactivate");

                                    GridFill(); //For Active Users;
                                    SetNumberOfUsers();

                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        //If Admin
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Deactivate This Admin Account & Information? If Yes, You Will Prompt To Enter The Password Of This Admin User.", "Deactivate Users", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                ValidateAdminPassword(ID); //Show Form For Admin Password Validation
                                if (resultFromPasswordValidationUsersForm == true)
                                {
                                    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                                    {
                                        //Update Users Status To Deactivate   
                                        mysqlCon.Open();
                                        MySqlCommand mySqlCommand1 = new MySqlCommand("UpdateUsersAccountStatusByID", mysqlCon);
                                        mySqlCommand1.CommandType = CommandType.StoredProcedure;
                                        mySqlCommand1.Parameters.AddWithValue("_UsersID", ID);
                                        mySqlCommand1.Parameters.AddWithValue("_Status", "Not Active");
                                        mySqlCommand1.ExecuteNonQuery();

                                        //Insert into users Log
                                        InsertIntoUsersLogs(ID, UserSubjectName, "Deactivate");

                                        GridFill(); //For Active Users;
                                        SetNumberOfUsers();
                                    }
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                resultFromPasswordValidationUsersForm = false;
            }
            catch (Exception ex)
            {
                resultFromPasswordValidationUsersForm = false;
                MessageBox.Show("Users Is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void InsertIntoUsersLogs(int subjectID, string subjectName, string action)
        {
            //Insert Into UsersInformation Log Table in Database
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                mysqlCon.Open();
                MySqlCommand mySqlCommand3 = new MySqlCommand("InsertUsersinformationLog", mysqlCon);
                mySqlCommand3.CommandType = CommandType.StoredProcedure;
                mySqlCommand3.Parameters.AddWithValue("_UsersID", UsersData.UsersID);
                mySqlCommand3.Parameters.AddWithValue("_UsersName", UsersData.UsersName);
                mySqlCommand3.Parameters.AddWithValue("_UsersSubjectID", subjectID);
                mySqlCommand3.Parameters.AddWithValue("_UsersSubjectName", subjectName);
                mySqlCommand3.Parameters.AddWithValue("_DateAndTime", DateAdded);
                mySqlCommand3.Parameters.AddWithValue("_Action", action);
                mySqlCommand3.ExecuteNonQuery();
            }
        }

        /*------------------------Activate Users-----------------------------*/
        private void btnActivateUsers_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAdminPassword(); //Show Form For Admin Password Validation
                //IF True From Password Validation
                if (resultFromPasswordValidationUsersForm == true)
                {
                    resultFromPasswordValidationUsersForm = false;//Set To Default Due To Using it Again Inside Inner IF

                    if (dataGridViewNotActiveUsers.CurrentRow.Index != -1)
                    {
                        int ID = Convert.ToInt32(dataGridViewNotActiveUsers.CurrentRow.Cells[0].Value);
                        string UserSubjectName = dataGridViewNotActiveUsers.CurrentRow.Cells[2].Value.ToString().Trim();
                        string Type = dataGridViewNotActiveUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                        DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Activate This Users?", "Activate Users", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                            {
                                //Update Users Status To Activate  
                                mysqlCon.Open();
                                MySqlCommand mySqlCommand1 = new MySqlCommand("UpdateUsersAccountStatusByID", mysqlCon);
                                mySqlCommand1.CommandType = CommandType.StoredProcedure;
                                mySqlCommand1.Parameters.AddWithValue("_UsersID", ID);
                                mySqlCommand1.Parameters.AddWithValue("_Status", "Active");
                                mySqlCommand1.ExecuteNonQuery();

                                //Insert into users Log
                                InsertIntoUsersLogs(ID, UserSubjectName, "Activate");

                                GridFillNotActiveUsers();
                                SetRowColorIntoRedWhenNotActive();
                                SetNumberOfUsers();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                resultFromPasswordValidationUsersForm = false;
            }
            catch (Exception ex)
            {
                resultFromPasswordValidationUsersForm = false;
                MessageBox.Show("Users Is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
    
