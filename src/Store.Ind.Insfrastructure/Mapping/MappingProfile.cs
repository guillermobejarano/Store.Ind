using AutoMapper;
using Store.Ind.Domain.Dtos;
using Store.Ind.Domain.Entities;
using System.Linq;

namespace Store.Ind.Insfrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(
                      dest => dest.Quantity,
                      opt => opt.MapFrom(src => src.Variants.Sum(x => x.Stock)))
                .ForMember(
                      dest => dest.BrandName,
                      opt => opt.MapFrom(src => src.Brand.Name))
                   .ForMember(
                      dest => dest.CategoryName,
                      opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
            ////.AfterMap((product, productDto) => product.Category = new Category { 
            ////    Name = productDto.Name
            //}).ReverseMap();
            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<Variant, VariantDto>()
               .ReverseMap();
        }
    }
}
