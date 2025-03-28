namespace FDS.CRM.Application.Supplier.Queries;

public class GetSupplierQuery : IQuery<ResultModel<SupplierDetailViewModel>>
{
    public Guid Id { get; set; }
}
internal class GetSupplierQueryHandler : IQueryHandler<GetSupplierQuery, ResultModel<SupplierDetailViewModel>>
{
    private readonly IRepository<Domain.Entities.Supplier, Guid> _supllierRepository;
    private readonly IMapper _mapper;
    public GetSupplierQueryHandler(IRepository<Domain.Entities.Supplier, Guid> supllierRepository, IMapper mapper)
    {   
        _supllierRepository = supllierRepository;
        _mapper = mapper;
    }
    public async Task<ResultModel<SupplierDetailViewModel>> HandleAsync(GetSupplierQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            var supplier = await _supllierRepository.SingleOrDefaultAsync(_supllierRepository.GetQueryableSet().Where(x => x.Id == query.Id));
            if (supplier is null)
            {
                throw new NotFoundException($"Product {query.Id} not found.");
            }
            var result = _mapper.Map<SupplierDetailViewModel>(supplier);
            

            return ResultModel<SupplierDetailViewModel>.Create(result);
        }
        catch (Exception ex)
        {
             return ResultModel<SupplierDetailViewModel>.Create(null, true, "Có lỗi xảy ra khi thao tác với DB", 400);
            //throw ex;
        }
       
        
    }
}
