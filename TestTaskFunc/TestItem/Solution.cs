using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestItem
{
    [TestFixture]
    public class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var newNums = nums.Select((n, k) => Tuple.Create(n, k)).OrderBy(t => t.Item1).ToList();

            var vc = new Comparer();

            for (int i = 0; i < newNums.Count; i++)
            {
                var firstValue = newNums[i].Item1;

                var index = newNums.BinarySearch(new Tuple<int, int>(target - firstValue, 0), vc);

                if (index > 0 && firstValue < newNums[index].Item1)
                {
                    return new[] { newNums[i].Item2, newNums[index].Item2 };
                }
            }

            return new int[] { };
        }
        private static readonly int[] numbersArray = { 1, 4, 7, 8, 12, 9, 16 };
        private static readonly int targetValue = 10;
        private static readonly int[] expectedIndexes = {0, 5};

        [Test]
        public static void UnitTest1()
        {
            Assert.That(TwoSum(numbersArray, targetValue),
                Is.EqualTo(expectedIndexes));
        }
    }
    public class Comparer : IComparer<Tuple<int, int>>
    {
        public int Compare(Tuple<int, int> x, Tuple<int, int> y)
        {
            if (x == null)
                return -1;
            if (y == null)
                return -1;
            return x.Item1.CompareTo(y.Item1);
        }
    }
}
