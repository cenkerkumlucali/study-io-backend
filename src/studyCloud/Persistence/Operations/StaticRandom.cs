namespace Persistence.Operations;

public static class StaticRandom
{
    private static int seed;

    private static ThreadLocal<Random?> threadLocal = new(() => new Random(Interlocked.Increment(ref seed)));

    static StaticRandom()
    {
        seed = Environment.TickCount;
    }

    public static Random? Instance => threadLocal.Value;
}