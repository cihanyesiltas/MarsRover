using System;
using MarsRover.Infrastructure;
using Xunit;

namespace MarsRover.Test
{
    public class PlateauTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("11")]
        [InlineData("1 S")]
        [InlineData("W S")]
        public void Init_InvalidCoordinateLetter_ExceptionThrown(string upperCoordinateLetter)
        {
            Assert.Throws<Exception>(() => new Plateau(upperCoordinateLetter));
        }

        [Theory]
        [InlineData("1 1")]
        [InlineData("2 1")]
        [InlineData("2 3")]
        public void Init_ValidCoordinateLetter_ReturnPlateau(string upperCoordinateLetter)
        {
            var plateau = new Plateau(upperCoordinateLetter);
            Assert.Equal("0 0", $"{plateau.LowerLeftCoordinate.X} {plateau.LowerLeftCoordinate.Y}");
            Assert.Equal(upperCoordinateLetter, $"{plateau.UpperRightCoordinate.X} {plateau.UpperRightCoordinate.Y}");
        }
    }
}
