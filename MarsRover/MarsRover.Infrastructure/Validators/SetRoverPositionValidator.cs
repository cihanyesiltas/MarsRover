using FluentValidation;
using MarsRover.Infrastructure.DTOs;

namespace MarsRover.Infrastructure.Validators
{
    public class SetRoverPositionValidator : AbstractValidator<SetPositionDTO>
    {
        public SetRoverPositionValidator()
        {
            RuleFor(dto => dto).NotNull().DependentRules(() =>
            {
                RuleFor(dto => dto.PositionLetter).NotNull().NotEmpty().Matches(@"^[0-9]+ [0-9]+ [NSWE]$")
                    .WithMessage("Invalid rover position letter!");
            });
        }
    }
}
