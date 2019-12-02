using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinORM
{
    public partial class InstertForm : Form
    {
        public InstertForm()
        {
            InitializeComponent();
        }
        Table tblInsert;
        public InstertForm(Table table)
        {
            tblInsert = table;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InstertForm_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {




            //SqlConnection con = DBConnect.myCon;
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "Execute Add @name,@pwd,@type";

            //cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = textBox1.Text.ToString();
            //cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 50).Value = textBox2.Text.ToString();


            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();


        }
    }
}
