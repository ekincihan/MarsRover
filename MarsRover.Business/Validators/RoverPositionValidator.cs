using FluentValidation;
using MarsRover.Core;

namespace MarsRover.Business.Validators
{
    public class RoverPositionValidator : AbstractValidator<IRoverPosition>
    {
        private readonly IArea _area;
        public RoverPositionValidator(IArea area)
        {
            _area = area;
            RuleFor(x => x).Must(BeAValid).WithMessage("Rover position must be in the area!");
        }
        private bool BeAValid(IRoverPosition roverPosition)
        {
            return (0 <= roverPosition.X && roverPosition.X <= _area.X) &&
                   (0 <= roverPosition.Y && roverPosition.Y <= _area.Y) &&
                   (roverPosition.Direction != Core.Utilities.Direction.EMPTY);
        }
    }
}
