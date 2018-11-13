using System;

namespace firstProject
{
    class Program
    {

        static void Main(string[] args)
        {
            var nC = new newClass();
            if (nC.B())
                Console.WriteLine("Just Hello");
            else
                Console.WriteLine("Hello World!");

        }
    }
    public class newClass
    {
        public bool B()
        {
            var a = 100;
            var b = 10;
            if (a > b)
                return true;
            return false;
        }

    }
}
