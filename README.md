BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1348 (20H2/October2020Update)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 5.0.12 (5.0.1221.52207), X64 RyuJIT  [AttachedDebugger]
  Job-FKIDUN : .NET 5.0.12 (5.0.1221.52207), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

|                Method |        N |       Mean |    Error |   StdDev | Ratio | RatioSD |
|---------------------- |--------- |-----------:|---------:|---------:|------:|--------:|
|                   __1 | 10000000 |   898.9 ms | 17.23 ms | 21.17 ms |  1.00 |    0.00 |
|     Bondar_QSort_Sync | 10000000 |   956.9 ms | 14.84 ms | 12.40 ms |  1.06 |    0.03 |
|   Bondar_QSort_Thread | 10000000 |   531.1 ms | 10.59 ms | 11.77 ms |  0.59 |    0.02 |
|     Bondar_QSort_Task | 10000000 |   295.4 ms |  5.89 ms |  5.78 ms |  0.33 |    0.01 |
| Kucherenko_NaiveQSort | 10000000 | 1,168.1 ms | 14.52 ms | 12.13 ms |  1.30 |    0.04 |
