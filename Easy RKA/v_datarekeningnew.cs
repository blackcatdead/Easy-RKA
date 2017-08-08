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
    public partial class v_datarekeningnew : DockContent
    {
        DBConnect db = new DBConnect();
        string _selectedidrekening = "";
        public v_datarekeningnew()
        {
            InitializeComponent();
        }

        private void v_datarekeningnew_Load(object sender, EventArgs e)
        {
            loadtreeview();
        }

        public void loadtreeview() 
        {
            treeView1.Nodes.Clear();
            DataTable _acountsTb = new DataTable();
            _acountsTb = db.Data_T_rekening();
           // MessageBox.Show(_acountsTb.Rows.Count.ToString());
            PopulateTreeView("", null, _acountsTb);
        }

        private void PopulateTreeView(string parentId, TreeNode parentNode, DataTable _acountsTb)
        {

            TreeNode childNode;
            foreach (DataRow dr in _acountsTb.Select("[id_parent]='" + parentId+"'"))
            {
                TreeNode t = new TreeNode();
                t.Text = dr["id_rekening"].ToString() + " - " + dr["rekening"].ToString();
                t.Name = dr["id_rekening"].ToString();
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
                PopulateTreeView(dr["id_rekening"].ToString(), childNode, _acountsTb);
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
            tb_idrekening.Text = no_rekening;
            tb_rekening.Text = rekening;
            _selectedidrekening = no_rekening;
        }

        private void btn_tambah_Click(object sender, EventArgs e)
        {
            T_rekening tr = new T_rekening();
            tr.id_rekening = tb_idrekening.Text.ToString();
            tr.id_parent = tb_induk.Text.ToString();
            tr.rekening = tb_rekening.Text.ToString();
            tr.status = "1";
            if (db.addT_rekening(tr))
            {
                MessageBox.Show("Tambah Rekening sukses");
                loadtreeview();
            }
            else
            {
                MessageBox.Show("Tambah Rekening gagal");
            }
        }

        private void btn_hapus_Click(object sender, EventArgs e)
        {
            T_rekening tr = new T_rekening();
            tr.id_rekening = tb_idrekening.Text.ToString();
            tr.id_parent = tb_induk.Text.ToString();
            tr.rekening = tb_rekening.Text.ToString();
            tr.status = "1";
            if (db.HapusT_rekening(tr))
            {
                MessageBox.Show("Hapus Rekening sukses");
                loadtreeview();
            }
            else 
            {
                MessageBox.Show("Hapus Rekening gagal");
            }
        }

        private void btn_ubah_Click(object sender, EventArgs e)
        {
            string id_rekening = "";
            id_rekening = _selectedidrekening;

            T_rekening tr = new T_rekening();
            tr.id_rekening = tb_idrekening.Text.ToString();
            tr.id_parent = tb_induk.Text.ToString();
            tr.rekening = tb_rekening.Text.ToString();
            tr.status = "1";
            if (db.ubahT_rekening(id_rekening, tr))
            {
                MessageBox.Show("Ubah Rekening sukses");
                loadtreeview();
            }
            else 
            {
                MessageBox.Show("Ubah Rekening gagal");
            }
        }


    }
}
