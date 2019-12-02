using CsGo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO
{
    public delegate void DoesHaveAttributeHandler(Silah silah);
    public abstract class Silah
    {
        
        public int range { get; set; }
        public int damage { get; set; }
     
        public override string ToString()
        {
            string name = this.GetType().Name;
            Type type = this.GetType();
            if (type.GetCustomAttributes(typeof(GunName), true).Length > 0)
            {

                GunName gn = (GunName)type.GetCustomAttributes(typeof(GunName), true)[0];
                name = gn.name;
            }
            else
            {
                //  doesHaveAttributeHandler.Invoke(this);
                string yaz = hataDondur(name);
            }

            return name;
        }
        string hataDondur(string _name)
        {
            return "attribute yok";
        }


        public event DoesHaveAttributeHandler doesHaveAttributeHandler;
    }
}
