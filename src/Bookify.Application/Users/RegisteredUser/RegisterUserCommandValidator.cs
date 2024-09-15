using FluentValidation;

namespace Bookify.Application.Users.RegisteredUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty");
        
        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty");
        
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email cannot be empty")
            .EmailAddress().WithMessage("Invalid email address");
        
        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(5).MaximumLength(16).WithMessage("Password must be between 5 and 16 characters");
    }
}