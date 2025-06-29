using InvoiceManagementSystemBO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBL.ProductManagementBL
{
    public interface IProductBL
    {
        Task<ResponseDTO<List<ProductDTO>>> GetProductsAsync();
        Task<ResponseDTO<ProductDTO>> AddProduct(ProductDTO product);
        Task<ResponseDTO<ProductDTO>> UpdateProduct(ProductDTO product);
        Task<ResponseDTO<int>> DeleteProduct(int productId);
    }
}
