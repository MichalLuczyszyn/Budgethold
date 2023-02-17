using Budgethold.Shared.Abstractions;

namespace Budgethold.Shared.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDateTime() => DateTime.UtcNow;
    public DateTimeOffset CurrentDateTimeOffset() => DateTimeOffset.UtcNow;
}