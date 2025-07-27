
using Application.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.ItemGallery.Commands;
using Domain.entities;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.ItemGallery.Handlers
{
    public class DeleteItemGalleryHandler(IItemGalleryRepository repository,ILogger<DeleteItemGalleryHandler>logger) : DeleteHandler<SoftDeleteItemGalleryCommand>
    {
        private readonly IItemGalleryRepository _repository = repository;
        private readonly ILogger<DeleteItemGalleryHandler> _logger= logger;

        public override async Task<bool> Handle(SoftDeleteItemGalleryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var itemGallery = await _repository.GetByIDAsync(request.ID);
                _logger.LogInformation("try to get ItemGallery With id = {ID}", request.ID);
                if (itemGallery != null)
                {
                    _logger.LogInformation("ItemGallery With id = {ID} is found Successfully", request.ID);

                    return await _repository.SoftDeleteAsync(request.ID) > 0;
                }
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to Delete ItemGallery with id={ID}", request.ID);

              throw; }
                    
                  

            return false;
        }
    }





}

