
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinORM
{
    class Helper
    {
        public static string GetClrType(SqlDbType sqlType)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return "long";

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return "byte[]";

                case SqlDbType.Bit:
                    return "bool";

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                    return "string";

                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Date:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                    return "DateTime";

                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return "decimal";

                case SqlDbType.Float:
                    return "double";

                case SqlDbType.Int:
                    return "int";

                case SqlDbType.Real:
                    return "float";

                case SqlDbType.UniqueIdentifier:
                    return "Guid";

                case SqlDbType.SmallInt:
                    return "short";

                case SqlDbType.TinyInt:
                    return "byte";

                case SqlDbType.Variant:
                    return "object";

                case SqlDbType.DateTimeOffset:
                    return "DateTimeOffset";

                default:
                    throw new ArgumentOutOfRangeException("sqlType");
            }
        }
     
    }
}