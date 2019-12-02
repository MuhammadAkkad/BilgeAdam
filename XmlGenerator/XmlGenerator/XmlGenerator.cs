using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlGenerator
{
    public class XmlGenerator
    {
        XName xName;
        XElement xElement;


        public XmlGenerator(Type type, List<object> list)
        {


            xElement = new XElement(type.Name);
            foreach (var obj in list)
            {

              //  XmlRootAttribute rootAttribute = obj.GetType().GetCustomAttribute<XmlRootAttribute>();
              //  xElement.Add(new XElement(rootAttribute == null ? null : rootAttribute.ElementName));

                foreach (PropertyInfo property in type.GetProperties())
                {


                    Attribute[] attr = Attribute.GetCustomAttributes(property, typeof(XmlAttributeAttribute), false);
                    Attribute[] element = Attribute.GetCustomAttributes(property, typeof(XmlElementAttribute), false);


                    // Element
                    if (element.Length > 0)
                    {
                        xElement.Add(new XElement(property.Name, type.GetProperty(property.Name).GetValue(obj)));
                    }

                    // Attribute
                    else if (attr.Length > 0)
                    {
                        xElement.Add(new XAttribute(property.Name, type.GetProperty(property.Name).GetValue(obj)));
                    }
                    else
                    {
                        xElement.Add(new XElement(property.Name, property.GetValue(obj)));
                    }

                    // XmlAttributeAttribute attribute = property.GetType().GetCustomAttribute<XmlAttributeAttribute>();
                    // element.Add(attribute == null ? null : attribute.AttributeName);

                    //XmlAttributeAttribute attribute2 = property.GetCustomAttribute<XmlAttributeAttribute>();
                    //element.Add(attribute2 == null ? null : attribute2.AttributeName);

                }
                xElement.Add(xElement);
            }
        }
    }
}






//public XmlGenerator(Type type, object obj)
//{
//    element = new XElement(type.Name);
//    foreach (PropertyInfo property in type.GetProperties())
//    {
//        element.Add(new XElement(property.Name, type.GetProperty(property.Name).GetValue(obj)));
//    }
//    element.Add(element);
//}

//if (property.GetCustomAttributes(typeof(XmlAttributeAttribute), true).Length > 0)
//{
//    element.Add(new XAttribute(property.Name, property), property.GetCustomAttribute(property.Name).GetValue(classes));
//    element.Add(new XElement(property.GetCustomAttribute(typeof(XmlElementAttribute), true).GetType().GetProperty("ElementName").GetValue(property.GetCustomAttribute(typeof(XmlElementAttribute), true)).ToString(), type.GetProperty(property.Name).GetValue(classes)));
//                        }
//else  element.Add(new XElement(property.Name, type.GetProperty(property.Name).GetValue(classes)));

