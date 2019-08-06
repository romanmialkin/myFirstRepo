using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit;
using NUnit.Framework;

namespace TestTaskFunc
{
    [TestFixture]
    public class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var newNums = nums.Select((n, i) => Tuple.Create(n, i)).OrderBy(t => t.Item1);
            

            var indexes = new int[2];
            return  indexes;
        }


       

        

        [Test]
        public static void Run1()
        {
            var numbers = new[] {1, 4, 7, 8, 12, 9, 16};
            var target = 10;
            var controlIndexex = new[] {0, 5};
            
            Assert.That(controlIndexex ==TwoSum(numbers, target));
        }

    }
}
