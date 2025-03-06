namespace FDS.CRM.Application.Product.Queries;

public class GetPagedRelationQuery : IQuery<ResultModel<List<RelationsDto>>>
{
    public Guid Id { get; set; }
}
public class RelationQueryValidator
{
    public static void Validate(GetPagedRelationQuery request)
    {
        ValidationException.NotNullOrWhiteSpace(request.Id.ToString(), "Id không được để trống.");
    }
}
internal class GetPagedRelationQueryHandler : IQueryHandler<GetPagedRelationQuery,ResultModel<List<RelationsDto>>>
{
    private readonly IRepository<Domain.Entities.Contact, Guid> _contactRepository;
    private readonly IRepository<Domain.Entities.OrderConfig, Guid> _orderRepository;
    private readonly IRepository<Quotes, Guid> _quoteRepository;
    private readonly IRepository<Domain.Entities.Company, Guid> _companyRepository;
    private readonly IRepository<Domain.Entities.Ticket, Guid> _ticketRepository;
    private readonly IRepository<Domain.Entities.Deal, Guid> _dealRepository;
    private readonly IRepository<Domain.Entities.ContactRelation, Guid> _contactRelationRepo;
    private readonly IRepository<Domain.Entities.CompanyRelation, Guid> _companyRelationRepo;
    private readonly IRepository<Domain.Entities.TicketRelation, Guid> _ticketRelationRepo;
    private readonly IRepository<Domain.Entities.DealRelation, Guid> _dealRelationRepo;
    private readonly IRepository<Domain.Entities.OrderRelation, Guid> _orderRelationRepo;
    private readonly IRepository<Domain.Entities.QuoreRelation, Guid> _quoreRelationRepo;

    public GetPagedRelationQueryHandler(
        IRepository<Domain.Entities.Contact,
        Guid> contactRepository,
        IRepository<Domain.Entities.OrderConfig, Guid> orderRepository,
        IRepository<Domain.Entities.Quotes, Guid> quoteRepository,
        IRepository<Domain.Entities.Company, Guid> companyRepository,
        IRepository<Domain.Entities.Ticket, Guid> ticketRepository,
        IRepository<Domain.Entities.Deal, Guid> dealRepository,
        IRepository<Domain.Entities.ContactRelation, Guid> contactRelationRepo,
        IRepository<CompanyRelation, Guid> companyRelationRepo,
        IRepository<TicketRelation, Guid> ticketRelationRepo,
        IRepository<DealRelation, Guid> dealRelationRepo,
        IRepository<OrderRelation, Guid> orderRelationRepo,
        IRepository<QuoreRelation, Guid> quoreRelationRepo)
    {
        _contactRepository = contactRepository;
        _orderRepository = orderRepository;
        _quoteRepository = quoteRepository;
        _companyRepository = companyRepository;
        _ticketRepository = ticketRepository;
        _dealRepository = dealRepository;
        _contactRelationRepo = contactRelationRepo;
        _companyRelationRepo = companyRelationRepo;
        _ticketRelationRepo = ticketRelationRepo;
        _dealRelationRepo = dealRelationRepo;
        _orderRelationRepo = orderRelationRepo;
        _quoreRelationRepo = quoreRelationRepo;
    }

    public async Task<ResultModel<List<RelationsDto>>> HandleAsync(GetPagedRelationQuery query, CancellationToken cancellationToken = default)
    {
        RelationQueryValidator.Validate(query);
        var companyRelations = _companyRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id);
        var orderRelations = _orderRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id);
        var dealRelations = _dealRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id);
        var ticketRelations = _ticketRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id);
        var contactRelations = _contactRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id);
        var quetoRelations = _quoreRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id);
        List<RelationsDto> resultQuery = new List<RelationsDto>();

        if (companyRelations.Any())
        {
            var subQuery = from a in _companyRepository.GetQueryableSet()
                           join b in companyRelations on a.Id equals b.CompanyId 
                           select new RelationsDto
                           {
                               ObjectId = a.Id,
                               RelationshipId = a.Id,
                               OwnerId = a.CompanyOwnerId,
                               CompanyType = a.CompanyType,
                               Name = a.Name,
                               RelationshipType = b.RelationshipType,
                               OwnerName = a.User.FullName,
                               Website = a.Website,
                               TaxCode = a.TaxCode,
                               AnnualRevenue = a.AnnualRevenue,
                               CommonName = a.CommonSetting.Name,
                               PhoneNumber = a.User.PhoneNumber,
                               Email = a.User.Email,

                           };
            resultQuery.AddRange(subQuery);
        }

        if (dealRelations.Any())
        {
            var subQuery = from a in _dealRepository.GetQueryableSet()
                           join b in dealRelations on a.Id equals b.DealId
                           select new RelationsDto
                           {
                               ObjectId = a.Id,
                               RelationshipId = a.Id,
                               Title = a.Title,
                               Amount = a.Amount,
                               CloseDate = a.CloseDate,
                               RelationshipType = b.RelationshipType,

                           };
            resultQuery.AddRange(subQuery);
        }

        if (orderRelations.Any())
        {
            var subQuery = from a in _orderRepository.GetQueryableSet()
                           join b in orderRelations on a.Id equals b.OrderId 
                           select new RelationsDto
                           {
                               ObjectId = a.Id,
                               RelationshipId = a.Id,
                               BankName = a.BankName,
                               SendEmailType = a.SendEmailType,
                               AccountName = a.AccountName,
                               AccountNumber = a.AccountNumber,
                               AllowPayment = a.AllowPayment,
                               ContractId = a.ContactId,
                               RelationshipType = b.RelationshipType,

                           };
             resultQuery.AddRange(subQuery);
        }

        if (contactRelations.Any())
        {
            var subQuery = from a in _contactRepository.GetQueryableSet()
                           join b in contactRelations on a.Id equals b.ContactId 
                           select new RelationsDto
                           {
                               ObjectId = a.Id,
                               RelationshipId = a.Id,
                               Name = a.Name,
                               Code = a.Code,
                               RelationshipType = b.RelationshipType,
                               PositionId = a.PositionId,
                               OwnerName = a.User.FullName,
                               OwnerId = a.ContactOwnerId,
                               PositionName = a.Position.Title,
                               JobTitle = b.JobTitle,
                               Email = a.User.Email,
                               CommonName = a.CommonSetting.Name,
                               PhoneNumber = a.User.PhoneNumber

                           };

            resultQuery.AddRange(subQuery);
        }
        if (ticketRelations.Any())
        {
            var subQuery = from a in _ticketRepository.GetQueryableSet()
                           join b in ticketRelations on a.Id equals b.TicketId 
                           select new RelationsDto
                           {
                               ObjectId = a.Id,
                               RelationshipId = a.Id,
                               CloseDate = a.ClosedDate,
                               Name = a.Name,
                               Code = a.Code,
                               RelationshipType = b.RelationshipType,

                           };
            resultQuery.AddRange(subQuery);
        }
        if (quetoRelations.Any())
        {
            var subQuery = from a in _quoteRepository.GetQueryableSet()
                           join b in quetoRelations on a.Id equals b.QuoreId 
                           select new RelationsDto
                           {
                               ObjectId = a.Id,
                               RelationshipId = a.Id,
                               Name = a.Name,
                               Code = a.Code,
                               RelationshipType = b.RelationshipType,

                           };
            resultQuery.AddRange(subQuery);
        }

        return new ResultModel<List<RelationsDto>>(resultQuery);

    }
}
