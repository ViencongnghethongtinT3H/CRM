namespace FDS.CRM.Domain.Entities;

public class Position : Entity<Guid>, IAggregateRoot
{
    [StringLength (100)]
    [Required]
    public string Title { get; set; }   // Tên chức vụ
    [StringLength(300)]
    public string? Description { get; set; }   // Tên chức vụ
    public Guid DepartmentID { get; set; }
    public Department Department { get; set; }  
}
