using Application.DTOs.Customer;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Customer.Queries.Queries;

namespace Application.Moduels.Customer.Handlers
{
   public class GetCustomerByIdHandler: GetByIdHander<GetCustomerByIdQuery, CustomerDto>
    {
        public GetCustomerByIdHandler(IMapper mapper,ICustomerRepository repository) :base (mapper, (IGenericRepository<IEntity>)repository)
        {
            
        }


        protected override int GetID(GetCustomerByIdQuery query) => query.Id;
      
    }
}
