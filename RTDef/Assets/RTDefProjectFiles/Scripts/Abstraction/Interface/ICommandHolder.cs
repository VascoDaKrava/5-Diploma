using RTDef.Abstraction.Commands;
using RTDef.Enum;
using System.Collections.Generic;


namespace RTDef.Abstraction
{
    /// <summary>
    /// Object, who can handle commands
    /// </summary>
    public interface ICommandHolder : IDataForPanel
    {
        /// <summary>
        /// Commands as Keys and Executors as values
        /// </summary>
        SortedDictionary<CommandName, CommandExecutorBase> AwailableExecutors { get; }

        IReadOnlyList<CommandName> AwailableCommands { get; }

        CommandName CurrentCommand { get; set; }
    }
}