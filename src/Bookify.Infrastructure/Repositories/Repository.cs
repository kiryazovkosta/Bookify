//using Bookify.Domain.Abstractions;
//using Microsoft.EntityFrameworkCore;

//namespace Bookify.Infrastructure.Repositories;

//internal abstract class Repository<T>
//    where T : Entity<TKey>
//{
//    protected readonly ApplicationDbContext DbContext;

//    protected Repository(ApplicationDbContext dbContext)
//    {
//        DbContext = dbContext;
//    }

//    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
//    {
//        return await DbContext
//            .Set<T>()
//            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
//    }

//    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
//    {
//        await DbContext
//            .Set<T>()
//            .AddAsync(entity, cancellationToken);
//    }
    
    
//}