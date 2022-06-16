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

namespace Db_Rt
{
    public partial class utama : Form
    {
        public utama()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8VLH0CG;Initial Catalog=DB_Rt06;User ID=sa;Password=1234");

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text, password = textBox2.Text;
            con.Open();
            SqlCommand c = new SqlCommand("exec Insertlog '" + username + "','" + password + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Berhasil Masuk");

            
            ww.Show();
            this.Hide();
        }
    }
}
