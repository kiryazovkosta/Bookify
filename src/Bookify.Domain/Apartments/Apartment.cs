using Bookify.Domain.Abstractions;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Apartments;

public sealed class Apartment(
    Guid id,
    Name name,
    Description description,
    Address address,
    Money price,
    Money cleaningFee,
    List<Amenity> amenities) : Entity(id) 
{
    public required Name Name { get; init; } = name;
    public required Description Description { get; init; } = description;
    public required Address Address { get; init; } = address;
    public required Money Price { get; init; } = price;
    public required Money CleaningFee { get; init; } = cleaningFee;
    public DateTime? LastBookedOnUtc { get; internal set; }
    public List<Amenity> Amenities { get; init; } = amenities;
}