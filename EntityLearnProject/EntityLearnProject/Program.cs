using System;
using System.Data.Entity.Core.EntityClient;
using System.Linq;

namespace EntityLearnProject
{
    class Program
    {
        static private void QueryContacts()
        {
            using (var context = new PEF())
            {
                //var contacts = from c in context.Contacts
                //               where c.FirstName == "Robert"
                //               select c;
                var contacts = context.Contacts
                .Where((c) => c.FirstName == "Robert")
                .OrderBy((foo) => foo.LastName);
                foreach (var contact in contacts)
                {
                    Console.WriteLine("{0}{1}{2}", contact.Title.Trim(), contact.FirstName.Trim(),
                        contact.LastName.Trim());
                }
            }
            Console.WriteLine("Please Enter ...");
            Console.ReadLine();
        }

        static void EntityClientQueryContacts()
        {
            using (EntityConnection conn = new
            EntityConnection("name=PEF"))
            {
                conn.Open();
                var queryString = "SELECT VALUE c " +
                "FROM PEF.Contacts AS c " +
                "WHERE c.FirstName='Robert'";
                EntityCommand cmd = conn.CreateCommand();
                cmd.CommandText = queryString;
                using (EntityDataReader rdr =
                cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess))
                {
                    while (rdr.Read())
                    {
                        var firstname = rdr.GetString(1);
                        var lastname = rdr.GetString(2);
                        var title = rdr.GetString(3);
                        Console.WriteLine("{0} {1} {2}",
                        title.Trim(), firstname.Trim(), lastname);
                    }
                }
                conn.Close();
                Console.Write("Press Enter...");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            //QueryContacts();
            EntityClientQueryContacts();
        }
    }
}
