namespace FDS.CRM.Domain.Entities;

public class ActivitySms : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public Activity Activity { get; set; }
    [StringLength(500)]
    public string Content { get; set; }
    [StringLength(15)]
    public string PhoneNumber { get; set; }
    public DateTime SentDate { get; set; }
    public SmsStatus SmsStatus { get; set; }

    private ActivitySms(Guid activityId, string content, string phoneNumber, 
        DateTime sentDate, SmsStatus smsStatus)
    {
        Id = Guid.NewGuid();
        ActivityId = activityId;
        Content = content;
        PhoneNumber = phoneNumber;
        SentDate = sentDate;
        SmsStatus = smsStatus;
    }

    public static ActivitySms Create(Guid activityId, string content, string phoneNumber, 
        DateTime sentDate, SmsStatus smsStatus)
    {
        return new ActivitySms(activityId, content, phoneNumber, sentDate, smsStatus);
    }
}
