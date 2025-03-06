using System.ComponentModel.DataAnnotations.Schema;

namespace FDS.CRM.Domain.Entities;

public class Activity : Entity<Guid>, IAggregateRoot
{
    [MaxLength(200)]
    public string Title { get; private set; }
    public Guid? TicketId { get; private set; }
    public Guid? ContactId { get; private set; }
    public Contact? Contact { get; set; }

    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }
    public Guid? DealId { get; set; }
    public Deal? Deal { get; set; }
    [ForeignKey("User")]
    public Guid OwnerId { get; set; }  // Người thực hiện
    public User? User { get; set; }
    public ActivityType ActivityType { get; set; }
    public int Sort { get; set; }
    public bool IsPinned { get; set; }   // có gắn lên top của activity ko

    public ICollection<ActivityAppointment> ActivityAppointments { get; set; }
    public ICollection<ActivityCall> ActivityCalls { get; set; }
    public ICollection<ActivityEmail> ActivityEmails { get; set; }
    public ICollection<ActivityNote> ActivityNotes { get; set; }
    public ICollection<ActivityReminder> ActivityReminders { get; set; }
    public ICollection<ActivitySms> ActivitySms { get; set; }
    public ICollection<ActivityTask> ActivityTasks { get; set; }

    private Activity(string title, Guid ownerId, ActivityType activityType, 
        Guid? contactId = null, Guid? companyId = null, Guid? dealId = null, Guid? ticketId = null)
    {
        Id = Guid.NewGuid();
        Title = title;
        OwnerId = ownerId;
        ActivityType = activityType;
        ContactId = contactId;
        CompanyId = companyId;
        DealId = dealId;
        TicketId = ticketId;
        Sort = 0;
        IsPinned = false;
    }

    public static Activity Create(string title, Guid ownerId, ActivityType activityType,
        Guid? contactId = null, Guid? companyId = null, Guid? dealId = null, Guid? ticketId = null)
    {
        return new Activity(title, ownerId, activityType, contactId, companyId, dealId, ticketId);
    }
}
