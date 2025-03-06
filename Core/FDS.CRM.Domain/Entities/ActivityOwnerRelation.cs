
namespace FDS.CRM.Domain.Entities;

// Lưu trữ những người phối hợp thực hiện các activity, 1 activity có thể có nhiều người thực hiện
public class ActivityOwnerRelation : Entity<Guid>
{
    public Guid ActivityTypeId { get; set; }  // Id của các loại activity
    public Guid UserId { get; set; }   // Id của những người liên quan
    public User? User { get; set; }
    public ActivityType ActivityType { get; set; }   // activity type
}
