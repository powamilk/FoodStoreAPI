using AutoMapper;
using FoodStoreAPI.Entities;
using FoodStoreAPI.ViewModel;

namespace FoodStoreAPI.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Order, UpdateOrderVM>().ReverseMap();

            CreateMap<Product, ProductVM>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemVM>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ReverseMap();

            CreateMap<Order, OrderVM>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();
        }
    }
}
