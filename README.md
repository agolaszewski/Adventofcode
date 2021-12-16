``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 20.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|          Method |          Mean |     Error |    StdDev |     Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|---------------- |--------------:|----------:|----------:|----------:|----------:|----------:|-----------:|
|  &#39;Day 1 Part 1&#39; |     0.1293 ms | 0.0005 ms | 0.0004 ms |    4.8828 |    2.4414 |         - |      89 KB |
|  &#39;Day 1 Part 2&#39; |     0.1450 ms | 0.0004 ms | 0.0003 ms |    4.8828 |    2.4414 |         - |      89 KB |
|  &#39;Day 2 Part 1&#39; |     0.2420 ms | 0.0015 ms | 0.0013 ms |   11.7188 |    5.8594 |         - |     216 KB |
|  &#39;Day 2 Part 2&#39; |     0.2385 ms | 0.0016 ms | 0.0015 ms |   12.2070 |    6.1035 |         - |     224 KB |
|  &#39;Day 3 Part 1&#39; |     0.1519 ms | 0.0002 ms | 0.0002 ms |    3.9063 |    1.9531 |         - |      75 KB |
|  &#39;Day 3 Part 2&#39; |     0.2259 ms | 0.0008 ms | 0.0007 ms |    7.8125 |    3.9063 |         - |     146 KB |
|  &#39;Day 4 Part 1&#39; |     0.4894 ms | 0.0026 ms | 0.0024 ms |   12.6953 |    5.8594 |         - |     244 KB |
|  &#39;Day 4 Part 2&#39; |     0.6231 ms | 0.0021 ms | 0.0019 ms |   12.6953 |    5.8594 |         - |     244 KB |
|  &#39;Day 5 Part 1&#39; |    37.0902 ms | 0.6532 ms | 0.6110 ms |  928.5714 |  428.5714 |  428.5714 |  19,839 KB |
|  &#39;Day 5 Part 2&#39; |   108.1324 ms | 1.5549 ms | 1.4545 ms | 1800.0000 | 1200.0000 |  800.0000 |  33,072 KB |
|  &#39;Day 6 Part 1&#39; |   105.7384 ms | 0.7561 ms | 0.6702 ms | 3000.0000 | 3000.0000 | 2400.0000 |  26,931 KB |
|  &#39;Day 6 Part 2&#39; |     0.0394 ms | 0.0001 ms | 0.0001 ms |    1.0986 |    0.5493 |         - |      21 KB |
|  &#39;Day 7 Part 1&#39; |     0.2036 ms | 0.0002 ms | 0.0002 ms |    3.6621 |    1.7090 |         - |      69 KB |
|  &#39;Day 7 Part 2&#39; |     0.2011 ms | 0.0002 ms | 0.0002 ms |    3.6621 |    1.7090 |         - |      69 KB |
|  &#39;Day 8 Part 1&#39; |     0.1755 ms | 0.0016 ms | 0.0015 ms |    8.7891 |    4.3945 |         - |     165 KB |
|  &#39;Day 8 Part 2&#39; |     3.0781 ms | 0.0148 ms | 0.0138 ms |  148.4375 |   27.3438 |         - |   2,730 KB |
|  &#39;Day 9 Part 1&#39; |     0.7017 ms | 0.0004 ms | 0.0004 ms |    8.7891 |    3.9063 |         - |     168 KB |
|  &#39;Day 9 Part 2&#39; |     1.5801 ms | 0.0008 ms | 0.0008 ms |   15.6250 |    7.8125 |         - |     312 KB |
| &#39;Day 10 Part 1&#39; |     0.2032 ms | 0.0005 ms | 0.0004 ms |    3.6621 |    1.7090 |         - |      71 KB |
| &#39;Day 10 Part 2&#39; |     0.3539 ms | 0.0011 ms | 0.0011 ms |    6.3477 |    2.9297 |         - |     123 KB |
| &#39;Day 11 Part 1&#39; |     0.5631 ms | 0.0004 ms | 0.0004 ms |   15.6250 |    7.8125 |         - |     294 KB |
| &#39;Day 11 Part 2&#39; |     0.5505 ms | 0.0003 ms | 0.0002 ms |         - |         - |         - |      11 KB |
| &#39;Day 12 Part 1&#39; |     2.2264 ms | 0.0010 ms | 0.0008 ms |         - |         - |         - |      20 KB |
| &#39;Day 12 Part 2&#39; |   289.6219 ms | 0.5052 ms | 0.4726 ms | 8000.0000 |         - |         - | 161,703 KB |
| &#39;Day 13 Part 1&#39; |     0.3472 ms | 0.0045 ms | 0.0042 ms |   18.5547 |    9.2773 |         - |     345 KB |
| &#39;Day 13 Part 2&#39; |     0.8011 ms | 0.0095 ms | 0.0089 ms |   42.9688 |   13.6719 |         - |     789 KB |
| &#39;Day 14 Part 1&#39; |     6.3061 ms | 0.0042 ms | 0.0039 ms |   85.9375 |   23.4375 |         - |   1,650 KB |
| &#39;Day 14 Part 2&#39; |     1.0357 ms | 0.0047 ms | 0.0044 ms |   31.2500 |    9.7656 |         - |     586 KB |
| &#39;Day 15 Part 1&#39; |    87.3015 ms | 0.0694 ms | 0.0615 ms |  166.6667 |  166.6667 |  166.6667 |   2,939 KB |
| &#39;Day 15 Part 2&#39; | 5,424.1635 ms | 4.0542 ms | 3.5940 ms | 3000.0000 | 2000.0000 | 1000.0000 |  65,655 KB |
