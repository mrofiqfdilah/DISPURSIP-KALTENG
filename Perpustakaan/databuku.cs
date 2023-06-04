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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Perpustakaan
{
    public partial class databuku : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public databuku()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Judul Buku");
            }
            else if (textBaox2.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Kategori Buku");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Penerbit Buku");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Tahun Terbit Buku");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Total Stok Buku");
            }
            else
            {
                MessageBox.Show("Buku Telah Berhasil Di Tambahkan");

                string judulbuku = textBox1.Text;
                string kategori = textBaox2.Text;
                string penerbit = textBox4.Text;
                string tahunterbit = textBox5.Text;
                string totalstokbuku = textBox6.Text;



                SqlConnection openCon = new SqlConnection(conn);
                openCon.Open();
                string buku = "INSERT INTO buku (judul_buku, kategori_buku, penerbit_buku, tahun_terbit, totalstokbuku) VALUES ('" + judulbuku + "', '" + kategori + "', '" + penerbit + "','" + tahunterbit + "','" + totalstokbuku + "')";

                SqlCommand querySaveStaff = new SqlCommand(buku, openCon);

                try
                {
                    querySaveStaff.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //Error when save data

                    MessageBox.Show("Error to save on database" + ex.Message);
                    openCon.Close();
                    Cursor = Cursors.Arrow;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void databuku_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 form9= new Form9();
            form9.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
