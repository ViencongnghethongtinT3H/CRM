namespace FDS.CRM.Application.ContactRelation;
public class ContactRelationDto
{
    public Guid RelationId { get; set; } // Có thể là deal, có thể là company, có thể contact, có thể ticket
    public string? JobTitle { get; set; }
}

public class ContactRelationDetailDto
{
    public string? JobTitle { get; set; }
}
