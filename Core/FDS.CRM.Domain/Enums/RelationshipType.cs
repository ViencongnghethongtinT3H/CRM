using System.ComponentModel;

namespace FDS.CRM.Domain.Enums;

public enum RelationshipType
{
    [Description("Khách hàng cá nhân")]
    Contact = 1,
    Company = 2,
    Deal = 3,
    Ticket = 4,
    Order = 5,
    Quore = 6,
    Invoice = 7,
    Customer = 8,
}
