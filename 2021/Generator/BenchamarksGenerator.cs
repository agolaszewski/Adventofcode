using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Linq;

namespace Generator
{
    public class Day
    {
        private int _dayNo;
        private int _part;

        public Day(int dayNo, int part)
        {
            _dayNo = dayNo;
            _part = part;
        }

        public string Instance => $"day{_dayNo}{_part} = new Y2021.Day{_dayNo}.Part{_part}(stub);";

        public string Field => $"private Y2021.Day{_dayNo}.Part{_part} day{_dayNo}{_part};";

        public string Benchamark => $@"[Benchmark(Description = ""Day {_dayNo} Part {_part}"")] public void D{_dayNo}{_part}() {{ day{_dayNo}{_part}.Solution(); }}";
    }

    [Generator]
    public class BenchamarksGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var days = new List<Day>();

            IAssemblySymbol assemblySymbol = context.Compilation.SourceModule.ReferencedAssemblySymbols.First(q => q.Name == "Y2021");
            var namepsace = assemblySymbol.GlobalNamespace.GetNamespaceMembers().First(n => n.Name == "Y2021");
            var members = namepsace.GetNamespaceMembers().ToList();
            foreach (var member in members)
            {
                var dayNo = member.Name.Substring(member.Name.LastIndexOf("Day") + 3).Trim();
                var parts = member.GetTypeMembers().Where(m => m.Name.Contains("Part"));
                var partsNo = parts.Select(part => part.Name.Substring(part.Name.LastIndexOf("Part") + 4)).ToList();
                partsNo.ForEach(part =>
                {
                    days.Add(new Day(int.Parse(dayNo), int.Parse(part)));
                });
            }

            var fields = days.Select(day => day.Field);
            var instances = days.Select(day => day.Instance);
            var benchamarks = days.Select(day => day.Benchamark);

            var template = $@"
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class BenchmarksRunner
    {{
{string.Join("\n", fields)}

        public BenchmarksRunner()
        {{
            var stub = new FakeTestOutputHelper();
{string.Join("\n", instances)}
        }}

{string.Join("\n", benchamarks)}
    }}
}}";
            context.AddSource("BenchmarksRunner.cs", SourceText.From(template, System.Text.Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}