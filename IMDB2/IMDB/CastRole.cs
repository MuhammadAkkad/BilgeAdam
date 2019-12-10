using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB
{
    class CastRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CastRoleID { get; set; }
        public int RoleName { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }
}
