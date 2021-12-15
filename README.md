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
|             ArraySort | 10000000 |   843.2 ms | 11.56 ms |  9.65 ms |  1.00 |    0.00 |
| Bondar_QuickSort_Sync | 10000000 |   905.1 ms | 17.44 ms | 23.28 ms |  1.07 |    0.03 |
|   Bondar_QSort_Thread | 10000000 |   496.0 ms |  9.87 ms |  9.69 ms |  0.59 |    0.01 |
|     Bondar_QSort_Task | 10000000 |   278.5 ms |  5.46 ms |  6.70 ms |  0.33 |    0.01 |
| Kucherenko_NaiveQSort | 10000000 | 1,057.6 ms |  7.21 ms |  6.39 ms |  1.26 |    0.02 |

