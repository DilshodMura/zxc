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
            CreateMap<ICustomer, CustomerDb>().ReverseMap();
            CreateMap<CustomerDb, Customer>();

            CreateMap<IOrder, OrderDb>().ReverseMap();
            CreateMap<OrderDb, Order>();

            CreateMap<IOrderItem,OrderItemDb>().ReverseMap();
            CreateMap<OrderItemDb, OrderItem>();

            CreateMap<IProduct, ProductDb>().ReverseMap();
            CreateMap<ProductDb, Product>();
        }
    }
}
