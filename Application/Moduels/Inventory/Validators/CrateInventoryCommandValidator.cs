using Application.Moduels.Inventory.Commands;
using FluentValidation;

namespace Application.Moduels.Inventory.Validators
{
    public class CrateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
    {

        
        public CrateInventoryCommandValidator()
        {
            RuleFor(C => C.inventoryDto.InventoryDevision).NotEmpty().WithMessage("Inventory Devision is required");
            RuleFor(C => C.inventoryDto.ItemQuantity).NotEmpty().NotEqual(0).WithMessage("Item Quantity is required");
          

        }



    }
}
