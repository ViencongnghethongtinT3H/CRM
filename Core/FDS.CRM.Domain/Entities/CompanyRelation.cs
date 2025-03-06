namespace FDS.CRM.Domain.Entities;

public class CompanyRelation : Entity<Guid>, IAggregateRoot
{
    public Guid CompanyId { get; private set; }
    public Company Company { get; set; }
    public Guid RelationId { get; private set; }
    public RelationshipType RelationshipType { get; set; }

    public static CompanyRelation Create(Guid companyId, Guid relationId, RelationshipType relationshipType)
    {
        return new CompanyRelation
        {
            Id = Guid.NewGuid(),
            CompanyId = companyId,
            RelationshipType = relationshipType,
            RelationId = relationId
        };
    }
}
