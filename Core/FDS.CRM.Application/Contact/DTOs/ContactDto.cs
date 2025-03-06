
namespace FDS.CRM.Application.Contact.DTOs
{
    public class ContactDto
    {
        public string Name { get; set; }
        public Guid ContactOwnerId { get; set; }  
        public Guid PositionId { get; set; } 
        public LeadStatusEnum LeadStatus { get; set; }
        public LifecycleStageEnum LifecycleStageEnum { get; set; }
        public CustomerSource CustomerSource { get; set; }
        public Guid? IndustryId{ get; set; }
        public Guid? CompanyId { get; set; }
        public int? LeadScored { get; set; }
        public string? Avatar { get; set; }
        public List<AssociatedInfoDto> AssociatedInfos { get; set; } = new List<AssociatedInfoDto>();
        public List<ContactRelationDto> ContactRelations { get; set; } = new List<ContactRelationDto>();
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
        public List<OrderConfigDto> OrderConfigs { get; set; } = new List<OrderConfigDto>();
        public List<PurchaseTransactionDto> PurchaseTransactions { get; set; } = new List<PurchaseTransactionDto>();
    }
}
