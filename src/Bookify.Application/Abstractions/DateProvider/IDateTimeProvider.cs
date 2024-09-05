namespace Bookify.Application.Abstractions.DateProvider;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}