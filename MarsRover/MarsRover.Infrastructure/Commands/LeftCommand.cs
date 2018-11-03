using MarsRover.Infrastructure.Contracts;

namespace MarsRover.Infrastructure.Commands
{
    public class LeftCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover?.TurnLeft();
        }
    }
}
