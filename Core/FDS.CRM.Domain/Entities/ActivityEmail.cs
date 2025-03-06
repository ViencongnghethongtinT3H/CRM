namespace FDS.CRM.Domain.Entities;

public class ActivityEmail : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public Activity Activity { get; set; }
    [StringLength(255)]
    public string Subject { get; set; }
    [StringLength(100)]
    public string EmailTo { get; set; }
    public string Body { get; set; }
    [StringLength(255)]
    public string Cc { get; set; }
    [StringLength(255)]
    public string Bcc { get; set; }
}
