using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class Form10 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public Form10()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            displaydgv();
        }
        void displaydgv()
        {
            try
            {

                SqlConnection connect = new SqlConnection(conn);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select idpengembali as 'ID Pengembalian', idtransaksipinjam as 'ID Peminjaman', tgl_kembali as 'Tanggal Pengembalian' FROM pengembali", connect);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                grid1.DataSource = dt;
                connect.Close();

                /*SqlDataAdapter reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                }*/
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //untuk report data grid view
            Class1 exportpdf = new Class1();
            Class1.export(grid1);
        }
    }
}
