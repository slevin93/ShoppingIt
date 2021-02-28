using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Domain;

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDetails>()
                  .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.SalesPrice))
                  .ReverseMap();
        }
    }
}
