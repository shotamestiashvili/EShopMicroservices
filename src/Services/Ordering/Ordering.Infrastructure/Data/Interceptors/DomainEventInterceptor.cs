using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Domain.Abstraction;

namespace Ordering.Infrastructure.Data.Interceptors;

public class DomainEventInterceptor(IMediator mediator)
    : SaveChangesInterceptor
{
    public override async  ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        DispatchDomainEvents(eventData.Context, result).GetAwaiter().GetResult();
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context, result).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    private async Task DispatchDomainEvents(DbContext? dbContext, InterceptionResult<int> result)
    {
        if (dbContext == null) return;
        
        var aggregates = dbContext.ChangeTracker
            .Entries<IAggregate>()
            .Where(a => a.Entity.DomainEvents.Any())
            .Select(a => a.Entity);

        var domainEvents = aggregates.
            SelectMany(a => a.DomainEvents)
            .ToList();
        
        aggregates.ToList().ForEach(a => a.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
            
    }
}