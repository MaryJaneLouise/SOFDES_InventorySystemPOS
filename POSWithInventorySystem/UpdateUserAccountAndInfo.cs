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
    public partial class UpdateUserAccountAndInfo : Form
    {
        public UpdateUserAccountAndInfo()
        {
            InitializeComponent();
        }

        public UpdateUserAccountAndInfo(string userID, string userSubjectName, LoginFormData usersData)
        {
            InitializeComponent();
            this.UsersID = userID;
            this.UserSubjectName = userSubjectName;
            this.UsersData = usersData;
        }
        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;
        string UsersID;
        string UserSubjectName;
        LoginFormData UsersData;
        MemoryStream memoryStream;

        private void UpdateUserAccountAndInfo_Load(object sender, EventArgs e)
        {
            ClearLabelError();
            ValidateNFillDataControl();
        }

        private void UpdateUserAccountAndInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
           memoryStream.Dispose(); 
        }

        private void DatepickerlBirthDay_onValueChanged(object sender, EventArgs e)
        {
            if (getAge() < 0)
                txtAge.Text = "Invalid Age";
            else
                txtAge.Text = getAge().ToString();
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

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblContactError.Text = "";
            SetMaximumLength(txtContact, 11);
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblFirstNameError.Text = "";
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblLastNameError.Text = "";
        }

        private void txtlAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblAddressError.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateUserInformation();
        }

        private void UpdateUserInformation()
        {
            try
            {
                bool isTrue = false;

                if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
                {
                    lblFirstNameError.Text = "❌";
                    isTrue = true;
                }
                if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
                {
                    lblLastNameError.Text = "❌";
                    isTrue = true;
                }
                if (string.IsNullOrEmpty(txtlAddress.Text.Trim()))
                {
                    lblAddressError.Text = "❌";
                    isTrue = true;
                }
                if (!string.IsNullOrEmpty(txtContact.Text.Trim()) && txtContact.Text.Length < 11)
                {
                    lblContactError.Text = "❌";
                    isTrue = true;
                }

                if (!isTrue)
                {
                    string UserID = lblUserIDValue.Text;
                    string FirstName = txtFirstName.Text.Trim();
                    string LastName = txtLastName.Text.Trim();
                    string MiddleName = txtMiddleName.Text.Trim();
                    string BirthDay = DatepickerlBirthDay.Value.ToString("yyyyMMdd");
                    int Age = getAge();
                    string Address = txtlAddress.Text.Trim();
                    string Contact = txtContact.Text;
                    string Sex = getSex();
                    byte[] image = getImage();

                    //Insert Updated info into users_information table in database
                    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                    {
                        MySqlCommand mySqlCommand2 = new MySqlCommand("UpdateUserPersonalInfo", mysqlCon);
                        mysqlCon.Open();
                        mySqlCommand2.CommandType = CommandType.StoredProcedure;
                        mySqlCommand2.Parameters.AddWithValue("_UsersID", UserID);
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

                        //Insert Into UsersInformation Log Table in Database
                        string DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

                        MySqlCommand mySqlCommand3 = new MySqlCommand("InsertUsersinformationLog", mysqlCon);
                        mySqlCommand3.CommandType = CommandType.StoredProcedure;
                        mySqlCommand3.Parameters.AddWithValue("_UsersID", UsersData.UsersID);
                        mySqlCommand3.Parameters.AddWithValue("_UsersName", UsersData.UsersName);
                        mySqlCommand3.Parameters.AddWithValue("_UsersSubjectID", UsersID);
                        mySqlCommand3.Parameters.AddWithValue("_UsersSubjectName", UserSubjectName);
                        mySqlCommand3.Parameters.AddWithValue("_DateAndTime", DateAdded);
                        mySqlCommand3.Parameters.AddWithValue("_Action", "Update");
                        mySqlCommand3.ExecuteNonQuery();
                        
                        /*-----------------------------------------------------*/
                        MessageBox.Show("Information Updated Successfuly!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ValidateNFillDataControl();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearLabelError()
        {
            lblFirstNameError.Text = "";
            lblLastNameError.Text = "";
            lblAddressError.Text = "";
            lblContactError.Text = "";
        }

        private void ValidateNFillDataControl()
        {
            try
            {
                if (UsersID != null)
                {
                    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                    {
                        mysqlCon.Open();
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectUserInformationByID", mysqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_UsersID", Convert.ToInt32(UsersID));
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);

                        if (dataTable.Rows.Count == 1)
                        {
                            lblUserIDValue.Text = dataTable.Rows[0]["UsersID"].ToString();
                            lblUserTypeValue.Text = dataTable.Rows[0]["UsersType"].ToString();
                            lblStatusValue.Text = dataTable.Rows[0]["Status"].ToString();
                            txtFirstName.Text = dataTable.Rows[0]["FirstName"].ToString();
                            txtLastName.Text = dataTable.Rows[0]["LastName"].ToString();
                            txtMiddleName.Text = dataTable.Rows[0]["MiddleName"].ToString();

                            DatepickerlBirthDay.Value = (DateTime)dataTable.Rows[0]["BirthDay"];
                            txtAge.Text = dataTable.Rows[0]["Age"].ToString();
                            txtlAddress.Text = dataTable.Rows[0]["Address"].ToString();
                            txtContact.Text = dataTable.Rows[0]["Contact"].ToString();

                            string Sex = dataTable.Rows[0]["Sex"].ToString();
                            GetSex(Sex);

                            byte[] Image = (byte[])dataTable.Rows[0]["Image"];
                            ViewUserImage(Image);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error UsersID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private void GetSex(String sex)
        {
            if (sex.Trim() == "Male")
            {
                radioButtonMale.Checked = true;
            }
            else
            {
                radioButtonFemale.Checked = true;
            }
        }

        private string getSex()
        {
            string sex = "";

            if (radioButtonMale.Checked)
                sex = "Male";
            else
                sex = "Female";

            return sex;
        }

        private void ViewUserImage(byte[] image)
        {
            if (image == null)
            {
                pictureBoxUserPic.Image = POSWithInventorySystem.Properties.Resources._666201__1_;
            }
            else
            {
                memoryStream = new MemoryStream(image);   //Conversion of byte to Stream
                pictureBoxUserPic.Image = Image.FromStream(memoryStream); //Fill PictureBox...
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

        private int getAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DatepickerlBirthDay.Value.Year;
            if (DatepickerlBirthDay.Value > today.AddYears(-age))
                age--;
            if (age < 1)
                age = 0;

            return age;
        }

        private byte[] getImage()
        {
            // This gives "A generic error occurred in GDI+" in some images, so I use the code below of comment to remove the error.
            /*
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBoxUserPic.Image.Save(ms, pictureBoxUserPic.Image.RawFormat);
                byte[] image = ms.ToArray();

                return image;
            }
            */

            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(pictureBoxUserPic.Image);
                bmp.Save(ms, pictureBoxUserPic.Image.RawFormat);

                return ms.ToArray();
            }
        }
    }
}
