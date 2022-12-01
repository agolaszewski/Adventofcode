using Xunit.Abstractions;

namespace Benchmarks
{
    public class FakeTestOutputHelper : ITestOutputHelper
    {
        public void WriteLine(string message)
        {
        }

        public void WriteLine(string format, params object[] args)
        {
        }
    }
}