using AutoMapper;
using TestApi1.DTO.Request;
using TestApi1.DTO.Response;
using TestApi1.Models;

namespace TestApi1.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper() {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<ProductCreationRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();
        }
    }
}
