using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

class Program
{
    static void Main()
    {
        var summary = BenchmarkRunner.Run<PerformanceTest>();
    }
}

[MemoryDiagnoser]
public class PerformanceTest
{
    private const int Iterations = 100000;

    [Benchmark]
    public void RegularClassTest()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var obj = new RegularClass();
            obj.Compute();
        }
    }

    [Benchmark]
    public void StaticClassTest()
    {
        for (int i = 0; i < Iterations; i++)
        {
            StaticClass.Compute();
        }
    }

    [Benchmark]
    public void AbstractClassTest()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var obj = new DerivedAbstract();
            obj.Compute();
        }
    }

    [Benchmark]
    public void SealedClassTest()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var obj = new SealedClass();
            obj.Compute();
        }
    }

    [Benchmark]
    public void RecordClassTest()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var obj = new RecordClass(30);
            obj.Compute();
        }
    }

    [Benchmark]
    public void GenericClassTest()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var obj = new GenericClass<int>();
            obj.Compute();
        }
    }

    [Benchmark]
    public void SingletonClassTest()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var obj = Singleton.Instance;
            obj.Compute();
        }
    }
}

// 1. Regular Class
public class RegularClass
{
    public void Compute()
    {
        long sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += i * i;
    }
}

// 2. Static Class
public static class StaticClass
{
    public static void Compute()
    {
        long sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += i * i;
    }
}

// 3. Abstract Class & Derived
public abstract class AbstractClass
{
    public abstract void Compute();
}

public class DerivedAbstract : AbstractClass
{
    public override void Compute()
    {
        long sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += i * i;
    }
}

// 4. Sealed Class
public sealed class SealedClass
{
    public void Compute()
    {
        long sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += i * i;
    }
}

// 5. Record Class
public record RecordClass(int Age)
{
    public void Compute()
    {
        long sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += i * i;
    }
}

// 6. Generic Class
public class GenericClass<T>
{
    public void Compute()
    {
        long sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += i * i;
    }
}

// 7. Singleton Class
public sealed class Singleton
{
    private static readonly Lazy<Singleton> _instance = new(() => new Singleton());
    public static Singleton Instance => _instance.Value;
    private Singleton() { }

    public void Compute()
    {
        long sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += i * i;
    }
}
