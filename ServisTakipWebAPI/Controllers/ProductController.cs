using Microsoft.AspNetCore.Mvc;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Services;

namespace ServisTakipWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService? productService)
        {
            _productService = productService;
        }

        [HttpGet("get")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetProductById(int id)
        {
            var products = _productService.GetProductById(id);
            return Ok(products);
        }

        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody] ProductRequestModel product)
        {
            _productService.CreateProduct(product);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct([FromBody] ProductRequestModel product, int id)
        {
            _productService.UpdateProduct(id, product);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}