using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Productfm : Form
    {
        public Productfm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Shop1;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {
            Home ag = new Home();
            ag.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Agentfm ag= new Agentfm();
            ag.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                Con.Open();
                String query = "insert into Product values('" + txtProductID.Text + "','" + txtProductName.Text + "'," + txtProductPrice.Text +  ")";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= ProductDGV.RowCount)
                return;
            try
            {
                DataGridViewRow row = ProductDGV.Rows[index];
                String ProductID = Convert.ToString(row.Cells[0].Value);
                String ProductName = Convert.ToString(row.Cells[1].Value);
                String ProductPrice = Convert.ToString(row.Cells[2].Value);

                txtProductID.Text = ProductID;
                txtProductName.Text = ProductName;
                txtProductPrice.Text = ProductPrice;

            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }
        private void populate()
        {
            Con.Open();
            String query = "select * from Product";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Productfm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtProductID.Text == "")
                {
                    MessageBox.Show("No Data to delete");
                }
                else
                {
                    Con.Open();
                    String query = "delete from Product where ProductID=" + txtProductID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");
                    Con.Close();
                    populate();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
