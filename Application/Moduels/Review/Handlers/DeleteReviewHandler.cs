

using Domain.Interface;
using Application.Moduels.Review.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.Review.Handlers
{
    public class DeleteReviewHandler :DeleteHandler<DeleteReviewCommand>
    {
        public DeleteReviewHandler( IReviewRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteReviewCommand command)=>command.ID;





    }





}

