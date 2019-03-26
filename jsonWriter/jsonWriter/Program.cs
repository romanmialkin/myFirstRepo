using System;

namespace jsonWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Specialist(1, "Milakin", "Roman", 3,
            SpecialistType.Doctor, "21");

            Console.WriteLine(p);
        }
    }


}
