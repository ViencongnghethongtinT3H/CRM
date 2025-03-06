namespace FDS.CRM.Domain.Entities;

public class QuoteItems : Entity<Guid>
{
    public Guid QuoteId { get; set; }
    public Quotes Quotes { get; set; }
    public Guid ProductionId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; } = 0;
}
