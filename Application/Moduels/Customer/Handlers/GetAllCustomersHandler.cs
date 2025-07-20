using Application.DTOs.Customer;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Customer.Queries.Queries;

namespace Application.Moduels.Customer.Handlers
{
    public class GetAllCustomersHandler : GetAllHandler<GetAllCustomersQuery, CustomerDto>
    {
        public GetAllCustomersHandler(IMapper mapper, ICustomerRepository repository) : base(mapper, (IGenericRepository<IEntity>)repository)
        {
        }
    }
}
