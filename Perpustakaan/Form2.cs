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
    public partial class Form2 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";

        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        void displaydgv()
        {
            try
            {
                databuku.DataSource= null;
                SqlConnection connect = new SqlConnection(conn);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select idbuku, judul_buku as Judul, kategori_buku as Kategori, penerbit_buku as Penerbit, totalstokbuku as Jumlah, tahun_terbit as Tahun FROM buku", connect);
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
        private void Form2_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            displaydgv();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e, Form form)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
             databuku formdatabuku = new databuku();
            formdatabuku.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row= databuku.Rows[e.RowIndex];
                label2.Text = row.Cells[0].Value.ToString();
            }
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

        private void send_data()
        {
            string ids = label2.Text;
            int id = Int32.Parse(ids);
            SqlConnection connect = new SqlConnection(conn);
            connect.Open();
            SqlCommand cmd = new SqlCommand("Select idbuku, judul_buku as Judul, kategori_buku as Kategori, penerbit_buku as Penerbit, totalstokbuku as Jumlah, tahun_terbit as Tahun FROM buku where id='"+id+"'", connect);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            connect.Close();
        }

        public static string id;
        private void button11_Click(object sender, EventArgs e)
        {
            id = label2.Text;
            Form11 form11 = new Form11();

            form11.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM buku WHERE idbuku="+label2.Text;
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data berhasil dihapus");
            displaydgv();

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            Class1.export(databuku);
        }
    }
}
