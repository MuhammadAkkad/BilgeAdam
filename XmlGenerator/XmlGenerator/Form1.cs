using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Student std1 = new Student { TCKN = 123456789, LastName = "Muhammad", Name = "Akkad", Miktar = 100 };
            Student std2 = new Student { TCKN = 321321332, LastName = "Samir", Name = "Sari", Miktar = 300 };
            Student std3 = new Student { TCKN = 421421332, LastName = "LAtife", Name = "SHAdy", Miktar = 400 };

            List<object> students = new List<object>();
            students.Add(std1);
            students.Add(std2);
            students.Add(std3);

            //Type[] types = new Type[1];
            //types[0] = typeof(Student);

            XmlGenerator xmlGenerator = new XmlGenerator(typeof(Student), students);



            // XmlSerializer serializer = new XmlSerializer(typeof(List<Ogrenci>), types);

            // TextWriter writer = new StreamWriter("harcListesi.xml");

            // serializer.Serialize(writer, ogrencis);
            // writer.Close(); //Close Yapmazsak çalışmaz!
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XElement contacts =
            new XElement("Contacts",
            new XElement("Contact",
            new XElement("Name", "Patrick Hines"),
            new XElement("Phone", "206-555-0144"),
            new XElement("Address",
            new XElement("Street1", "123 Main St"),
            new XElement("City", "Mercer Island"),
            new XElement("State", "WA"),
            new XElement("Postal", "68042")
           )
       )
   );

            // XElement Ogrenciler = new XElement("Ogrenciler",new XElement("Ogrneci",new XElement("Name","Boran"),new XElement()"LastName")),

        }
    }
}
