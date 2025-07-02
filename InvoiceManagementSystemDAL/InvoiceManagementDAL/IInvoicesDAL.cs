using InvoiceManagementSystemBO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemDAL.InvoiceManagementDAL
{
    public interface IInvoicesDAL
    {
        Task<bool> AddInvoice(InvoiceDTO invoice);
        Task<List<InvoiceDTO>> GetInvoices();
        Task<bool> UpdateInvoice(InvoiceDTO invoice);

    }
}
