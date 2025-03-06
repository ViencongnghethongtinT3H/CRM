namespace FDS.CRM.Domain.Entities;

public class TicketFeedBack : Entity<Guid>
{
    public Guid TicketId { get; set; }
    public int Rating { get; set; }
    [StringLength(2000)]
    public string Comment { get; set; }
}
