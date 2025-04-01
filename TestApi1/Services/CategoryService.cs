using AutoMapper;
using TestApi1.DTO.Request;
using TestApi1.DTO.Response;
using TestApi1.Enums;
using TestApi1.Models;
using TestApi1.Repositories;

namespace TestApi1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<CategoryResponse>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return new ApiResponse<IEnumerable<CategoryResponse>>(200, "Success", response);
        }

        public async Task<ApiResponse<CategoryResponse>> GetCategoryByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
                return new ApiResponse<CategoryResponse>((int)ErrorCode.NotFound, "Category not found", null);

            var response = _mapper.Map<CategoryResponse>(category);
            return new ApiResponse<CategoryResponse>(200, "Success", response);
        }

        public async Task<ApiResponse<CategoryResponse>> CreateCategoryAsync(CategoryCreationRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.CreateCategoryAsync(category);
            var response = _mapper.Map<CategoryResponse>(category);
            return new ApiResponse<CategoryResponse>(200, "Category created successfully", response);
        }

        public async Task<ApiResponse<CategoryResponse>> UpdateCategoryAsync(Guid id, CategoryUpdateRequest request)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
                return new ApiResponse<CategoryResponse>((int)ErrorCode.NotFound, "Category not found",null);

            _mapper.Map(request, category);
            await _categoryRepository.UpdateCategoryAsync(category);
            var response = _mapper.Map<CategoryResponse>(category);
            return new ApiResponse<CategoryResponse>(200, "Category updated successfully", response);
        }

        public async Task<ApiResponse<string>> DeleteCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
                return new ApiResponse<string>((int)ErrorCode.NotFound, "Category not found", null);

            await _categoryRepository.DeleteCategoryAsync(id);
            return new ApiResponse<string>(200, "Category deleted successfully", null);
        }
    }
}
