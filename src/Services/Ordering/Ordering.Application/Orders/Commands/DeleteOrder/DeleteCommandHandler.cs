using BuildingBlocks.CQRS;
using MapsterMapper;
using Ordering.Application.Data;
using Ordering.Application.Exceptions;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = command.OrderId;
        var order = await dbContext.Orders.FindAsync([orderId], cancellationToken: cancellationToken);

        if (order is null)
        {
            throw new OrderNotFoundException(command.OrderId);
        }
        
        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteOrderResult(true);
    }
}