using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinORM
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Key:Attribute
    {
        public KeyType Type { get; set; }
    }
}
