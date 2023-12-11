using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aldrin
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\WINDOWS 10\Documents\asd.accdb;";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            string edp = textBox1.Text;
            string firstName = textBox2.Text;
            string lastName = textBox3.Text;
            string course = textBox4.Text;

            // Create the SQL query
            string query = "INSERT INTO Students (EDP, FirstName, LastName, Course) VALUES (@edp, @firstName, @lastName, @course)";

            // Create and open a connection
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Create a command with parameters
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add parameters and their values
                    command.Parameters.AddWithValue("@edp", edp);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@course", course);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data saved successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Error saving data.");
                    }
                }
                LoadDataIntoDataGridView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            string edp = textBox1.Text; // Assuming textBox1 contains the EDP number
            string firstName = textBox2.Text;
            string lastName = textBox3.Text;
            string course = textBox4.Text;

            // Create the SQL query to update the record based on the EDP number
            string query = "UPDATE Students SET FirstName = @firstName, LastName = @lastName, Course = @course WHERE EDP = @edp";

            // Create and open a connection
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Create a command with parameters
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add parameters and their values
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@course", course);
                    command.Parameters.AddWithValue("@edp", edp);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No matching record found for the given EDP number.");
                    }
                }
            }

            // Refresh the DataGridView to show the updated data
            LoadDataIntoDataGridView();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            string edp = textBox1.Text; // Assuming textBox1 contains the EDP number

            // Create the SQL query to delete the record based on the EDP number
            string query = "DELETE FROM Students WHERE EDP = @edp";

            // Create and open a connection
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Create a command with parameters
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add the EDP parameter and its value
                    command.Parameters.AddWithValue("@edp", edp);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No matching record found for the given EDP number.");
                    }
                }
            }

            // Refresh the DataGridView to show the updated data
            LoadDataIntoDataGridView();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            // Create the SQL query to select all records from your table
            string query = "SELECT EDP, FirstName, LastName, Course FROM Students";

            // Create a DataTable to hold the data
            DataTable dataTable = new DataTable();

            // Create and open a connection
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Create a data adapter and fill the DataTable
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            // Set the DataTable as the DataSource for the DataGridView
            dataGridView1.DataSource = dataTable;
        }
    }
}
