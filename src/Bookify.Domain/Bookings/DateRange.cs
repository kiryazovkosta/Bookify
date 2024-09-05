namespace Bookify.Domain.Bookings;

public record DateRange
{
    private DateRange()
    {
    }
    
    public DateOnly Start { get; init; }
    
    public DateOnly End { get; init; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ArgumentException("Start must be before end", nameof(start));
        }
        
        return new DateRange()
        {
            Start = start, 
            End = end
        };
    }
}