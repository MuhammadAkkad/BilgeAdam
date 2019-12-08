using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB
{
    class Cast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CastID { get; set; }
        public string CastName { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }
}
