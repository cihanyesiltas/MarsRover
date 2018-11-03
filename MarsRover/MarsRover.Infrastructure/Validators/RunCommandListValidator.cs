using FluentValidation;
using MarsRover.Infrastructure.DTOs;

namespace MarsRover.Infrastructure.Validators
{
    public class RunCommandListValidator : AbstractValidator<RunCommandListDTO>
    {
        public RunCommandListValidator()
        {
            RuleFor(dto => dto).NotNull().DependentRules(() =>
            {
                RuleFor(dto => dto.CommandLetters).NotNull().NotEmpty().Matches(@"^[LMR]+$")
                    .WithMessage("Invalid rover command letters!");
            });
        }
    }
}
