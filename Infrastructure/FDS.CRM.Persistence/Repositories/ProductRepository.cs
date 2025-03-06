namespace FDS.CRM.Persistence.Repositories;

public class ProductRepository : Repository<Product, Guid>, IProductRepository
{
    public ProductRepository(CrmDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
    {
    }

    public IQueryable<Product> Get(ProductsQueryOptions queryOptions)
    {
        var query = GetQueryableSet();
        if (string.IsNullOrEmpty(queryOptions.ProductName))
        {
            query = query.Where(x => x.Name == queryOptions.ProductName);
        }

        if (queryOptions.CategoryId is not null)
        {
            query = query.Where(x => x.CategoryId == queryOptions.CategoryId);
        }

        if (queryOptions.SupplierId is not null)
        {
            query = query.Where(x => x.SupplierId == queryOptions.SupplierId);
        }
        if (queryOptions.AsNoTracking)
        {
            query = query.AsNoTracking();
        }

        return query;

    }
}
