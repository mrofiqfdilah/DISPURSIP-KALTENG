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

namespace Perpustakaan
{
    public partial class Form7 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public Form7()
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

        void displaydgv()
        {
            try
            {
                databuku.DataSource = null;
                SqlConnection connect = new SqlConnection(conn);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select idpeminjam as ID, judul_buku as Judul, nama_lengkap as 'Nama lengkap', no_telepon as 'Nomor Telepon', nis as NIS FROM peminjamm", connect);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                databuku.DataSource = dt;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            displaydgv();
        }

        private void databuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = databuku.Rows[e.RowIndex];
                label4.Text = row.Cells[0].Value.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM peminjamm WHERE idpeminjam=" + label4.Text;
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data berhasil dihapus");
            displaydgv();
        }
        private void send_data()
        {
            string ids = label4.Text;
            int id = Int32.Parse(ids);
            SqlConnection connect = new SqlConnection(conn);
            connect.Open();
            SqlCommand cmd = new SqlCommand("Select idpeminjam, judul_buku as Judul, no_telepon as Nomor Telepon, nis as NIS FROM peminjamm where idpeminjam='" + id + "'", connect);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            connect.Close();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            id = label4.Text;
            editanggota editanggota = new editanggota();
            send_data();
            editanggota.Show();
            this.Hide();
            
        }

        public static string id;

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
            Class1.export(databuku);
        }
    }
}

