using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB
{
    [Table("Movie")]
    class Movie
    {
        [Key]
        [Column("ID")]
        public int MovieID { get; set; }

        [Column("Name")]
        public string MovieName { get; set; }

        public string Link { get; set; }


        [Range(0,10)]
        [Index("Rank")]
        public decimal Rank { get; set; }


        public ICollection<MovieCast> MovieCasts { get; set; }

    }
}
