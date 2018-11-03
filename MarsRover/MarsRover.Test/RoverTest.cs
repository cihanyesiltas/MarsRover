using System;
using MarsRover.Infrastructure;
using MarsRover.Infrastructure.Commands;
using MarsRover.Infrastructure.Contracts;
using MarsRover.Infrastructure.DTOs;
using Moq;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1 1")]
        [InlineData("X Y N")]
        [InlineData("1 Y N")]
        [InlineData("X 1 N")]
        [InlineData("1 1 R")]
        public void SetPosition_InvalidPositionLetter_ExceptionThrown(string positionLetter)
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();

            var rover = new Rover(plateau, mockCommandFactory.Object);
            Assert.Throws<Exception>(()=> rover.SetPosition(new SetPositionDTO { PositionLetter = positionLetter }));
        }

        [Fact]
        public void SetPosition_ValidPositionLetter_GetPosition()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 N" });
            Assert.Equal("1 1 N", rover.GetPosition());
        }

        [Fact]
        public void TurnLeft_RoverOrientationNorth_BeWest()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new LeftCommand());
            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 N" });
            rover.TurnLeft();

            Assert.Equal("1 1 W", rover.GetPosition());
        }

        [Fact]
        public void TurnLeft_RoverOrientationWest_BeSouth()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();

            var rover = new Rover(plateau, mockCommandFactory.Object);
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new LeftCommand());
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 W" });
            rover.TurnLeft();

            Assert.Equal("1 1 S", rover.GetPosition());
        }

        [Fact]
        public void TurnLeft_RoverOrientationSouth_BeEast()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new LeftCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 S" });
            rover.TurnLeft();

            Assert.Equal("1 1 E", rover.GetPosition());
        }

        [Fact]
        public void TurnLeft_RoverOrientationEast_BeNorth()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new LeftCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 E" });
            rover.TurnLeft();

            Assert.Equal("1 1 N", rover.GetPosition());
        }

        [Fact]
        public void TurnRight_RoverOrientationNorth_BeEast()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new RightCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 N" });
            rover.TurnRight();

            Assert.Equal("1 1 E", rover.GetPosition());
        }

        [Fact]
        public void TurnRight_RoverOrientationEast_BeSouth()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new RightCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 E" });
            rover.TurnRight();

            Assert.Equal("1 1 S", rover.GetPosition());
        }

        [Fact]
        public void TurnRight_RoverOrientationSouth_BeWest()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new RightCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 S" });
            rover.TurnRight();

            Assert.Equal("1 1 W", rover.GetPosition());
        }

        [Fact]
        public void TurnRight_RoverOrientationWest_BeNorth()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new RightCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 W" });
            rover.TurnRight();

            Assert.Equal("1 1 N", rover.GetPosition());
        }

        [Fact]
        public void MoveForward_RoverOrientationNorth_IncreaseY()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new MoveCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 N" });
            rover.MoveForward();

            Assert.Equal("1 2 N", rover.GetPosition());
        }

        [Fact]
        public void MoveForward_RoverOrientationEast_IncreaseX()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new MoveCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 E" });
            rover.MoveForward();

            Assert.Equal("2 1 E", rover.GetPosition());
        }

        [Fact]
        public void MoveForward_RoverOrientationSouth_DecreaseY()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new MoveCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 S" });
            rover.MoveForward();

            Assert.Equal("1 0 S", rover.GetPosition());
        }

        [Fact]
        public void MoveForward_RoverOrientationWest_DecreaseX()
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
            mockCommandFactory.Setup(a => a.GetCommand(It.IsAny<char>())).Returns(new MoveCommand());

            var rover = new Rover(plateau, mockCommandFactory.Object);
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 W" });
            rover.MoveForward();

            Assert.Equal("0 1 W", rover.GetPosition());
        }

        [Theory]
        [InlineData("")]
        [InlineData("lmr")]
        [InlineData("L M R")]
        [InlineData("L M 1")]
        public void RunCommandList_InvalidCommandLetters_ExceptionThrown(string commandLetters)
        {
            var plateau = new Plateau("5 5");
            var mockCommandFactory = new Mock<ICommandFactory>();
         
            var rover = new Rover(plateau, mockCommandFactory.Object);
            
            Assert.Throws<Exception>(
                () => rover.RunCommandList(new RunCommandListDTO {CommandLetters = commandLetters}));
        }

        [Fact]
        public void RunCommandList_ValidCommandLetters_BeNewPosition()
        {
            var plateau = new Plateau("5 5");

            var rover = new Rover(plateau, new CommandFactory());
            rover.SetPosition(new SetPositionDTO { PositionLetter = "1 1 W" });
            rover.RunCommandList(new RunCommandListDTO{CommandLetters = "LMR"});

            Assert.Equal("1 0 W", rover.GetPosition());
        }
    }
}
