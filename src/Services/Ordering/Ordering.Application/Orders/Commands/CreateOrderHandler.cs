using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands;

public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // create order
        //save to db
        //return resutl
        
        throw new NotImplementedException();
    }
}