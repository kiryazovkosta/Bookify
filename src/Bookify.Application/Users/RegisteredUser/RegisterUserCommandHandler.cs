using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Application.Users.RegisteredUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly UserManager<User> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        UserManager<User> userManager, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User() { 
            UserName = request.Email, 
            Email = request.Email, 
            FirstName = new FirstName(request.FirstName), 
            LastName = new LastName(request.LastName), 
            EmailConfirmed = true };

        return user.Id;
    }
}