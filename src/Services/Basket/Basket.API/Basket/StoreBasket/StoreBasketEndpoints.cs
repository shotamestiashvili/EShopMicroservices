
namespace Basket.API.Basket.StoreBasket;

public record StoreBasketRequest(ShoppingCart Cart) : IRequest<ShoppingCart>;

public record StoreBasketResponse(string Username);

public class StoreBasketEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async  (StoreBasketRequest request, ISender Sender) =>
        {
            var command = request.Adapt<StoreBasketCommand>();
            var result = Sender.Send(command);
            var response = result.Adapt<StoreBasketResponse>();
            
            return Results.Created($"/basket/{response.Username}", response);
        })
        .WithName("CreateProduct")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}