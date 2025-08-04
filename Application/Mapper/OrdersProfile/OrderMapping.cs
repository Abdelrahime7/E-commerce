using Application.DTOs.Order;
using AutoMapper;
using Domain.Cart;
using Domain.entities;
using Domain.Enums;

namespace Application.Mapper.OrdersProfile;

 internal class OrderMapping : Profile
{
   

      public void ApllyMapping()
    {
      CreateMap<Order, OrderDto>();
    }
   

}
public class CartToOrderProfile : Profile
{
    public CartToOrderProfile()
    {
        CreateMap<ClientInfo, Customer>();

        CreateMap<ItemDetaills, Invoice>()
            .ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.itemID))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total));

        CreateMap<Cart, OrderDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.clientInfo))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.itemDetaills.Sum(i => i.total)))
            .ForMember(dest => dest.invoices, opt => opt.MapFrom(src => src.itemDetaills))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src=> OrderStatus.PendingConfired))
            .ForMember(dest => dest.PurchaseHistory, opt => opt.MapFrom(src => new PurchaseHistory()))
            .ForMember(dest => dest.Sale, opt => opt.MapFrom(src => new { }));
    }
}

