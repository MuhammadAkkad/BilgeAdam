using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IMDB
{
    class CastRole
    {
        [Key]
        public int CastRoleID { get; set; }
        public int MyProperty { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
