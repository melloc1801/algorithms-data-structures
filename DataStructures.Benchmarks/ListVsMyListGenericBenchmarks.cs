using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DataStructures.Benchmarks
{
    public class ListVsMyListGenericBenchmarks
    {
        private const int N = 10;
        
        private readonly List<int> _list = new List<int>(new []{1,2, 3, 4});

        [GlobalSetup]
        public void Setup()
        {
            for (var i = 0; i < N; i++)
            {
                this._list.Add(i);
            }
        }
        
        [Benchmark]
        public void For()
        {
            for (var i = 0; i < N; i++)
            {
               this._list.Add(i);
            }
        }
    }
}