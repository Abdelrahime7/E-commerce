using Application.Moduels.Sale.Commands;
using FluentValidation;

namespace Application.Moduels.Sale.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreateSaleCommand>
    {

        
        public CrateCommandValidator()
        {
            RuleFor(C => C.saleDto.TotalFees).NotEmpty().WithMessage("Total Fees is required");
            RuleFor(C => C.saleDto.OrderId).NotEmpty().WithMessage("Order Id is required");
           

        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdateSaleCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.TotalFees).NotEmpty().WithMessage("Total Fees is required");
            RuleFor(C => C.Response.OrderId).NotEmpty().WithMessage("Order Id is required");


        }



    }

    public class DeleteCommandValidator : AbstractValidator<SoftDeleteSaleCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
