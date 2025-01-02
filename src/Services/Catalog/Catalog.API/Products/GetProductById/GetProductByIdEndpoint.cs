namespace Catalog.API.Products.GetProductById;

public class GetProductByIdEndpoint: CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            
            return Results.Ok(result);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdQuery>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("GetProductById")
        .WithDescription("GetProductById");
    }
}