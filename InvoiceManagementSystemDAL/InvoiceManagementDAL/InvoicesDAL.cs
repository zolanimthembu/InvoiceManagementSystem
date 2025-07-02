using InvoiceManagementSystemBO.Data;
using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemBO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemDAL.InvoiceManagementDAL
{
    public class InvoicesDAL : IInvoicesDAL
    {
        private readonly ApplicationDbContext _context;
        public InvoicesDAL(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddInvoice(InvoiceDTO invoice)
        {
            try
            {
                await _context.Invoices.AddAsync(new Invoice { CreatedByUserId = invoice.CreatedByUserEmail, CreatedDate = DateTime.Now, Total = 0 });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }

        }

        public Task<List<InvoiceDTO>> GetInvoices()
        {
            return (from invoice in _context.Invoices
             join user in _context.Users on invoice.CreatedByUserId equals user.Id
             select new InvoiceDTO
             {
                 CreatedByUserEmail = user.Email,
                 CreatedDate = invoice.CreatedDate,
                 Total = invoice.Total
             }).ToListAsync();
        }

        public Task<bool> UpdateInvoice(InvoiceDTO invoice)
        {
            throw new NotImplementedException();
        }
    }
}
