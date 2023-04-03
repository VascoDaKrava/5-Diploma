using RTDef.Enum;


namespace RTDef.Abstraction.Commands
{
    public interface IStopCommand : ICommand
    {
        CommandName CommandToStop { get; }
    }
}