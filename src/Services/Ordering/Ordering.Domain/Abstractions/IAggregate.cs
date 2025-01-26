namespace Ordering.Domain.Abstractions;

public interface IAggregate<T> : IEntity<T>
{
}

public interface IAggregate : IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}