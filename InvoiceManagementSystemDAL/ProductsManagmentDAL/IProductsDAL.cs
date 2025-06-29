using InvoiceManagementSystemBO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemDAL.ProductsManagmentDAL
{
    public interface IProductsDAL
    {
        Task<List<ProductDTO>> GetProductsAsync();
        Task<bool> AddProduct(ProductDTO product);
        Task<bool> UpdateProduct(ProductDTO product);
        Task<bool> DeleteProduct(int productId);


    }
}
