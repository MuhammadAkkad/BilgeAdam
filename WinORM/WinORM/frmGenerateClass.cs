using Microsoft.SqlServer.Management.Smo;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinORM
{
    public partial class FrmGenerateClass : Form
    {
        string ownerDB;
        public FrmGenerateClass()
        {
            InitializeComponent();
        }
        Table tbl;
        RichTextBox rbClass;
        public FrmGenerateClass(Table table, RichTextBox _rbClass)
        {
            rbClass = _rbClass;
            tbl = table;
            InitializeComponent();
        }

        private void frmGenerateClass_Load(object sender, EventArgs e)
        {
            txtClassName.Text = tbl.Name;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string propertyTemp = File.ReadAllText("C:\\Users\\BA\\source\\repos\\WinORM\\WinORM\\Property.txt");
            string result = File.ReadAllText("C:\\Users\\BA\\source\\repos\\WinORM\\WinORM\\ClassTamplate.txt");

            ownerDB = tbl.Owner + "." + tbl.Name;

            result = result.Replace("#Attribute#","[DbTable(Name = \""+ ownerDB + "\")]");

            result = result.Replace("#NameSpace#", txtNameSpace.Text.Trim());
            if (cbIsPublic.Checked)
            {
                result = result.Replace("#AccessModifier#", "public");
            }
            else
            {
                result = result.Replace("#AccessModifier#", "");
            }
            StringBuilder stringBuilder = new StringBuilder();
            string property = "";
            foreach (Column column in tbl.Columns)
            {
                string key = "";
                if (column.InPrimaryKey && column.IsForeignKey)
                {
                    key = "[Key(Type = KeyType.PrimaryKey)]" +"\n "+ "[Key(Type = KeyType.ForeignKey)]" + "\n ";
                }
                else if (column.IsForeignKey)
                {
                    key = "[Key(Type = KeyType.ForeignKey)]" + "\n ";
                }
                else if (column.InPrimaryKey)
                {
                    key = "[Key(Type = KeyType.PrimaryKey)]" + "\n ";
                }
                result = result.Replace("#ClassName#",tbl.Name);

                SqlDbType dbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), column.DataType.Name, true);
                property = propertyTemp.Replace("#Type#", Helper.GetClrType(dbType));
                property = property.Replace("#Name#", column.Name) + "\n";
                stringBuilder.Append(key);
                stringBuilder.Append(property);
            }
            result = result.Replace("#Property#", stringBuilder.ToString());


            using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter("C:\\Users\\BA\\source\\repos\\WinORM\\WinORM\\Entity\\" + txtClassName.Text + ".cs", true))
            { file.WriteLine(result); }

            
            rbClass.Text = result;

            FrmGenerateClass.ActiveForm.Close();
        }

        private void txtClassName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInstert_Click(object sender, EventArgs e)
        {
            InstertForm instertForm = new InstertForm(tbl);
            instertForm.Show();
        }
    }
}
