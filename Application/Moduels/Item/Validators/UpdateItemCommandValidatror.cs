using Application.Moduels.Item.Commands;
using FluentValidation;

namespace Application.Moduels.Item.Validators
{
    public class UpdateItemCommandValidatror : AbstractValidator<UpdateItemCommand>
    {


        public UpdateItemCommandValidatror()
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


}
