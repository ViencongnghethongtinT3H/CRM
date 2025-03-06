namespace FDS.CRM.Domain.Entities;

public class Province
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string EnglishName { get; set; }
    public string FullName { get; set; }
    public string EnglishFullName { get; set; }
    public string CustomName { get; set; }
    public int AdministrativeUnitId { get; set; }

    // Navigation properties
    public virtual AdministrativeUnit AdministrativeUnit { get; set; }
    public virtual ICollection<District> Districts { get; set; }
}
