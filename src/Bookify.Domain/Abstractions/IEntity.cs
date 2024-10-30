namespace Bookify.Domain.Abstractions;

public interface IEntity<T> 
    where T : IEquatable<T>
{
    T Id { get; }
}
