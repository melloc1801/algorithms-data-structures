using BenchmarkDotNet.Running;

namespace DataStructures.Benchmarks;

public class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<ListVsMyListGenericBenchmarks>();
        Console.ReadKey();
    }
}