using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Validators
{
    public class ActionValidator : AbstractValidator<string>
    {
        private readonly char[] ACTIONS = { 'M', 'L', 'R' };
        public ActionValidator()
        {
           RuleFor(x=> x).Must(BeAValid).WithMessage("Wrong Direction");
        }
        private bool BeAValid(string action)
        {
            return !action.ToUpper().ToCharArray().Any(f => !ACTIONS.Contains(f));
        }
    }
}
