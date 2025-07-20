
using Application.Moduels.ItemGallery.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interface;

namespace Application.Moduels.ItemGallery.Handlers
{
    public class DeleteItemGalleryHandler(IItemGalleryRepository repository) : DeleteHandler<DeleteItemGalleryCommand>
    {
        private readonly IItemGalleryRepository _repository = repository;

        public override async Task<bool> Handle(DeleteItemGalleryCommand request, CancellationToken cancellationToken)
        {
            var itemGallery = await _repository.GetByIDAsync(request.ID);
            if (itemGallery != null) {
                await _repository.DeleteAsync(request.ID);
                return true;
            }
            return false;
        }
    }





}

