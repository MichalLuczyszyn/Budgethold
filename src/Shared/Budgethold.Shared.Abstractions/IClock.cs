namespace Budgethold.Shared.Abstractions;

public interface IClock
{
    DateTime CurrentDateTime();
    DateTimeOffset CurrentDateTimeOffset();
}