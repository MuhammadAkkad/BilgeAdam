using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb
{
    public class Cast
    {
        public int CastId { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCast> movieCasts { get; set; }
    }
}
