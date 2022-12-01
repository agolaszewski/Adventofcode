using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Benchmarks;
using Perfolizer.Horology;

//BenchmarkRunner.Run<BenchmarksRunner>(
//    DefaultConfig.Instance.WithSummaryStyle(
//        SummaryStyle.Default.WithTimeUnit(TimeUnit.Millisecond)));