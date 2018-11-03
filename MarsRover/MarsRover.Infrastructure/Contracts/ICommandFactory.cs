namespace MarsRover.Infrastructure.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(char letter);
    }
}
