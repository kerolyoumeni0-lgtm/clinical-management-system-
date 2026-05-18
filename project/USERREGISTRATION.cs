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

namespace project
{
    public partial class USERREGISTRATION : Form
    {
        public USERREGISTRATION()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
private void Clearbtn_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // Check if any of the fields are empty
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtconfirmpassword.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                if (txtPassword.Text != txtconfirmpassword.Text)
                {
                    MessageBox.Show("Passwords do not match.");
                    return;
                }
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\utilisateur\source\repos\project\project\Database1.mdf; Integrated Security = True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string query = "INSERT INTO LOGINTbl (USERNAME, PASSWORD) VALUES (@username, @password)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                            MessageBox.Show("User registered successfully!");
                        else
                            MessageBox.Show("Registration failed.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }
            }
        }


                        private void button2_Click(object sender, EventArgs e)
                        {
                            LOGIN loginform = new LOGIN();
                            loginform.Show();
                            this.Hide();
                        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
        
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtconfirmpassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
   }
