using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinORM
{
    static class DBConnect
    {
        public static SqlConnection myCon = null;

        static public void CreateConnection()
        {
            myCon = new SqlConnection("");
            myCon.Open();
        }
    }
}
