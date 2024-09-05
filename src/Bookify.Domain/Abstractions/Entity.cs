namespace Bookify.Domain.Abstractions;

public abstract class Entity(Guid id) : IEquatable<Entity>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public Guid Id { get; init; } = id;

    public bool Equals(Entity? other)
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

        return obj is Entity entity && entity.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 1914;
    }
    
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    
    public void ClearDomainEvents() => _domainEvents.Clear();
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}