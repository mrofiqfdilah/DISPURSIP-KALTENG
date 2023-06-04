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
    public partial class Form11 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public Form11()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "UPDATE buku SET judul_buku = '" + textBox1.Text + "', kategori_buku = '" + textBaox2.Text + "', penerbit_buku = '" + textBox4.Text + "', totalstokbuku = '" + textBox5.Text + "', tahun_terbit = '" + textBox6.Text + "' WHERE idbuku = "+ id_txt.Text;
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            textBox1.Text = string.Empty;
            textBaox2.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;

            MessageBox.Show("Data berhasil diperbarui");
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            view();
        }
        private void view()
        {
            int id = int.Parse(Form2.id.ToString());
            SqlConnection connect = new SqlConnection(conn);
            connect.Open();
            SqlCommand cmd = new SqlCommand("Select judul_buku as Judul, kategori_buku as Kategori, penerbit_buku as Penerbit, totalstokbuku as Jumlah, tahun_terbit as 'Tahun Terbit' FROM buku where idbuku='" + id + "'", connect);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();

            sda.Fill(dt);

            connect.Close();

            id_txt.Text = id.ToString();
            textBox1.Text = dt.Rows[0][0].ToString();
            textBaox2.Text = dt.Rows[0][1].ToString();
            textBox4.Text = dt.Rows[0][2].ToString();
            textBox5.Text = dt.Rows[0][3].ToString();
            textBox6.Text = dt.Rows[0][4].ToString();
        }

        private void id_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }
    }

    
            }
        
      
