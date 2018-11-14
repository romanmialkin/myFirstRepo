using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace simpleTest
{   
    [TestFixture]
    public class simpleTest
    {
        static void Main(string[] args)
        {
            SelTest();
        }

        public static void SelTest()
        {
            var chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://www.google.com/");
            System.Threading.Thread.Sleep(5000);
            chrome.Quit();

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
