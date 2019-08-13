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
                var t = target - firstValue;
                var index = newNums.BinarySearch(new Tuple<int, int>(t, 0), vc);

                if (index > 0 && firstValue < newNums[index].Item1)
                {
                    var firstIndex = newNums[i].Item2;
                    var secondIndex = newNums[index].Item2;
                    return firstIndex > secondIndex ? new[] { secondIndex, firstIndex } 
                        : new[] { firstIndex, secondIndex };
                }
            }

            return new int[] { };
        }
        

        [Test]
        public static void UnitTest1()
        {
            var numbersArray = new[] {9, 4, 7, 1};
            var targetValue = 10;
            var expectedIndexes = new[] {0, 3};

            Assert.That(TwoSum(numbersArray, targetValue),
                Is.EqualTo(expectedIndexes));
        }

        [Test]
        public static void UnitTest2()
        {
            var numbersArray = new[] {int.MaxValue, int.MinValue, 0, 10};
            var targetValue = int.MaxValue;
            var expectedIndexes = new[] {0, 2};
            Assert.That(TwoSum(numbersArray, targetValue),
                Is.EqualTo(expectedIndexes));
        }

        [Test]
        public static void UnitTest3()
        {
            var numbersArray = new[] { int.MaxValue, int.MinValue, 0, -15 };
            var targetValue = -1;
            var expectedIndexes = new[] { 0, 1 };
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
