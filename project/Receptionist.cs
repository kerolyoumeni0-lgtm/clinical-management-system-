using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace project
{
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
        }

        private void Docbtn_Click(object sender, EventArgs e)
        {
            doctor doctorform = new doctor();
            doctorform.Show();
            this.Hide();
        }

        private void Patientbtn_Click(object sender, EventArgs e)
        {
            patient patientform = new patient();
            patientform.Show();
            this.Hide();
        }

        private void Prescriptionbtn_Click(object sender, EventArgs e)
        {
            Prescription Prescriptionform = new Prescription();
            Prescriptionform.Show();
            this.Hide();
        }

        private void Recepbtn_Click(object sender, EventArgs e)
        {
            Receptionist Receptionistform = new Receptionist();
            Receptionistform.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void Docbtn_Click_1(object sender, EventArgs e)
        {
            doctor doctorform = new doctor();
            doctorform.Show();
            this.Hide();
        }

        private void Patientbtn_Click_1(object sender, EventArgs e)
        {
            patient patientform = new patient();
            patientform.Show();
            this.Hide();
        }

        private void Prescriptionbtn_Click_1(object sender, EventArgs e)
        {
            Prescription Prescriptionform = new Prescription();
            Prescriptionform.Show();
            this.Hide();
        }

        private void Recepbtn_Click_1(object sender, EventArgs e)
        {
            Receptionist Receptionistform = new Receptionist();
            Receptionistform.Show();
            this.Hide();
        }

        
            private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (txtrecepid.Text == "")
            {
                MessageBox.Show("Please select a receptionist ID to update.");
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE ReceptionistTbl SET RecepName=@Name, RecepPhone=@Phone, Recepshift=@Shift, RecepGen=@Gender, RecepEmail=@Email, RecepAdd=@Address WHERE RecepId=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", txtrecepid.Text);
                    cmd.Parameters.AddWithValue("@Name", txtrecepname.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@Shift", txtshift.Text);
                    cmd.Parameters.AddWithValue("@Gender", cmbgender.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Receptionist updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
           
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN loginForm = new LOGIN();
            loginForm.Show();
            this.Hide();
        }


        private string GenerateNewReceptionistID()
        {
     
        {
            string prefix = "REC";
            int maxID = 0;

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(RecepId, 4, LEN(RecepId) - 3) AS INT)) FROM ReceptionistTbl", con);
                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }

            return prefix + (maxID + 1).ToString("D2"); // e.g., REC01, REC02
        }
        }


        private void Receptionist_Load(object sender, EventArgs e)
        {
            txtrecepid.Text = GenerateNewReceptionistID();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {

            if (txtrecepid.Text == "" || txtrecepname.Text == "" || txtaddress.Text == "" || txtemail.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    txtrecepid.Text = GenerateNewReceptionistID();

                    SqlCommand cmd = new SqlCommand("INSERT INTO ReceptionistTbl (RecepId, RecepName, RecepPhone, Recepshift, RecepGen, RecepEmail, RecepAdd) " +
                                                     "VALUES (@RecepId, @Name, @Phone, @Shift, @Gender, @Email, @Address )", con);

                    cmd.Parameters.AddWithValue("@RecepId", txtrecepid.Text);
                    cmd.Parameters.AddWithValue("@Name", txtrecepname.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@Shift", txtshift.Text); 
                    cmd.Parameters.AddWithValue("@Gender", cmbgender.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void txtrecepid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Delebtn_Click(object sender, EventArgs e)
        {
            if (txtrecepid.Text == "")
            {
                MessageBox.Show("Please select a receptionist ID to delete.");
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM ReceptionistTbl WHERE RecepId=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", txtrecepid.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Receptionist deleted successfully!");
                        Clearbtn_Click(sender, e); // Optional: reset form
                    }
                    else
                    {
                        MessageBox.Show("No record found with the selected ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Clearbtn_Click_1(object sender, EventArgs e)
        {
            txtrecepname.Text = "";
            txtphone.Text = "";
            txtshift.Text = "";
            cmbgender.SelectedIndex = -1;
            txtemail.Text = "";
            txtaddress.Text = "";
            txtrecepid.Text = GenerateNewReceptionistID(); 
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            string email = txtemail.Text;

            // Basic email pattern like kerol@gmail.com
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (Regex.IsMatch(email, pattern))
            {
                txtemail.BackColor = System.Drawing.Color.LightGreen; // valid
                errorProvider1.SetError(txtemail, "");
            }
            else
            {
                txtemail.BackColor = System.Drawing.Color.LightPink; // invalid
                errorProvider1.SetError(txtemail, "Please enter a valid email like kerol@gmail.com");
            }
        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            string phone = txtphone.Text;

            // UK phone number 
            string pattern = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";

            if (Regex.IsMatch(phone, pattern))
            {
                txtphone.BackColor = System.Drawing.Color.LightGreen; // valid
            }
            else
            {
                txtphone.BackColor = System.Drawing.Color.LightPink; // invalid
            }
        }
    }
}
