namespace FDS.CRM.Domain.Entities;

public class Ward
{
    public string Id { get; set; }
    public string DistrictCode { get; set; }
    public string DistrictId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string EnglishName { get; set; }
    public string FullName { get; set; }
    public string EnglishFullName { get; set; }
    public string CustomName { get; set; }
    public int AdministrativeUnitId { get; set; }

    // Navigation properties
    public virtual District District { get; set; }
    public virtual AdministrativeUnit AdministrativeUnit { get; set; }
}
