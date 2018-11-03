using System;
using MarsRover.Infrastructure;
using MarsRover.Infrastructure.Commands;
using Xunit;

namespace MarsRover.Test
{
    public class CommandFactoryTest
    {
        [Fact]
        public void GetCommand_CommandLetter_L_ReturnLeftCommand()
        {
            var commandFactory = new CommandFactory();
            var command =commandFactory.GetCommand('L');
            Assert.Equal(typeof(LeftCommand), command.GetType());
        }

        [Fact]
        public void GetCommand_CommandLetter_R_ReturnRightCommand()
        {
            var commandFactory = new CommandFactory();
            var command = commandFactory.GetCommand('R');
            Assert.Equal(typeof(RightCommand), command.GetType());
        }

        [Fact]
        public void GetCommand_CommandLetter_M_ReturnMoveCommand()
        {
            var commandFactory = new CommandFactory();
            var command = commandFactory.GetCommand('M');
            Assert.Equal(typeof(MoveCommand), command.GetType());
        }

        [Fact]
        public void GetCommand_InvalidCommandLetter_A_ExceptionThrown()
        {
            var commandFactory = new CommandFactory();
            Assert.Throws<ArgumentException>(() => commandFactory.GetCommand('A'));
        }
    }
}
