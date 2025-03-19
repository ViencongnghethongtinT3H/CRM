namespace FDS.CRM.Domain.Entities;

public class Quotes : Entity<Guid>, IAggregateRoot
{
    [StringLength(300)]
    [Required]
    public string Name { get; set; }

    [StringLength(20)]
    [Required]
    public string Code { get; set; }
    public Guid DealId { get; set; }   // link vs bảng cơ hội
    public Guid ContactId { get; set; }   // link vs bảng cơ hội
    public QuoteStatus QuoteStatus { get; set; }

    [Precision(18, 3)]
    public decimal Amount { get; set; }
    public Guid PaymentTermId { get; set; }   // link vs bảng điều khoản thanh toán

    public ICollection<QuoreRelation> QuoreRelations { get; set; }  

}
