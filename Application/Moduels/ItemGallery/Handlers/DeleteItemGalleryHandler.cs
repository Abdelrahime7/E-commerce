
using Application.Moduels.ItemGallery.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interface;

namespace Application.Moduels.ItemGallery.Handlers
{
    public class DeleteItemGalleryHandler(IItemGalleryRepository repository) : DeleteHandler<SoftDeleteItemGalleryCommand>
    {
        private readonly IItemGalleryRepository _repository = repository;

        public override async Task<bool> Handle(SoftDeleteItemGalleryCommand request, CancellationToken cancellationToken)
        {
            var itemGallery = await _repository.GetByIDAsync(request.ID);
            if (itemGallery != null) {
              return  await _repository.SoftDeleteAsync(request.ID)>0;
              
            }
            return false;
        }
    }





}

