namespace FDS.CRM.Application.RelationManager.Queries;

public class GetManagerRealtionQuery : IQuery<ResultModel<List<RelationsDto>>>
{
    public Guid Id { get; set; }
    public RelationshipType RelationshipType { get; set; }
}
public class AddUpdateRelationValidator
{
    public static void Validate(GetManagerRealtionQuery request)
    {
        ValidationException.NotNullOrWhiteSpace(request.Id.ToString(), "Id không được để trống.");
        ValidationException.NotNullOrWhiteSpace(request.RelationshipType.ToString(), "RelationshipType không được để trống.");
    }
}
internal class GetRelationQueryHandler : IQueryHandler<GetManagerRealtionQuery, ResultModel<List<RelationsDto>>>
{
    private readonly IRepository<Domain.Entities.Contact, Guid> _contactRepository;
    private readonly IRepository<Domain.Entities.OrderConfig, Guid> _orderRepository;
    private readonly IRepository<Domain.Entities.Quotes, Guid> _quoteRepository;
    private readonly IRepository<Domain.Entities.Company, Guid> _companyRepository;
    private readonly IRepository<Domain.Entities.Ticket, Guid> _ticketRepository;
    private readonly IRepository<Domain.Entities.Deal, Guid> _dealRepository;
    private readonly IRepository<Domain.Entities.ContactRelation, Guid> _contactRelationRepo;
    private readonly IRepository<Domain.Entities.CompanyRelation, Guid> _companyRelationRepo;
    private readonly IRepository<Domain.Entities.TicketRelation, Guid> _ticketRelationRepo;
    private readonly IRepository<Domain.Entities.DealRelation, Guid> _dealRelationRepo;
    private readonly IRepository<Domain.Entities.OrderRelation, Guid> _orderRelationRepo;
    private readonly IRepository<Domain.Entities.QuoreRelation, Guid> _quoreRelationRepo;


    public GetRelationQueryHandler(IRepository<Domain.Entities.Contact, Guid> contactRepository,
        IRepository<Domain.Entities.OrderConfig, Guid> orderRepository,
        IRepository<Domain.Entities.Company, Guid> companyRepository,
        IRepository<Domain.Entities.Ticket, Guid> ticketRepository,
        IRepository<Domain.Entities.Deal, Guid> dealRepository,
        IRepository<Domain.Entities.ContactRelation, Guid> contactRelationRepo,
        IRepository<CompanyRelation, Guid> companyRelationRepo,
        IRepository<TicketRelation, Guid> ticketRelationRepo,
        IRepository<DealRelation, Guid> dealRelationRepo,
        IRepository<OrderRelation, Guid> orderRelationRepo,
        IRepository<QuoreRelation, Guid> quoreRelationRepo,
        IRepository<Quotes, Guid> quoreRepository)
    {
        _contactRepository = contactRepository;
        _orderRepository = orderRepository;
        _companyRepository = companyRepository;
        _ticketRepository = ticketRepository;
        _dealRepository = dealRepository;
        _contactRelationRepo = contactRelationRepo;
        _companyRelationRepo = companyRelationRepo;
        _ticketRelationRepo = ticketRelationRepo;
        _dealRelationRepo = dealRelationRepo;
        _orderRelationRepo = orderRelationRepo;
        _quoreRelationRepo = quoreRelationRepo;
        _quoteRepository = quoreRepository;
    }

    public async Task<ResultModel<List<RelationsDto>>> HandleAsync(GetManagerRealtionQuery query, CancellationToken cancellationToken)
    {
        AddUpdateRelationValidator.Validate(query);
        var result = new List<RelationsDto>();
        if (query.RelationshipType == RelationshipType.Contact)
        {
            var contactRelations = _contactRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id && p.RelationshipType == RelationshipType.Contact);
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
                result.AddRange(subQuery);
            }
        }
        if (query.RelationshipType == RelationshipType.Order)
        {
            var orderRelations = _orderRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id && p.RelationshipType == RelationshipType.Order);
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
                result.AddRange(subQuery);
            }
        }
        if (query.RelationshipType == RelationshipType.Company)
        {
            var companyRelations = _companyRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id && p.RelationshipType == RelationshipType.Company);
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
                result.AddRange(subQuery);
            }
        }

        else if (query.RelationshipType == RelationshipType.Deal)
        {
            var dealRelations = _dealRelationRepo.GetQueryableSet().Where(p => p.RelationId == query.Id && p.RelationshipType == RelationshipType.Deal);
            if (dealRelations.Any())
            {
                var subQuery = from a in _dealRepository.GetQueryableSet()
                               join b in dealRelations on a.Id equals b.RelationId
                               select new RelationsDto
                               {
                                   ObjectId = a.Id,
                                   RelationshipId = a.Id,
                                   Title = a.Title,
                                   Amount = a.Amount,
                                   CloseDate = a.CloseDate,
                                   RelationshipType = b.RelationshipType,

                               };
                result.AddRange(subQuery);
            }
        }

        else if (query.RelationshipType == RelationshipType.Ticket)
        {
            var ticketRelations = _ticketRelationRepo.GetQueryableSet().Where(p => p.TicketId == query.Id && p.RelationshipType == RelationshipType.Ticket);
            if (ticketRelations.Any())
            {
                var subQuery = from a in _ticketRepository.GetQueryableSet()
                               join b in ticketRelations on a.Id equals b.RelationId
                               select new RelationsDto
                               {
                                   ObjectId = a.Id,
                                   RelationshipId = a.Id,
                                   CloseDate = a.ClosedDate,
                                   Name = a.Name,
                                   Code = a.Code,
                                   RelationshipType = b.RelationshipType,

                               };
                result.AddRange(subQuery);
            }
        }
        else if (query.RelationshipType == RelationshipType.Quore)
        {
            var quoreRelations = _quoreRelationRepo.GetQueryableSet().Where(p => p.QuoreId == query.Id && p.RelationshipType == RelationshipType.Quore);
            if (quoreRelations.Any())
            {
                var subQuery = from a in _quoteRepository.GetQueryableSet()
                               join b in quoreRelations on a.Id equals b.RelationId
                               select new RelationsDto
                               {
                                   ObjectId = a.Id,
                                   RelationshipId = a.Id,
                                   Name = a.Name,
                                   Code = a.Code,
                                   AmountQuore = a.Amount,
                                   QuoteStatus = a.QuoteStatus,
                                   RelationshipType = b.RelationshipType,

                               };
                result.AddRange(subQuery);
            }
        }


        return new ResultModel<List<RelationsDto>>(result);
    }
}
