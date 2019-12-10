using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace imdb
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Year { get; set; }
        public string Link { get; set; }
        public byte[] Photo { get; set; }
        public decimal Rank { get; set; }
        public ICollection<MovieCast> movieCasts { get; set; }

    }
}
