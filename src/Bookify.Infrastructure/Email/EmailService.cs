using Bookify.Application.Abstractions.Email;

namespace Bookify.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendEmailAsync(string recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}