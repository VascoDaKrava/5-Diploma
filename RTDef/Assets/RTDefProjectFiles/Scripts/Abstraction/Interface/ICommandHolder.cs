using RTDef.Enum;
using System.Collections.Generic;


namespace RTDef.Abstraction
{
    public interface ICommandHolder : IDataForPanel
    {
        SortedSet<CommandName> AwailableCommands { get; }
    }
}