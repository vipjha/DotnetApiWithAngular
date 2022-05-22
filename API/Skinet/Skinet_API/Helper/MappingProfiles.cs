using AutoMapper;
using Skinet_API.Dtos;
using Skinet_Core.Entities;
using Skinet_Core.Entities.Identity;

namespace Skinet_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d=>d.ProductBrand, o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=>d.ProductType, o=>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(d=>d.PictureUrl, o=>o.MapFrom<ProductUrlResolver>());
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
