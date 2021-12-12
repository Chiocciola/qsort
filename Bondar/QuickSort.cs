using System;
using System.Runtime.CompilerServices;

namespace SortingAlgorithms
{
    public static class QSort
    {
        public struct Interval
        {
            public int Lo;
            public int Hi;

            public Interval(int lo, int hi)
            {
                Lo = lo;
                Hi = hi;
            }
        }

        public static void Sort(int[] a, IScheduler<Interval> scheduler)
        {
            //var scheduler = new ThreadScheduler<Interval>(Sort);

            scheduler.SetHandler(Sort);
            scheduler.Enque(new Interval(0, a.Length - 1));
            scheduler.Wait();

            void Sort(Interval interval)
            {
                while (interval.Lo < interval.Hi)
                {
                    if (interval.Hi - interval.Lo < 16)
                    {
                        //Array.Sort(a, interval.Lo, interval.Hi - interval.Lo + 1);
                        InsertionSort(a, interval);
                        return;
                    }

                    int p = Partition(a, interval.Lo, interval.Hi);

                    scheduler.Enque(new Interval(interval.Lo, p - 1));

                    interval.Lo = p + 1;
                }
            }
        }

        public static void InsertionSort(int[] a, Interval interval)
        {
            for (int i = interval.Lo + 1; i <= interval.Hi; i++)
            {
                var toInsert = a[i];
                var j = i;

                while (j > interval.Lo && a[j - 1] > toInsert)
                {
                    a[j] = a[--j];
                }

                a[j] = toInsert;
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