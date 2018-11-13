using System;
using NUnit.Framework;
namespace simpleTest
{   
    [TestFixture]
    public class simpleTest
    {
        static void Main(string[] args)
        {
            
        }

        [Test]
        public void simpleTest1()
        {
            var a = 1;
            var b = 3;
            Assert.Greater(b, a);
        }
        [Test]
        public void simpleTest2()
        {
            var a = 3;
            var b = 2.95;
            var deviation = 0.1;
            Assert.AreEqual(a, b, deviation, 
                            $"Deviation is more than {deviation}!");
        }

    }
}
