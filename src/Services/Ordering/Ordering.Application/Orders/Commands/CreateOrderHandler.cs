using BuildingBlocks.CQRS;
using MapsterMapper;
using Ordering.Application.Data;

namespace Ordering.Application.Orders.Commands;

public class CreateOrderHandler (IApplicationDbContext dbContext, IMapper mapper)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // create order
        //save to db
        //return resutl
        
        throw new NotImplementedException();
    }
}