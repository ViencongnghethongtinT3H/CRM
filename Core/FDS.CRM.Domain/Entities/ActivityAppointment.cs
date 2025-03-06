using System.ComponentModel.DataAnnotations.Schema;

namespace FDS.CRM.Domain.Entities;

// cuộc hẹn
public class ActivityAppointment : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public Activity Activity { get; set; }
    [StringLength(2000)]
    public string Description { get; set; }
    [StringLength(500)]
    public bool IsAllDay { get; set; }
    public string Address { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ActivityStatus ActivityStatus { get; set; }  // Trạng thái

    private ActivityAppointment(Guid activityId, string description, bool isAllDay, 
        string address, DateTime startTime, DateTime endTime, ActivityStatus activityStatus)
    {
        Id = Guid.NewGuid();
        ActivityId = activityId;
        Description = description;
        IsAllDay = isAllDay;
        Address = address;
        StartTime = startTime;
        EndTime = endTime;
        ActivityStatus = activityStatus;
    }

    public static ActivityAppointment Create(Guid activityId, string description, bool isAllDay, 
        string address, DateTime startTime, DateTime endTime, ActivityStatus activityStatus)
    {
        return new ActivityAppointment(activityId, description, isAllDay, address, startTime, endTime, activityStatus);
    }
}
