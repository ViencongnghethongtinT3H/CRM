namespace FDS.CRM.Application.Product.DTOs;

public class ProductEntryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public string SuppilerName { get; set; }
    public decimal BasePrice { get; set; }  // giá gốc
    public decimal SalePrice { get; set; }  // giá bán
    public int StockQuantity { get; set; }  // số lượng tồn kho

}
