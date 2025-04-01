using TestApi1.DTO.Request;
using TestApi1.DTO.Response;

namespace TestApi1.Services
{
    public interface ICategoryService
    {
        Task<ApiResponse<IEnumerable<CategoryResponse>>> GetAllCategoriesAsync();
        Task<ApiResponse<CategoryResponse>> GetCategoryByIdAsync(Guid id);
        Task<ApiResponse<CategoryResponse>> CreateCategoryAsync(CategoryCreationRequest request);
        Task<ApiResponse<CategoryResponse>> UpdateCategoryAsync(Guid id, CategoryUpdateRequest request);
        Task<ApiResponse<string>> DeleteCategoryAsync(Guid id);
    }
}
