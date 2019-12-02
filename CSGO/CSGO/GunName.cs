using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GunName : Attribute
    {


        public string  name { get; set; }

        public GunName(string name) {
            this.name = name;
        }

    }
}
