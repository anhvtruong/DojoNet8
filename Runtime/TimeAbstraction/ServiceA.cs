using System.Diagnostics;

namespace TimeAbstraction;

public class ServiceA(TimeProvider timeProvider)
{
    public async Task MethodAThen(CancellationToken cancellationToken = default)
    {
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
        DateTimeOffset localNow = DateTimeOffset.Now;

        await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);

        await MethodB().WaitAsync(TimeSpan.FromSeconds(3), cancellationToken);

        long start = Stopwatch.GetTimestamp();
        // Code to measure
        await MethodB();
        TimeSpan period = Stopwatch.GetElapsedTime(start);
    }

    public async Task MethodA(CancellationToken cancellationToken = default)
    {
        DateTimeOffset utcNow = timeProvider.GetUtcNow();
        DateTimeOffset localNow = timeProvider.GetLocalNow();

        await Task.Delay(TimeSpan.FromSeconds(3), timeProvider, cancellationToken);

        await MethodB().WaitAsync(TimeSpan.FromSeconds(3), timeProvider, cancellationToken);

        long start = timeProvider.GetTimestamp();
        // Code to measure
        await MethodB();
        TimeSpan period = timeProvider.GetElapsedTime(start);
    }

    public async Task MethodB()
    {
        await Task.Delay(TimeSpan.FromSeconds(30));
    }
}
