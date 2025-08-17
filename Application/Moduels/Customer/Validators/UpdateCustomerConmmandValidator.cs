using Application.Moduels.Customer.Commands;
using FluentValidation;

namespace Application.Moduels.Customer.Validators
{
    public class UpdateCustomerConmmandValidator : AbstractValidator<UpdateCustomerCommand>
    {


        public UpdateCustomerConmmandValidator()
        {
            RuleFor(C => C.Request.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Request.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.Request.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.Request.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.Request.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");

        }



    }



}
