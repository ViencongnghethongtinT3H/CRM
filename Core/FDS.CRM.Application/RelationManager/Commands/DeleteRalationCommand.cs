
namespace FDS.CRM.Application.RelationManager.Commands
{
    public class DeleteRalationCommand : ICommand
    {
        public DeleteRalationRequest query { get; set; }
        public class DeleteRalationRequest() 
        {
            public Guid Id { get; set; }
            public Guid RelationId { get; set; }
            public RelationshipType RelationshipType { get; set; }
        }
        

    }
    public class DeleteRelationValidator
    {
        public static void Validate(DeleteRalationCommand request)
        {
            ValidationException.NotNullOrWhiteSpace(request.query.Id.ToString(), "Id không được để trống.");
            ValidationException.NotNullOrWhiteSpace(request.query.RelationId.ToString(), "RelationId không được để trống.");
        }
    }
    internal class DeleteRelationCommandHandler : ICommandHandler<DeleteRalationCommand>
    {
        private readonly ICrudService<Domain.Entities.ContactRelation> _contactRelationService;
        private readonly ICrudService<CompanyRelation> _companyRelationService;
        private readonly ICrudService<TicketRelation> _ticketRelationService;
        private readonly ICrudService<DealRelation> _dealRelationService;
        private readonly ICrudService<OrderRelation> _orderRelationService;
        private readonly ICrudService<QuoreRelation> _quoreRelationService;

        private readonly IUnitOfWork _unitOfWork;
        public DeleteRelationCommandHandler(ICrudService<Domain.Entities.ContactRelation> contactRelationService,
            ICrudService<CompanyRelation> companyRelationService,
            ICrudService<TicketRelation> ticketRelationService,
            ICrudService<DealRelation> dealService, ICrudService<OrderRelation> orderRelationService,
            ICrudService<QuoreRelation> quoreRelationService,
            IUnitOfWork unitOfWork)
        {
            _contactRelationService = contactRelationService;
            _companyRelationService = companyRelationService;
            _ticketRelationService = ticketRelationService;
            _dealRelationService = dealService;
            _orderRelationService = orderRelationService;
            _quoreRelationService = quoreRelationService;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteRalationCommand command, CancellationToken cancellationToken = default)
        {
            DeleteRelationValidator.Validate(command);

            using (await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken))
            {
                if (command.query.RelationshipType == RelationshipType.Deal)
                {
                    var deal = _dealRelationService.GetQueryableSet().FirstOrDefault(p => p.RelationId == command.query.RelationId && p.DealId == command.query.Id);
                    if (deal is null)
                    {
                        throw new Exception("lỗi không tìm thấy liên kết cơ hội");
                    }
                    await _dealRelationService.DeleteAsync(deal);
                }
                else if (command.query.RelationshipType == RelationshipType.Company)
                {
                    var company = _companyRelationService.GetQueryableSet().FirstOrDefault(p => p.RelationId == command.query.RelationId && p.CompanyId == command.query.Id);
                    if (company is null)
                    {
                        throw new Exception("lỗi không tìm thấy liên kết doanh nghiệp");
                    }
                    await _companyRelationService.DeleteAsync(company);
                }
                else if (command.query.RelationshipType == RelationshipType.Contact)
                {
                    var contact = _contactRelationService.GetQueryableSet().FirstOrDefault(p => p.RelationId == command.query.RelationId && p.ContactId == command.query.Id);
                    if (contact is null)
                    {
                        throw new Exception("lỗi không tìm thấy liên kết cá nhân");
                    }
                    await _contactRelationService.DeleteAsync(contact);
                }
                else if (command.query.RelationshipType == RelationshipType.Order)
                {
                    var order = _orderRelationService.GetQueryableSet().FirstOrDefault(p => p.RelationId == command.query.RelationId && p.OrderId == command.query.Id);
                    if (order is null)
                    {
                        throw new Exception("lỗi không tìm thấy liên kết đơn hàng");
                    }
                    await _orderRelationService.DeleteAsync(order);
                }
                else if (command.query.RelationshipType == RelationshipType.Ticket)
                {
                    var ticket = _ticketRelationService.GetQueryableSet().FirstOrDefault(p => p.RelationId == command.query.RelationId && p.TicketId == command.query.Id);
                    if (ticket is null)
                    {
                        throw new Exception("lỗi không tìm thấy liên kết phiếu hỗ trợ");
                    }
                    await _ticketRelationService.DeleteAsync(ticket);
                }
                else if (command.query.RelationshipType == RelationshipType.Quore)
                {
                    var quore = _quoreRelationService.GetQueryableSet().FirstOrDefault(p => p.RelationId == command.query.RelationId && p.QuoreId == command.query.Id);
                    if (quore is null)
                    {
                        throw new Exception("lỗi không tìm thấy liên kết báo giá");
                    }
                    await _quoreRelationService.DeleteAsync(quore);
                }
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }


        }
    }
}
