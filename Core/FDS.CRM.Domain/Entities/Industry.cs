using System.ComponentModel.DataAnnotations;

namespace FDS.CRM.Domain.Entities
{
    public class Industry : Entity<Guid>
    {
        public Guid? ParrentId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}
