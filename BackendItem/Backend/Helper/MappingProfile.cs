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
               .ForMember(d => d.Category, o => o.MapFrom(s => s.Category));

            CreateMap<Category, CategoryToReturnDTO>();

            CreateMap<Order, OrderToReturnDTO>();

            CreateMap<Review, ReviewToReturnDTO>();

            CreateMap<OrderItem, OrderItemToReturnDTO>();

            CreateMap<UserSignUpDTO, User>();
            
            CreateMap<User, UserToReturnDTO >();
            
            CreateMap<Address, AddressDTO>();
        }
    }
}