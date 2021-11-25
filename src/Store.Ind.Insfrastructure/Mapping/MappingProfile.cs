using AutoMapper;
using Store.Ind.Domain.Dtos;
using Store.Ind.Domain.Entities;

namespace Store.Ind.Insfrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                //.ForMember(
                //      dest => dest.CategoryName,
                //      opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(
                      dest => dest.BrandName,
                      opt => opt.MapFrom(src => src.Brand.Name))
                .ReverseMap();
            ////.AfterMap((product, productDto) => product.Category = new Category { 
            ////    Name = productDto.Name
            //}).ReverseMap();
            CreateMap<Category, CategoryDto>()
                .ReverseMap();
        }
    }
}
