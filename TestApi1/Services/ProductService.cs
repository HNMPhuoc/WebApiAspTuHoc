using AutoMapper;
using TestApi1.DTO.Request;
using TestApi1.DTO.Response;
using TestApi1.Enums;
using TestApi1.Models;
using TestApi1.Repositories;

namespace TestApi1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProductResponse>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            var response = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return new ApiResponse<IEnumerable<ProductResponse>>(200, "Success", response);
        }

        public async Task<ApiResponse<IEnumerable<ProductResponse>>> GetAllProductsByCategoryIdAsync(Guid categoryId)
        {
            var products = await _productRepository.GetAllProductsByCategoryIdAsync(categoryId);
            if (products == null)
                return new ApiResponse<IEnumerable<ProductResponse>>((int)ErrorCode.NotFound, "No products found for this category", null);

            var response = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return new ApiResponse<IEnumerable<ProductResponse>>(200, "Success", response);
        }

        public async Task<ApiResponse<ProductResponse>> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                return new ApiResponse<ProductResponse>((int)ErrorCode.NotFound, "Product not found", null);

            var response = _mapper.Map<ProductResponse>(product);
            return new ApiResponse<ProductResponse>(200, "Success", response);
        }

        public async Task<ApiResponse<ProductResponse>> CreateProductAsync(ProductCreationRequest request)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.CreateProductAsync(product);
            var response = _mapper.Map<ProductResponse>(product);
            return new ApiResponse<ProductResponse>(200, "Product created successfully", response);
        }

        public async Task<ApiResponse<ProductResponse>> UpdateProductAsync(Guid id, ProductUpdateRequest request)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                return new ApiResponse<ProductResponse>((int)ErrorCode.NotFound, "Product not found", null);

            _mapper.Map(request, product);
            await _productRepository.UpdateProductAsync(product);
            var response = _mapper.Map<ProductResponse>(product);
            return new ApiResponse<ProductResponse>(200, "Product updated successfully", response);
        }

        public async Task<ApiResponse<string>> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                return new ApiResponse<string>((int)ErrorCode.NotFound, "Product not found", null);

            await _productRepository.DeleteProductAsync(id);
            return new ApiResponse<string>(200, "Product deleted successfully", null);
        }        

    }
}
