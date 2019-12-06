using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IMDB
{
    class Cast
    {
        [Key]
        public int CastID { get; set; }
        public string CastName { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
