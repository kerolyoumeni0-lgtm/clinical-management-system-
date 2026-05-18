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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            USERREGISTRATION Userregform = new USERREGISTRATION();
            Userregform.Show();
            this.Close();
        }

        private void LOGINbtn_Click(object sender, EventArgs e)
        {
            string username= txtusername.Text;
            string password= txtPassword.Text;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\utilisateur\\source\\repos\\project\\project\\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " SELECT COUNT(*) FROM LOGINTbl WHERE USERNAME=@username AND PASSWORD=@password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);


                conn.Open();
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    menuform menuform = new menuform();
                    menuform.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("invalid username or password");
                }

            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
    }

