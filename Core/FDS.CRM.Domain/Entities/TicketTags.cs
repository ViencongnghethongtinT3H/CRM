namespace FDS.CRM.Domain.Entities;
public class TicketTags : Entity<Guid>
{
    public Guid TicketId { get; set; }
    public Guid TicketTagId { get; set; }
}
