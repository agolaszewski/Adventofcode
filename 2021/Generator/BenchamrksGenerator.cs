using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Linq;

namespace Generator
{
    public class Day
    {
        private int _dayNo;

        public Day(int dayNo)
        {
            _dayNo = dayNo;
        }

        public string Instance(int part) => $"day{_dayNo}{part} = new Y2021.Day{_dayNo}.Part{part}(stub);";

        public string Field(int part) => $"private Y2021.Day{_dayNo}.Part{part} day{_dayNo}{part};";

        public string Benchamark(int part) => $@"[Benchmark(Description = ""Day {_dayNo} Part {part}"")] public void D{_dayNo}{part}() {{ day{_dayNo}{part}.Solution(); }}";
    }

    [Generator]
    public class BenchamrksGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var days = Enumerable.Range(2, 5).Select(i => new Day(i)).ToList();

            var fields = days.SelectMany(d => Enumerable.Range(1, 2).Select(part => d.Field(part))).ToList();
            var instances = days.SelectMany(d => Enumerable.Range(1, 2).Select(part => d.Instance(part))).ToList();
            var benchamarks = days.SelectMany(d => Enumerable.Range(1, 2).Select(part => d.Benchamark(part))).OrderBy(x => x).ToList();

            var template = $@"
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class BenchmarksRunner
    {{
        private Y2021.Day1.Day1 day1;
{string.Join("\n", fields)}

        public BenchmarksRunner()
        {{
            var stub = new FakeTestOutputHelper();
            day1 = new Y2021.Day1.Day1(stub);
{string.Join("\n", instances)}
        }}

        [Benchmark(Description = ""Day 1 Part 1"")]
        public void D1()
        {{
            day1.Solution1();
        }}

        [Benchmark(Description = ""Day 1 Part 2"")]
        public void D2()
        {{
            day1.Solution1();
        }}

{string.Join("\n", benchamarks)}
    }}
}}";
            context.AddSource("benchamrksGenerator", SourceText.From(template, System.Text.Encoding.UTF8));
        }

        private string CreateInstances()
        {
            return "day21 = new Y2021.Day2.Part1(stub);";
        }

        private string GenerateFields()
        {
            return "private Y2021.Day2.Part1 day21;";
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}