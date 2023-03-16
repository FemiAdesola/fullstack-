using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.Images, o => o.MapFrom<ImageUrlResolver>());

            CreateMap<Category, CategoryToReturnDTO>();

            // CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            // CreateMap<CustomerBasketDto, CustomerBasket>();
            // CreateMap<BasketItemDto, BasketItem>();
            // CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
            // CreateMap<Order, OrderToReturnDto>()
            //     .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
            //     .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            // CreateMap<OrderItem, OrderItemDto>()
            //     .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
            //     .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
            //     .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
            //     .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}