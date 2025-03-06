namespace FDS.CRM.Application.Product.Queries;

public class GetProductQuery : IQuery<Domain.Entities.Product>
{
    public Guid Id { get; set; }
    public bool IncludeCategory { get; set; }
    public bool IncludeSupplier { get; set; }
    public bool ThrowNotFoundIfNull { get; set; }
}
internal class GetProductQueryHandler : IQueryHandler<GetProductQuery, Domain.Entities.Product>
{
    private readonly IRepository<Domain.Entities.Product, Guid> _productRepository;

    public GetProductQueryHandler(IRepository<Domain.Entities.Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Domain.Entities.Product> HandleAsync(GetProductQuery query, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.FirstOrDefaultAsync(_productRepository.GetQueryableSet().Where(x => x.Id == query.Id));

        if (query.ThrowNotFoundIfNull && product == null)
        {
            throw new NotFoundException($"Product {query.Id} not found.");
        }

        return product;
    }
}
