using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlGenerator
{
    [XmlRoot("NewStudent")]
    class Student
    {

        [XmlAttribute(DataType = "int", AttributeName = "TC number")]
        public int TCKN { get; set; }

        [XmlElement(DataType = "string", ElementName ="Name Attr")]
        public string Name { get; set; }

        [XmlElement(DataType = "string", ElementName = "Last name Attr")]
        public string LastName { get; set; }

        [XmlElement(DataType = "int", ElementName = "Total")]
        public int Miktar { get; set; }
    }
}
