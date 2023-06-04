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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Perpustakaan
{
    public partial class Form5 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";

        public Form5()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            try
            {

                SqlConnection connect = new SqlConnection(conn);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select judul_buku as Judul, kategori_buku as Kategori, penerbit_buku as Penerbit, totalstokbuku as Jumlah, tahun_terbit as 'Tahun Terbit' FROM buku", connect);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                label7.Text = row.Cells[0].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan NIS");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Nama Lengkap");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Nomor Telepon");
            }
            else
            {
                MessageBox.Show("Berhasil Meminjam Buku");

                string nis = textBox1.Text;
                string namalengkap = textBox2.Text;
                string no_telepon = textBox3.Text;
                string judulbuku = label7.Text;
                string tgl_pinjam = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string tgl_kembali = dateTimePicker2.Value.ToString("yyyy-MM-dd");




                SqlConnection openCon = new SqlConnection(conn);
                openCon.Open();
                string peminjamm = "INSERT INTO peminjamm (nis, nama_lengkap, no_telepon, judul_buku, tgl_pinjam, tgl_kembali) VALUES ('" + nis + "', '" + namalengkap + "', '" + no_telepon + "','" + judulbuku + "', '" + tgl_pinjam +"', '" + tgl_kembali + "')";

                SqlCommand querySaveStaff = new SqlCommand(peminjamm, openCon);

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

        private void button4_Click(object sender, EventArgs e)
        {
            //untuk report data grid view
            Class1 exportpdf = new Class1();
            Class1.export(dataGridView1);
        }
    }
}
