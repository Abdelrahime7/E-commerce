﻿using Application.DTOs.Customer;
using MediatR;

namespace Application.Moduels.Customer.Queries
{
    public class Queries
    {
        public record GetCustomerByIdQuery(int Id) : IRequest<CustomerDto>;
        public record GetAllCustomersQuery : IRequest<IReadOnlyCollection<CustomerDto>>;


    }
}
