using System.ComponentModel.DataAnnotations.Schema;

namespace FDS.CRM.Domain.Entities;

public class Company : Entity<Guid>, IAggregateRoot
{
    [StringLength(200)]
    [Required]
    public string Name { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }
    [StringLength(100)]
    public string? Website { get; set; }
    
    [StringLength(50)]
    public string? TaxCode { get; set; }
    public double? AnnualRevenue { get; set; }  // Doanh thu hàng năm
    public int? NumberOfEmployees { get; set; }  // Số lượng nhân viên
    public Guid? CompanyOwnerId { get; set; }  // người đại diện cty  -> link vs Contact or customer
    [ForeignKey("CommonSetting")]
    public Guid? IndustryId { get; set; }
    public CommonSetting? CommonSetting { get; private set; }   // Liên kết vs bảng commonsetting
    public CompanyType CompanyType { get; set; }
    [ForeignKey("User")]
    public Guid? OwnerId { get; private set; }  // Nhân viên kinh doanh Liên kết với bảng user
    public User? User { get; set; }

    [StringLength(200)]
    public string? Avatar { get; private set; }

    #region Constructor
    private Company(string name, string description, string? website, string? taxCode, 
                   double? annualRevenue, int? numberOfEmployees, Guid? companyOwnerId,
                   Guid? industryId, CompanyType companyType, Guid? ownerId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Website = website;
        TaxCode = taxCode;
        AnnualRevenue = annualRevenue;
        NumberOfEmployees = numberOfEmployees;
        CompanyOwnerId = companyOwnerId;
        IndustryId = industryId;
        CompanyType = companyType;
        OwnerId = ownerId;
        Avatar = CrossCuttingConcerns.Helper.StringHelpers.GetRandomColor();
    }
    #endregion

    #region Business Logic
    public static Company Create(string name, string description, string? website, string? taxCode,
                               double? annualRevenue, int? numberOfEmployees, Guid? companyOwnerId,
                               Guid? industryId, CompanyType companyType, Guid? ownerId)
    {
        return new Company(name, description, website, taxCode, annualRevenue, numberOfEmployees, 
                         companyOwnerId, industryId, companyType, ownerId);
    }
    #endregion

    #region Relation       
    private readonly List<Address> _addresses = new();
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    private readonly List<Activity> _activities = new();
    public IReadOnlyCollection<Activity> Activities => _activities.AsReadOnly();

    private readonly List<CompanyRelation> _companyRelations = new();
    public IReadOnlyCollection<CompanyRelation> CompanyRelations => _companyRelations.AsReadOnly();
    #endregion

    public void AddAddress(Address address)
    {
        _addresses.Add(address);
    }
}
