namespace Bookify.Infrastructure.Email;

using Application.Abstractions.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email email, string subject, string body)
    {
        return Task.CompletedTask;
    }
}