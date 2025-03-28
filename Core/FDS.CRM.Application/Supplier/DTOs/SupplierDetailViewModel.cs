namespace FDS.CRM.Application.Supplier.DTOs;

public class SupplierDetailViewModel : SupplierDto
{
    public Guid Id { get; set; }
    public string? UserNameCreated { get; set; }
    public DateTimeOffset CreatedDateTime { get; set; }
}
