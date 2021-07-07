using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassportApplicationStatus
{
    public partial class OptionPage : Form
    {
        public OptionPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyPassport apply = new ApplyPassport();
            apply.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeStatusPage CSP = new ChangeStatusPage();
            CSP.Show();
            this.Hide();
        }
    }
}
