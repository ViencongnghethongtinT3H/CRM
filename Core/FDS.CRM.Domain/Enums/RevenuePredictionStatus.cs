namespace FDS.CRM.Domain.Enums;

public enum RevenuePredictionStatus
{
    Success = 1,              // Đã thành công
    HighChance = 2,           // Khả năng chốt được cao
    MediumChance = 3,         // Khả năng sẽ chốt cơ hội
    Uncertain = 4,            // Chưa chắc lắm
    NearFailure = 5,          // Gần như thất bại
    Failed = 6                // Đã thất bại
}
