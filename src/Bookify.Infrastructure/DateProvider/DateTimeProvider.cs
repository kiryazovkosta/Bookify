using Bookify.Application.Abstractions.DateProvider;

namespace Bookify.Infrastructure.DateProvider;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}