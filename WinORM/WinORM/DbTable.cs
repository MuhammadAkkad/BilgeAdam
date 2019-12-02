using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinORM
{       [AttributeUsage(AttributeTargets.Class)]
    class DbTable : Attribute
    {
        public string Name { get; set; }

    }
}
