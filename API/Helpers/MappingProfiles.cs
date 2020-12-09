using API.DTOS;
using API.Models;
using API.Models.Identity;
using API.Models.OrderAggregate;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, p => p.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, p => p.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, p => p.MapFrom<ProductUrlResolver>());
            CreateMap<Models.Identity.Adress, AdressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AdressDto, Models.OrderAggregate.Address>();
                 CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
               .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
               .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
               .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
               .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}