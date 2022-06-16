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

namespace Data_Rt_06
{
    public partial class datawarga : Form
    {
        public datawarga()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8VLH0CG;Initial Catalog=DB_Rt06;User ID=sa;Password=1234");
        private void button1_Click(object sender, EventArgs e)
        {
            int wargaid = int.Parse(textBox1.Text);
            string nama = textBox2.Text, asal = comboBox1.Text, nohp = textBox3.Text, kelamin = "";
            double umur = double.Parse(textBox3.Text);
            DateTime migrasi = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { kelamin = "Male"; } else { kelamin = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec InsertWar_SP '" + wargaid + "','" + nama + "','" + asal + "','" + umur + "','" + kelamin + "','" + migrasi + "','" + nohp + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Berhasil Ditambahkan....");
            GetWarList(); 
        }
        void GetWarList()
        {
            SqlCommand c = new SqlCommand("exec ListWar_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Update
            int wargaid = int.Parse(textBox1.Text);
            string nama = textBox2.Text, asal = comboBox1.Text, nohp = textBox3.Text, kelamin = "";
            double umur = double.Parse(textBox3.Text);
            DateTime migrasi = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { kelamin = "Male"; } else { kelamin = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec UpdateWar_SP '" + wargaid + "','" + nama + "','" + asal + "','" + umur + "','" + kelamin + "','" + migrasi + "','" + nohp + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Berhasil Diedit....");
            GetWarList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetWarList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete
            if(MessageBox.Show("Serius nih mau di delete?","Menghapus", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                int wargaid = int.Parse(textBox1.Text);
                con.Open();
                SqlCommand c = new SqlCommand("exec DeleteWar_SP '" + wargaid + "'", con);
                c.ExecuteNonQuery();
                MessageBox.Show("Berhasil Dihapus....");
                GetWarList();


            }
           
        }
    }
}
