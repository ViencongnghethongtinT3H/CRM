using System.ComponentModel;

namespace FDS.CRM.Domain.Enums;

public enum VoucherType
{
    [Description("Theo phần trăm")]
    Percent = 1,  // giam gia theo %
    [Description("Theo giá tiền")]
    Value = 2,    // Giam gia theo gia tri
}
