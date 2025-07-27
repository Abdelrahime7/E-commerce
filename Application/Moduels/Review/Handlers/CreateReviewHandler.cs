
using AutoMapper;
using Domain.Interface;
using Application.Moduels.Review.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.Review.Handlers
{


    public class CreateReviewHandler : CreatHandler<CreateReviewCommand>
    {
        public CreateReviewHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<CreateReviewHandler> logger) : base(mapper, repository, logger)
        {

        }

    }





}
