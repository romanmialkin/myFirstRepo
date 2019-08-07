using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestItem
{
    public class ValueComparer : IComparer<Tuple<int, int>>
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

    [TestFixture]
    public class Solution
    {
        public static IEnumerable<int[]> TwoSum(int[] nums, int target)
        {
            var newNums = nums.Select((n, k) => Tuple.Create(n, k)).OrderBy(t => t.Item1).ToList();
            
            var vc = new ValueComparer();

            for (int i = 0; i < newNums.Count; i++)
            {
                var firstValue = newNums[i].Item1;
                
                var index = newNums.BinarySearch(new Tuple<int, int>(target - firstValue, 0), vc);

                if (index > 0)
                {
                    var output = new[] { newNums[i].Item2, newNums[index].Item2 };
                    yield return output;
                }
            }
        }

        public static IEnumerable<int[]> ExpectedIndexes
        {
            get { yield return new[] {1, 6}; }
        }

        [Test, TestCaseSource(nameof(ExpectedIndexes))]
        public static void UnitTest1(int[] expectedIndexes)
        {
            var numbers = new[] {-5, 1, 4, 7, 8, 12, 9, 16};
            var target = 10;
            
            CollectionAssert.AreEqual(expectedIndexes,TwoSum(numbers, target).FirstOrDefault());
        }

    }


}
