using Bookify.Domain.Abstractions;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Apartments;

public sealed class Apartment : Entity
{
    public Apartment(
        Guid id,
        Name name, 
        Description 
        description, 
        Address address, 
        Money price, 
        Money cleaningFee, 
        DateTime? lastBookedOnUtc, 
        List<Amenity> amenities)
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        LastBookedOnUtc = lastBookedOnUtc;
        Amenities = amenities;
    }

    private Apartment()
    {
    }

    public required Name Name { get; init; }
    public required Description Description { get; init; }
    public required Address Address { get; init; }
    public required Money Price { get; init; }
    public required Money CleaningFee { get; init; }
    public DateTime? LastBookedOnUtc { get; internal set; }
    public List<Amenity> Amenities { get; init; }
}