namespace FDS.CRM.Domain.Entities;

// các deal quan hệ với nhau
public class OrderRelation : Entity<Guid>, IAggregateRoot
{
    public Guid OrderId { get; private set; }
    public Guid RelationId { get; private set; }
    public RelationshipType RelationshipType { get; private set; }
    public static OrderRelation Create(Guid orderId, Guid relationId, RelationshipType relationshipType)
    {
        return new OrderRelation
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            RelationshipType = relationshipType,
            RelationId = relationId
        };
    }
}
