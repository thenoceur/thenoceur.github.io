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
    public partial class ApplyPassport : Form
    {
        public ApplyPassport()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI ; Integrated Security=true ; Initial Catalog = PassportApplicationStatus");

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int passportRefNumber = r.Next(1, 2000);
            string ppstatus = "Pending";
            string dob = Wikitechy.UserDetails.GetDate(dateTimePicker1.Value);

            conn.Open();
            string query = "insert into passport_details(FirstName,Surname,Email,DOB,[Address],District,[State],Gender,photo,PassportRefNumber,PPStatus)values('" + txt_FirstName.Text + "' , '" + txt_surname.Text + "' , '" + txt_Email.Text + "', '" + dob + "', '" + txt_Address.Text + "' , '" + txt_District.Text + "' , '" + txt_State.Text + "' , '" + cmb_gender.Text + "' , '" + txt_PhotoName.Text + "' , '" + passportRefNumber.ToString() + "' , '" + ppstatus + "')";
            SqlCommand cmd= new SqlCommand(query, conn);
            int status = cmd.ExecuteNonQuery();

            if(status ==1)
            {
                MessageBox.Show("Passport Details Updated Succesfully!");
            
            }
            else
            {
                MessageBox.Show("Issue In Updating!");
            }
            // passport user login details

            SqlCommand cmd1 = new SqlCommand("select id from passport_details order by id desc", conn);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);

            int id =Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            MessageBox.Show("The Reference Number For Your Passport is : " + passportRefNumber.ToString());
            string query3 = "insert into passport_logindetails(Id,username,pwd,Security_Question,Security_Password) values(" + id.ToString() + ", '" + txt_UserName.Text + "' , '" + txt_Password.Text + "' , '" + cmb_secQuestion.SelectedItem.ToString() + "' , '" + txt_secAnswer.Text + "')";
            SqlCommand cmd2 = new SqlCommand(query3, conn);

            int val2 = cmd2.ExecuteNonQuery();

            if (val2 > 0)
            {
                MessageBox.Show("Passport User Login Details added successfully!");
            }
            else
            {
                MessageBox.Show("Data Insertion Failed!");
            }



            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *jpeg; *.gif; *.bmp";
                if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                //Display image in picture box
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                //Image file path
                txt_PhotoName.Text = openFileDialog1.FileName;
                Image img = pictureBox1.Image;
                img.Save(txt_FirstName.Text + "-" + txt_surname.Text + ".jpg");
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage loginpg = new LoginPage();
            loginpg.Show();
            this.Hide();
        }
    }
}
