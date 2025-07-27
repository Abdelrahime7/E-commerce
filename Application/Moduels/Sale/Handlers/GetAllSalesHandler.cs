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
    public class GetAllSalesHandler : GetAllHandler<GetAllSalesQuery, SaleDto>
    {
        public GetAllSalesHandler(IMapper mapper, ISaleRepository  repository,
            ILogger <GetAllSalesHandler> logger) : base(mapper, (IGenericRepository<IEntity>)repository, logger)
        {
        }
    }
}
