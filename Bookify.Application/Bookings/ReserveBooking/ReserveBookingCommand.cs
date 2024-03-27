namespace Bookify.Application.Bookings.ReserveBooking;

using Abstractions.Messaging;

public sealed record ReserveBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;