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
    public partial class ViewStatusPage : Form
    {
        public ViewStatusPage()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI ; Integrated Security=true ; Initial Catalog = PassportApplicationStatus");

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPage loginpg = new LoginPage();
            loginpg.Show();
            this.Hide();
        }

        private void ViewStatusPage_Load(object sender, EventArgs e)
        {
            conn.Open();
            int id = Convert.ToInt32(Wikitechy.UserDetails.Username);
            MessageBox.Show(id.ToString());
            string query= "select * from passport_details a inner join passport_logindetails b on a.id=b.id where a.id= " + id.ToString(); 
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
           
            conn.Close();
        }
    }
}
