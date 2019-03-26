using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readInfoXmlModelDependencies
{
    class Program
    {
        static void Main(string[] args)
        {
            var xml = XDocument.Load(@"C:\ProgramData\Kongsberg\Nemo\System\Object\OILRG16\OILRG16.info.xml");
            var info = xml.Descendants("Dependency");

           // foreach (var x in info.Attributes("ObjectType").Where(n => n.Value == "Object"))
           // {
           //     Console.WriteLine(x.NextAttribute.NextAttribute.Value);
           // }

            var objNames = info.Attributes("ObjectType").Where(n => n.Value == "Object")
                .Select(x => x.NextAttribute.NextAttribute.Value);

            


            var destPath = @"C:\Users\RomanM\Desktop\Spec";
            //var sourcePath = @"\\pfile01\p100\Nemo\Models.DeployAll-2.5.1\Models.DeployAll_2.5.1-20190311.1";
            

            var sourcePath = @"c:\ProgramData\Kongsberg\Nemo\System\Object\";
            
            foreach (var name in objNames)
            {
                Console.WriteLine(name);
                Directory.CreateDirectory(Path.Combine(destPath, name));
                var files = Directory.GetFiles(Path.Combine(sourcePath, name));
            
                foreach (var file in files)
                {
                    File.Copy(file, Path.Combine(destPath, name, Path.GetFileName(file)).
                        Replace(Path.Combine(sourcePath, name), 
                            Path.Combine(destPath, name, Path.GetFileName(file))), true);
                }
                
            }

            //var path = @"c:\users\RomanM\Desktop\Obj\";
            //
            //foreach (var dir in Directory.GetDirectories(path))
            //{
            //    Console.WriteLine(dir);
            //} 

            Console.ReadLine();

        }
    }
}
