using InvoiceManagementSystemBL.InvoiceManagementBL;
using InvoiceManagementSystemBO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceBL _invoiceBL;
        public InvoicesController(IInvoiceBL invoiceBL)
        {
            _invoiceBL = invoiceBL;
        }
        [HttpGet("GetInvoices")]
        [Authorize]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceBL.GetInvoices();
            return Ok(invoices);
        }

        [HttpPost("AddInvoice")]
        [Authorize]
        public async Task<IActionResult> AddInvoice(InvoiceDTO invoice)
        {
            var response = await _invoiceBL.AddInvoice(invoice);
            return Ok(response);
        }
    }
}
