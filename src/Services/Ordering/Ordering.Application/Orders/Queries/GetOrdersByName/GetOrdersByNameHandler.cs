using BuildingBlocks.CQRS;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrdersByNameHandler (IApplicationDbContext _dbContext)
    : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
{
    public Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        var order = await _dbContext.Orders
            .Include()
        throw new NotImplementedException();
    }
}