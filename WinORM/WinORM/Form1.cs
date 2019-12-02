using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinORM
{
    public partial class DbManager : Form
    {
        public DbManager()
        {
            InitializeComponent();
        }

        public DbManager(string str)
        {
            string classString = str;
            InitializeComponent();
        }
        private void connect_Click(object sender, EventArgs e)
        {
            Server server = new Server(txtServer.Text);
            foreach (Database database in server.Databases)
            {
                TreeNode node = new TreeNode(database.Name);
                node.Tag = database;
                node.ImageIndex = 0;
                trvServerItems.Nodes.Add(node);
            }
        }
        private void trvServerItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.ImageIndex)
            {
                case 0:
                    getDatabase();
                    break;
                case 1:
                    getTable();
                    break;
                default:
                    break;
            }
        }
        private void getDatabase()
        {
            Database database = (Database)trvServerItems.SelectedNode.Tag;

            TreeNode treeNodeTable = new TreeNode("Tables");
            trvServerItems.SelectedNode.Nodes.Add(treeNodeTable);
            foreach (Table table in database.Tables)
            {
                TreeNode node = new TreeNode(table.Name);
                node.Tag = table;
                node.ImageIndex = 1;
                node.ContextMenuStrip = contextMenuStrip1;
                treeNodeTable.Nodes.Add(node);
            }

            TreeNode treeNodeView = new TreeNode("Views");
            trvServerItems.SelectedNode.Nodes.Add(treeNodeView);
            foreach (Microsoft.SqlServer.Management.Smo.View view in database.Views)
            {
                TreeNode node = new TreeNode(view.Name);
                node.Tag = view;
                treeNodeView.Nodes.Add(node);
            }
        }
        private void getTable()
        {
            Table table = (Table)trvServerItems.SelectedNode.Tag;
            trvServerItems.SelectedNode.Nodes.Clear();
            trvServerItems.SelectedNode.ImageIndex = 2;
            foreach (Column clm in table.Columns)
            {
                string nullable = clm.Nullable ? "Null" : "Not Null";
                TreeNode node = new TreeNode(clm.Name + " (" + clm.DataType.Name
                    + " (" + clm.DataType.MaximumLength.ToString() + ")," + nullable + ")");
                node.ImageIndex = 3;
                if (clm.InPrimaryKey) node.ImageIndex = 4;
                trvServerItems.SelectedNode.Nodes.Add(node);
            }
        }
        private void DbManager_Load(object sender, EventArgs e)
        {
            //int asdf = Convert.ToInt32(KeyType.ForeignKey);
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void generateClassContextMenu_Click(object sender, EventArgs e)
        {
            Table tbl = (Table)trvServerItems.SelectedNode.Tag;
            FrmGenerateClass frmGenerateClass = new FrmGenerateClass(tbl, richTextBox1); ;
            frmGenerateClass.Show();
        }
    }
}
