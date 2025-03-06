namespace FDS.CRM.Application.Company.DTOs;

public class CompanyDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Website { get; set; }
    public double? AnnualRevenue { get; set; }
    public int? NumberOfEmployees { get; set; }
    public Guid CompanyOwnerId { get; set; }
    public Guid? IndustryId { get; set; }
    public CompanyType CompanyType { get; set; }
}
