namespace Bookify.Application.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }

    DateTime Today { get; }
}