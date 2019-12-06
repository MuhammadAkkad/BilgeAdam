using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IMDB
{
    class MovieCast
    {
     // [Key]
        public Cast CastID { get; set; }
     //   [Key]
        public Movie MovieID { get; set; }
        [for]
        public MovieCast MovieCastID { get; set; }
    }
}

