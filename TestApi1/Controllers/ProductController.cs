using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi1.DTO.Request;
using TestApi1.Services;

namespace TestApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllProductsAsync();
            return StatusCode(response.Code, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            return StatusCode(response.Code, response);
        }
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetAllProductByCategoryId(Guid id)
        {
            var response = await _productService.GetAllProductsByCategoryIdAsync(id);
            return StatusCode(response.Code, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreationRequest request)
        {
            var response = await _productService.CreateProductAsync(request);
            return StatusCode(response.Code, response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductUpdateRequest request)
        {
            var response = await _productService.UpdateProductAsync(id, request);
            return StatusCode(response.Code, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productService.DeleteProductAsync(id);
            return StatusCode(response.Code, response);
        }
    }
}
