using System;
using System.Linq;
using Xunit;
using SortingAlgorithms;

namespace Bondar.Test
{
    public class InsertionSortTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(1000)]
        public void InsertionSortIsCorrect(int N)
        {
            var random = new Random(42);

            var unsorted = new int[N];
            var sorted = new int[N];
            
            for (int i = 0; i < N; i++)
            {
                unsorted[i] = random.Next(int.MinValue, int.MaxValue);
            }

            Array.Copy(unsorted, sorted, N);
            Array.Sort(sorted);

            QSort.InsertionSort(unsorted, new QSort.Interval(0, N - 1));

            Assert.True(unsorted.SequenceEqual(sorted), "Sorting is not correct");
        }
    }
}