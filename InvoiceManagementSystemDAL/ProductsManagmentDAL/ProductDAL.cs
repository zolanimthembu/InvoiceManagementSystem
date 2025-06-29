using InvoiceManagementSystemBO.Data;
using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemBO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemDAL.ProductsManagmentDAL
{
    public class ProductDAL : IProductsDAL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductDAL(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> AddProduct(ProductDTO product)
        {
            try
            {
                await _applicationDbContext.Products.AddAsync(new Product
                {

                    CostPerItem = product.CostPerItem,
                    ItemsInStock = product.ItemsInStock,
                    Name = product.Name,
                    Id = product.ProductId
                });
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product == null)
                    return false;
                _applicationDbContext.Products.Remove(product);
                return true;
            } catch (Exception ex)
            {
                return false;    
            }
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.Select(
                p => new ProductDTO
                { 
                   CostPerItem = p.CostPerItem,
                   ItemsInStock = p.ItemsInStock,
                   Name = p.Name,
                   ProductId = p.Id 
                 }).ToListAsync();
        }

        public async Task<bool> UpdateProduct(ProductDTO product)
        {
            try
            {
                var productUpdate = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == product.ProductId);
                if (product == null)
                    return false;
                productUpdate!.ItemsInStock = product.ItemsInStock;
                productUpdate.Name = product.Name;
                productUpdate.CostPerItem = product.CostPerItem;
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
