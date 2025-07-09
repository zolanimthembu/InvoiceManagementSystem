using InvoiceManagementSystemBO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBO.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserEmail { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
