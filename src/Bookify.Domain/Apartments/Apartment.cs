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
        Name = new Name(string.Empty);
        Description = new Description(string.Empty);
        Address = new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        Price = new Money(0, Currency.None);
        CleaningFee = new Money(0, Currency.None);
        Amenities = [];
    }

    public Name Name { get; init; }
    public Description Description { get; init; }
    public Address Address { get; init; }
    public Money Price { get; init; }
    public Money CleaningFee { get; init; }
    public DateTime? LastBookedOnUtc { get; internal set; }
    public List<Amenity> Amenities { get; init; }
}