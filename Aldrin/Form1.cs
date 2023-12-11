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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
