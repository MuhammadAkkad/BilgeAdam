using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
 public class DirectorLink
    {
        DirectorLink() {
            
        }

        public static string getlink(string str, string from, string to) {
            string slimmedP;
            int fromIndex, toIndex;

            fromIndex = str.IndexOf("<h4 class=\"inline\">Directors:</h4>");
            slimmedP = str.Substring(fromIndex);
            fromIndex = slimmedP.IndexOf("<h4 class=\"inline\">Directors:</h4>") + "<h4 class=\"inline\">Directors:</h4>".Length;
            toIndex = slimmedP.IndexOf("credit_summary_item");
            str = slimmedP.Substring(fromIndex, toIndex);

            return str;
        }
    }
}
