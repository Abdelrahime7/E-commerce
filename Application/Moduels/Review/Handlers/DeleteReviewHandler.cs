


using Application.Moduels.Review.Commands;
using Application.Moduels.GenericHndlers;


using Application.Interface;

namespace Application.Moduels.Review.Handlers
{
    public class DeleteReviewHandler(IReviewRepository repository) : DeleteHandler<DeleteReviewCommand>
    {
        private readonly IReviewRepository _repository = repository;

       public override async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetByIDAsync(request.ID);
            if (review == null) 
                return false;
            await _repository.DeleteAsync(review.Id);
           
            return true;

        }
    }





}

