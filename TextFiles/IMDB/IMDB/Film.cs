using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    class Film
    {
        public string name { get; set; }
        public string year { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string rank { get; set; }
        public override string ToString()
        {
            return this.name + " "+ this.year;
        }

        public static List<Film> films { get; set; }
        public List<Director> directors { get; set; }
        public List<Writer> writers { get; set; }
        public List<Star> stars { get; set; }

    }
}
