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
   
    public partial class Form3 : Form
    {
        string conn = "Data Source=LAPTOP-2TMGFEGH;Initial Catalog=Perpustakaan;Integrated Security=true;";
        public Form3()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd/dd/MM/yyyy | hh:mm");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nis = textBox1.Text;
            string namalengkap = textBox2.Text;
            string jk = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                jk = radioButton1.Text;
            else
                jk = radioButton2.Text;

            SqlConnection openCon = new SqlConnection(conn);
            openCon.Open();
            string pengunjung = "INSERT INTO pengunjung (nis, nama_lengkap, jenis_kelamin) VALUES ('" + nis + "','" + namalengkap + "','" + jk + "')";

            SqlCommand querySaveStaff = new SqlCommand(pengunjung, openCon);

            try
            {
                querySaveStaff.ExecuteNonQuery();
                MessageBox.Show("Anda Berhasil Memasukkan Data");
            }
            catch (Exception ex)
            {
                //Error when save data

                MessageBox.Show("Error to save on database" + ex.Message);

                Cursor = Cursors.Arrow;
            }
            openCon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}

