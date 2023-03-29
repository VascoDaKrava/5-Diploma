using RTDef.Enum;
using System.Collections.Generic;


namespace RTDef.Abstraction
{
    /// <summary>
    /// Object, who can send commands
    /// </summary>
    public interface ICommandHolder : IDataForPanel
    {
        SortedSet<CommandName> AwailableCommands { get; }
    }
}