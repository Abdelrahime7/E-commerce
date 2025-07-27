using Application.DTOs.Review;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Review.Queries.Queries;

namespace Application.Moduels.Review.Handlers
{
    public class GetAllReviewsHandler : GetAllHandler<GetAllReviewsQuery, ReviewDto>
    {
        public GetAllReviewsHandler(IMapper mapper,IReviewRepository repository,
            ILogger<GetAllReviewsHandler> logger) : base(mapper, (IGenericRepository<IEntity>)repository,logger)
        {
        }
    }
}
