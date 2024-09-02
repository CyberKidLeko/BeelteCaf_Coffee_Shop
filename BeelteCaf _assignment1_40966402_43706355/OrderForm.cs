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
using System.Globalization;

namespace BeelteCaf__assignment1_40966402_43706355
{
    public partial class OrderForm : Form
    {
        SqlConnection cnn;
        SqlCommand command1;
        SqlCommand command2;
        SqlCommand command3;
        SqlDataAdapter adapt;
        DataSet ds;
        SqlDataReader reader;
        int sum = 0;
        
        public string itemList;


        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nkulu\source\repos\BeelteCaf _assignment1_40966402_43706355\BeelteCaf _assignment1_40966402_43706355\Database1.mdf"";Integrated Security=True";
        public OrderForm()
        {
            InitializeComponent();
        }
        public void UpdateSum()
        {
            sum = 0;
            foreach (var item in lstCart.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length == 2)
                {
                    int value;
                    if (int.TryParse(parts[1].Trim(), out value))
                    {
                        sum += value;
                    }
                }

            }
            lblSubTotal.Text = sum.ToString("c",CultureInfo.CreateSpecificCulture("en-ZA"));
            lblSubTotal.ForeColor = Color.Green;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            try
            {

                cnn = new SqlConnection(connectionString); //create a connection 
                cnn.Open(); //opent the connection
                DataSet ds = new DataSet();

                string query1 = "SELECT * FROM Pastries";
                command1 = new SqlCommand(query1, cnn);
                SqlDataAdapter adapt1 = new SqlDataAdapter(command1);
                DataTable dataTable1 = new DataTable();
                adapt1.Fill(dataTable1);
                dataTable1.TableName = "Pastries";

                string query2 = "SELECT * FROM Sandwiches";
                command2 = new SqlCommand(query2, cnn);
                SqlDataAdapter adapt2 = new SqlDataAdapter(command2);
                DataTable dataTable2 = new DataTable();
                adapt2.Fill(dataTable2);
                dataTable2.TableName = "Sandwiches";

                string query3 = "SELECT * FROM [Hot drinks]";
                command3 = new SqlCommand(query3, cnn);
                SqlDataAdapter adapt3 = new SqlDataAdapter(command3);
                DataTable dataTable3 = new DataTable();
                adapt3.Fill(dataTable3);
                dataTable3.TableName = "[Hot drinks]";

                ds = new DataSet();
                ds.Tables.Add(dataTable1);
                ds.Tables.Add(dataTable2);
                ds.Tables.Add(dataTable3);

                // Add columns for each table to the DataGridView
                dataGridView1.ColumnCount = 4;

                dataGridView1.Columns[1].Name = "Pastries";
                dataGridView1.Columns[2].Name = "Sandwiches";
                dataGridView1.Columns[3].Name = "Hot drinks";

                /// Clear existing columns in the DataGridView
                dataGridView1.Columns.Clear();

                // Add columns for the first table to the DataGridView
                foreach (DataColumn column in dataTable1.Columns)
                {
                    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                }

                // Add an empty column as a separator
                dataGridView1.Columns.Add("EmptyColumn1", "");

                // Add columns for the second table to the DataGridView
                foreach (DataColumn column in dataTable2.Columns)
                {
                    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                }

                // Add an empty column as a separator
                dataGridView1.Columns.Add("EmptyColumn2", "");

                // Add columns for the third table to the DataGridView
                foreach (DataColumn column in dataTable3.Columns)
                {
                    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                }

                // Get the maximum row count among all tables
                int maxRowCount = Math.Max(dataTable1.Rows.Count, Math.Max(dataTable2.Rows.Count, dataTable3.Rows.Count));

                // Add rows to the DataGridView
                for (int i = 0; i < maxRowCount; i++)
                {
                    string[] rowData = new string[dataGridView1.Columns.Count];

                    // Populate row data for the first table
                    for (int j = 0; j < dataTable1.Columns.Count; j++)
                    {
                        rowData[j] = (i < dataTable1.Rows.Count) ? dataTable1.Rows[i][j].ToString() : "";
                    }

                    // Add an empty value for the separator column
                    rowData[dataTable1.Columns.Count] = "";

                    // Populate row data for the second table
                    for (int j = 0; j < dataTable2.Columns.Count; j++)
                    {
                        rowData[dataTable1.Columns.Count + 1 + j] = (i < dataTable2.Rows.Count) ? dataTable2.Rows[i][j].ToString() : "";
                    }
                    // Add an empty value for the separator column
                    rowData[dataTable1.Columns.Count + dataTable2.Columns.Count + 1] = "";

                    // Populate row data for the third table
                    for (int j = 0; j < dataTable3.Columns.Count; j++)
                    {
                        rowData[dataTable1.Columns.Count + dataTable2.Columns.Count + 2 + j] = (i < dataTable3.Rows.Count) ? dataTable3.Rows[i][j].ToString() : "";
                    }

                    dataGridView1.Rows.Add(rowData);
                }
                cnn.Close();
            }
            catch (SqlException error)// exception handling
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtSearchMenu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                string search = txtSearchMenu.Text;
                string query = "SELECT * FROM Pastries WHERE Pastries LIKE '%" + txtSearchMenu.Text + "%'";
                command1 = new SqlCommand(query, cnn);
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = command1;

