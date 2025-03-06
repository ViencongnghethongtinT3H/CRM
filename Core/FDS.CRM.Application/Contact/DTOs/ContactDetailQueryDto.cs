namespace FDS.CRM.Application.Contact.DTOs
{
    public class ContactDetailQueryDto
    {
        public string Name { get; set; }
        public string Code { get; set; } 
        public string ContactOwnerName { get; set; }
        public string PositionName { get; set; }
        public string LeadStatus { get; set; }
        public string LifecycleStageEnum { get; set; }
        public string CustomerSource { get; set; }
        public string Industry { get; set; }
        public string? CompanyName { get; set; }
        public int? LeadScored { get; set; }
        public string CreatedDate { get; set; }
        public List<AssociatedInfoDetailDto> AssociatedInfos { get; set; } = new List<AssociatedInfoDetailDto>();
        public List<AddressDetailDto> Addresses { get; set; } = new List<AddressDetailDto>();
        public List<ContactRelationDetailDto> ContactRelations { get; set; } = new List<ContactRelationDetailDto>();
        public List<OrderConfigDetailDto> OrderConfigs { get; set; } = new List<OrderConfigDetailDto>();
        public List<PurchaseTransactionDetailDto> PurchaseTransactions { get; set; } = new List<PurchaseTransactionDetailDto>();
    }
}
