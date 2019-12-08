using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB
{
    class MovieCast
    {
        [Key]
        public Cast CastID { get; set; }

        [Key]
        public Movie MovieID { get; set; }

        [Key]
        public Movie Movie
    }
}

