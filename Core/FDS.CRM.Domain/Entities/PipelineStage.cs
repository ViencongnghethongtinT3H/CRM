namespace FDS.CRM.Domain.Entities;

public class PipelineStage : Entity<Guid>
{
    public Guid PipelineId { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
    [StringLength(300)]
    public string? Description { get; set; } 
    public int Sort { get; set; }
    public decimal? Probability { get; set; }
    public ICollection<Deal> Deals { get; set; }
}
