namespace FDS.CRM.Domain.Entities;

public class ActivityNote : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public Activity Activity { get; set; }
    [StringLength(2000)]
    public string Content { get; set; }

    private ActivityNote(Guid activityId, string content)
    {
        Id = Guid.NewGuid();
        ActivityId = activityId;
        Content = content;
    }

    public static ActivityNote Create(Guid activityId, string content)
    {
        return new ActivityNote(activityId, content);
    }
}
