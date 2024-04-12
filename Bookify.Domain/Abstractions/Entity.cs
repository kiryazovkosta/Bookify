namespace Bookify.Domain.Abstractions;

public abstract class Entity : IEquatable<Entity>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public Guid Id { get; init; }

    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        var entity = obj as Entity;
        return entity is not null && Equals(entity);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return this._domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        this._domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        this._domainEvents.Add(domainEvent);
    }
}