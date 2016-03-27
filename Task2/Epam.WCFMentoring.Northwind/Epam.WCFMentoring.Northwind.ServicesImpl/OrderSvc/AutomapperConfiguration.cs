using AutoMapper;
using Epam.WCFMentoring.Northwind.DbEntities;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;

namespace Epam.WCFMentoring.Northwind.ServicesImpl.OrderSvc
{
    internal static class AutomapperConfiguration
    {
        public static void Configure() 
        {
            Mapper.CreateMap<Product, ProductDTO>()
                .ForMember(p => p.IsDiscontinued, opt => opt.MapFrom(p => p.Discontinued));

            Mapper.CreateMap<OrderDetail, OrderDetailsDTO>();

            Mapper.CreateMap<Order, OrderDTO>();
            Mapper.CreateMap<Order, DetailedOrderDTO>();


            Mapper.CreateMap<NewOrderDTO, Order>();
            Mapper.CreateMap<ChangeOrderDTO, Order>();

            Mapper.CreateMap<ProductDTO, Product>()
                .ForMember(p => p.Discontinued, opt => opt.MapFrom(p => p.IsDiscontinued));

            Mapper.CreateMap<OrderDetailsDTO, OrderDetail>();
        }
    }
}
