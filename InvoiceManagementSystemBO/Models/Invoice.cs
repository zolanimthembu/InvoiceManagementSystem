using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBO.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<InvoiceItem> Items { get; set; }
    }

}
