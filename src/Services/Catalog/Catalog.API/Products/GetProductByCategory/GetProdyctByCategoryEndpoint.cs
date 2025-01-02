namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryResponse(IEnumerable<Product> Products);

public class GetProductByCategoryEndpoint: CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender Sender) =>
        {
            var result = await Sender.Send(new GetProdyctByCategoryQuery(category));

            var response = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);
        })
            .WithName("GetProductByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("GetProductByCategory")
        .WithDescription("GetProductByCategory");
    }
}