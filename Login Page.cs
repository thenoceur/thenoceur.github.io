using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Wikitechy;

namespace PassportApplicationStatus
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=MSI ; Integrated Security=true ; Initial Catalog = PassportApplicationStatus");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select count(1) from[dbo].[loginTable] where[username] = '" + txt_admin_username.Text + "' and[pwd] = '" + txt_admin_pwd.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            int val = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            MessageBox.Show(val.ToString());
            if (val > 0)
            {
                MessageBox.Show("Valid Login");
                OptionPage optpage = new OptionPage();
                optpage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
            
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select id from [dbo].[passport_logindetails] where username='" + txt_username.Text + "'and pwd='" + txt_pwd.Text + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            int val = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            Wikitechy.UserDetails.Username = val.ToString();
            if (val > 0)
            {
                MessageBox.Show("Valid Passport User Login");

                ViewStatusPage vsp = new ViewStatusPage();
                vsp.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
            conn.Close();
        }

        private void txt_admin_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewLoginPage newlogin = new NewLoginPage();
            newlogin.Show();
            this.Hide();
        }
    }
}
