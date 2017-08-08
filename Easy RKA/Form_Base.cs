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
    public partial class f_base : Form
    {
        public f_base()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void f_base_Load(object sender, EventArgs e)
        {
            toolStrip_nama_username.Text = Properties.Settings.Default.login_name + " (" + Properties.Settings.Default.login_username + ")";
            toolStrip_role.Text = Properties.Settings.Default.login_role;


        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            v_usermanagement f = new v_usermanagement();
            f.Show(dockPanel1);
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            v_dataurusan f = new v_dataurusan();
            f.Show(dockPanel1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            v_datarekeningnew f = new v_datarekeningnew();
            f.Show(dockPanel1);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
