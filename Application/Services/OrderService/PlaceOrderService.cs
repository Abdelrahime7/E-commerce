using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OrderService
{
    public class PlaceOrderService : IIorderService
    {
        public Task<Guid> PlaceOrderAsync(OrderDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
