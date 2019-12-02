using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGO;

namespace GunGame
{
    [GunName("AkAk")]
    public class Ak47 : Silah, IAtesEdebilable
    {
        public string AtesEt()
        {
            return " Gun fired  with Damage of " + this.damage + " and range of " + this.range + " Maşallah";
        }
    }
           
}
