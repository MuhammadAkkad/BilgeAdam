using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Core
{
   public abstract class Agency
    {
        public string name { get; set; }

        public string link { get; set; }

        public abstract List<NewsItem> getNews();
    }
}
