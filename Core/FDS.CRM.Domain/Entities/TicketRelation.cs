namespace FDS.CRM.Domain.Entities;

public class TicketRelation : Entity<Guid>, IAggregateRoot
{
    public Guid TicketId { get; private set; }
    public Guid RelationId { get; private set; }
    public Ticket Ticket { get; private set; }
    public RelationshipType RelationshipType { get; private set; }

    public static TicketRelation Create(Guid ticketId, Guid relationId, RelationshipType relationshipType)
    {
        return new TicketRelation
        {
            Id = Guid.NewGuid(),
            TicketId = ticketId,
            RelationshipType = relationshipType,
            RelationId = relationId
        };
    }
}
