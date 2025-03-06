namespace FDS.CRM.Domain.Entities;

// các deal quan hệ với nhau
public class QuoreRelation : Entity<Guid>, IAggregateRoot
{
    public Guid QuoreId { get; set; }
    public Guid RelationId { get; set; }
    public RelationshipType RelationshipType { get; set; }
    public static QuoreRelation Create(Guid quoreId, Guid relationId, RelationshipType relationshipType)
    {
        return new QuoreRelation
        {
            Id = Guid.NewGuid(),
            QuoreId = quoreId,
            RelationshipType = relationshipType,
            RelationId = relationId
        };
    }
}
