namespace FDS.CRM.Domain.Entities;

public class Category : Entity<Guid>, IAggregateRoot
{
    [StringLength(200)]
    [Required]
    public string Name { get; private set; }
    [StringLength(100)]
    [Required]
    public string Code { get; private set; }
    [StringLength(500)]
    public string? Description { get; private set; }
    private Category() { }

    public static Category Create(string name, string code, string description)
    {
        return new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            Code = code,
            Description = description
        };
    }
}
