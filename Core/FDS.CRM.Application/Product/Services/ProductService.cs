using FDS.CRM.Application.Common;
using FDS.CRM.Application.Common.Services;

namespace FDS.CRM.Application.Product.Services;

public class ProductService : CrudService<Domain.Entities.Product>, IProductService
{
    public ProductService(IRepository<Domain.Entities.Product, Guid> productRepository, Dispatcher dispatcher)
        : base(productRepository, dispatcher)
    {
    }
}
