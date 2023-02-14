using BenchmarkDotNet.Attributes;

namespace DataStructures.Benchmark;

public class MyListGenericBenchmarks
{
    private readonly List<int> list = new List<int>();
    private readonly MyList<int> myList = new MyList<int>();

    [Params(1000, 10000)] public int N;

    [Benchmark]
    public void FillList()
    {
        for (int i = 0; i < N; i++)
        {
            list.Add(i);
        }
    }
    [Benchmark]
    public void FillMyList()
    {
        for (int i = 0; i < N; i++)
        {
            myList.Add(i);
        }
    }
}