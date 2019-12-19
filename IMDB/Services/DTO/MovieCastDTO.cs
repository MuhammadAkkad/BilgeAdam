using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class MovieCastDTO
    {
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public int CastRoleId { get; set; }
    }
}
