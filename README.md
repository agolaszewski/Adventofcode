``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1288 (21H2)
Intel Core i7-4710MQ CPU 2.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|         Method |         Mean |       Error |       StdDev |     Gen 0 |     Gen 1 |    Gen 2 | Allocated |
|--------------- |-------------:|------------:|-------------:|----------:|----------:|---------:|----------:|
| &#39;Day 1 Part 1&#39; |     147.9 μs |     0.97 μs |      0.86 μs |   28.8086 |    0.2441 |        - |     88 KB |
| &#39;Day 1 Part 2&#39; |     153.8 μs |     1.28 μs |      1.19 μs |   28.8086 |    0.2441 |        - |     88 KB |
| &#39;Day 2 Part 1&#39; |     226.5 μs |     1.60 μs |      1.50 μs |   70.0684 |         - |        - |    215 KB |
| &#39;Day 2 Part 2&#39; |     232.0 μs |     1.48 μs |      1.39 μs |   72.7539 |    0.2441 |        - |    223 KB |
| &#39;Day 3 Part 1&#39; |     167.2 μs |     1.80 μs |      1.68 μs |   24.1699 |    9.0332 |   0.2441 |     74 KB |
| &#39;Day 3 Part 2&#39; |     204.3 μs |     3.24 μs |      4.09 μs |   47.3633 |    0.2441 |        - |    146 KB |
| &#39;Day 4 Part 1&#39; |     415.8 μs |     2.09 μs |      1.75 μs |   79.1016 |         - |        - |    243 KB |
| &#39;Day 4 Part 2&#39; |     516.1 μs |     2.32 μs |      1.93 μs |   79.1016 |         - |        - |    243 KB |
| &#39;Day 5 Part 1&#39; |  59,178.4 μs | 1,138.15 μs |  1,595.53 μs | 3222.2222 | 1333.3333 | 666.6667 | 19,838 KB |
| &#39;Day 5 Part 2&#39; | 144,780.5 μs | 4,046.23 μs | 11,930.39 μs | 5200.0000 | 2200.0000 | 800.0000 | 33,070 KB |