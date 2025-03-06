namespace FDS.CRM.Domain.Entities;

public class Pipeline : Entity<Guid>, IAggregateRoot
{
    [StringLength(200)]
    [Required]
    public string Name { get; set; }
    [StringLength(100)]
    public string Description { get; set; }
    public Guid UserId { get; set; }
}
