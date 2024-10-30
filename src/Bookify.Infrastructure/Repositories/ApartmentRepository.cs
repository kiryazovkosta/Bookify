using Bookify.Domain.Apartments;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories;

internal sealed  class ApartmentRepository : IApartmentRepository
{
    private readonly ApplicationDbContext _context;

    public ApartmentRepository(ApplicationDbContext context) 
    {
        _context = context;
    }

    public async Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context
            .Set<Apartment>()
            .FirstOrDefaultAsync(apartment => apartment.Id == id, cancellationToken);
    }
}