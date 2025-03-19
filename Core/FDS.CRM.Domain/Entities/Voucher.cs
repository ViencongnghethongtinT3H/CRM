namespace FDS.CRM.Domain.Entities;

public class Voucher : Entity<Guid>
{
    #region Property

    public string Name { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int? CountUse { get; private set; }   // so lan su dung
    public VoucherType VoucherType { get; private set; }
    [Precision(18, 3)]
    public decimal Amount { get; private set; }  // số tiền hoặc số % giảm giá



    #endregion

    #region Relationship

    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    //public ICollection<Product> Products { get; private set; }

    #endregion

    #region Bussiness Logic



    #endregion
}
