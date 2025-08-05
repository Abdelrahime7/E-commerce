using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using Application.Moduels.Order.Commands;
using  MediatR;
using System.Net.Http.Headers;
using static Application.Moduels.Order.Queries.Queries;


namespace Infrastructure.Services.OrderService
{
     
    public class OrderService : IOrderService
    {
        private readonly Mediator _mediator;


        public OrderService(Mediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
            => await _mediator.Send(new GetAllOrdersQuery());
       

        public async Task<OrderDto> GetOrderByIDAsync(int ID)
            =>await _mediator.Send( new GetOrderByIdQuery(ID));

        public async Task PlaceOrderAsync(OrderDto dto)   
          => await _mediator.Send(dto);
            
        public async Task<bool> SoftDeleteOrderAsync(int ID)
            => await _mediator.Send( new SoftDeleteOrderCommand(ID));
     

        public async Task<OrderDto> UpdateOrderAsync(OrderResponse response)
           => await _mediator.Send(new UpdateOrderCommand(response));

           
        
    }
}
