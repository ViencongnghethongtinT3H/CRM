
using System.ComponentModel;

namespace FDS.CRM.Domain.Enums;


// Lead Status cho biết trạng thái hiện tại của một lead trong quy trình bán hàng
public enum LeadStatusEnum
{
    [Description("Mới")]
    New = 0,  // Lead mới đc tạo chưa có tương tác 

    [Description("Đang xử lý")]
    Open = 1,  // Lead đang được xử lý

    [Description("Đang trao đổi")]
    Inprogress = 2,  // Đang trong quá trình trao đổi với lead

    [Description("Cơ hội bán hàng")]
    OpenDeal = 3,  // Đã chuyển thành cơ hội bán hàng

    [Description("Không phù hợp")]
    Unqualified = 4,  // Lead không phù hợp với tiêu chí

    [Description("Liên hệ thất bại")]
    AttemptedToContact = 5,   // Đã cố gắng liên hệ nhưng chưa thành công

    [Description("Liên hệ được thiết lập")]
    Connected = 6,    // Đã thiết lập được liên hệ

    [Description("Chưa sẵng sàng")]
    BadTiming = 7 // Lead chưa sẵn sàng mua hàng tại thời điểm này
}
