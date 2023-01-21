using Budgethold.Shared.Abstractions;

namespace Budgethold.Shared.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}