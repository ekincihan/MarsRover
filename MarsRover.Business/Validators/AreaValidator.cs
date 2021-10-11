using FluentValidation;
using MarsRover.Core;

namespace MarsRover.Business.Validations
{
    public class AreaValidator : AbstractValidator<IArea>
    {
        public AreaValidator()
        {
            RuleFor(x => x.X).GreaterThan(0).WithMessage("horizontal area value must be greater than zero!");
            RuleFor(x => x.Y).GreaterThan(0).WithMessage("vertical area value must be greater than zero!");
        }
    }
}
