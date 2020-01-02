using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb
{
    public class CastRole
    {
        public int CastRoleId { get; set; }
        public string Role { get; set; }
        public ICollection<MovieCast> movieCasts { get; set; }
    }
}
