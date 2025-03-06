namespace FDS.CRM.Application.RelationManager.DTOs
{
    public class ManagerRelationDto
    {
        public Guid Id { get; set; }
        public List<Guid> RelationId { get; set; } 
        public RelationshipType RelationshipType { get; set; }
        public RelationshipType MainType { get; set; }

    }
}
