using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDS.CRM.Application.Supplier.DTOs
{
    public class SupplierDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Tax { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
