using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemBO.Models;
using InvoiceManagementSystemDAL.ProductsManagmentDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBL.ProductManagementBL
{
    public class ProductBL : IProductBL
    {
        private readonly IProductsDAL _productsDAL;
        public ProductBL(IProductsDAL productsDAL)
        {
            _productsDAL = productsDAL;
        }
        public async Task<ResponseDTO<ProductDTO>> AddProduct(ProductDTO product)
        {
           var response = await _productsDAL.AddProduct(product);
            if(response)
                return new ResponseDTO<ProductDTO> { ResponseCode = 200, ResponseMessage = "Added Successfully", ResponseObject = product };
            return new ResponseDTO<ProductDTO> { ResponseCode = 500, ResponseMessage = "Error While Adding", ResponseObject = product };

        }

        public async Task<ResponseDTO<int>> DeleteProduct(int productId)
        {
            var response = await _productsDAL.DeleteProduct(productId);
            if (response)
                return new ResponseDTO<int> { ResponseCode = 200, ResponseMessage = "Delete Successfully", ResponseObject = productId };
            return new ResponseDTO<int> { ResponseCode = 500, ResponseMessage = "Error While Deleting", ResponseObject = productId };
        }

        public async Task<ResponseDTO<List<ProductDTO>>> GetProductsAsync()
        {
            var response = await _productsDAL.GetProductsAsync();
            return new ResponseDTO<List<ProductDTO>> { ResponseCode = 200, ResponseMessage = "", ResponseObject = response };
        }

        public async Task<ResponseDTO<ProductDTO>> UpdateProduct(ProductDTO product)
        {
            var response = await _productsDAL.UpdateProduct(product);
            if (response)
                return new ResponseDTO<ProductDTO> { ResponseCode = 200, ResponseMessage = "Updated Successfully", ResponseObject = product };
            return new ResponseDTO<ProductDTO> { ResponseCode = 500, ResponseMessage = "Error While Updating", ResponseObject = product };
        }
    }
}
