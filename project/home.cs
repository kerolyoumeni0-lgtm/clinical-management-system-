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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Nxtbtn_Click(object sender, EventArgs e)
        {
            LOGIN loginform = new LOGIN();
            loginform.Show();
            this.Hide();
        }

        private void home_Load(object sender, EventArgs e)
        {
            
        }
    }
}
