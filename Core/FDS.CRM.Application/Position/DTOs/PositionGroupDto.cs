namespace FDS.CRM.Application.Position.DTOs
{
    public class PositionGroupDto
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<PositionDto> Positions { get; set; }
    }
}
