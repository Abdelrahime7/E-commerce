using FluentValidation;
using MediatR;


namespace Application.Moduels.Common.Behaviors
{
    public class ValidationBehavior<Trequest, Trespons> : IPipelineBehavior<Trequest, Trespons>
        where Trequest : IRequest<Trespons>
    {
        private readonly IEnumerable<IValidator<Trequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<Trequest>> validators)
        {
            _validators = validators;
        }

        public async Task<Trespons> Handle(Trequest request, RequestHandlerDelegate<Trespons> next, CancellationToken cancellationToken)
        {


            var context = new ValidationContext<Trequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);

            return await next(cancellationToken);

        }
    }
}
