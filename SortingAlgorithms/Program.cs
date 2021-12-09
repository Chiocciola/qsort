//
// // Load System.Threading
// Thread.Sleep(1);
// // Load Collections.Concurrent
// new System.Collections.Concurrent.ConcurrentQueue<int>();
//
// var a = new int[10000000];
//
// var rnd = new Random();
// for (int i = 0; i < a.Length; i++)
// {
//     a[i] = rnd.Next(int.MinValue, int.MaxValue);
// }
//
// var b = new int[a.Length];Q
// a.CopyTo(b, 0);
//
// var c = new int[a.Length];
// a.CopyTo(c, 0);
//
// var watch = new System.Diagnostics.Stopwatch();
//
//
// watch.Reset();
// watch.Start();
// Array.Sort(c);
// watch.Stop();
// Console.WriteLine($"Array.Sort: {watch.ElapsedMilliseconds}");
//
//
//
// watch.Reset();
// watch.Start();
// var b1 = b.AsParallel().OrderBy(x => x).ToArray();
// watch.Stop();
// Console.WriteLine($"PLINQ: {watch.ElapsedMilliseconds}, sorting is correct: {b1.SequenceEqual(c)}");
//
//
// watch.Reset();
// watch.Start();
// SortingAlgorithms.QSort.Sort(a);
// watch.Stop();
//
// Console.WriteLine($"Multithread: {watch.ElapsedMilliseconds}, sorting is correct: {a.SequenceEqual(c)}");
