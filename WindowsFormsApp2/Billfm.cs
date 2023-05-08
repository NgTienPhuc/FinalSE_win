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

namespace WindowsFormsApp2
{
    public partial class Billfm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Shop1;Integrated Security=True");

        private void populate()
        {
            Con.Open();
            String query = "select * from Bill";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        public Billfm()
        {
            InitializeComponent();
        }

        private void Billfm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Home ag = new Home();
            ag.Show();
            this.Hide();
        }

        private void BillDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= BillDGV.RowCount)
                return;
            try
            {
                DataGridViewRow row = BillDGV.Rows[index];
                String BillID = Convert.ToString(row.Cells[0].Value);
                String AgentID = Convert.ToString(row.Cells[1].Value);
                String Price = Convert.ToString(row.Cells[2].Value);

                txtBillID.Text = BillID;
                txtAgentID.Text = AgentID;
                txtPrice.Text = Price;

            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(2); // generates a random number between 0 and 1

            if (randomNumber == 0)
            {
                e.Graphics.DrawString("SHOP", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(380));
                e.Graphics.DrawString("Bill ID: " + txtBillID.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(200, 100));
                e.Graphics.DrawString("Agent ID: " + txtAgentID.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(200, 120));
                e.Graphics.DrawString("Price: " + txtPrice.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(200, 140));
                e.Graphics.DrawString("Shipping status: Delivering", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(200, 160));
            }
            else
            {

                e.Graphics.DrawString("SHOP", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(380));
                e.Graphics.DrawString("Bill ID: " + txtBillID.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(200, 100));
                e.Graphics.DrawString("Agent ID: " + txtAgentID.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(200, 120));
                e.Graphics.DrawString("Price: " + txtPrice.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(200, 140));
                e.Graphics.DrawString("Shipping status: Arrived", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(200, 160));
            }
        }
    }
}
