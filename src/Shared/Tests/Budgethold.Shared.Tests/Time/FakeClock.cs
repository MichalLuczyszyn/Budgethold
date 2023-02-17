namespace Budgethold.Shared.Tests.Time;

using Abstractions;

public sealed class FakeClock : IClock
{
    public DateTime CurrentDateTime() => new(2022, 4, 10, 6, 0, 0, DateTimeKind.Utc);
    public DateTimeOffset CurrentDateTimeOffset() => new(2022, 4, 10, 6, 0, 0, TimeSpan.Zero);
}