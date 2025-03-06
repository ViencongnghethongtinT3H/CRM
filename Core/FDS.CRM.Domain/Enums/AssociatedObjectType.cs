using System.ComponentModel;

namespace FDS.CRM.Domain.Enums
{
    public enum AssociatedObjectType
    {
        [Description("Khách hàng cá nhân")]
        Contact = 1,
        [Description("Công ty")]
        Company = 2,
        Lead = 3
    }
}
