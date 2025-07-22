using Application.Moduels.Item.Commands;
using FluentValidation;

namespace Application.Moduels.Item.Validators
{
    public class CrateItemCommandValidatror : AbstractValidator<CreateItemCommand>
    {

        
        public CrateItemCommandValidatror()
        {
       

            RuleFor(C => C.itemDto.Name).NotEmpty().WithMessage("name is required");
            RuleFor(C => C.itemDto.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(C => C.itemDto.InventoryDevision).NotEmpty().WithMessage("Inventory Devision is required");
            RuleFor(C => C.itemDto.ItemQuantity).NotEmpty().WithMessage("Email is required");
            RuleFor(C => C.itemDto.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.itemDto.ExpireDate).NotEmpty().WithMessage("ExpireDate is required");
            RuleFor(C => C.itemDto.ProdDate).NotEmpty().WithMessage("ProdDate is required");
            RuleFor(C => C.itemDto.UnitType).NotEmpty().WithMessage("UnitType is required");



        }



    }


}
