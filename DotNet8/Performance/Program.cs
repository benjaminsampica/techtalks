// See the entire thing: https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-8/
// Chart benchmarkdotnet: https://chartbenchmark.net/

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

var config = DefaultConfig.Instance
    .AddJob(Job.Default.WithId(".NET 7").WithRuntime(CoreRuntime.Core70).AsBaseline())
    .AddJob(Job.Default.WithId(".NET 8").WithRuntime(CoreRuntime.Core80));

BenchmarkSwitcher.FromAssembly(typeof(ListsTests).Assembly).Run(args, config);


[HideColumns("Error", "StdDev", "Median", "RatioSD", "EnvironmentVariables", "Runtime")]
public class ListsTests
{
    private readonly IEnumerable<int> _source = GetItems(1024);
    private readonly List<int> _list = new();

    [Benchmark]
    public void AddRange()
    {
        _list.Clear();
        _list.AddRange(_source);
    }

    private static IEnumerable<int> GetItems(int count)
    {
        for (int i = 0; i < count; i++) yield return i;
    }
}

[HideColumns("Error", "StdDev", "Median", "RatioSD")]
public class LINQTests
{
    private readonly IEnumerable<int> _source = Enumerable.Range(0, 1024).ToArray();

    [Benchmark]
    public List<int> SelectToList() => _source.Select(i => i * 2).ToList();

    [Benchmark]
    public List<byte> RepeatToList() => Enumerable.Repeat((byte)'a', 1024).ToList();

    [Benchmark]
    public List<int> RangeSelectToList() => Enumerable.Range(0, 1024).Select(i => i * 2).ToList();
}
