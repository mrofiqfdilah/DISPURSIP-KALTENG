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
    public partial class editanggota : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public editanggota()
        {
            InitializeComponent();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string query = "UPDATE peminjamm SET judul_buku = '" + textBox1.Text + "', nama_lengkap = '" + textBox4.Text + "', no_telepon = '" + textBox5.Text + "', nis = '" + textBox6.Text + "' WHERE idpeminjam = '" + id_txt.Text + "'";
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            command.ExecuteNonQuery();
            connection.Close();
            textBox1.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;

            MessageBox.Show("Data berhasil diperbarui");
        }

        private void editanggota_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            view();
            }
            private void view()
            {
                int id = int.Parse(Form7.id.ToString());
                SqlConnection connect = new SqlConnection(conn);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select idpeminjam as ID, judul_buku as Judul, nama_lengkap as 'Nama lengkap', no_telepon as 'Nomor Telpon', nis as NIS FROM peminjamm where idpeminjam='" + id + "'", connect);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                connect.Close();

                id_txt.Text = id.ToString();
                textBox1.Text = dt.Rows[0][1].ToString();
                textBox4.Text = dt.Rows[0][2].ToString();
                textBox5.Text = dt.Rows[0][3].ToString();
                textBox6.Text = dt.Rows[0][4].ToString();
            }

        private void button12_Click(object sender, EventArgs e)
        {
            Form7 anggota = new Form7();
            anggota.Show();
            this.Hide();
        }
    }
    

       

      
    }

