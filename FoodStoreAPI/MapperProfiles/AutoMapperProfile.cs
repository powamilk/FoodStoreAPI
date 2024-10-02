using AutoMapper;
using FoodStoreAPI.Entities;
using FoodStoreAPI.ViewModel;
using FoodStoreAPI.ViewModel.Order;

namespace FoodStoreAPI.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();

            CreateMap<Product, ProductVM>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemVM>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ReverseMap();

            CreateMap<OrderItem, DisplayOrderItemVM>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ReverseMap();

            CreateMap<Order, DisplayOrderVM>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems)) 
                .ReverseMap();

            CreateMap<Order, CreateOrderVM>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();

            CreateMap<Order, EditOrderVM>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();
        }
    }
}
