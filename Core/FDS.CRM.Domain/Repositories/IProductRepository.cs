namespace FDS.CRM.Domain.Repositories;

public class ProductsQueryOptions
{
    public string? ProductName { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? SupplierId { get; set; }
    public bool AsNoTracking { get; set; }
}

public interface IProductRepository : IRepository<Product, Guid>
{
    IQueryable<Product> Get(ProductsQueryOptions queryOptions);
}
