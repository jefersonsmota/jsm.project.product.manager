using AutoMapper;
using jsm.product.manager.contracts.Products;
using jsm.product.manager.domain.Entities;

namespace jsm.product.manager.application.Mappings.Products
{
    public class GetProductResponseMappingProfile : Profile
    {
        public GetProductResponseMappingProfile()
        {
            CreateMap<Product, GetProductResponse>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
                .ForMember(x => x.ImageURL, opt => opt.MapFrom(x => x.ImageURL));
        }
    }
}
