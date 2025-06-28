﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBO.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }

        public virtual Product Product { get; set; }
    }
}
