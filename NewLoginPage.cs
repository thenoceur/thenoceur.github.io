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
    public partial class NewLoginPage : Form
    {
        public NewLoginPage()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=MSI ; Integrated Security=true ; Initial Catalog = PassportApplicationStatus");

        private void label1_Click(object sender, EventArgs e)
        {
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();

            string dob = Wikitechy.UserDetails.GetDate(dateTimePicker1.Value);

            SqlCommand cmd = new SqlCommand("insert into loginTable values('" + txt_Name.Text + "' , '" + txt_Username.Text + "' , '" + txt_pwd.Text + "' , '" + dob + "' , '" + cmb_SecurityQuestion.SelectedItem.ToString() + "' , '" + txt_SecAnswer.Text + "')",conn);
             int status = cmd.ExecuteNonQuery(); //this line will retuen whether the above code retuens success 1 or failuere 0  

            if (status > 0)
            { 
                    MessageBox.Show("User Added Successfully");
            }
            else
            {
                MessageBox.Show("Problem in Data Insertion");
            }
            conn.Close();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginpg = new LoginPage();
            loginpg.Show();
            this.Hide();

        }

        private void NewLoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
