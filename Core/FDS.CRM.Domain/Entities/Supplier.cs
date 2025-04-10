using System.ComponentModel.DataAnnotations.Schema;

namespace FDS.CRM.Domain.Entities;

public class Supplier : Entity<Guid>, IAggregateRoot
{
    [StringLength(200)]
    [Required]
    public string Name { get; set; }
    [Column(TypeName = "varchar(50)")]
    [Required]
    public string Code { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string? Tax { get; set; }
    [StringLength(200)]
    public string? Address { get; set; }
    [Column(TypeName = "varchar(15)")]
    public string? PhoneNumber { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string? Email { get; set; }

    #region Bussiness Logic

    public static Supplier Create(string name, string code, string? tax, string? address, string? phone, string? email)
    {
        return new Supplier
        {
            Id = Guid.NewGuid(),
            Name = name,
            Code = code,
            Address = address,
            PhoneNumber = phone,
            Email = email            
        };
    }

    public void SetFilter(string filter)
    {
        Filter = filter;
    }

    #endregion
}
