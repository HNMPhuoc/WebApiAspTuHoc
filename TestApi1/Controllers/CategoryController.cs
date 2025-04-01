using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi1.DTO.Request;
using TestApi1.Services;

namespace TestApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreationRequest request)
        {
            var response = await _categoryService.CreateCategoryAsync(request);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CategoryUpdateRequest request)
        {
            var response = await _categoryService.UpdateCategoryAsync(id, request);
            return StatusCode(response.Code, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);
            return StatusCode(response.Code, response);
        }
    }
}
