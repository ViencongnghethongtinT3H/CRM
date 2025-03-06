namespace FDS.CRM.Domain.Entities;

public class AdministrativeUnit
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string EnglishFullName { get; set; }
    public string ShortName { get; set; }
    public string EnglishShortName { get; set; }

    // Navigation properties
    public virtual ICollection<Province> Provinces { get; set; }
    public virtual ICollection<District> Districts { get; set; }
    public virtual ICollection<Ward> Wards { get; set; }
}
