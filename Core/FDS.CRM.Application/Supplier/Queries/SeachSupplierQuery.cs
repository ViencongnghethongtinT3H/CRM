using FDS.CRM.Application.Common.Services;

namespace FDS.CRM.Application.Supplier.Queries;

public class SeachSupplierQuery : BaseSearchQuery<Domain.Entities.Supplier, SearchSupplierResponse>
{
    public SeachSupplierQuery(SearchSupplierQueryParams queryParams) 
    {
        SearchRequest = queryParams.ToSearchRequest();
    }

    public override IQueryable<Domain.Entities.Supplier> AddIncludes(IQueryable<Domain.Entities.Supplier> query)
    {
        return query;
    }

    public override IOrderedQueryable<Domain.Entities.Supplier> ApplySort(IQueryable<Domain.Entities.Supplier> query, string sortField, bool isDescending)
    {
        return (sortField.ToLower(), isDescending) switch
        {
            ("createddatetime", true) => query.OrderByDescending(x => x.CreatedDateTime),
            ("name", true) => query.OrderByDescending(x => x.Name),
            _ => query.OrderByDescending(x => x.CreatedDateTime)
        };
    }

    public override Expression<Func<Domain.Entities.Supplier, bool>> GetFilterExpression(SearchCondition condition)
    {
        return condition switch
        {
            { Field: "name", Operator: "contains" } =>
                x => x.Name.Contains((string)condition.Value),

            { Field: "Status", Operator: "==" } =>
                x => (int)x.Status ==  int.Parse(condition.Value.ToString()),
            _ => null
        };
    }

    public override Expression<Func<Domain.Entities.Supplier, SearchSupplierResponse>> GetSelectExpression()
    {
        return supplier => new SearchSupplierResponse
        {
            Id = supplier.Id,
            Name = supplier.Name,
           Email = supplier.Email,
           Tax = supplier.Tax,
           Created = supplier.CreatedDateTime.LocalDateTime,
           StatusString = supplier.Status.GetDescription(),
        };
    }
}
public class SearchSupplierQueryHandler : BaseSearchQueryHandler<Domain.Entities.Supplier, SearchSupplierResponse, SeachSupplierQuery>
{
    public SearchSupplierQueryHandler(ICrudService<Domain.Entities.Supplier> crudService) : base(crudService)
    {
    }

    public override async Task<SearchResponseModel<SearchSupplierResponse>> HandleAsync(
       SeachSupplierQuery query,
       CancellationToken cancellationToken = default)
    {
        //    IQueryHandler<SeachSupplierQuery, SearchResponseModel<SearchSupplierResponse>> handler =
        //new SearchSupplierQueryHandler(_crudService);

        //    var result = await handler.HandleAsync(query, cancellationToken);
        var result =  await base.HandleAsync(query, cancellationToken);

        return result;
    }
}
