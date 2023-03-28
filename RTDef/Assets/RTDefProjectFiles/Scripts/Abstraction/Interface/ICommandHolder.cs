using System.Collections.Generic;


namespace RTDef.Abstraction
{
    public interface ICommandHolder : IDataForPanel
    {
        List<ICommand> AwailableCommands { get; }
    }
}