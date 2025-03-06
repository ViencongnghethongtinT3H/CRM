namespace FDS.CRM.Application.Contact.Queries;

public class GetContactQuery : IQuery<ResultModel<List<GetContactQueryDto>>>
{
    public string? Name { get; set; }
}

public class GetContactQueryHandler : IQueryHandler<GetContactQuery, ResultModel<List<GetContactQueryDto>>>
{
    private readonly IContactRepository _contactRepository;

    public GetContactQueryHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ResultModel<List<GetContactQueryDto>>> HandleAsync(GetContactQuery query, CancellationToken cancellationToken)
    {
        var contacts = await _contactRepository.GetContactsAsync();
        var queryContact = contacts.Where(p => p.Name == query.Name)
            .Select(g => new GetContactQueryDto
            {
                Id = g.Id,
                Name = g.Name,
            }).ToList();
        var result = new ResultModel<List<GetContactQueryDto>>(queryContact);

        return result;
    }
}
