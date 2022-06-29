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

namespace POSWithInventorySystem {
    public partial class POSForm : Form {
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;
        
        int UserID;

        public bool resultFromPasswordValidationUsersForm = false;
        
        LoginFormData UsersData;
        
        public POSForm() {
            InitializeComponent();
        }

        public POSForm(int userID, LoginFormData usersData) {
            InitializeComponent();
            this.UserID = userID;
            this.UsersData = usersData;
        }
        

        //Register New User tab
        private void UsersForm_Load(object sender, EventArgs e) {
            comboBoxActiveOrNotUsers.SelectedIndex = 0;
            SetActiveOrNotUsers(); 

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

        private void btnCreate_Click(object sender, EventArgs e) {
            ValidateAdminPassword(); 

            if (resultFromPasswordValidationUsersForm == true) {
                bool isTrue = false;

                if (string.IsNullOrEmpty(txtUsername.Text.Trim())) {
                    lblErrorUsername.Text = "❌";
                    isTrue = true;
                }

                if (string.IsNullOrEmpty(txtPassword.Text.Trim())) {
                    lblPasswordError.Text = "❌";
                    isTrue = true;
                }

                if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim())) {
                    lblPasswordConfirmError.Text = "❌";
                    isTrue = true;
                }

                if (txtPassword.Text != txtConfirmPassword.Text) {
                    lblPasswordNotMatch.Text = "❌";
                    isTrue = true;
                }

                if (string.IsNullOrEmpty(txtFirstName.Text.Trim())) {
                    lblFirstNameError.Text = "❌";
                    isTrue = true;
                }

                if (string.IsNullOrEmpty(txtLastName.Text.Trim())) {
                    lblLastNameError.Text = "❌";
                    isTrue = true;
                }

                if (string.IsNullOrEmpty(txtlAddress.Text.Trim())) {
                    lblAddressError.Text = "❌";
                    isTrue = true;
                }

                if(!string.IsNullOrEmpty(txtContact.Text.Trim()) && txtContact.Text.Length < 11) {
                    lblContactError.Text = "❌";
                    isTrue = true;
                }

                if (DatepickerlBirthDay.Value.Date == DateTime.Today) {
                    lblBirthdayError.Text = "❌";
                    isTrue = true;
                }

                if (!isTrue) {
                    if (!CheckUsernameIfAlreadyExist(txtUsername.Text.Trim())) {
                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
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

                            //Insert new user in the database
                            mysqlCon.Open();
                            MySqlCommand mySqlCommand1 = new MySqlCommand("AddUsersAccount", mysqlCon);
                            mySqlCommand1.CommandType = CommandType.StoredProcedure;
                            mySqlCommand1.Parameters.AddWithValue("_UsersType", UserType);
                            mySqlCommand1.Parameters.AddWithValue("_Username", Username);
                            mySqlCommand1.Parameters.AddWithValue("_Password", Password);
                            mySqlCommand1.Parameters.AddWithValue("_Status", "Active");
                            mySqlCommand1.ExecuteNonQuery();

                            //Insert new user's information in the database
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

                            //Getting the last inserted UserID
                            int LastUsersInsertedID;

                            MySqlDataAdapter mySqlDa = new MySqlDataAdapter("SelectUsersLastInsertedID", mysqlCon);
                            mySqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                            DataTable dtLastUsersInsertedID = new DataTable();
                            mySqlDa.Fill(dtLastUsersInsertedID);

                            LastUsersInsertedID = Convert.ToInt32(dtLastUsersInsertedID.Rows[0]["UsersID"]);

                            //Insert addition of user in User's History
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

                            MessageBox.Show("The user has been successfully registered.", "Registered New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pictureBoxUserPic.Image = POSWithInventorySystem.Properties.Resources.placeholder;
                            ClearAllText();

                            GridFill();
                            SetNumberOfUsers();

                            if (comboBoxActiveOrNotUsers.SelectedIndex == 1) {
                                comboBoxActiveOrNotUsers.SelectedIndex = 0;
                            }
                        }
                    }

                    else {
                        lblErrorUsername.Text = "❌";
                    }
                }
            }

