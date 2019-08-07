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

            //var output = new List<int[]>();
            for (int i = 0; i < newNums.Count; i++)
            {
                var firstValue = newNums[i].Item1;
                
                var index = newNums.BinarySearch(new Tuple<int, int>(target - firstValue, 0), vc);

                if (index > 0)
                {
                    yield return new[]{newNums[i].Item2, newNums[index].Item2};
                }
            }

            //return output;
        }
        
        public static IEnumerable<int[]> ExpectedIndexes
        {
            get
            {
                yield return new[] { 0, 5 };
                yield return new[] { 1, 3 };
                yield return new[] { 3, 1 };
            }
        }

        [Test]
        public static void UnitTest1()
        {
            var numbers = new[] { 1, 4, 7, 6, 12, 9, 16};
            var target = 10;
            
            
            CollectionAssert.AreEqual(ExpectedIndexes, TwoSum(numbers, target));
            
            

        }

    }


}
