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

    public partial class Form8 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public Form8()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
            displaydgv();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                label2.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM pengunjung WHERE idpengunjung =" + label2.Text;
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data berhasil dihapus");
            displaydgv();
        }
        public static int id;
        private void button9_Click(object sender, EventArgs e)
        {
            id = int.Parse(label2.Text);
            editanggota editanggota = new editanggota();

            editanggota.Show();
            this.Hide();
        }
        void displaydgv()
        {
            try
            {

                SqlConnection connect = new SqlConnection(conn);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select idpengunjung as id, nis as NIS, nama_lengkap as 'Nama lengkap', jenis_kelamin as 'Jenis Kelamin' FROM pengunjung", connect);
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
            Class1.export(dataGridView1);
        }
    }
}
