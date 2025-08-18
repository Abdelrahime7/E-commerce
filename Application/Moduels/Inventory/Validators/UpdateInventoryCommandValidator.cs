using Application.Moduels.Inventory.Commands;
using FluentValidation;

namespace Application.Moduels.Inventory.Validators
{
    public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommand>
    {


        public UpdateInventoryCommandValidator()
        {
            RuleFor(C => C.Request.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Request.ItemID).NotEqual(0).NotEmpty().WithMessage("ID is required");
                          
            RuleFor(C => C.Request.InventoryDevision).NotEmpty().WithMessage("Inventory Devision is required");
            RuleFor(C => C.Request.ItemQuantity).NotEmpty().NotEqual(0).WithMessage("Item Quantity is required");



        }



    }
}
