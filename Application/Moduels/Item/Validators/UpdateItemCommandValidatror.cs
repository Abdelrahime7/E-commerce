using Application.Moduels.Item.Commands;
using FluentValidation;

namespace Application.Moduels.Item.Validators
{
    public class UpdateItemCommandValidatror : AbstractValidator<UpdateItemCommand>
    {


        public UpdateItemCommandValidatror()
        {
            RuleFor(C => C.Request.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(C => C.Request.Name).NotEmpty().WithMessage("name is required");
            RuleFor(C => C.Request.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(C => C.Request.ItemQuantity).NotEmpty().WithMessage("Item Quantity is required");
            RuleFor(C => C.Request.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.Request.ExpireDate).NotEmpty().WithMessage("ExpireDate is required");
            RuleFor(C => C.Request.ProdDate).NotEmpty().WithMessage("ProdDate is required");
            RuleFor(C => C.Request.UnitType).NotEmpty().WithMessage("UnitType is required");



        }



    }


}
