using Application.Moduels.Inventory.Commands;
using FluentValidation;

namespace Application.Moduels.Inventory.Validators
{
    public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommand>
    {


        public UpdateInventoryCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.ItemID).NotEqual(0).NotEmpty().WithMessage("ID is required");

            RuleFor(C => C.Response.InventoryDevision).NotEmpty().WithMessage("Inventory Devision is required");
            RuleFor(C => C.Response.ItemQuantity).NotEmpty().NotEqual(0).WithMessage("Item Quantity is required");



        }



    }
}
