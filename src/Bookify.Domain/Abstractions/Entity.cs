namespace Bookify.Domain.Abstractions;

public abstract class Entity<T> : IEntity<T>, IEquatable<Entity<T>> 
    where T : IEquatable<T>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(T id)
    {
        Id = id;
    }

    public T Id { get; init; }

    public bool Equals(Entity<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        return other.GetType() == GetType() && other.Id.Equals(Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return obj is Entity<T> entity && entity.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 1914;
    }
    
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    
    public void ClearDomainEvents() => _domainEvents.Clear();
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}