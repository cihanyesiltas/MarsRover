using FluentValidation;

namespace MarsRover.Infrastructure.Validators
{
    public class PlateauUpperRightCoordinateLetterValidator : AbstractValidator<string>
    {
        public PlateauUpperRightCoordinateLetterValidator()
        {
            RuleFor(letter => letter).NotNull().NotEmpty().Matches(@"^[1-9][0-9]* [1-9][0-9]*$")
                .WithMessage("Invalid upper-right coordinate letter!");
        }
    }
}
