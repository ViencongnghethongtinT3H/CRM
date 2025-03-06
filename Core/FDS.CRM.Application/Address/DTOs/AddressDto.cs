namespace FDS.CRM.Application.Address.DTOs;

public class AddressDto
{
    public string AddressName { get; set; }
    public string? ProvinceId { get; set; } 
    public string? DistrictId { get; set; }  
    public string? WardId { get; set; }  
    public string Country { get; set; }
    public AddressType AddressType { get; set; }
    public Guid? CompanyId { get; set; } 
}

public class AddressDetailDto
{
    public string AddressName { get; set; }
    public string? ProvinceName { get; set; }
    public string? DistrictName { get; set; }
    public string? WardName { get; set; }
    public string Country { get; set; }
    public string AddressType { get; set; }
    public string? CompanyName { get; set; }
}
