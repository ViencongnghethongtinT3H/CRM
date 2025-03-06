using FDS.CRM.Application.Company.DTOs;
namespace FDS.CRM.Application.Contact.Queries;

public class GetCompanyQuery : IQuery<ResultModel<List<GetCompanyQueryDto>>>
{
    public string? name { get; set; }
}

public class GetCompanyQueryHandler : IQueryHandler<GetCompanyQuery, ResultModel<List<GetCompanyQueryDto>>>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyQueryHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<ResultModel<List<GetCompanyQueryDto>>> HandleAsync(GetCompanyQuery query, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetCompanysAsync();
        var result = company.Where(p => p.Name == query.name)
            .Select(g => new GetCompanyQueryDto
            {
                Id = g.Id,
                Name = g.Name,
            }).ToList();
        return new ResultModel<List<GetCompanyQueryDto>>(result);
    }
}
