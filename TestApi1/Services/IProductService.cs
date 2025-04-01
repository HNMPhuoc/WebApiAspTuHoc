using TestApi1.DTO.Request;
using TestApi1.DTO.Response;

namespace TestApi1.Services
{
    public interface IProductService
    {
        Task<ApiResponse<IEnumerable<ProductResponse>>> GetAllProductsAsync();
        Task<ApiResponse<IEnumerable<ProductResponse>>> GetAllProductsByCategoryIdAsync(Guid categoryId);
        Task<ApiResponse<ProductResponse>> GetProductByIdAsync(Guid id);
        Task<ApiResponse<ProductResponse>> CreateProductAsync(ProductCreationRequest request);
        Task<ApiResponse<ProductResponse>> UpdateProductAsync(Guid id, ProductUpdateRequest request);
        Task<ApiResponse<string>> DeleteProductAsync(Guid id);
    }
}
