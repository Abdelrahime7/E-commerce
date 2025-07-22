using Application.Moduels.Inventory.Commands;
using FluentValidation;

namespace Application.Moduels.Inventory.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreateInventoryCommand>
    {

        
        public CrateCommandValidator()
        {
            RuleFor(C => C.inventoryDto.InventoryDevision).NotEmpty().WithMessage("Inventory Devision is required");
            RuleFor(C => C.inventoryDto.ItemQuantity).NotEmpty().NotEqual(0).WithMessage("Item Quantity is required");
          

        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdateInventoryCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.ItemID).NotEqual(0).NotEmpty().WithMessage("ID is required");

            RuleFor(C => C.Response.InventoryDevision).NotEmpty().WithMessage("Inventory Devision is required");
            RuleFor(C => C.Response.ItemQuantity).NotEmpty().NotEqual(0).WithMessage("Item Quantity is required");



        }



    }


    public class DeleteCommandValidator : AbstractValidator<SoftDeleteInventoryCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }
}
