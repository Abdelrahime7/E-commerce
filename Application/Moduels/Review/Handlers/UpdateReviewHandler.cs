using AutoMapper;

using Domain.Interface;
using Application.Moduels.Review.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Review;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Review.Handlers
{
    public class UpdateReviewHandler : UpdateHandler<UpdateReviewCommand,ReviewDto>
    {
        public UpdateReviewHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdateReviewHandler>logger) : base(mapper, repository,logger)
        {
        }

        protected override int GetId(UpdateReviewCommand command) => command.Response.Id;
       
    }





}

