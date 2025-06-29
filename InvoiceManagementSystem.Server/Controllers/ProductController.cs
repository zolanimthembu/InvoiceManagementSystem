using InvoiceManagementSystemBL.ProductManagementBL;
using InvoiceManagementSystemBO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL _productBL;
        public ProductController(IProductBL productBL)
        {
            _productBL = productBL;
        }
        [HttpGet("GetProducts")]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productBL.GetProductsAsync();
            return Ok(products);
        }

        [HttpPost("AddProduct")]
        [Authorize]
        public async Task<IActionResult> AddProduct(ProductDTO product)
        {
            var products = await _productBL.AddProduct(product);
            return Ok(products);
        }
        [HttpPut("UpdateProduct")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(ProductDTO product)
        {
            var products = await _productBL.UpdateProduct(product);
            return Ok(products);
        }
        [HttpDelete("DeleteProduct/{productId}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var products = await _productBL.DeleteProduct(productId);
            return Ok(products);
        }
    }
}
