using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemDAL.InvoiceManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBL.InvoiceManagementBL
{
    public class InvoiceBL : IInvoiceBL
    {
        private readonly IInvoicesDAL _invoicesDAL;
        public InvoiceBL(IInvoicesDAL invoicesDAL)
        {
            _invoicesDAL = invoicesDAL;
        }
        public async Task<ResponseDTO<InvoiceDTO>> AddInvoice(InvoiceDTO invoice)
        {
            if(await _invoicesDAL.AddInvoice(invoice))
                return new ResponseDTO<InvoiceDTO>() { ResponseCode = 200, ResponseMessage = "Added Successfully", ResponseObject = invoice };
            return new ResponseDTO<InvoiceDTO>() { ResponseCode = 500, ResponseMessage = "Error Adding", ResponseObject = invoice };
        }

        public async Task<ResponseDTO<List<InvoiceDTO>>> GetInvoices()
        {
            var invoices  = await _invoicesDAL.GetInvoices();
            return new ResponseDTO<List<InvoiceDTO>>() { ResponseObject = invoices, ResponseCode = 200, ResponseMessage = "success" };
        }
    }
}
