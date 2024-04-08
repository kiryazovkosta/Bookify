namespace Bookify.Infrastructure.Repositories;

using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

internal abstract class Repository<T>
    where T : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await DbContext.AddAsync(entity, cancellationToken);
    }
}