
namespace FDS.CRM.Application.RelationManager.Commands;

public class AddUpdateRelationCommand : ICommand
{
    public ManagerRelationDto ManagerRelationDto { get; set; }
}
public class AddUpdateRelationValidator
{
    public static void Validate(AddUpdateRelationCommand request)
    {
        ValidationException.NotNullOrWhiteSpace(request.ManagerRelationDto.Id.ToString(), "Id không được để trống.");
        ValidationException.NotEmpty(request.ManagerRelationDto.RelationId, "RelationId không được để trống.");
        ValidationException.NotNullOrWhiteSpace(request.ManagerRelationDto.RelationshipType.ToString(), "RelationshipType không được để trống.");
    }
}

internal class AddUpdateRelationCommandHandler : ICommandHandler<AddUpdateRelationCommand>
{
    private readonly ICrudService<Domain.Entities.ContactRelation> _contactRelationService;
    private readonly ICrudService<CompanyRelation> _companyRelationService;
    private readonly ICrudService<TicketRelation> _ticketRelationService;
    private readonly ICrudService<DealRelation> _dealRealtionService;
    private readonly ICrudService<OrderRelation> _orderRelationService;
    private readonly ICrudService<QuoreRelation> _quoreRelationService;
    private readonly IUnitOfWork _unitOfWork;
    public AddUpdateRelationCommandHandler(IUnitOfWork unitOfWork,
        ICrudService<Domain.Entities.ContactRelation> contactRelationService,
        ICrudService<CompanyRelation> companyRelationService,
        ICrudService<TicketRelation> ticketRelationService,
        ICrudService<DealRelation> dealService,
        ICrudService<OrderRelation> orderRelationService,
        ICrudService<QuoreRelation> quoreRelationService)
    {
        _unitOfWork = unitOfWork;
        _contactRelationService = contactRelationService;
        _companyRelationService = companyRelationService;
        _ticketRelationService = ticketRelationService;
        _dealRealtionService = dealService;
        _orderRelationService = orderRelationService;
        _quoreRelationService = quoreRelationService;
    }

    public async Task HandleAsync(AddUpdateRelationCommand command, CancellationToken cancellationToken = default)
    {
        AddUpdateRelationValidator.Validate(command);

        using (await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken))
        {
            if (command.ManagerRelationDto.RelationshipType == RelationshipType.Contact)
            {
                // check cơ hội liên kết vs cá nhân
                if (command.ManagerRelationDto.MainType == RelationshipType.Deal)
                {
                    var checkContractWithDeal = _contactRelationService.GetQueryableSet().Where(p => p.RelationId == command.ManagerRelationDto.Id);
                    if (checkContractWithDeal.IsAny())
                    {
                        throw new Exception("1 cơ hội chỉ có thể liên kết vs 1 cá nhân");
                    }
                    if (command.ManagerRelationDto.RelationId.Count() > 1)
                    {
                        throw new Exception("1 cơ hội chi có thể liên kết vs 1 cá nhân");
                    }
                }

                // check đơn hàng liên kết vs cá nhân
                if (command.ManagerRelationDto.MainType == RelationshipType.Order)
                {
                    var checkContractWithOrder = _contactRelationService.GetQueryableSet().Where(p => p.RelationId == command.ManagerRelationDto.Id);
                    if (checkContractWithOrder.IsAny())
                    {
                        throw new Exception("1 đơn hàng chi có thể liên kết vs 1 cá nhân");
                    }

                    if (command.ManagerRelationDto.RelationId.Count() > 1)
                    {
                        throw new Exception("1 đơn hàng chi có thể liên kết vs 1 cá nhân");
                    }

                }

                // check hóa đơn liên kết vs cá nhân :TODO
                if (command.ManagerRelationDto.MainType == RelationshipType.Invoice)
                {
                    var checkContractWithOrder = _contactRelationService.GetQueryableSet().Where(p => p.RelationId == command.ManagerRelationDto.Id);
                    if (checkContractWithOrder.IsAny())
                    {
                        throw new Exception("1 đơn hàng chi có thể liên kết vs 1 cá nhân");
                    }

                    if (command.ManagerRelationDto.RelationId.Count() > 1)
                    {
                        throw new Exception("1 đơn hàng chi có thể liên kết vs 1 cá nhân");
                    }

                }

                var contacts = new List<Domain.Entities.ContactRelation>();

                foreach (var item in command.ManagerRelationDto.RelationId)
                {
                    var contact = Domain.Entities.ContactRelation.Create(item, command.ManagerRelationDto.Id, "",  command.ManagerRelationDto.RelationshipType);
                    contacts.Add(contact);
                }
                await _contactRelationService.AddRangerAsync(contacts);
               
            }

            if (command.ManagerRelationDto.MainType == RelationshipType.Ticket)
            {

                var tickets = new List<TicketRelation>();
                foreach (var item in command.ManagerRelationDto.RelationId)
                {
                    var ticket = TicketRelation.Create(item, command.ManagerRelationDto.Id, command.ManagerRelationDto.RelationshipType);
                    tickets.Add(ticket);
                }
                await _ticketRelationService.AddRangerAsync(tickets);
            }

            if (command.ManagerRelationDto.MainType == RelationshipType.Company)
            {

                var companys = new List<CompanyRelation>();
                foreach (var item in command.ManagerRelationDto.RelationId)
                {
                    var company = CompanyRelation.Create(item, command.ManagerRelationDto.Id, command.ManagerRelationDto.RelationshipType);
                    companys.Add(company);
                }
                await _companyRelationService.AddRangerAsync(companys);
            }

            if (command.ManagerRelationDto.MainType == RelationshipType.Deal)
            {

                var deals = new List<DealRelation>();
                foreach (var item in command.ManagerRelationDto.RelationId)
                {
                    var deal = DealRelation.Create(item, command.ManagerRelationDto.Id, command.ManagerRelationDto.RelationshipType);
                    deals.Add(deal);
                }
                await _dealRealtionService.AddRangerAsync(deals);
            }

            if (command.ManagerRelationDto.MainType == RelationshipType.Quore)
            {
                var quores = new List<QuoreRelation>();
                foreach (var item in command.ManagerRelationDto.RelationId)
                {
                    var deal = QuoreRelation.Create(item,command.ManagerRelationDto.Id, command.ManagerRelationDto.RelationshipType);
                    quores.Add(deal);
                }
                await _quoreRelationService.AddRangerAsync(quores);
            }

            if (command.ManagerRelationDto.RelationshipType == RelationshipType.Order)
            {
                var orders = new List<OrderRelation>();
                foreach (var item in command.ManagerRelationDto.RelationId)
                {
                    var order = OrderRelation.Create(item, command.ManagerRelationDto.Id, command.ManagerRelationDto.RelationshipType);
                    orders.Add(order);
                }
                await _orderRelationService.AddRangerAsync(orders);
            }


            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
    }
}

