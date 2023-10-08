using AutoMapper;
using project.contracts.Products;
using project.domain.Entities;

namespace project.application.Mappings.Products
{
    public class PostProductMappingProfile : Profile
    {
        public PostProductMappingProfile()
        {
            CreateMap<PostProductRequest, Product>(MemberList.Destination)
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
                .ForMember(x => x.ImageURL, opt => opt.MapFrom(x => x.ImageURL));
        }
    }
}
