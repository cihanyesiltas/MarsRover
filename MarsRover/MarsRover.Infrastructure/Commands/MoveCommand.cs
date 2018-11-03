using MarsRover.Infrastructure.Contracts;

namespace MarsRover.Infrastructure.Commands
{
    public class MoveCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover?.MoveForward();
        }
    }
}
