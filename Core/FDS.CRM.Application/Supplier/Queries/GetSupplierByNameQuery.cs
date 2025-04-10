namespace FDS.CRM.Application.Supplier.Queries;

public class GetSupplierByNameQuery : IQuery<ResultModel<List<BaseGetNameDto>>>
{
    public string? Name { get; set; }
}

public class GetSupplierByNameQueryHandler : IQueryHandler<GetSupplierByNameQuery, ResultModel<List<BaseGetNameDto>>>
{
    private readonly IRepository<Domain.Entities.Supplier, Guid> _supplierRepository;

    public GetSupplierByNameQueryHandler(IRepository<Domain.Entities.Supplier, Guid> supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<ResultModel<List<BaseGetNameDto>>> HandleAsync(GetSupplierByNameQuery query, CancellationToken cancellationToken)
    {
        // Trả ra bảng supplier
        var supplierQuery = _supplierRepository.GetQueryableSet();

        if (!string.IsNullOrEmpty(query.Name))
        {
            supplierQuery = supplierQuery.Where(x => x.Name.Contains(query.Name));
        }
        else
        {
            supplierQuery = supplierQuery.Take(5);
        }

        var supplier = await supplierQuery.Select(g => new BaseGetNameDto
        {
            Id = g.Id,
            Name = g.Name,
            // Avatar = string.IsNullOrEmpty(g.Name) ? CrossCuttingConcerns.Helper.StringHelpers.GetRandomColor() : g.Name
            Avatar = CrossCuttingConcerns.Helper.StringHelpers.GetRandomColor()
        }).ToListAsync();

        return new ResultModel<List<BaseGetNameDto>>(supplier);
    }
}