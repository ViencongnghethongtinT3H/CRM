using System.ComponentModel;

namespace FDS.CRM.Domain.Enums
{
    public enum AssociatedInfoType
    {
        /// <summary>
        /// Số điẹn thoại KHCN
        /// </summary>
        [Description("Số điện thoại")]
        Phone = 1,
        /// <summary>
        /// Email KHCN
        /// </summary>
        [Description("Email")]
        Email = 2
    }
}
