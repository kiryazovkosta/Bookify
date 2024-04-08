namespace Bookify.Infrastructure.Repositories;

using Domain.Apartments;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext) 
        : base(dbContext)
    {
    }
}