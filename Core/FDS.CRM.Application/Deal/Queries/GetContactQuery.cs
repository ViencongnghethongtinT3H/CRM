using FDS.CRM.Application.Deal.DTOs;

namespace FDS.CRM.Application.Deal.Queries;

public class GetDealQuery : IQuery<ResultModel<List<GetDealQueryDto>>>
{
    public string? name { get; set; }
}

public class GetDealQueryHandler : IQueryHandler<GetDealQuery, ResultModel<List<GetDealQueryDto>>>
{
    private readonly IDealRepository _DealRepository;

    public GetDealQueryHandler(IDealRepository DealRepository)
    {
        _DealRepository = DealRepository;
    }

    public async Task<ResultModel<List<GetDealQueryDto>>> HandleAsync(GetDealQuery query, CancellationToken cancellationToken)
    {
        var Deal = await _DealRepository.GetDealsAsync();
        var result = Deal.Where(p=>p.Title == query.name)
            .Select(g => new GetDealQueryDto
            {
                Id = g.Id,
                Name = g.Title,
            }).ToList();
        return new ResultModel<List<GetDealQueryDto>>(result);
    }
}
