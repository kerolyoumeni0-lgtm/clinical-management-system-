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
using System.Text.RegularExpressions;

namespace project
{
    public partial class patient : Form
    {
        public patient()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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


        private void LoadPatientIDs()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PatId FROM patientTbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtpatid.DataSource = dt;
                txtpatid.DisplayMember = "PatId";  // Use the PatId column for display
                txtpatid.ValueMember = "PatId";    // Optional: assign ValueMember as well
            }
        }


        private string GenerateNewPatientID()
        {
            string prefix = "PAT";
            int maxID = 0;

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PatId FROM patientTbl", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetString(0); // e.g. PAT01
                    if (id.StartsWith(prefix))
                    {
                        string numberPart = id.Substring(prefix.Length);
                        if (int.TryParse(numberPart, out int num))
                        {
                            if (num > maxID)
                                maxID = num;
                        }
                    }
                }
                reader.Close();
            }

            return prefix + (maxID + 1).ToString("D2"); // e.g. PAT01, PAT02, PAT03...
        }



        private void Addbtn_Click(object sender, EventArgs e)



        {


            if (txtpatid.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtemail.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            txtpatid.Text = GenerateNewPatientID();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\utilisateur\source\repos\project\project\Database1.mdf;Integrated Security=True");

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO patientTbl (PatId, Patname, PatEmail, Patphone, PatDOB, PatAddress, PatGender, PatBloodgr) VALUES (@ID, @Patname, @Email, @Phone, @DOB, @Address, @Gender, @Blood)", con);

                cmd.Parameters.AddWithValue("@ID", txtpatid.Text);
                cmd.Parameters.AddWithValue("@PatName", txtname.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@DOB", dtpdob.Value);
                cmd.Parameters.AddWithValue("@Gender", cmbgender.Text);
                cmd.Parameters.AddWithValue("@Phone", txtphoneNo.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Blood", txtblood.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dtpdop_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Docbtn_Click_1(object sender, EventArgs e)
        {

        }

        private void Docbtn_Click_2(object sender, EventArgs e)
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



        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (txtpatid.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtemail.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\PROJECT\PROJECT\DATABASE1.MDF;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE patientTbl SET Patname=@Patname, PatEmail=@Email, Patphone=@Phone, PatDOB=@DOB, PatAddress=@Address, PatGender=@Gender, PatBloodgr=@Blood WHERE PatId=@ID", con);

                    cmd.Parameters.AddWithValue("@ID", txtpatid.Text); 
                    cmd.Parameters.AddWithValue("@Patname", txtname.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphoneNo.Text);
                    cmd.Parameters.AddWithValue("@DOB", dtpdob.Value);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@Gender", cmbgender.Text);
                    cmd.Parameters.AddWithValue("@Blood", txtblood.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Delebtn_Click(object sender, EventArgs e)
        
        {
            if (txtpatid.Text == "")
            {
                MessageBox.Show("Please select or enter a Patient ID to delete.");
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM patientTbl WHERE PatId = @ID", con);
                    cmd.Parameters.AddWithValue("@ID", txtpatid.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Patient record deleted successfully.");
                        Clearbtn_Click(sender, e); // Clear form after deletion
                    }
                    else
                    {
                        MessageBox.Show("No record found with the entered Patient ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        

        private void patient_Load(object sender, EventArgs e)
        {
            LoadPatientIDs();
        }

        private void button2_Click(object sender, EventArgs e)
        
        {
            LOGIN loginForm = new LOGIN();  
            loginForm.Show();               
            this.Hide();                    
        }

        
            private void Clearbtn_Click(object sender, EventArgs e)
        {
            txtpatid.Text = "";
            txtname.Text = "";
            txtemail.Text = "";
            txtphoneNo.Text = "";
            txtaddress.Text = "";
            txtblood.Text = "";
            cmbgender.SelectedIndex = -1;
            dtpdob.Value = DateTime.Now;
        }

        private void txtpatid_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void txtphoneNo_TextChanged(object sender, EventArgs e)
        {
            string phone = txtphoneNo.Text;

            // UK phone number 
            string pattern = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";

            if (Regex.IsMatch(phone, pattern))
            {
                txtphoneNo.BackColor = System.Drawing.Color.LightGreen; // valid
            }
            else
            {
                txtphoneNo.BackColor = System.Drawing.Color.LightPink; // invalid
            }
        }
    }
    }
   
   
 



