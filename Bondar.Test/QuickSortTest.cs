using System;
using System.Linq;
using Xunit;

namespace Bondar.Test
{
    public class QuickSortTest
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

            Array.Copy(unsorted,sorted, N);
            Array.Sort(sorted);

            QuickSort.Sort(unsorted, QuickSort.SchedulerType.Sync);

            Assert.True(unsorted.SequenceEqual(sorted), "Sorting is not correct");
        }
    }
}