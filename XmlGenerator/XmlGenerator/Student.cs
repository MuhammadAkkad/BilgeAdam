using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlGenerator
{
    [XmlRoot("Student")]
    class Student
    {
        [XmlAttribute("Number")]
        public int TCKN { get; set; }

        [XmlElement("First Name")]
        public string Name { get; set; }

        [XmlElement("Second Name")] 
        public string LastName { get; set; }

        [XmlElement("Total")]
        public int Miktar { get; set; }
    }
}
