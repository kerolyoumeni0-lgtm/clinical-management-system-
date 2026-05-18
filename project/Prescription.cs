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
using System.Xml.Linq;

namespace project
{
    public partial class Prescription : Form
    {
        public Prescription()
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

        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN loginForm = new LOGIN();
            loginForm.Show();
            this.Hide();
        }

        private void Addbtn_Click(object sender, EventArgs e)

        {
            if (txtpresid.Text == "" || txtdocid.Text == "" || txtpatname.Text == "" || txtpatid.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO PrescriptionTbl (PresId, DoctorId, DocName, PatId, PatName, PresCost, PrescriptionDetails) VALUES (@PresId, @DoctorId, @DocName, @PatId, @PatName, @PresCost, @Details)", con);

                    cmd.Parameters.AddWithValue("@PresId", txtpresid.Text);
                    cmd.Parameters.AddWithValue("@DoctorId", txtdocid.Text);
                    cmd.Parameters.AddWithValue("@DocName", txtdocname.Text);
                    cmd.Parameters.AddWithValue("@PatId", txtpatid.Text);
                    cmd.Parameters.AddWithValue("@PatName", txtpatname.Text);
                    cmd.Parameters.AddWithValue("@PresCost", txtcost.Text);
                    cmd.Parameters.AddWithValue("@Details", rtxtprescription.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Prescription added successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string GenerateNewPrescriptionID()
        {
            string prefix = "PRS";
            int maxID = 0;

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(PresId, 4, LEN(PresId)-3) AS int)) FROM PrescriptionTbl", con);
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }

            return prefix + (maxID + 1).ToString("D2");
        }

        private void Prescription_Load(object sender, EventArgs e)
        {
            txtpresid.Text = GenerateNewPrescriptionID();
            LoadDoctorIDs();
            LoadPatientIDs();
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
                txtdocid.DisplayMember = "DoctorId";
                txtdocid.ValueMember = "DoctorId";
            }
        }

        private void LoadPatientIDs()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PatId FROM PatientTbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtpatid.DataSource = dt;
                txtpatid.DisplayMember = "PatId";
                txtpatid.ValueMember = "PatId";
            }
        }
        
        
        private void txtpatid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (txtpresid.Text == "")
            {
                MessageBox.Show("Please enter or select a Prescription ID to update.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE PrescriptionTbl SET DoctorId=@DoctorId, DocName=@DocName, PatId=@PatId, PatName=@PatName, PresCost=@Cost, PrescriptionDetails=@Details WHERE PresId=@PresId", con);

                    cmd.Parameters.AddWithValue("@PresId", txtpresid.Text);
                    cmd.Parameters.AddWithValue("@DoctorId", txtdocid.Text);
                    cmd.Parameters.AddWithValue("@DocName", txtdocname.Text);
                    cmd.Parameters.AddWithValue("@PatId", txtpatid.Text);
                    cmd.Parameters.AddWithValue("@PatName", txtpatname.Text);
                    cmd.Parameters.AddWithValue("@Cost", txtcost.Text);
                    cmd.Parameters.AddWithValue("@Details", rtxtprescription.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Prescription updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Clearbtn_Click_1(object sender, EventArgs e)
        {
            txtdocid.SelectedIndex = -1;
            txtdocname.Text = "";
            txtpatid.SelectedIndex = -1;
            txtpatname.Text = "";
            txtcost.Text = "";
            rtxtprescription.Clear();
        }

        private void Delebtn_Click(object sender, EventArgs e)
        {
            if (txtpresid.Text == "")
            {
                MessageBox.Show("Please enter or select a Prescription ID to delete.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UTILISATEUR\source\repos\project\project\Database1.mdf;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM PrescriptionTbl WHERE PresId = @PresId", con);
                    cmd.Parameters.AddWithValue("@PresId", txtpresid.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Prescription deleted successfully.");
                        Clearbtn_Click_1(sender, e);
                    }
                   
                    {
                        MessageBox.Show("No record found with this Prescription ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
