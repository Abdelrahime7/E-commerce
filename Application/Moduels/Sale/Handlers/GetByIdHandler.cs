using Application.DTOs.Sale;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Sale.Queries.Queries;

namespace Application.Moduels.Sale.Handlers
{
   public class GetSaleByIdHandler: GetByIdHander<GetSaleByIdQuery, SaleDto>
    {
        public GetSaleByIdHandler(IMapper mapper,ISaleRepository repository,
            ILogger<GetSaleByIdHandler>logger) :base (mapper, (IGenericRepository<IEntity>)repository, logger)
        {
            
        }


        protected override int GetID(GetSaleByIdQuery query) => query.Id;
      
    }
}
