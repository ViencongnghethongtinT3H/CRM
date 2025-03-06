namespace FDS.CRM.Domain.Entities;

public class Department : Entity<Guid>
{
    [StringLength(100)]
    [Required]
    public string Name { get; set; }
   
    public Guid ParentID { get; set; }

    [StringLength(300)]
    public string? Description { get; set; }   
    public ICollection<Position> Positions { get; set; }
    public ICollection<User> Users { get; set; }
}
