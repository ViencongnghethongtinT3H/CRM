namespace FDS.CRM.Domain.Entities;

public class ContactRelation : Entity<Guid>, IAggregateRoot
{
    public Guid ContactId { get; private set; }
    public Contact Contact { get;  set; }
    public Guid RelationId { get; private set; } // Có thể là deal, có thể là company, có thể contact, có thể ticket
    //  vai trò của khách hàng cá nhân
    [MaxLength(100)]
    public string? JobTitle { get; set; } 
    public RelationshipType RelationshipType { get; set; }

    public static ContactRelation Create(Guid contractId, Guid relationId, string? jobTitle, RelationshipType relationshipType)
    {
        return new ContactRelation
        {
            Id = Guid.NewGuid(),
            ContactId = contractId,
            JobTitle = jobTitle,
            RelationshipType = relationshipType,
            RelationId = relationId
        };
    }
}
