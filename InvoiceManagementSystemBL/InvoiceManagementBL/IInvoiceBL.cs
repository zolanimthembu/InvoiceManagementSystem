using InvoiceManagementSystemBO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBL.InvoiceManagementBL
{
    public interface IInvoiceBL
    {
        Task<ResponseDTO<InvoiceDTO>> AddInvoice(InvoiceDTO invoice);
        Task<ResponseDTO<List<InvoiceDTO>>> GetInvoices();
    }
}
