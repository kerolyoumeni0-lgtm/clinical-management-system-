using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class menuform : Form
    {
        public menuform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Patientbtn_Click(object sender, EventArgs e)
        {
            patient patientform = new patient();
            patientform.Show();
            this.Hide();
        }

        private void Docbtn_Click(object sender, EventArgs e)
        {
            
            doctor doctorform = new doctor();
            doctorform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            home homeform = new home();
            homeform.Show();
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void Prescriptionbtn_Click(object sender, EventArgs e)
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

        private void button2_Click_2(object sender, EventArgs e)
        {
            LOGIN loginForm = new LOGIN();
            loginForm.Show();
            this.Hide();
        }
    }
}
