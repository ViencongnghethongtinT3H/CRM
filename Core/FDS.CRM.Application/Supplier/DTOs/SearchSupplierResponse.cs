namespace FDS.CRM.Application.Supplier.DTOs;

public class SearchSupplierResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Tax { get; set; }
    public string StatusString { get; set; }
    public DateTime Created { get; set; }
}
