using Application.Moduels.Item.Commands;
using Domain.Enums;
using FluentValidation;

namespace Application.Moduels.Item.Validators
{
    public class CrateCommandValidatror:AbstractValidator<CreateItemCommand>
    {

        
        public CrateCommandValidatror()
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

    public class UpdateCommandValidatror : AbstractValidator<UpdateItemCommand>
    {


        public UpdateCommandValidatror()
        {
            RuleFor(C => C.Response.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(C => C.Response.Name).NotEmpty().WithMessage("name is required");
            RuleFor(C => C.Response.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(C => C.Response.ItemQuantity).NotEmpty().WithMessage("Item Quantity is required");
            RuleFor(C => C.Response.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.Response.ExpireDate).NotEmpty().WithMessage("ExpireDate is required");
            RuleFor(C => C.Response.ProdDate).NotEmpty().WithMessage("ProdDate is required");
            RuleFor(C => C.Response.UnitType).NotEmpty().WithMessage("UnitType is required");



        }



    }
    public class DeleteCommandValidator : AbstractValidator<SoftDeleteItemCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }


}
