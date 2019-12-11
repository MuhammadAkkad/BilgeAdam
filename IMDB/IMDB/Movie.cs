using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
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
        [Column(TypeName ="image")]
        public Image Photo { get; set; }
        [Column(TypeName = "numeric")]
        public string Rank { get; set; }
        public ICollection<MovieCast> movieCasts { get; set; }

    }
}
