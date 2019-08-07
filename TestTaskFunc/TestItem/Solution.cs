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
    public static class Solver
    {
        public static IEnumerable<int[]> TwoSum(int[] nums, int target)
        {
            var newNums = nums.Select((n, k) => Tuple.Create(n, k)).OrderBy(t => t.Item1).ToList();

            var vc = new ValueComparer();

            for (int i = 0; i < newNums.Count; i++)
            {
                var firstValue = newNums[i].Item1;

                var index = newNums.BinarySearch(new Tuple<int, int>(target - firstValue, 0), vc);

                if (index > 0 && firstValue < newNums[index].Item1)
                {
                    yield return new[] { newNums[i].Item2, newNums[index].Item2 };
                }
            }
        }
    }


    [TestFixture]
    public class Solution
    {
        private static readonly int[] numbers = { 1, 4, 7, 6, 12, 9, 16 };
        private static readonly int target = 10;
        public static IEnumerable<TestCaseData> ExpectedIndexes
        {
            get
            {
                yield return new TestCaseData(new[] { 0, 5 }, 0, numbers, target);
                yield return new TestCaseData(new[] { 1, 4 }, 1, numbers, target); //TODO: Index 4 is incorrect
            }
        }

        [Test, TestCaseSource(typeof(Solution), nameof(ExpectedIndexes))]
        public static void UnitTest1(int[] expectedIndexes, int index, int[] numbers, int target)
        {
            
            
            CollectionAssert.AreEqual(expectedIndexes, Solver.TwoSum(numbers, target).ElementAt(index));
            Assert.That(Solver.TwoSum(numbers, target).ElementAt(index), Is.EqualTo(expectedIndexes));

        }
        

    }


}
