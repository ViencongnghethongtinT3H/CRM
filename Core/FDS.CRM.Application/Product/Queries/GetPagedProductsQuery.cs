using FDS.CRM.Application.Common.DTOs;
using FDS.CRM.Application.Product.DTOs;

namespace FDS.CRM.Application.Product.Queries;

public class GetPagedProductsQuery : ProductsQueryOptions, IQuery<Paged<ProductEntryDto>>
{
    public int Page { get; set; }

    public int PageSize { get; set; }
}

internal class GetPagedAuditEntriesQueryHandler : IQueryHandler<GetPagedProductsQuery, Paged<ProductEntryDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IRepository<Domain.Entities.Category, Guid> _categoryRepository;
    private readonly IRepository<Supplier, Guid> _supplierRepository;

    public GetPagedAuditEntriesQueryHandler(IProductRepository productRepository, IRepository<Domain.Entities.Category, Guid> categoryRepository,
        IRepository<Supplier, Guid> supplierRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _supplierRepository = supplierRepository;
    }

    public async Task<Paged<ProductEntryDto>> HandleAsync(GetPagedProductsQuery queryOptions, CancellationToken cancellationToken = default)
    {
        var productQuery = _productRepository.Get(queryOptions);
        var categoryQuery = _categoryRepository.GetQueryableSet();
        var supplierQuery = _supplierRepository.GetQueryableSet();

        var result = new Paged<ProductEntryDto>
        {
            TotalItems = productQuery.Count(),
        };

        var products = productQuery.OrderByDescending(x => x.CreatedDateTime)
            .Paged(queryOptions.Page, queryOptions.PageSize);

        var query = from p in productQuery
                    join c in categoryQuery on p.CategoryId equals c.Id into pc
                    from c in pc.DefaultIfEmpty() // Left join để tránh null reference
                    join s in supplierQuery on p.SupplierId equals s.Id into ps
                    from s in ps.DefaultIfEmpty() // Left join để tránh null reference
                    orderby p.CreatedDateTime descending
                    select new ProductEntryDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        CategoryName = c != null ? c.Name : string.Empty,
                        SuppilerName = s != null ? s.Name : string.Empty,
                        BasePrice = p.BasePrice,
                        SalePrice = p.SalePrice,
                        StockQuantity = p.StockQuantity
                    };
        result.Items = await _productRepository.ToListAsync(query);

        return result;
    }
}
