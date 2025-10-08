using BenchmarkDotNet.Running;
using floatbench.Tests;

public class Program
{
    public static void Main()
    {
        _= BenchmarkRunner.Run<BenchmarkTests>();
    }
}