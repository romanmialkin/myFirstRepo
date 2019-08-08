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
        private static readonly int[] numbersArray = { 1, 4, 7, 6, 12, 9, 16 };
        private static readonly int targetVaulue = 10;
        public static IEnumerable<MyTestCaseData> ExpectedIndexes
        {
            get
            {
                yield return new MyTestCaseData(new[] { 0, 5 }, 0, numbersArray, targetVaulue);
                yield return new MyTestCaseData(new[] { 1, 3 }, 1, numbersArray, targetVaulue);
            }
        }

        [Test, TestCaseSource(typeof(Solution), nameof(ExpectedIndexes))]
        public static void UnitTest1(MyTestCaseData caseData)
        {
            Assert.That(Solver.TwoSum(caseData.Numbers, caseData.Target).ElementAt(caseData.IndexData), 
                Is.EqualTo(caseData.ExpectedIndex));

        }
        

    }
    public class MyTestCaseData
    {
        public MyTestCaseData(int[] expected, int index, int[] numbers, int target)
        {
            ExpectedIndex = expected;
            IndexData = index;
            Numbers = numbers;
            Target = target;
        }
        public int[] ExpectedIndex { get;}
        public int IndexData { get;}
        public int[] Numbers { get;}
        public int Target { get;}
        public override string ToString()
        {
            var str1 = $@"Indexes: [{ExpectedIndex[0]}, {ExpectedIndex[1]}], #";
            var str2 = IndexData.ToString();
            
            return str1 + str2;
        }
    }



}
