using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace xmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var objXml = XDocument.Load(@"xml1.xml");
            var objs = objXml.Descendants("SubObject");
            foreach (var obj in objs)
            {
                Console.WriteLine(obj.Value);
            }

            Console.WriteLine();

            var types = objs.Attributes("type");
            foreach (var type in types)
            {
                Console.WriteLine(type.Value);
            }

            Console.WriteLine();

            var shape3d = objs.Single(s => s.Attribute("type").Value == "3DShape");

            Console.WriteLine(shape3d.Value);
            Console.WriteLine();

            foreach (var obj in objs.Where(x => x.Attribute("type").Value == "Shape"))
            {
                Console.WriteLine(obj.Value);
            }

            Console.WriteLine();

            foreach (var obj in objs.Where(x => x.Attribute("vertNumber").Value == "0"))
            {
                Console.WriteLine(obj.Value);
            }


        }
    }
}
