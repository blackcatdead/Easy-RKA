using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Easy_RKA
{
    public partial class f_loginsetting : Form
    {
        public f_loginsetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.host=this.tb_host.Text;
            Properties.Settings.Default.user=this.tb_user.Text;
            Properties.Settings.Default.password = this.tb_password.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void f_loginsetting_Load(object sender, EventArgs e)
        {
            this.tb_host.Text = Properties.Settings.Default.host;
            this.tb_user.Text = Properties.Settings.Default.user;
            this.tb_password.Text = Properties.Settings.Default.password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string host = this.tb_host.Text;
            string user = this.tb_user.Text;
            string pass = this.tb_password.Text;
            DBConnect db = new DBConnect(host, user, pass);
            db.TestConnection();
        }
    }
}