                DataSet ds1 = new DataSet(); // creating dataset.
                adapt.Fill(ds1, "Pastries");
                dataGridView1.DataSource = ds1;
                dataGridView1.DataMember = "Pastries";
                

                string query2 = "SELECT * FROM Sandwiches WHERE Sandwiches LIKE '%" + txtSearchMenu.Text + "%'";
                command2 = new SqlCommand(query2, cnn);
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = command1;

                DataSet ds2 = new DataSet(); // creating dataset.
                adapt.Fill(ds2, "Sandwiches");
                dataGridView1.DataSource = ds2;
                dataGridView1.DataMember = "Sandwiches";
                

                string query3 = "SELECT * FROM [Hot drinks] WHERE [Hot drinks] LIKE '%" + txtSearchMenu.Text + "%'";
                command3 = new SqlCommand(query3, cnn);
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = command1;

                DataSet ds3 = new DataSet(); // creating dataset.
                adapt.Fill(ds3, "[Hot drinks]");
                dataGridView1.DataSource = ds3;
                dataGridView1.DataMember = "[Hot drinks]";
                





                cnn.Close();
            }
            catch (SqlException error)// exception handling
            {
                MessageBox.Show(error.Message);
            }
        
            

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Check if a valid row index is clicked
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    string selectedItem1 = selectedRow.Cells[e.ColumnIndex].Value.ToString();
                    string selectedItem2 = selectedRow.Cells[e.ColumnIndex + 1].Value.ToString();

                    lstCart.Items.Add(selectedItem1 + " - " + selectedItem2);
                   
                }
                UpdateSum();
            }
            catch (SqlException error)// exception handling
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCart.SelectedIndex >= 0) // Check if an item is selected
                {
                    lstCart.Items.RemoveAt(lstCart.SelectedIndex);
                    UpdateSum();
                }
                
               
            }
            catch (SqlException error)// exception handling
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            itemList = string.Join("\n", lstCart.Items.Cast<string>()); //converting listbox items to string sequences so theey can be displayed
            string sum = lblSubTotal.Text;

            if(lstCart.Items.Count == 0)
            {
                MessageBox.Show("Please enter something in cart");
            }
            if(string.IsNullOrEmpty(customerName))
            {
                errorProviderName.SetError(txtCustomerName, "Please enter customer name");
            }
            else
            {
                DialogResult confirmation = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    string message = "\nThank you for placing your order. Here are your selected items:\n" + itemList + "\n\n" +
                             $"The total sum is: " + sum + "\n\nPlease wait for your name to be called out, and have your payment ready.";

                    MessageBox.Show("Hello " + customerName + "!\n" + message, "Order Summary");
                }
                
            }

            
            

            
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
