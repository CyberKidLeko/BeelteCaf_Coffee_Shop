using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BeelteCaf__assignment1_40966402_43706355
{
    public partial class StaffUpdate : Form
    {
        SqlConnection cnn;
        SqlCommand command;
        SqlCommand command1;
        SqlCommand command2;
        SqlCommand command3;
        SqlDataAdapter adapt;
        DataSet ds;
        SqlDataReader reader;

        int sum = 0;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nkulu\source\repos\BeelteCaf _assignment1_40966402_43706355\BeelteCaf _assignment1_40966402_43706355\Database1.mdf"";Integrated Security=True";
        public StaffUpdate()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedCells.Count > 0)
                {
                    cnn = new SqlConnection(connectionString); //create a connection 
                    cnn.Open(); //opent the connection
                    DataSet ds = new DataSet();

                    string query1 = "DELETE FROM Pastries";
                    command1 = new SqlCommand(query1, cnn);
                    SqlDataAdapter adapt1 = new SqlDataAdapter(command1);
                    DataTable dataTable1 = new DataTable();
                    adapt1.Fill(dataTable1);
                    dataTable1.TableName = "Pastries";

                    string query2 = "DELETE * FROM Sandwiches";
                    command2 = new SqlCommand(query2, cnn);
                    SqlDataAdapter adapt2 = new SqlDataAdapter(command2);
                    DataTable dataTable2 = new DataTable();
                    adapt2.Fill(dataTable2);
                    dataTable2.TableName = "Sandwiches";

                    string query3 = "DELETE * FROM [Hot drinks]";
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
                    dataGridView1.ColumnCount = 3;
                    dataGridView1.Columns[0].Name = "Pastries";
                    dataGridView1.Columns[1].Name = "Sandwiches";
                    dataGridView1.Columns[2].Name = "Ho drinks";

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
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button4_Click(object sender, EventArgs e)
            {
                
            }

            private void StaffUpdate_Load(object sender, EventArgs e)
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
                    dataGridView1.ColumnCount = 3;
                    dataGridView1.Columns[0].Name = "Pastries";
                    dataGridView1.Columns[1].Name = "Sandwiches";
                    dataGridView1.Columns[2].Name = "Hot drinks";

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

            private void txtUpdate_Click(object sender, EventArgs e)
            {

            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

