﻿namespace Ordering.Domain.Abstraction;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeudEvents = _domainEvents.ToArray();
        
        _domainEvents.Clear();
        
        return dequeudEvents;
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IDomainEvent[] GetDomainEvents()
    {
        return _domainEvents.ToArray();
    }
}