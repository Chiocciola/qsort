using System;
using BenchmarkDotNet.Attributes;
using SortingAlgorithms;

namespace Benchmarks
{
    public class SortingAlgorithms
    {
        [Params(10_000_000)]
        public int N;
        
        private int[] unsorted;
        private int[] data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(42);
            unsorted = new int[N];
            data = new int[N];
            
            for (int i = 0; i < N; i++)
            {
                unsorted[i] = random.Next(int.MinValue, int.MaxValue);
            }
            
            //Array.Sort(unsorted);
        }

        [IterationSetup]
        public void IterationSetup()
        {
            Array.Copy(unsorted, data, N);
        }

        [Benchmark(Baseline = true)]
        public void ArraySort()
        {
            Array.Sort(data);
        }
        
        // [Benchmark]
        // public void PLinq_OrderBy()
        // {
        //     data = data.AsParallel().OrderBy(x => x).ToArray();
        // }
        
        // [Benchmark]
        // public void __2()
        // {
        //     Array.Sort(data);
        // }

        [Benchmark]
        public void Bondar_QuickSort_Sync()
        {
            Bondar.QuickSort.Sort(data, Bondar.QuickSort.SchedulerType.Sync);
        }

        [Benchmark]
        public void Bondar_QSort_Thread()
        {
            Bondar.QuickSort.Sort(data, Bondar.QuickSort.SchedulerType.ThreadBased);
        }

        [Benchmark]
        public void Bondar_QSort_Task()
        {
            Bondar.QuickSort.Sort(data, Bondar.QuickSort.SchedulerType.TaskBased);
        }
        
        // [Benchmark]
        // public void __3()
        // {
        //     Array.Sort(data);
        // }

        [Benchmark]
        public void Kucherenko_NaiveQSort()
        {
            KuSort.NaiveSort(data);
        }

        // [Benchmark]
        // public void __4()
        // {
        //     Array.Sort(data);
        // }
    }
}