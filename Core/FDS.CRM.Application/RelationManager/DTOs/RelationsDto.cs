namespace FDS.CRM.Application.RelationManager.DTOs
{
    public class RelationsDto
    {
        // chung
        public string? Name { get; set; }
        public string? Code { get; set; }
        public RelationshipType? RelationshipType { get; set; }
        public Guid? RelationshipId { get; set; }
        public Guid? ObjectId { get; set; }

        // company
        
        public CompanyType? CompanyType { get; set; }
        public string? Website { get; set; }

        public string? TaxCode { get; set; }
        public double? AnnualRevenue { get; set; }  // Doanh thu hàng năm

        // contact
      
        public string? JobTitle { get; set; }

        // contact + company
        public string? OwnerName { get; set; }// Nhân viên kinh doanh
        public Guid? OwnerId { get; set; }// Nhân viên kinh doanh
        public string PositionName { get; set; }// chức danh
        public Guid PositionId { get; set; }// chức danh
        public string? CommonName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }


        // Ticket
        public TicketStatus? TicketStatus { get; set; }

        // deal
        public string? Title { get; set; }
        public decimal? Amount { get; set; }    
        public DateTime? CloseDate { get; set; }

        // order
        public Guid ContractId { get; set; }
        public string? BankName { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public bool AllowPayment { get; set; }   
        public SendEmailType? SendEmailType { get; set; }

        // quore
        public QuoteStatus QuoteStatus { get; set; }
        public decimal AmountQuore { get; set; }
    }
}
