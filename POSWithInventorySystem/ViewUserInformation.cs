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
    public partial class ViewUserInformation : Form
    {
        public ViewUserInformation()
        {
            InitializeComponent();
        }

        public ViewUserInformation(int userID)
        {
            InitializeComponent();
            this.UsersID = userID;
        }

        //string connectionString = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none";
        string connectionString = DatabaseConnection.Connection;

        int UsersID;
        MemoryStream memoryStream;

        private void ViewUserInformation_Load(object sender, EventArgs e)
        {
            PopulateUiControls();
        }

        private void ViewUserInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            memoryStream.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            memoryStream.Dispose();
            this.Close();
        }

        private void PopulateUiControls()
        {
            try
            {
                if (Convert.ToString(UsersID) != null)
                {
                    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                    {
                        mysqlCon.Open();
                        MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectUserInformationByIDForView", mysqlCon);
                        sqlDa.SelectCommand.Parameters.AddWithValue("_UsersID", Convert.ToInt32(UsersID));
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        sqlDa.Fill(dataTable);

                        if (dataTable.Rows.Count == 1)
                        {
                            lblUserIDValue.Text = dataTable.Rows[0]["UsersID"].ToString();
                            lblUserTypeValue.Text = dataTable.Rows[0]["UsersType"].ToString();
                            lblStatusUsersValue.Text = dataTable.Rows[0]["Status"].ToString();
                            lblFirstNameValue.Text = dataTable.Rows[0]["FirstName"].ToString();
                            lblLastNameValue.Text = dataTable.Rows[0]["LastName"].ToString();
                            lblMiddlleNameValue.Text = dataTable.Rows[0]["MiddleName"].ToString();

                            lblBirthDayValue.Text = dataTable.Rows[0]["BirthDay"].ToString();
                            lblAgeValue.Text = dataTable.Rows[0]["Age"].ToString();
                            lblAddressValue.Text = dataTable.Rows[0]["Address"].ToString();
                            lblContactValue.Text = dataTable.Rows[0]["Contact"].ToString();

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
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetSex(String sex)
        {
            if (sex.Trim() == "Male")
            {
                lblSexValue.Text = "Male";
            }
            else
            {
                lblSexValue.Text = "Female";
            }
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
    }
}
