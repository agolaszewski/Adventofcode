``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 20.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|          Method |          Mean |     Error |    StdDev |     Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|---------------- |--------------:|----------:|----------:|----------:|----------:|----------:|-----------:|
|  &#39;Day 1 Part 1&#39; |     0.1286 ms | 0.0007 ms | 0.0007 ms |    4.8828 |    2.4414 |         - |      89 KB |
|  &#39;Day 1 Part 2&#39; |     0.1464 ms | 0.0009 ms | 0.0008 ms |    4.8828 |    2.4414 |         - |      89 KB |
|  &#39;Day 2 Part 1&#39; |     0.2366 ms | 0.0013 ms | 0.0012 ms |   11.7188 |    5.8594 |         - |     216 KB |
|  &#39;Day 2 Part 2&#39; |     0.2406 ms | 0.0018 ms | 0.0017 ms |   12.2070 |    6.1035 |         - |     224 KB |
|  &#39;Day 3 Part 1&#39; |     0.1511 ms | 0.0006 ms | 0.0005 ms |    3.9063 |    1.7090 |         - |      75 KB |
|  &#39;Day 3 Part 2&#39; |     0.2261 ms | 0.0007 ms | 0.0007 ms |    7.8125 |    3.9063 |         - |     146 KB |
|  &#39;Day 4 Part 1&#39; |     0.4766 ms | 0.0015 ms | 0.0013 ms |   13.1836 |    6.3477 |         - |     244 KB |
|  &#39;Day 4 Part 2&#39; |     0.6200 ms | 0.0036 ms | 0.0034 ms |   12.6953 |    5.8594 |         - |     244 KB |
|  &#39;Day 5 Part 1&#39; |    37.2257 ms | 0.3499 ms | 0.3273 ms |  928.5714 |  428.5714 |  428.5714 |  19,839 KB |
|  &#39;Day 5 Part 2&#39; |   105.5106 ms | 1.3804 ms | 1.2237 ms | 1800.0000 | 1200.0000 |  800.0000 |  33,072 KB |
|  &#39;Day 6 Part 1&#39; |   106.1137 ms | 2.1118 ms | 4.2660 ms | 3166.6667 | 3166.6667 | 2500.0000 |  26,929 KB |
|  &#39;Day 6 Part 2&#39; |     0.0391 ms | 0.0003 ms | 0.0003 ms |    1.0986 |    0.5493 |         - |      21 KB |
|  &#39;Day 7 Part 1&#39; |     0.2049 ms | 0.0004 ms | 0.0004 ms |    3.6621 |    1.7090 |         - |      69 KB |
|  &#39;Day 7 Part 2&#39; |     0.2021 ms | 0.0003 ms | 0.0003 ms |    3.6621 |    1.7090 |         - |      69 KB |
|  &#39;Day 8 Part 1&#39; |     0.1752 ms | 0.0022 ms | 0.0021 ms |    8.7891 |    4.3945 |         - |     165 KB |
|  &#39;Day 8 Part 2&#39; |     3.0443 ms | 0.0170 ms | 0.0151 ms |  148.4375 |   27.3438 |         - |   2,730 KB |
|  &#39;Day 9 Part 1&#39; |     0.6874 ms | 0.0006 ms | 0.0005 ms |    8.7891 |    3.9063 |         - |     168 KB |
|  &#39;Day 9 Part 2&#39; |     1.5773 ms | 0.0007 ms | 0.0007 ms |   15.6250 |    7.8125 |         - |     312 KB |
| &#39;Day 10 Part 1&#39; |     0.2056 ms | 0.0005 ms | 0.0005 ms |    3.6621 |    1.7090 |         - |      71 KB |
| &#39;Day 10 Part 2&#39; |     0.3505 ms | 0.0007 ms | 0.0007 ms |    6.3477 |    2.9297 |         - |     123 KB |
| &#39;Day 11 Part 1&#39; |     0.5664 ms | 0.0013 ms | 0.0013 ms |   15.6250 |    7.8125 |         - |     294 KB |
| &#39;Day 11 Part 2&#39; |     0.5511 ms | 0.0036 ms | 0.0032 ms |    0.4883 |         - |         - |      11 KB |
| &#39;Day 12 Part 1&#39; |     2.2232 ms | 0.0012 ms | 0.0010 ms |         - |         - |         - |      20 KB |
| &#39;Day 12 Part 2&#39; |   293.5693 ms | 2.3461 ms | 2.1945 ms | 8000.0000 |         - |         - | 161,703 KB |
| &#39;Day 13 Part 1&#39; |     0.3422 ms | 0.0035 ms | 0.0033 ms |   18.5547 |    9.2773 |         - |     345 KB |
| &#39;Day 13 Part 2&#39; |     0.7756 ms | 0.0125 ms | 0.0117 ms |   42.9688 |   13.6719 |         - |     789 KB |
| &#39;Day 14 Part 1&#39; |     5.6580 ms | 0.0189 ms | 0.0232 ms |   85.9375 |   23.4375 |         - |   1,650 KB |
| &#39;Day 14 Part 2&#39; |     0.8329 ms | 0.0164 ms | 0.0331 ms |   31.2500 |    9.7656 |         - |     586 KB |
| &#39;Day 15 Part 1&#39; |    88.0526 ms | 0.0718 ms | 0.0672 ms |  166.6667 |  166.6667 |  166.6667 |   2,939 KB |
| &#39;Day 15 Part 2&#39; | 5,697.6384 ms | 3.9894 ms | 3.7317 ms | 4000.0000 | 3000.0000 | 2000.0000 |  64,634 KB |
| &#39;Day 16 Part 1&#39; |     0.2638 ms | 0.0019 ms | 0.0016 ms |   11.7188 |    5.8594 |         - |     215 KB |
| &#39;Day 16 Part 2&#39; |     0.2801 ms | 0.0018 ms | 0.0017 ms |   12.2070 |    5.8594 |         - |     223 KB |
| &#39;Day 17 Part 1&#39; |     2.4331 ms | 0.0005 ms | 0.0004 ms |         - |         - |         - |      10 KB |
| &#39;Day 17 Part 2&#39; |     5.1172 ms | 0.0053 ms | 0.0049 ms |         - |         - |         - |      10 KB |
