using System;
using MarsRover.Infrastructure.Commands;
using MarsRover.Infrastructure.Contracts;

namespace MarsRover.Infrastructure
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand GetCommand(char letter)
        {
            switch (letter)
            {
                case 'L':
                    return new LeftCommand();
                case 'R':
                    return new RightCommand();
                case 'M':
                    return new MoveCommand();
                default:
                    throw new ArgumentException($"{letter} is not valid command!");
            }
        }
    }
}
