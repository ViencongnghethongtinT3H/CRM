using System.ComponentModel;

namespace FDS.CRM.Domain.Enums;

public enum CustomerSource
{
    /// <summary>
    /// Khách hàng do nhân viên kinh doanh tự tìm kiếm.
    /// </summary>
    [Description("Nhân viên tìm kiếm")]
    SalespersonInitiated = 1,

    /// <summary>
    /// Khách hàng hoặc đối tác tự giới thiệu.
    /// </summary>
    [Description("Đối tác giới thiệu")]
    PartnerReferral = 2,

    /// <summary>
    /// Khách hàng đến từ sự kiện.
    /// </summary>
    [Description("Sự kiện")]
    Event = 3,

    /// <summary>
    /// Khách hàng tự tìm đến.
    /// </summary>
    [Description("Tự tìm đến")]
    CustomerInitiated = 4
}
