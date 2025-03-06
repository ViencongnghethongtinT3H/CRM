namespace FDS.CRM.Domain.Entities;

// các deal quan hệ với nhau
public class DealRelation : Entity<Guid>, IAggregateRoot
{
    public Guid DealId { get;private set; }
    public Deal Deal { get; set; }
    public Guid RelationId { get; private set; }
    public RelationshipType RelationshipType { get; private set; }

    public static DealRelation Create(Guid dealId, Guid relationId, RelationshipType relationshipType)
    {
        return new DealRelation
        {
            Id = Guid.NewGuid(),
            DealId = dealId,
            RelationshipType = relationshipType,
            RelationId = relationId
        };
    }
}
