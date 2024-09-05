using FluentValidation;

namespace Bookify.Application.Bookings.ReserveBooking;

public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
{
    public ReserveBookingCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty().WithMessage("UserId cannot be empty");
        
        RuleFor(c => c.ApartmentId).NotEmpty().WithMessage("ApartmentId cannot be empty");
        
        RuleFor(c => c.StartDate).LessThan(c => c.EndDate).WithMessage("StartDate cannot be greater than EndDate");
    }
}