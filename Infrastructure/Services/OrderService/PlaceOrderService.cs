using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using  MediatR;
using static Application.Moduels.Order.Queries.Queries;


namespace Infrastructure.Services.OrderService
{
     
    public class PlaceOrderService : IOrderService
    {
        private readonly Mediator _mediator;


        public PlaceOrderService(Mediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OrderDto> GetOrderByID(int orderId)=>await _mediator.Send( new GetOrderByIdQuery(orderId));
      
        public async Task PlaceOrderAsync(OrderDto dto)
        {
            if (dto!=null)
            {
                await _mediator.Send(dto);
            }
           
        }
    }
}
