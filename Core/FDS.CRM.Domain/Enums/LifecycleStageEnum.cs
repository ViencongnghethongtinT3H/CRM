

using System.ComponentModel;

namespace FDS.CRM.Domain.Enums;

// Lifecycle Stage thể hiện vị trí của contact trong hành trình khách hàng
//  từ khi là lead tiềm năng cho đến khi trở thành khách hàng trung thành.
public enum LifecycleStageEnum
{
    [Description("Đã đăng ký nhận thông tin")]
    Subscriber,  //  Đã đăng ký nhận thông tin marketing

    [Description("Quan tâm nhiều về sản phẩm")]
    Lead,        // Đã thể hiện sự quan tâm nhiều hơn đến sản phẩm/dịch vụ

    [Description("Khả năng chuyển đồi cao")]
    MarketingQualifiedLead,   // Lead có khả năng chuyển đổi cao theo tiêu chí marketing

    [Description("Cơ hội bán hàng")]
    Opportunity,             // Đã trở thành cơ hội bán hàng cụ thể

    [Description("Khách hàng đã mua")]
    Customer,               // Đã mua hàng và trở thành khách hàng

    [Description("Khách hàng tích cực quảng bá")]
    Evangelist,             // Khách hàng tích cực quảng bá về thương hiệu

    [Description("Khác")]
    Other
}
