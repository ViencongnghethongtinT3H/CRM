namespace FDS.CRM.Domain.Entities;

public class Ticket : Entity<Guid>, IAggregateRoot
{
    [StringLength(100)]
    [Required]
    public string Code { get; private set; }   // mã phiếu
    [StringLength(300)]
    [Required]
    public string Name { get; private set; }
    public Guid CustomerId { get; private set; }
    [StringLength(300)]
    [Required]
    public string Description { get; private set; }
    public TicketStatus TicketStatus { get; private set; }
    public Guid AssignedTo { get; private set; }  // ID nhân viên chịu trách nhiệm chính
    public Guid AssignedTeamId { get; private set; }  // ID nhóm được giao xử lý.
    public Guid PipelineStageId { get; private set; }  // kết nối với PipelineStage
    public Guid PipelineId { get; private set; }  // kết nối với Pipeline để biết đang dùng pipeline nào
    public Guid ProductId { get; private set; }
    public Guid OrderId { get; private set; }
    public Priority Priority { get; private set; }
    public DateTime? ClosedDate { get; private set; }
    private List<TicketRelation> _ticketRelation = new();
    public IReadOnlyCollection<TicketRelation> TicketRelations => _ticketRelation.AsReadOnly();
}
