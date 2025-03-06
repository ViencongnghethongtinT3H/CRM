using System.ComponentModel.DataAnnotations.Schema;

namespace FDS.CRM.Domain.Entities;

public class ActivityCall : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public Activity Activity { get; set; }
    public int CallDuration { get; set; }
    [StringLength(500)]
    public string CallResult { get; set; }

    private ActivityCall(Guid activityId, int callDuration, string callResult)
    {
        Id = Guid.NewGuid();
        ActivityId = activityId;
        CallDuration = callDuration;
        CallResult = callResult;
    }

    public static ActivityCall Create(Guid activityId, int callDuration, string callResult)
    {
        return new ActivityCall(activityId, callDuration, callResult);
    }
}
