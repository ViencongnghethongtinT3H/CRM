namespace FDS.CRM.Application.Contact.Queries;

public class GetDetailContactQuery : IQuery<ResultModel<ContactDetailQueryDto>>
{
    public Guid ContactId { get; set; }

    public GetDetailContactQuery(Guid contactId)
    {
        ContactId = contactId;
    }

    public static void Validate(GetDetailContactQuery request)
    {
        if (request.ContactId == Guid.Empty)
        {
            throw new ValidationException("ContactId không hợp lệ.");
        }
    }
}

public class GetDetailContactQueryHandler : IQueryHandler<GetDetailContactQuery, ResultModel<ContactDetailQueryDto>>
{
    private readonly IContactRepository _contactRepository;

    public GetDetailContactQueryHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ResultModel<ContactDetailQueryDto>> HandleAsync(GetDetailContactQuery query, CancellationToken cancellationToken)
    {
        GetDetailContactQuery.Validate(query);

        var contact = await _contactRepository.GetContactDetailByIdAsync(query.ContactId, cancellationToken);
        if (contact == null)
        {
            throw new NotFoundException($"Không tìm thấy contact với ID {query.ContactId}");
        }

        var contactResult = new ContactDetailQueryDto
        {
            Name = contact.Name,
            Code = contact.Code,
            ContactOwnerName = contact.User.FullName,
            PositionName = contact.Position.Title,
            LeadStatus = Enum.IsDefined(typeof(LeadStatusEnum), contact.LeadStatus) ? contact.LeadStatus.GetDescription() : string.Empty,
            LifecycleStageEnum = Enum.IsDefined(typeof(LifecycleStageEnum), contact.LifecycleStageEnum) ? contact.LifecycleStageEnum.GetDescription() : string.Empty,
            CustomerSource = Enum.IsDefined(typeof(CustomerSource), contact.CustomerSource) ? contact.CustomerSource.GetDescription() : string.Empty,
            Industry = contact.CommonSetting.Value,
            CompanyName = contact.Company?.Name ?? string.Empty,
            LeadScored = contact.LeadScored,
            CreatedDate = contact.CreatedDateTime.DateTime.ToString("dd/MM/yyyy") ?? string.Empty,
            AssociatedInfos = contact.AssociatedInfos?.Select(a => new AssociatedInfoDetailDto
            {
                Value = a.Value,
                AssociatedInfoType = Enum.IsDefined(typeof(AssociatedInfoType), a.AssociatedInfoType)
                ? a.AssociatedInfoType.GetDescription()
                : string.Empty
            }).ToList() ?? new List<AssociatedInfoDetailDto>(),
            Addresses = contact.Addresses?.Select(a => new AddressDetailDto
            {
                AddressName = a.AddressName,
                ProvinceName = a.Province?.Name ?? string.Empty,
                DistrictName = a.District?.FullName ?? string.Empty,
                WardName = a.Ward?.Name ?? string.Empty,
                Country = a.Country ?? string.Empty,
                AddressType = Enum.IsDefined(typeof(AddressType), a.AddressType) ? a.AddressType.GetDescription() : string.Empty,
                CompanyName = a.Company?.Name ?? string.Empty
            }).ToList() ?? new List<AddressDetailDto>(),
            OrderConfigs = contact.OrderConfigs?.Select(o => new OrderConfigDetailDto
            {
                BankName = o.BankName,
                AccountName = o.AccountName,
                AccountNumber = o.AccountNumber,
                AllowPayment = o.AllowPayment,
                SendEmailType = Enum.IsDefined(typeof(SendEmailType), o.SendEmailType) ? o.SendEmailType.GetDescription() : string.Empty
            }).ToList() ?? new List<OrderConfigDetailDto>(),
            PurchaseTransactions = contact.PurchaseTransactions?.Select(p => new PurchaseTransactionDetailDto
            {
                BuyPaymentMethodName = p.PaymentMethod.PaymentMethodName,
                BuyPaymentTermName = p.PaymentTerm.Name,
                //SalePaymentMethod = p.SalePaymentMethodId,
                //SalePaymentTermId = p.SalePaymentTermId,
                SaleName = p.User.FullName
            }).ToList() ?? new List<PurchaseTransactionDetailDto>(),
            ContactRelations = contact.ContactRelations?.Select(cr => new ContactRelationDetailDto
            {
                JobTitle = cr.JobTitle
            }).ToList() ?? new List<ContactRelationDetailDto>()
        };
        return ResultModel<ContactDetailQueryDto>.Create(contactResult);
    }
}
