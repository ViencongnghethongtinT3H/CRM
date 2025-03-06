namespace FDS.CRM.Domain.Entities;

public class Supplier : Entity<Guid>, IAggregateRoot
{
    [StringLength(200)]
    [Required]
    public string Name { get; set; }
    [StringLength(200)]
    [Required]
    public string Code { get; set; }
    [StringLength(15)]
    public string? Tax { get; set; }
    [StringLength(200)]
    public string? Address { get; set; }
    [StringLength(15)]
    public string? PhoneNumber { get; set; }
    [StringLength(15)]
    public string? Email { get; set; }
}
