``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 20.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|          Method |        Mean |     Error |    StdDev |      Median |     Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|---------------- |------------:|----------:|----------:|------------:|----------:|----------:|----------:|-----------:|
|  &#39;Day 1 Part 1&#39; |   0.1276 ms | 0.0016 ms | 0.0015 ms |   0.1276 ms |    4.8828 |    2.4414 |         - |      89 KB |
|  &#39;Day 1 Part 2&#39; |   0.1261 ms | 0.0013 ms | 0.0011 ms |   0.1259 ms |    4.8828 |    2.4414 |         - |      89 KB |
|  &#39;Day 2 Part 1&#39; |   0.1974 ms | 0.0023 ms | 0.0022 ms |   0.1978 ms |   11.7188 |    5.8594 |         - |     216 KB |
|  &#39;Day 2 Part 2&#39; |   0.1991 ms | 0.0024 ms | 0.0023 ms |   0.1990 ms |   12.2070 |    6.1035 |         - |     224 KB |
|  &#39;Day 3 Part 1&#39; |   0.1326 ms | 0.0012 ms | 0.0011 ms |   0.1329 ms |    3.9063 |    1.7090 |         - |      75 KB |
|  &#39;Day 3 Part 2&#39; |   0.1638 ms | 0.0022 ms | 0.0020 ms |   0.1638 ms |    7.8125 |    3.9063 |         - |     146 KB |
|  &#39;Day 4 Part 1&#39; |   0.4235 ms | 0.0031 ms | 0.0046 ms |   0.4237 ms |   13.1836 |    6.3477 |         - |     244 KB |
|  &#39;Day 4 Part 2&#39; |   0.5501 ms | 0.0034 ms | 0.0032 ms |   0.5502 ms |   12.6953 |    5.8594 |         - |     244 KB |
|  &#39;Day 5 Part 1&#39; |  32.3339 ms | 0.3344 ms | 0.3128 ms |  32.2384 ms |  937.5000 |  437.5000 |  437.5000 |  19,839 KB |
|  &#39;Day 5 Part 2&#39; |  87.9202 ms | 1.2345 ms | 1.0944 ms |  88.1553 ms | 1833.3333 | 1166.6667 |  833.3333 |  33,073 KB |
|  &#39;Day 6 Part 1&#39; |  37.8834 ms | 0.6660 ms | 0.6230 ms |  37.9586 ms | 2642.8571 | 2571.4286 | 2000.0000 |  26,911 KB |
|  &#39;Day 6 Part 2&#39; |   0.0339 ms | 0.0003 ms | 0.0003 ms |   0.0338 ms |    1.0986 |    0.5493 |         - |      21 KB |
|  &#39;Day 7 Part 1&#39; |   0.1798 ms | 0.0007 ms | 0.0007 ms |   0.1798 ms |    3.6621 |    1.7090 |         - |      69 KB |
|  &#39;Day 7 Part 2&#39; |   0.1978 ms | 0.0039 ms | 0.0089 ms |   0.2018 ms |    3.6621 |    1.7090 |         - |      69 KB |
|  &#39;Day 8 Part 1&#39; |   0.1409 ms | 0.0027 ms | 0.0030 ms |   0.1396 ms |    8.7891 |    4.3945 |         - |     165 KB |
|  &#39;Day 8 Part 2&#39; |   2.9839 ms | 0.0310 ms | 0.0290 ms |   2.9908 ms |  148.4375 |   27.3438 |         - |   2,730 KB |
|  &#39;Day 9 Part 1&#39; |   0.6144 ms | 0.0013 ms | 0.0012 ms |   0.6147 ms |    8.7891 |    3.9063 |         - |     168 KB |
|  &#39;Day 9 Part 2&#39; |   1.3937 ms | 0.0023 ms | 0.0022 ms |   1.3939 ms |   15.6250 |    7.8125 |         - |     312 KB |
| &#39;Day 10 Part 1&#39; |   0.1877 ms | 0.0012 ms | 0.0012 ms |   0.1877 ms |    3.6621 |    1.7090 |         - |      71 KB |
| &#39;Day 10 Part 2&#39; |   0.3540 ms | 0.0015 ms | 0.0014 ms |   0.3539 ms |    6.3477 |    2.9297 |         - |     123 KB |
| &#39;Day 11 Part 1&#39; |   0.2150 ms | 0.0001 ms | 0.0001 ms |   0.2150 ms |    0.4883 |    0.2441 |         - |      11 KB |
| &#39;Day 11 Part 2&#39; |   0.5922 ms | 0.0003 ms | 0.0003 ms |   0.5921 ms |         - |         - |         - |      11 KB |
| &#39;Day 12 Part 1&#39; |   2.2394 ms | 0.0053 ms | 0.0047 ms |   2.2369 ms |         - |         - |         - |      20 KB |
| &#39;Day 12 Part 2&#39; | 289.5317 ms | 1.6635 ms | 1.5561 ms | 289.7666 ms | 8000.0000 |         - |         - | 161,703 KB |
| &#39;Day 13 Part 1&#39; |   0.3385 ms | 0.0039 ms | 0.0037 ms |   0.3375 ms |   18.5547 |    9.2773 |         - |     345 KB |
| &#39;Day 13 Part 2&#39; |   0.7677 ms | 0.0141 ms | 0.0132 ms |   0.7684 ms |   42.9688 |   13.6719 |         - |     789 KB |
| &#39;Day 14 Part 1&#39; |   6.3599 ms | 0.0114 ms | 0.0107 ms |   6.3632 ms |   85.9375 |   23.4375 |         - |   1,650 KB |
| &#39;Day 14 Part 2&#39; |   0.8247 ms | 0.0079 ms | 0.0074 ms |   0.8247 ms |   31.2500 |    9.7656 |         - |     586 KB |
