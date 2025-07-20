using Application.DTOs.Purchase;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Purchase.Queries.Queries;

namespace Application.Moduels.Purchase.Handlers
{
    public class GetAllPurchasesHandler : GetAllHandler<GetAllPurchasesQuery, PurchasHistoryDto>
    {
        public GetAllPurchasesHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }
    }
}
