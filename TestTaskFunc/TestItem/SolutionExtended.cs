using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using NUnit.Framework;

namespace TestItem
{
    public static class Solver
    {
        [Pure]
        public static IEnumerable<int[]> TwoSum(int[] nums, int target)
        {
            var newNums = nums.Select((n, k) => Tuple.Create(n, k)).OrderBy(t => t.Item1).ToList();

            var vc = new ValueComparer();

            for (int i = 0; i < newNums.Count; i++)
            {
                var firstValue = newNums[i].Item1;

                var index = newNums.BinarySearch(new Tuple<int, int>(target - firstValue, 0), vc);

                if (index > 0 && firstValue == newNums[index].Item1)
                {
                    var firstIndex = newNums[i].Item2;
                    var secondIndex = newNums[i + 1].Item2;

                    yield return firstIndex > secondIndex ? new[] { secondIndex, firstIndex }
                        : new[] { firstIndex, secondIndex };
                }

                if (index > 0 && firstValue < newNums[index].Item1)
                {
                    var firstIndex = newNums[i].Item2;
                    var secondIndex = newNums[index].Item2;
                    
                    yield return firstIndex > secondIndex ? new[] { secondIndex, firstIndex }
                        : new[] { firstIndex, secondIndex };
                   
                }
            }
        }
    }
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
    public class SolutionExtended
    {
        private static readonly int[] numbersArray = { 9, 4, 6, 1};
        private static readonly int targetValue = 10;
        public static IEnumerable<MyTestCaseData> ExpectedIndexes
        {
            get
            {
                yield return new MyTestCaseData(new[] { 0, 3 }, 0, numbersArray, targetValue);
                yield return new MyTestCaseData(new[] { 1, 2 }, 1, numbersArray, targetValue);
                yield return new MyTestCaseData(new[] { 0, 1 }, 0, new[] { 1, 0, 0, 1 }, 1);
                yield return new MyTestCaseData(new[] { 0, 2 }, 1, new[] { 1, 0, 0, 1 }, 1);
                yield return new MyTestCaseData(new[] { 0, 3 }, 0, new[] { 1, 0, 0, 1 }, 2);
                yield return new MyTestCaseData(new[] { 0, 3 }, 0, new[] { -1, 0, 0, -1 }, -2);
                yield return new MyTestCaseData(new[] { 1, 3 }, 0, new[] { 0, 2, 2, 1 }, 3);
            }
        }

        [Test, TestCaseSource(typeof(SolutionExtended), nameof(ExpectedIndexes))]
        public static void UnitTest(MyTestCaseData caseData)
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
            return $@"Indexes: [{ExpectedIndex[0]}, {ExpectedIndex[1]}], #{IndexData.ToString()}, Target: {Target.ToString()}";
        }
    }
}
