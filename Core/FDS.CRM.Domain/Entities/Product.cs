namespace FDS.CRM.Domain.Entities;

public class Product : Entity<Guid>, IAggregateRoot
{
    [StringLength(200)]
    [Required]
    public string Name { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
    public Guid SupplierId { get; set; }
    [StringLength(2000)]
    [Required]
    public string Description { get; set; }
    public decimal BasePrice { get; set; }  // giá gốc
    public decimal SalePrice { get; set; }  // giá bán
    public int StockQuantity { get; set; }  // số lượng tồn kho
    public int Vat { get; set; }   // thuế giá trị gia trăng
    public bool IsCheckInventoty { get; set; }   // có theo dõi tồn kho
    public ProductUnit ProductUnit { get; set; }   // Đơn vị tính

    public ICollection<QuoteItems> QuoteItems { get; set;}
}