            resultFromPasswordValidationUsersForm = false;
        }

        private void txtUsername_Enter(object sender, EventArgs e) {
            lblErrorUsername.Text = "";
        }

        private void txtPassword_Enter(object sender, EventArgs e) {
            lblPasswordError.Text = "";
            lblPasswordNotMatch.Text = "";
        }

        private void txtFirstName_Enter(object sender, EventArgs e) {
            lblFirstNameError.Text = "";
        }

        private void txtLastName_Enter(object sender, EventArgs e) {
            lblLastNameError.Text = "";
        }

        private void txtlAddress_Enter(object sender, EventArgs e) {
            lblAddressError.Text = "";
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e) {
            lblPasswordConfirmError.Text = "";
            lblPasswordNotMatch.Text = "";
        }

        private void txtContact_Enter(object sender, EventArgs e) {
            lblContactError.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e) {
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

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar);
        }

        private void txtMiddleName_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar);
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e) {
            lblContactError.Text = "";
            SetMaximumLength(txtContact, 11);
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void DatepickerlBirthDay_onValueChanged(object sender, EventArgs e) {
            if (getAge() < 0)
                txtAge.Text = "Invalid Age";
            
            else
                txtAge.Text = getAge().ToString();

            lblBirthdayError.Text = "";
        }

        private void DatepickerlBirthDay_Enter(object sender, EventArgs e) {
            lblBirthdayError.Text = "";
        }

        private void btnBrowseImage_Click(object sender, EventArgs e) {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif| *.jpg; *.png; *.gif)";
            
            if (opf.ShowDialog() == DialogResult.OK) {
                pictureBoxUserPic.Image = Image.FromFile(opf.FileName);
            }
        }

        private void SetMaximumLength(Bunifu.Framework.UI.BunifuMetroTextbox metroTextbox, int maxlength) {
            foreach (Control ctl in metroTextbox.Controls) {
                if (ctl.GetType() == typeof(TextBox)) {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = maxlength;
                }
            }
        }

        public string Hash(string password) {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;

            using (var algorithm = new System.Security.Cryptography.SHA512Managed()) {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            return Convert.ToBase64String(hashBytes);
        }

        public int getAge() {
            var today = DateTime.Today;
            var age = today.Year - DatepickerlBirthDay.Value.Year;
            
            if (DatepickerlBirthDay.Value > today.AddYears(-age))
                age--;
            
            if (age < 1)
                age = 0;

            return age;
        }

        public string getSex() {
            string sex = "";

            if (radioButtonMale.Checked)
                sex = "Male";
            else
                sex = "Female";

            return sex;
        }

        private byte[] getImage() {
            using (MemoryStream ms = new MemoryStream()) {
                pictureBoxUserPic.Image.Save(ms, pictureBoxUserPic.Image.RawFormat);
                byte[] image = ms.ToArray();

                return image;
            }
        }

        private string getUserType() {
            string type = comboBoxUserType.Items[comboBoxUserType.SelectedIndex].ToString();

            return type.Trim();
        }

        public void ClearAllText() {
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

        private bool CheckUsernameIfAlreadyExist(string userName) {
            bool isTrue = false;

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("ValidateUsernameIfAlreadyExist", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_Username", userName.Trim());
                MySqlDataReader dr = mySqlCmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(dr);

                if (dt.Rows.Count == 1) {
                    isTrue = true;
                }
            }

            return isTrue;
        }

        private void GridFill() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
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
            catch(Exception ex) {
                throw;
            }
        }

        private void GridFillNotActiveUsers() {
            try {
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
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

            catch (Exception ex) {
                throw;
            }
        }

        private void SetRowColorIntoRedWhenNotActive() {
            foreach (DataGridViewRow row in dataGridViewNotActiveUsers.Rows) {
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dataGridDesign() {
            //For active users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 0) {
                dataGridViewUsers.EnableHeadersVisualStyles = false;
                dataGridViewUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridViewUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
                dataGridViewUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }

            //For deactivated users
            else {
                dataGridViewNotActiveUsers.EnableHeadersVisualStyles = false;
                dataGridViewNotActiveUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridViewNotActiveUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; //Color.FromArgb(20, 25, 72);
                dataGridViewNotActiveUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }

        }

        private void dataGridWidth() {
            //For active users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 0) {
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

            //For deactivated users
            else {
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

        private void SetNumberOfUsers() {
            //For active users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 0) {
                lblNumberOfUsersValue.Text = dataGridViewUsers.Rows.Count.ToString();
            }

            //For deactivated users
            else {
                lblNumberOfUsersValue.Text = dataGridViewNotActiveUsers.Rows.Count.ToString();
            }
        }

        private void dataGridViewUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            //For deactivated users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 1) {
                SetRowColorIntoRedWhenNotActive();
            }
        }

        private void bunifuSwitch_Click(object sender, EventArgs e) {
            if(bunifuSwitch.Value == true) {
                btnDeleteUsers.Enabled = true;
            }

            else {
                btnDeleteUsers.Enabled = false;
            }
        }

        private void bunifuSwitchActivateUsers_Click(object sender, EventArgs e) {
            if(bunifuSwitchActivateUsers.Value == true) {
                btnActivateUsers.Enabled = true;
            }

            else {
                btnActivateUsers.Enabled = true;
            }
        }

        private void bunifuSwitchbtnDeactivateUsers_Click(object sender, EventArgs e) {
            if (bunifuSwitchbtnDeactivateUsers.Value == true) {
                btnDeactivateUsers.Enabled = true;
            }

            else {
                btnDeactivateUsers.Enabled = true;
            }
        }

        private void btnDeleteUsers_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidationUsersForm == true) {
                    resultFromPasswordValidationUsersForm = false;

                    if (dataGridViewNotActiveUsers.CurrentRow.Index != -1) {
                        int ID = Convert.ToInt32(dataGridViewNotActiveUsers.CurrentRow.Cells[0].Value);
                        string UserSubjectName = dataGridViewNotActiveUsers.CurrentRow.Cells[2].Value.ToString().Trim();
                        string Type = dataGridViewNotActiveUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the user? This cannot be undone.", "Delete selected user", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        
                        if (dialogResult == DialogResult.Yes) {
                            //Delete the selected user in the datagrid
                            DeleteUsersInfo(ID);

                            //Insert deletion to the user's history
                            InsertUsersinformationDeleteLog(ID, UserSubjectName);

                            //Fill the datagrid
                            GridFillNotActiveUsers();
                            SetRowColorIntoRedWhenNotActive();
                            SetNumberOfUsers();
                        }

                        else return;
                    }
                }

                resultFromPasswordValidationUsersForm = false;
            }
            catch(Exception ex) {
                MessageBox.Show("The users' list is empty. Please add users first.", "Empty user list", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewUsers_DoubleClick(object sender, EventArgs e) {
            try {
                if (dataGridViewUsers.CurrentRow.Index != -1) {
                    int ID = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value);
                    string Type = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                    ViewUserInformation viewUserInformation = new ViewUserInformation(ID);
                    viewUserInformation.ShowDialog();
                }
            }

            catch(Exception ex) {
                MessageBox.Show("There was an error while trying to view the user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewNotActiveUsers_DoubleClick(object sender, EventArgs e) {
            try {
                if (dataGridViewNotActiveUsers.CurrentRow.Index != -1) {
                    int ID = Convert.ToInt32(dataGridViewNotActiveUsers.CurrentRow.Cells[0].Value);
                    string Type = dataGridViewNotActiveUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                    ViewUserInformation viewUserInformation = new ViewUserInformation(ID);
                    viewUserInformation.ShowDialog();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("There was an error while trying to view the user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteUsersInfo(int id) {
            using(MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("DeleteUsersAccount", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;
                mysqlCmd.Parameters.AddWithValue("_UsersID", id);
                mysqlCmd.ExecuteNonQuery();
            }
        }

        private void InsertUsersinformationDeleteLog(int userSubjectID, string userSubjectName) {
            //Insert deletion in the user's history
            string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
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

        private void timer1_Tick(object sender, EventArgs e) {
            //Insert code here if you want something to show or what
        }

        private void txtSearchValue_OnValueChanged(object sender, EventArgs e) {
            try {
                //For active users
                if (comboBoxActiveOrNotUsers.SelectedIndex == 0) {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridViewUsers.DataSource;
                    bs.Filter = "Convert([UsersID], 'System.String') LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [UsersType] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [FirstName] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [LastName] LIKE '%" + txtSearchValue.Text + "%'"
                                + "OR [MiddleName] LIKE '%" + txtSearchValue.Text + "%'";

                    dataGridViewUsers.DataSource = bs;
                }

                //For deactivated users
                else {
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
            catch (EvaluateException ex) {
                //Insert code here if you want to show something
            }
        }

        private void comboBoxActiveOrNotUsers_SelectedIndexChanged(object sender, EventArgs e) {
            SetActiveOrNotUsers();
        }

        private void SetActiveOrNotUsers() {
            //For active users
            if (comboBoxActiveOrNotUsers.SelectedIndex == 0) {
                dataGridDesign();
                GridFill();
                dataGridWidth();
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

            //For deactivated users
            else {
                dataGridDesign();
                GridFillNotActiveUsers();
                dataGridWidth();
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

        //For current active users
        private void ValidateAdminPassword() {
            ValidateAdminPasswordDialog validateAdminPassword = new ValidateAdminPasswordDialog(UserID, "UsersForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }

        private void ValidateAdminPassword(int userID) {
            ValidateAdminPasswordDialog validateAdminPassword = new ValidateAdminPasswordDialog(userID, "UsersForm");
            validateAdminPassword.Owner = this;
            validateAdminPassword.ShowDialog();
        }

        private void btnUpdateUsers_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword(); 

                if (resultFromPasswordValidationUsersForm == true) {
                    resultFromPasswordValidationUsersForm = false;

                    if (dataGridViewUsers.CurrentRow.Index != -1) {
                        int ID = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value);
                        string UserSubjectNameUpdate = dataGridViewUsers.CurrentRow.Cells[2].Value.ToString().Trim();
                        string Type = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                        //Employee
                        if (Type == "Employee") {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update the employee's information?", "Update Employee's Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            
                            if (dialogResult == DialogResult.Yes) {
                                UpdateUserAccountAndInfo updateUserAccountAndInfo = new UpdateUserAccountAndInfo(ID.ToString(), UserSubjectNameUpdate, UsersData);
                                updateUserAccountAndInfo.ShowDialog();

                                GridFill();
                            }
                            else return;

                        }
                        
                        //Administrator
                        else {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update the employee's information? You will be prompt to enter admin's password again.", "Update Administrator's Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes) {
                                ValidateAdminPassword(ID);

                                if (resultFromPasswordValidationUsersForm == true) {
                                    UpdateUserAccountAndInfo updateUserAccountAndInfos = new UpdateUserAccountAndInfo(ID.ToString(), UserSubjectNameUpdate, UsersData);
                                    updateUserAccountAndInfos.ShowDialog();
                                    GridFill();
                                }
                            }
                            else return;
                        }
                    }
                }

                resultFromPasswordValidationUsersForm = false;
            }
            catch(Exception ex) {
                resultFromPasswordValidationUsersForm = false;
                MessageBox.Show("The users' list is empty. Please add users first.", "Empty User list", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        //Deactivated Users
        private void btnDeactivateUsers_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword();

                if (resultFromPasswordValidationUsersForm == true) {
                    resultFromPasswordValidationUsersForm = false;

                    if (dataGridViewUsers.CurrentRow.Index != -1) {
                        int ID = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value);
                        string UserSubjectName = dataGridViewUsers.CurrentRow.Cells[2].Value.ToString().Trim();
                        string Type = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                        //Employee
                        if (Type == "Employee") {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to deactivate this employee?", "Deactivate Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            
                            if (dialogResult == DialogResult.Yes) {
                                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                                    //Updating the selected user to be in deactivated status  
                                    mysqlCon.Open();
                                    MySqlCommand mySqlCommand1 = new MySqlCommand("UpdateUsersAccountStatusByID", mysqlCon);
                                    mySqlCommand1.CommandType = CommandType.StoredProcedure;
                                    mySqlCommand1.Parameters.AddWithValue("_UsersID", ID);
                                    mySqlCommand1.Parameters.AddWithValue("_Status", "Not Active");
                                    mySqlCommand1.ExecuteNonQuery();

                                    //Insert deactivation to the User's History
                                    InsertIntoUsersLogs(ID, UserSubjectName, "Deactivate");

                                    GridFill();
                                    SetNumberOfUsers();
                                }
                            }
                            else return;
                        }

                        //Administrator
                        else {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to deactivate this administrator? You will be prompted to input HIS/HER password.", "Deactivate Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            
                            if (dialogResult == DialogResult.Yes) {
                                ValidateAdminPassword(ID);
                                
                                if (resultFromPasswordValidationUsersForm == true) {
                                    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                                        //Updating the selected user to be in deactivated status  
                                        mysqlCon.Open();
                                        MySqlCommand mySqlCommand1 = new MySqlCommand("UpdateUsersAccountStatusByID", mysqlCon);
                                        mySqlCommand1.CommandType = CommandType.StoredProcedure;
                                        mySqlCommand1.Parameters.AddWithValue("_UsersID", ID);
                                        mySqlCommand1.Parameters.AddWithValue("_Status", "Not Active");
                                        mySqlCommand1.ExecuteNonQuery();

                                        //Insert deactivation to the User's History
                                        InsertIntoUsersLogs(ID, UserSubjectName, "Deactivate");

                                        GridFill(); //For Active Users;
                                        SetNumberOfUsers();
                                    }
                                }
                            }
                            else return;
                        }
                    }
                }

                resultFromPasswordValidationUsersForm = false;
            }
            catch (Exception ex) {
                resultFromPasswordValidationUsersForm = false;
                MessageBox.Show("The users' list is empty. Please add users first.", "Empty User list", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void InsertIntoUsersLogs(int subjectID, string subjectName, string action) {
            ///Insert update of the users to the User's History
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
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

        //Activating Users
        private void btnActivateUsers_Click(object sender, EventArgs e) {
            try {
                ValidateAdminPassword(); 

                if (resultFromPasswordValidationUsersForm == true) {
                    resultFromPasswordValidationUsersForm = false;

                    if (dataGridViewNotActiveUsers.CurrentRow.Index != -1) {
                        int ID = Convert.ToInt32(dataGridViewNotActiveUsers.CurrentRow.Cells[0].Value);
                        string UserSubjectName = dataGridViewNotActiveUsers.CurrentRow.Cells[2].Value.ToString().Trim();
                        string Type = dataGridViewNotActiveUsers.CurrentRow.Cells[1].Value.ToString().Trim();

                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to activate this user?", "Activate User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        
                        if (dialogResult == DialogResult.Yes) {
                            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString)) {
                                //Update user's status to "Active"
                                mysqlCon.Open();
                                MySqlCommand mySqlCommand1 = new MySqlCommand("UpdateUsersAccountStatusByID", mysqlCon);
                                mySqlCommand1.CommandType = CommandType.StoredProcedure;
                                mySqlCommand1.Parameters.AddWithValue("_UsersID", ID);
                                mySqlCommand1.Parameters.AddWithValue("_Status", "Active");
                                mySqlCommand1.ExecuteNonQuery();

                                //Insert update status of the user in User's History
                                InsertIntoUsersLogs(ID, UserSubjectName, "Activate");

                                GridFillNotActiveUsers();
                                SetRowColorIntoRedWhenNotActive();
                                SetNumberOfUsers();
                            }
                        }
                        else return;
                    }
                }

                resultFromPasswordValidationUsersForm = false;
            }

            catch (Exception ex) {
                resultFromPasswordValidationUsersForm = false;
                MessageBox.Show("The users' list is empty. Please add users first.", "Empty User list", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
    
