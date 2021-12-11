# qsort

|                Method |        N |       Mean |    Error |   StdDev | Ratio | RatioSD |
|---------------------- |--------- |-----------:|---------:|---------:|------:|--------:|
|                   __1 | 10000000 |   895.2 ms | 16.73 ms | 17.91 ms |  1.00 |    0.00 |
|     Bondar_QSort_Sync | 10000000 |   955.0 ms |  9.44 ms |  8.37 ms |  1.07 |    0.03 |
|   Bondar_QSort_Thread | 10000000 |   532.7 ms | 10.53 ms |  9.85 ms |  0.59 |    0.02 |
|     Bondar_QSort_Task | 10000000 |   374.8 ms |  7.00 ms |  9.59 ms |  0.42 |    0.02 |
| Kucherenko_NaiveQSort | 10000000 | 1,374.0 ms | 17.86 ms | 15.83 ms |  1.53 |    0.04 |
