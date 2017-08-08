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
    public partial class v_dataurusan : DockContent
    {
        DBConnect db = new DBConnect();
        string _selectedidurusan = "";
        public v_dataurusan()
        {
            InitializeComponent();
        }

        private void v_dataurusan_Load(object sender, EventArgs e)
        {
            loadtreeview();
        }

        public void loadtreeview()
        {
            treeView1.Nodes.Clear();
            DataTable _acountsTb = new DataTable();
            _acountsTb = db.Data_T_urusan();
            //MessageBox.Show(_acountsTb.Rows.Count.ToString());
            PopulateTreeView("", null, _acountsTb);
        }

        private void PopulateTreeView(string parentId, TreeNode parentNode, DataTable _acountsTb)
        {

            TreeNode childNode;
            foreach (DataRow dr in _acountsTb.Select("[id_parent]='" + parentId + "'"))
            {
                TreeNode t = new TreeNode();
                t.Text = dr["id_urusan"].ToString() + " - " + dr["urusan"].ToString();
                t.Name = dr["id_urusan"].ToString();
                t.Tag = _acountsTb.Rows.IndexOf(dr);
                if (parentNode == null)
                {
                    treeView1.Nodes.Add(t);
                    childNode = t;
                }
                else
                {
                    parentNode.Nodes.Add(t);
                    childNode = t;
                }
                PopulateTreeView(dr["id_urusan"].ToString(), childNode, _acountsTb);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string parent = "";
            string no_rekening = "";
            string rekening = "";
            if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
            {
                string[] aa = e.Node.Parent.Text.ToString().Split('-');
                parent = aa[0].Trim();
            }
            else
            {
                //"No parent node.";
            }

            string[] bb = e.Node.Text.ToString().Split('-');
            no_rekening = bb[0].Trim();
            rekening = bb[1].Trim();

            tb_induk.Text = parent;
            tb_idurusan.Text = no_rekening;
            tb_urusan.Text = rekening;
            _selectedidurusan = no_rekening;
        }

        private void btn_tambah_Click(object sender, EventArgs e)
        {
            T_urusan tr = new T_urusan();
            tr.id_urusan = tb_idurusan.Text.ToString();
            tr.id_parent = tb_induk.Text.ToString();
            tr.urusan = tb_urusan.Text.ToString();
            tr.status = "1";
            if (db.addT_urusan(tr))
            {
                MessageBox.Show("Tambah Urusan sukses");
                loadtreeview();
            }
            else
            {
                MessageBox.Show("Tambah Urusan gagal");
            }
        }

        private void btn_ubah_Click(object sender, EventArgs e)
        {
            string id_urusan = "";
            id_urusan = _selectedidurusan;

            T_urusan tr = new T_urusan();
            tr.id_urusan = tb_idurusan.Text.ToString();
            tr.id_parent = tb_induk.Text.ToString();
            tr.urusan = tb_urusan.Text.ToString();
            tr.status = "1";
            if (db.ubahT_urusan(id_urusan, tr))
            {
                MessageBox.Show("Ubah Urusan sukses");
                loadtreeview();
            }
            else
            {
                MessageBox.Show("Ubah Urusan gagal");
            }
        }

        private void btn_hapus_Click(object sender, EventArgs e)
        {
            T_urusan tr = new T_urusan();
            tr.id_urusan = tb_idurusan.Text.ToString();
            tr.id_parent = tb_induk.Text.ToString();
            tr.urusan = tb_urusan.Text.ToString();
            tr.status = "1";
            if (db.HapusT_urusan(tr))
            {
                MessageBox.Show("Hapus Urusan sukses");
                loadtreeview();
            }
            else
            {
                MessageBox.Show("Hapus Urusan gagal");
            }
        }
    }
}
