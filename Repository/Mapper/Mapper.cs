using AutoMapper;
using Database.Entites;
using Domain.Entities;
using Repository.Business_Models;

namespace Repository.Mapper
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<IUser, ApplicationUserDb>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
               .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
               .ReverseMap();

            CreateMap<IUser, CustomerDb>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<IOrder, OrderDb>().ReverseMap();
            CreateMap<OrderDb, Order>();

            CreateMap<IOrderItem, OrderItemDb>().ReverseMap();
            CreateMap<OrderItemDb, OrderItem>();

            CreateMap<IProduct, ProductDb>().ReverseMap();
            CreateMap<ProductDb, Product>();
        }
    }
}
