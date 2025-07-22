using Application.Moduels.Customer.Commands;
using FluentValidation;

namespace Application.Moduels.Customer.Validators
{
    public class UpdateCustomerConmmandValidator : AbstractValidator<UpdateCustomerCommand>
    {


        public UpdateCustomerConmmandValidator()
        {
            RuleFor(C => C.Response.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.Response.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.Response.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.Response.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");

        }



    }



}
