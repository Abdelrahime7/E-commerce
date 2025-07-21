


using Application.Moduels.Review.Commands;
using Application.Moduels.GenericHndlers;


using Application.Interface;

namespace Application.Moduels.Review.Handlers
{
    public class DeleteReviewHandler(IReviewRepository repository) : DeleteHandler<SoftDeleteReviewCommand>
    {
        private readonly IReviewRepository _repository = repository;

       public override async Task<bool> Handle(SoftDeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetByIDAsync(request.ID);
            if (review == null) 
                return false;
           return await _repository.SoftDeleteAsync(review.Id)>0;
           
          

        }
    }





}

