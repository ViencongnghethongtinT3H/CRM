namespace FDS.CRM.Domain.Entities;

public class Address : Entity<Guid>
{
    public string AddressName { get; set; }
    public string? WardId { get; set; }
    public virtual Ward? Ward { get; set; }

    public string? DistrictId { get; set; }
    public virtual District? District { get; set; }

    public string? ProvinceId { get; set; }
    public virtual Province? Province { get; set; }

    public string Country { get; set; }
    public AddressType AddressType { get; set; }
    public Guid? ContactId { get; set; }
    public Contact? Contact { get; set; }
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }

    #region Constructor
    public Address(
        string addressName, string country, AddressType addressType, Guid? contactId, Guid? companyId,
        string? wardId = null, string? districtId = null, string? provinceId = null)
    {
        Id = Guid.NewGuid();
        AddressName = addressName;
        Country = country;
        AddressType = addressType;
        ContactId = contactId;
        CompanyId = companyId;
        WardId = wardId;
        DistrictId = districtId;
        ProvinceId = provinceId;
    }
    #endregion

    #region Business Logic
    public static Address Create(
        string addressName, string country, AddressType addressType, Guid? contactId, Guid? companyId,
        string? wardId = null, string? districtId = null, string? provinceId = null)
    {
        return new Address(addressName, country, addressType, contactId, companyId, wardId, districtId, provinceId);
    }
    #endregion
}
