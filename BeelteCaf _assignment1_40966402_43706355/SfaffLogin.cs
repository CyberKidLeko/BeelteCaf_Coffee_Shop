using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BeelteCaf__assignment1_40966402_43706355
{
    public partial class SfaffLogin : Form
    {
        SqlConnection cnn;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommand command;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nkulu\source\repos\BeelteCaf _assignment1_40966402_43706355\BeelteCaf _assignment1_40966402_43706355\Database1.mdf"";Integrated Security=True";
        public SfaffLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                int dbStaffNumber;

                // Login Code
                string enteredPassword = txtStaffPassword.Text;
                int staffNumber = int.Parse(txtStaffnumber.Text);
                string query = "SELECT StaffNumber FROM StaffLogin WHERE StaffNumber = " + staffNumber;

                string Password = "admin";
                command = new SqlCommand(query, cnn);
                dbStaffNumber = (int)command.ExecuteScalar();



                if ((enteredPassword == Password)&& (staffNumber == dbStaffNumber))
                {
                    // Passwords match, open the desired form
                    StaffUpdate staffUpdate = new StaffUpdate();
                    staffUpdate.Show();
                }
                else
                {
                    // Passwords do not match, display an error message
                    MessageBox.Show("Invalid credentials. Please try again.");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        
    }
}       

