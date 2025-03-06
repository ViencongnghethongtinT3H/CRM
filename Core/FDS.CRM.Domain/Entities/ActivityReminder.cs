namespace FDS.CRM.Domain.Entities;

// Nhắc nhở
public class ActivityReminder : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public Activity Activity { get; set; }
    public Guid ActivityTypeId { get; set; }  // Id của các loại activity
    public NotificationType NotificationType { get; set; }  // Kiểu notification
    public DateTime RemindAt { get; set; }  // Thời gian nhắc nhở
    public bool IsSent { get; set; }  // 
    [StringLength(300)]
    public string Message { get; set; }  // thông báo nhắc nhở

    private ActivityReminder(Guid activityId, Guid activityTypeId, NotificationType notificationType,
        DateTime remindAt, string message)
    {
        Id = Guid.NewGuid();
        ActivityId = activityId;
        ActivityTypeId = activityTypeId;
        NotificationType = notificationType;
        RemindAt = remindAt;
        Message = message;
        IsSent = false;
    }

    public static ActivityReminder Create(Guid activityId, Guid activityTypeId, 
        NotificationType notificationType, DateTime remindAt, string message)
    {
        return new ActivityReminder(activityId, activityTypeId, notificationType, remindAt, message);
    }
}
