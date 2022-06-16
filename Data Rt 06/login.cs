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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8VLH0CG;Initial Catalog=DB_Rt06;User ID=sa;Password=1234");

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text, password = textBox2.Text;
            con.Open();
            SqlCommand c = new SqlCommand("exec Insertlog '" + username + "','" + password + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Berhasil Masuk");

            datawarga dw = new datawarga();
            dw.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
