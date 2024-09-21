using Bookify.Application.Abstractions.DateProvider;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Bookify.Domain.Reviews;

namespace Bookify.Application.Reviews.AddReview;

public class AddReviewCommandHandler : ICommandHandler<AddReviewCommand>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddReviewCommandHandler(
        IBookingRepository bookingRepository, 
        IReviewRepository reviewRepository, 
        IUnitOfWork unitOfWork, 
        IDateTimeProvider dateTimeProvider)
    {
        _bookingRepository = bookingRepository;
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(request.BookingId, cancellationToken);
        if (booking is null)
        {
            return Result.Failure(BookingErrors.NotFound);
        }

        var ratingResult = Rating.Create(request.Rating);
        if (ratingResult.IsFailure)
        {
            return Result.Failure(ratingResult.Error);
        }

        var reviewResult = Review.Create(
            booking,
            ratingResult.Value ?? throw new InvalidOperationException(),
            new Comment(request.Comment),
            _dateTimeProvider.UtcNow);
        if (reviewResult.IsFailure)
        {
            return Result.Failure(reviewResult.Error);
        }

        await _reviewRepository.AddAsync(reviewResult.Value!, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}