using AutoMapper;
using TestApi1.DTO.Request;
using TestApi1.DTO.Response;
using TestApi1.Models;

namespace TestApi1.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() {
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<CategoryCreationRequest, Category>();
            CreateMap<CategoryUpdateRequest, Category>();
        }
    }
}
