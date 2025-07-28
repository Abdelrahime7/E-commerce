


using Application.Moduels.Review.Commands;
using Application.Moduels.GenericHndlers;


using Application.Interface;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Review.Handlers
{
    public class DeleteReviewHandler(IReviewRepository repository,
       ILogger<DeleteReviewHandler> logger) : DeleteHandler<SoftDeleteReviewCommand>
    {
        private readonly ILogger<DeleteReviewHandler>_logger=logger;
        private readonly IReviewRepository _repository = repository;

       public override async Task<bool> Handle(SoftDeleteReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var review = await _repository.GetByIDAsync(request.ID);
                _logger.LogInformation("get review with id : {id} ", request.ID);
                if (review == null)
                {
                    _logger.LogWarning("review with id : {id} not found ", request.ID);
                    return false;
                }

                var result= await _repository.SoftDeleteAsync(review.Id) > 0;
                _logger.LogInformation(" review with id : {id} softDeleted ", request.ID);

                return result;
            }
            catch (Exception ex) {
                _logger.LogInformation("Erorr !! review with {id} not deleted  ", request.ID);
                throw new Exception(ex.Message); }
          

        }
    }





}

