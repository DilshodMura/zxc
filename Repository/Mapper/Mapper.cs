using AutoMapper;
using Database.Entites;
using Domain.Entities;

namespace Repository.Mapper
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ICustomer, CustomerDb>();
            CreateMap<IOrder, OrderDb>();
            CreateMap<IOrderItem,OrderItemDb>();
            CreateMap<IProduct, ProductDb>();
        }
    }
}
