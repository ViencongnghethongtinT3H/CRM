using System.ComponentModel.DataAnnotations.Schema;

namespace FDS.CRM.Domain.Entities;

public class Contact : Entity<Guid>, IAggregateRoot
{
    [StringLength(100)]
    [Required]
    public string Name { get; private set; }
    [StringLength(50)]
    [Required]
    public string Code { get; private set; }  // Mã liên hệ
    [ForeignKey("User")]
    public Guid ContactOwnerId { get; private set; }  // Nhân viên kinh doanh Liên kết với bảng user
    public User User { get; set; }
    public Guid PositionId { get; private set; }   // chức danh
    public Position Position { get; private set; }   // chức danh
    public LeadStatusEnum LeadStatus { get; private set; }
    public LifecycleStageEnum LifecycleStageEnum { get; private set; }
    public CustomerSource CustomerSource { get; private set; }
    [ForeignKey("CommonSetting")]
    public Guid? IndustryId { get; private set; }
    public CommonSetting CommonSetting { get; private set; }   // Liên kết vs bảng commonsetting
    public Guid? CompanyId { get; private set; }
    public Company? Company { get; private set; }
    public int? LeadScored { get; private set; }
    [StringLength(200)]
    public string? Avatar { get; private set; }

    #region Relation
    private readonly List<Address> _addresses = new();
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    private readonly List<OrderConfig> _orderConfigs = new();
    public IReadOnlyCollection<OrderConfig> OrderConfigs => _orderConfigs.AsReadOnly();

    private readonly List<PurchaseTransaction> _purchaseTransactions = new();
    public IReadOnlyCollection<PurchaseTransaction> PurchaseTransactions => _purchaseTransactions.AsReadOnly();

    private readonly List<AssociatedInfo> _associatedInfos = new();
    public IReadOnlyCollection<AssociatedInfo> AssociatedInfos => _associatedInfos.AsReadOnly();

    private readonly List<Activity> _activities = new();
    public IReadOnlyCollection<Activity> Activities => _activities.AsReadOnly();

    private readonly List<ContactRelation> _contactRelations = new();
    public IReadOnlyCollection<ContactRelation> ContactRelations => _contactRelations.AsReadOnly();
    #endregion

    #region Constructor
    private Contact(string name, string code, Guid contactOwnerId, Guid positionId,
                        LeadStatusEnum leadStatus, LifecycleStageEnum lifecycleStageEnum,
                        CustomerSource customerSource, Guid? companyId, Guid? industryId, int? leadScored, string? avatar)
    {
        Id = Guid.NewGuid();
        Name = name;
        Code = code;
        ContactOwnerId = contactOwnerId;
        PositionId = positionId;
        LeadStatus = leadStatus;
        LifecycleStageEnum = lifecycleStageEnum;
        CustomerSource = customerSource;
        CompanyId = companyId;
        IndustryId = industryId;
        LeadScored = leadScored;
        Avatar = CrossCuttingConcerns.Helper.StringHelpers.GetRandomColor();
    }
    #endregion

    #region Business Logic

    public static Contact Create(string name, string code, Guid contactOwnerId, Guid positionId,
                                 LeadStatusEnum leadStatus, LifecycleStageEnum lifecycleStageEnum,
                                 CustomerSource customerSource, Guid? companyId, Guid? industry, int? leadScored, string? avatar)
    {
        return new Contact(name, code, contactOwnerId, positionId, leadStatus, lifecycleStageEnum, customerSource, companyId, industry, leadScored, avatar);
    }

    public void AddAddress(string addressName, string? provinceId, string? districtId, string? wardId,
                       string country, AddressType addressType)
    {
        var address = Address.Create(addressName, country, addressType, Id, CompanyId, wardId, districtId, provinceId);
        _addresses.Add(address);
    }

    public void AddOrderConfig(string bankName, string accountName, string accountNumber,
                               bool allowPayment, SendEmailType sendEmailType)
    {
        var orderConfig = OrderConfig.Create(Id, bankName, accountName, accountNumber, allowPayment, sendEmailType);
        _orderConfigs.Add(orderConfig);
    }

    public void AddPurchaseTransaction(Guid buyPaymentMethodId, Guid buyPaymentTermId,
                                       /*Guid salePaymentMethodId, Guid salePaymentTermId,*/ Guid saleId)
    {
        var purchaseTransaction = PurchaseTransaction.Create(Id, buyPaymentMethodId, buyPaymentTermId, /*salePaymentMethodId, salePaymentTermId,*/ saleId);
        _purchaseTransactions.Add(purchaseTransaction);
    }

    public void AddAssociatedInfo(string value, AssociatedInfoType associatedInfoType)
    {
        var associatedInfo = AssociatedInfo.Create(Id, value, associatedInfoType, AssociatedObjectType.Contact);
        _associatedInfos.Add(associatedInfo);
    }

    public void AddContactRelation(Guid relationId, string? jobTitle)
    {
        var contactRelation = ContactRelation.Create(Id, relationId, jobTitle, RelationshipType.Contact);
        _contactRelations.Add(contactRelation);
    }
    public void SetFilter(string filter)
    {
        Filter = filter;
    }
    #endregion

}