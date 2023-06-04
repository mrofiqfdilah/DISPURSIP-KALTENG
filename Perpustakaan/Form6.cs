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
    public partial class Form6 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            displaydgv();
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

        private void button9_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }
        void displaydgv()
        {
            try
            {

                SqlConnection connect = new SqlConnection(conn);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select idpeminjam as ID, judul_buku as 'Judul Buku', nama_lengkap as 'Nama lengkap', no_telepon 'No Telpon', nis as NIS, tgl_pinjam as 'Tanggal Pinjam', tgl_kembali as 'Tanggal Kembali' FROM peminjamm", connect);
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

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                label2.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string idpinjam = label2.Text;
            DateTime tglkembali= DateTime.Today;
            SqlConnection openCon = new SqlConnection(conn);
            openCon.Open();
            string buku = "INSERT INTO pengembali (idtransaksipinjam, tgl_kembali) VALUES ('" + idpinjam + "', '" + tglkembali + "')";

            SqlCommand querySaveStaff = new SqlCommand(buku, openCon);

            try
            {
                querySaveStaff.ExecuteNonQuery();
                MessageBox.Show("Berhasil Dikembalikan");
            }
            catch (Exception ex)
            {
                //Error when save data

                MessageBox.Show("Error to save on database" + ex.Message);
                openCon.Close();
                Cursor = Cursors.Arrow;
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
            Class1.export(dataGridView1);
        }
    }
}
