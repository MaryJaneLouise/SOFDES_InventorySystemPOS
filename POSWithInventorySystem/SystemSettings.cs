using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSWithInventorySystem
{
    class SystemSettings
    {
        public SystemSettings()
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(DatabaseConnection.Connection))
                {
                    mysqlCon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SelectSystemSettings", mysqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);
                    
                    if(dataTable.Rows.Count > 0)
                    {
                        name = dataTable.Rows[0]["name"].ToString();
                        address = dataTable.Rows[0]["address"].ToString();
                        contact = dataTable.Rows[0]["contact"].ToString();
                        email = dataTable.Rows[0]["email"].ToString();
                    }
                    else
                    {
                        name = "POS with Inventory System";
                        address = "";
                        contact = "";
                        email = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Database: " + " " + ex, "Error");
            }
        }

        public string name;
        public string address;
        public string contact;
        public string email;
    }
}
