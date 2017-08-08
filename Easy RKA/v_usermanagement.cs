using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Easy_RKA
{
    public partial class v_usermanagement : DockContent
    {
        DBConnect db = new DBConnect();
        public v_usermanagement()
        {
            InitializeComponent();
        }

        private void v_usermanagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'easyrkaDataSet1.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.easyrkaDataSet1.user);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User usr = new User();
            usr.username = tb_username.Text;
            usr.password = tb_password.Text;
            usr.name = tb_name.Text;
            usr.role = (cb_role.SelectedIndex == 0) ? "1" : "2";
            usr.user_status = (cb_status.SelectedIndex == 0) ? "1" : "0";
            db.addUser(usr);

            this.userTableAdapter.Fill(this.easyrkaDataSet1.user);
            dataGridView1.Refresh();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            tb_id_user.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tb_username.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tb_password.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tb_name.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            int selected_role = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "1") ? 0 : 1;
            int selected_status = (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() == "1") ? 0 : 1;

            cb_role.SelectedIndex = selected_role;
            cb_status.SelectedIndex = selected_status;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show("Apakah anda ingin menghapus user?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {
                db.HapusUser(tb_id_user.Text);
                this.userTableAdapter.Fill(this.easyrkaDataSet1.user);
                dataGridView1.Refresh();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            User usr = new User();
            usr.username = tb_username.Text;
            usr.password = tb_password.Text;
            usr.name = tb_name.Text;
            usr.role = (cb_role.SelectedIndex == 0) ? "1" : "2";
            usr.user_status = (cb_status.SelectedIndex == 0) ? "1" : "0";

            db.UbahUser(tb_id_user.Text, usr);
            this.userTableAdapter.Fill(this.easyrkaDataSet1.user);
            dataGridView1.Refresh();
        }


    }
}
