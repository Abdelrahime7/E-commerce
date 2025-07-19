using Application.DTOs.Purchase;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Purchase.Queries.Queries;

namespace Application.Moduels.Purchase.Handlers
{
   public class GetPurchaseByIdHandler: GetByIdHander<GetPurchaseByIdQuery, PurchasHistoryDto>
    {
        public GetPurchaseByIdHandler(IMapper mapper,IPurchaseRepository repository) :base (mapper, (IGenericRepository<IEntity>)repository)
        {
            
        }


        protected override int GetID(GetPurchaseByIdQuery query) => query.Id;
      
    }
}
