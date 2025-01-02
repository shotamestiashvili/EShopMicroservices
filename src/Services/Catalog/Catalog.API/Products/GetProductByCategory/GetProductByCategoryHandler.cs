namespace Catalog.API.Products.GetProductByCategory;

public record GetProdyctByCategoryQuery(string CategoryName) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger) 
    : IQueryHandler<GetProdyctByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProdyctByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.CategoryName))
            .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}