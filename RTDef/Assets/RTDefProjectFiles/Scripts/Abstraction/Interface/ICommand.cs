using RTDef.Enum;


namespace RTDef.Abstraction
{
    public interface ICommand
    {
        CommandName Command { get; }
    }
}