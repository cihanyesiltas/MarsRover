namespace MarsRover.Infrastructure.Contracts
{
    public interface ICommand
    {
        void Execute(Rover rover);
    }
}
