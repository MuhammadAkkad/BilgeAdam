using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Core
{
    public abstract class Agency
    {
        public string Name { get; set; }
        
        public string Link { get; set; }



       public abstract List<NewsItem> GetNews();
    }
}
