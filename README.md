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
|                   __1 | 10000000 |   854.7 ms |  7.58 ms |  6.33 ms |  1.00 |    0.00 |
|     Bondar_QSort_Sync | 10000000 | 1,012.0 ms |  8.14 ms |  6.79 ms |  1.18 |    0.01 |
|   Bondar_QSort_Thread | 10000000 |   522.6 ms |  7.28 ms |  6.08 ms |  0.61 |    0.01 |
|     Bondar_QSort_Task | 10000000 |   304.8 ms |  5.80 ms |  7.34 ms |  0.36 |    0.01 |
| Kucherenko_NaiveQSort | 10000000 | 1,097.6 ms | 16.04 ms | 14.22 ms |  1.28 |    0.02 |

