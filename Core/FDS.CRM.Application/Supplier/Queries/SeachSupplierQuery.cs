using FDS.CRM.Application.Common.Queries;
using FDS.CRM.Application.Contact.Queries;
using System.Linq.Expressions;

namespace FDS.CRM.Application.Supplier.Queries;

public class SeachSupplierQuery : BaseSearchQuery<Domain.Entities.Supplier, SupplierDto>
{
    public SeachSupplierQuery(SearchSupplierQueryParams queryParams) 
    {
        SearchRequest = queryParams.ToSearchRequest();
    }

    public override IQueryable<Domain.Entities.Supplier> AddIncludes(IQueryable<Domain.Entities.Supplier> query)
    {
        throw new NotImplementedException();
    }

    public override IOrderedQueryable<Domain.Entities.Supplier> ApplySort(IQueryable<Domain.Entities.Supplier> query, string sortField, bool isDescending)
    {
        throw new NotImplementedException();
    }

    public override Expression<Func<Domain.Entities.Supplier, bool>> GetFilterExpression(SearchCondition condition)
    {
        throw new NotImplementedException();
    }

    public override Expression<Func<Domain.Entities.Supplier, SupplierDto>> GetSelectExpression()
    {
        throw new NotImplementedException();
    }
}
public class SearchSupplierQueryHandler : BaseSearchQueryHandler<Domain.Entities.Supplier, SupplierDto, SeachSupplierQuery>
{
    public SearchSupplierQueryHandler(ICrudService<Domain.Entities.Supplier> crudService) : base(crudService)
    {
    }

    public override async Task<SearchResponseModel<SupplierDto>> HandleAsync(
       SeachSupplierQuery query,
       CancellationToken cancellationToken = default)
    {

    }
}
