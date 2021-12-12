# Multithread Quicksort challenge

## The goals

1. Refresh/Learn how to work with Git/GitHub
2. Refresh/Learn how to work with C# project/solutions in VS Code
3. Refresh/Learn what is QuickSort
4. Challenge yourself to implement multithreaded version of QuickSort

## Where to start
1. Good start piont is a Wikipedia article: https://en.wikipedia.org/wiki/Quicksort
2. To start working with code fork this project
3. Add a project named with your name/nickname
4. Update Benchmarks project
5. Submit pull request

## Current benchmarks
Thanks to @olegku for introducing support of https://github.com/dotnet/BenchmarkDotNet


|                Method |        N |       Mean |    Error |   StdDev | Ratio | RatioSD |
|---------------------- |--------- |-----------:|---------:|---------:|------:|--------:|
|                   __1 | 10000000 |   898.9 ms | 17.23 ms | 21.17 ms |  1.00 |    0.00 |
|     Bondar_QSort_Sync | 10000000 |   956.9 ms | 14.84 ms | 12.40 ms |  1.06 |    0.03 |
|   Bondar_QSort_Thread | 10000000 |   531.1 ms | 10.59 ms | 11.77 ms |  0.59 |    0.02 |
|     Bondar_QSort_Task | 10000000 |   295.4 ms |  5.89 ms |  5.78 ms |  0.33 |    0.01 |
| Kucherenko_NaiveQSort | 10000000 | 1,168.1 ms | 14.52 ms | 12.13 ms |  1.30 |    0.04 |
