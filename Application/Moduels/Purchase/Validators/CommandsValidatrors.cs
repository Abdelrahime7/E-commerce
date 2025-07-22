using Application.Moduels.Purchase.Commands;
using FluentValidation;

namespace Application.Moduels.Purchase.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreatePurchaseCommand>
    {

        
        public CrateCommandValidator()
        {
            RuleFor(C => C.purhcaseDto.OrderId).NotEmpty().WithMessage("Order Id is required");
            RuleFor(C => C.purhcaseDto.CustomerId).NotEmpty().WithMessage("Customer Id is required");
          

        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdatePurchaseCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(C => C.Response.OrderId).NotEmpty().WithMessage("Order Id is required");
            RuleFor(C => C.Response.CustomerId).NotEmpty().WithMessage("Customer Id is required");


        }



    }
    public class DeleteCommandValidator : AbstractValidator<SoftDeletePurchaseCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }


}
