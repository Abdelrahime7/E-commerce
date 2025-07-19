using Application.DTOs.Sale;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Sale.Queries.Queries;

namespace Application.Moduels.Sale.Handlers
{
   public class GetSaleByIdHandler: GetByIdHander<GetSaleByIdQuery, SaleDto>
    {
        public GetSaleByIdHandler(IMapper mapper,ISaleRepository repository) :base (mapper, (IGenericRepository<IEntity>)repository)
        {
            
        }


        protected override int GetID(GetSaleByIdQuery query) => query.Id;
      
    }
}
