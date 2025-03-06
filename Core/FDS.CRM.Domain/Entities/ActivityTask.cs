namespace FDS.CRM.Domain.Entities;

public class ActivityTask : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public Activity Activity { get; set; }
    [StringLength(2000)]
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime? CompletedDate { get; set; }
    public DateTime? DueDate { get; set; }
    public ActivityTaskType ActivityTaskType { get; set; }

    private ActivityTask(Guid activityId, string description, Priority priority,
        DateTime? completedDate, DateTime? dueDate, ActivityTaskType activityTaskType)
    {
        Id = Guid.NewGuid();
        ActivityId = activityId;
        Description = description;
        Priority = priority;
        CompletedDate = completedDate;
        DueDate = dueDate;
        ActivityTaskType = activityTaskType;
    }

    public static ActivityTask Create(Guid activityId, string description, Priority priority,
        DateTime? completedDate, DateTime? dueDate, ActivityTaskType activityTaskType)
    {
        return new ActivityTask(activityId, description, priority, completedDate, dueDate, activityTaskType);
    }
}
