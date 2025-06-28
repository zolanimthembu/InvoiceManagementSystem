using InvoiceManagementSystemBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBO.DTO
{
    public class LoginResponseDTO
    {
        public ApplicationUser User { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }

    }
}
