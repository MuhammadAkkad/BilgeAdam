using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Core
{
     public class NewsItem
    {
        public string guid  { get; set; }

        public string link { get; set; }

        public string title { get; set; }

        public string description { get; set; }
    }
}
