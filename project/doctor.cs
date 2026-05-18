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
using System.Xml.Linq;

namespace project
{
    public partial class doctor : Form
    {
        public doctor()
        {
            InitializeComponent();
        }

        

       private void doctor_Load(object sender, EventArgs e)
        {
            LoadDoctorIDs(); // loads combo box
            txtdocid.Text = GenerateNewDoctorID(); // generates new ID
        }
        private void LoadDoctorIDs()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DoctorId FROM DoctorTbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txtdocid.DataSource = dt;
                txtdocid.DisplayMember = "DoctorId"; // What is shown in the ComboBox
                txtdocid.ValueMember = "DoctorId";   // Optional but keeps consistency
            }
        }

        private string GenerateNewDoctorID()
        {
            string prefix = "DOC";
            int maxID = 0;

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MAX(DoctorId) FROM DoctorTbl", con);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    string lastId = result.ToString(); // e.g., "DOC03"
                    int number = int.Parse(lastId.Substring(3)); // Get the number part
                    maxID = number;
                }
            }

            return prefix + (maxID + 1).ToString("D2"); // e.g., DOC04
        }









        private void Recepbtn_Click(object sender, EventArgs e)
        {
            Receptionist Receptionistform = new Receptionist();
            Receptionistform.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Prescriptionbtn_Click(object sender, EventArgs e)
        {
            Prescription Prescriptionform = new Prescription();
            Prescriptionform.Show();
            this.Hide();
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

        private void button2_Click(object sender, EventArgs e)
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

        private void Addbtn_Click(object sender, EventArgs e)
        
        {
            if (txtdocid.Text == "" || txtdocname.Text == "" || txtaddress.Text == "" || txtdocemail.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            txtdocid.Text = GenerateNewDoctorID();

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO DoctorTbl (DoctorId, DoctorName, DocPhoneNo, DocEmail, DocDOB, DocGen, DocSpec, DocAdd) " +
                                                    "VALUES (@DoctorId, @Name, @Phone, @Email, @DOB, @Gender, @Spec, @Address)", con);

                    cmd.Parameters.AddWithValue("@DoctorId", txtdocid.Text);
                    cmd.Parameters.AddWithValue("@Name", txtdocname.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtdocphone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtdocemail.Text);
                    cmd.Parameters.AddWithValue("@DOB", dtpdocdob.Value);
                    cmd.Parameters.AddWithValue("@Gender", cmbgender.Text);
                    cmd.Parameters.AddWithValue("@Spec", txtspecial.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        
        {
            LOGIN loginForm = new LOGIN();  
            loginForm.Show();               
            this.Hide();                    
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (txtdocid.Text == "" || txtdocname.Text == "" || txtdocphone.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE DoctorTbl SET DoctorName=@Name, DocPhoneNo=@Phone, DocEmail=@Email, DocDOB=@DOB, DocGen=@Gender, DocSpec=@Spec, DocAdd=@Address WHERE DoctorId=@DoctorId", con);

                    cmd.Parameters.AddWithValue("@DoctorId", txtdocid.Text);
                    cmd.Parameters.AddWithValue("@Name", txtdocname.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtdocphone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtdocemail.Text);
                    cmd.Parameters.AddWithValue("@DOB", dtpdocdob.Value);
                    cmd.Parameters.AddWithValue("@Gender", cmbgender.Text);
                    cmd.Parameters.AddWithValue("@Spec", txtspecial.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor record updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
            private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (txtdocid.Text == "")
            {
                MessageBox.Show("Please select a Doctor ID to delete.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM DoctorTbl WHERE DoctorId = @DoctorId", con);
                    cmd.Parameters.AddWithValue("@DoctorId", txtdocid.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Doctor record deleted successfully.");
                        Clearbtn_Click(sender, e); // Reuse Clear code to clear fields
                    }
                    else
                    {
                        MessageBox.Show("No record found with this Doctor ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        

       
            private void Clearbtn_Click(object sender, EventArgs e)
        {
            txtdocid.Text = "";
            txtdocname.Text = "";
            txtdocphone.Text = "";
            txtdocemail.Text = "";
            dtpdocdob.Value = DateTime.Now;
            cmbgender.SelectedIndex = -1;
            txtspecial.Text = "";
            txtaddress.Text = "";
        }

        private void txtdocemail_TextChanged(object sender, EventArgs e)
        {
            string email = txtdocemail.Text;

            // Basic email pattern like kerol@gmail.com
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (Regex.IsMatch(email, pattern))
            {
                txtdocemail.BackColor = System.Drawing.Color.LightGreen; // valid
                errorProvider1.SetError(txtdocemail, "");
            }
            else
            {
                txtdocemail.BackColor = System.Drawing.Color.LightPink; // invalid
                errorProvider1.SetError(txtdocemail, "Please enter a valid email like kerol@gmail.com");
            }
        }

        private void txtdocphone_TextChanged(object sender, EventArgs e)
        {
            string phone = txtdocphone.Text;

            // UK phone number 
            string pattern = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";

            if (Regex.IsMatch(phone, pattern))
            {
                txtdocphone.BackColor = System.Drawing.Color.LightGreen; // valid
            }
            else
            {
                txtdocphone.BackColor = System.Drawing.Color.LightPink; // invalid
            }
        }
    }
    }





