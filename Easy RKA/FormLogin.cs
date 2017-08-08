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
    public partial class f_login : Form
    {
        User user = new User();

        public f_login()
        {
            InitializeComponent();
        }

        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login(this, new EventArgs());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            toolstrip_status.Text = "Loging in...";
            DBConnect db = new DBConnect();

            user = db.Login(tb_username.Text, tb_password.Text);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (user != null)
            {
                Properties.Settings.Default.login_id_user = user.id_user;
                Properties.Settings.Default.login_username = user.username;
                Properties.Settings.Default.login_name = user.name;
                Properties.Settings.Default.login_role = user.role;

                f_base f = new f_base();
                this.Hide();
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
            else
            {
                MessageBox.Show("Username atau password salah.", "Login gagal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            toolstrip_status.Text = "Ready";
            panel1.Enabled = true;
        }

        private void btn_login(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btn_setting(object sender, EventArgs e)
        {
            f_loginsetting f = new f_loginsetting();
            f.ShowDialog();
        }
    }
}
