using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CANCEL_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            String user, pass;
            user = txtUsername.Text;
            pass = txtPassword.Text;
            if (user == "admin" && pass == "123")
            {
                Home ag = new Home();
                ag.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
