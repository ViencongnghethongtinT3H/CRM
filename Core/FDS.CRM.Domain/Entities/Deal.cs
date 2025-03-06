using System.ComponentModel.DataAnnotations.Schema;

namespace FDS.CRM.Domain.Entities;

public class Deal : Entity<Guid>, IAggregateRoot
{
    [StringLength(100)]
    [Required]
    public string Title { get; private set; }
    [StringLength(1000)]
    public string Description { get;private set; }
    public decimal Amount { get; private set; }
    public decimal? PredictedRevenue { get; private set; }   // dự đoán doanh thu
    public DateTime CloseDate { get; private set; }
    public Guid PipelineStageId { get; private set; }  // kết nối với PipelineStage
    public Guid PipelineId { get; private set; }  // kết nối với Pipeline để biết đang dùng pipeline nào
    [ForeignKey("User")]
    public Guid OwnerId { get; set; }  // Người sở hữu giao dịch
    public User User { get; set; }  // Liên kết với bảng user
    public DealType DealType { get; private set; }
    public Priority Priority { get; private set; }
    public RevenuePredictionStatus RevenuePrediction { get; private set; }  // trạng thái dự đoán doanh thu.

    #region Relation       
    private List<Activity> _activities = new();
    public IReadOnlyCollection<Activity> Activitys => _activities.AsReadOnly();

    private readonly List<DealRelation> _dealRelations = new();
    public IReadOnlyCollection<DealRelation> DealRelations => _dealRelations.AsReadOnly();
    #endregion
}
