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
    public partial class Form12 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            view();
        }
        private void view()
        {
            int id = int.Parse(Form8.id.ToString());
            id_txt.Text = id.ToString();

            SqlConnection connect = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("Select nis as NIS, nama_lengkap as 'Nama lengkap', jenis_kelamin as 'Jenis kelamin' FROM pengunjung where idpengunjung='" + id_txt.Text + "'", connect);
            connect.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            connect.Close();

            
            textBox1.Text = dt.Rows[0][0].ToString();
            textBaox2.Text = dt.Rows[0][1].ToString();
            textBox4.Text = dt.Rows[0][2].ToString();
        }

        private void id_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "UPDATE pengunjung SET nis = '" + textBox1.Text + "', nama_lengkap = '" + textBaox2.Text + "', jenis_kelamin = '" + textBox4.Text + "' WHERE idpengunjung = " + id_txt.Text;
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            textBox1.Text = string.Empty;
            textBaox2.Text = string.Empty;
            textBox4.Text = string.Empty;


            MessageBox.Show("Data berhasil diperbarui");
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }
    }
}
