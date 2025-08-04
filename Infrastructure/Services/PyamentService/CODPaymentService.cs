using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using AutoMapper;
using Domain.Cart;
using Domain.entities;
using Domain.Enums;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Infrastructure.Services.PyamentService
{
    public class CODPaymentService : ICODService
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CODPaymentService(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
             _orderService = orderService;
        }

        public async Task<bool> ConfirmAsync(int ID)
        {
            OrderDto orderDto = await _orderService.GetOrderByID(ID);
     Order order= _mapper.Map<Order>(orderDto);
            if (order != null)
            {
                order.Status = OrderStatus.Confirmed;
                return true;
            }
           
            return false;
               
        }

        public async Task InitiateAsync(Cart cart)
        {
           if (cart == null) throw new ArgumentNullException(nameof(cart));
            OrderDto orderDto = _mapper.Map<OrderDto>(cart);
         
             await _orderService.PlaceOrderAsync(orderDto);
           
        }

        
    }
}
