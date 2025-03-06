using System.ComponentModel;

namespace FDS.CRM.Domain.Enums;

public enum AddressType
{
    /// <summary>
    /// Địa chỉ liên hệ.
    /// </summary>
    [Description("Địa chỉ liên hệ")]
    ContactAddress = 1,

    /// <summary>
    /// Địa chỉ trên hóa đơn.
    /// </summary>
    [Description("Địa chỉ hóa đơn")]
    BillingAddress = 2,

    /// <summary>
    /// Địa chỉ giao hàng.
    /// </summary>
    [Description("Địa chỉ giao hàng")]
    ShippingAddress = 3
}
