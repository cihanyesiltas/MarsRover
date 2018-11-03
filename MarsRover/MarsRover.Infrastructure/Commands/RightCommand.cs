using MarsRover.Infrastructure.Contracts;

namespace MarsRover.Infrastructure.Commands
{
    public class RightCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover?.TurnRight();
        }
    }
}
