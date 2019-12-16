using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb
{
    public class MovieCast
    {

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieCastId { get; set; }


        [Key, Column(Order = 1)]
        public int MovieId { get; set; }

        [Key, Column(Order = 2)]
        public int CastId { get; set; }

        [Key, Column(Order = 3)]
        public int CastRoleId { get; set; }




        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("CastId")]
        public Cast Cast { get; set; }

        [ForeignKey("CastRoleId")]
        public CastRole CastRole { get; set; }
    }
}
