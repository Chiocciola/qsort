using System;
using System.Runtime.CompilerServices;

namespace SortingAlgorithms
{
    public static class QSort
    {
        private struct Interval
        {
            public int Lo;
            public int Hi;

            public Interval(int lo, int hi)
            {
                Lo = lo;
                Hi = hi;
            }
        }

        public static void Sort(int[] a)
        {
            //var scheduler = new ThreadScheduler<Interval>(Sort);
            var scheduler = new TaskBasedScheduler<Interval>(Sort);

            scheduler.Enque(new Interval(0, a.Length - 1));
            //Sort(new Interval(0, a.Length - 1), scheduler);
            
            scheduler.Wait();

            void Sort(Interval interval, IScheduler<Interval> scheduler)
            {
                while (interval.Lo < interval.Hi)
                {
                    if (interval.Hi - interval.Lo < 1024)
                    {
                        Array.Sort(a, interval.Lo, interval.Hi - interval.Lo + 1);
                        return;
                    }

                    int p = Partition(a, interval.Lo, interval.Hi);

                    scheduler.Enque(new Interval(interval.Lo, p - 1));

                    interval.Lo = p + 1;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Partition(int[] a, int lo, int hi)
        {
            // Median-of-three (Lomuto partition)
            int mid = (lo + hi) / 2;
            if (a[mid] < a[lo]) Swap(a, lo, mid);
            if (a[hi]  < a[lo]) Swap(a, lo ,hi);
            if (a[mid] < a[hi]) Swap(a, mid, hi);

            int pivot = a[hi];
            int i = lo - 1;

            for (int j = lo; j <= hi; j++)
            {
                if (a[j] <= pivot && ++i != j)
                {
                    Swap(a, i, j);
                }
            }

            return i;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Swap(int[] a, int lo, int hi)
        {
            int t = a[lo];
            a[lo] = a[hi];
            a[hi] = t;
        }
    }
}