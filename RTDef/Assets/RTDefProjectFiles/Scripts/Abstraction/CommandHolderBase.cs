using RTDef.Enum;
using System.Collections.Generic;


namespace RTDef.Abstraction.Commands
{
    public abstract class CommandHolderBase : SelectableObjectBase, ICommandHolder
    {

        #region Properties

        public CommandName CurrentCommand { get; private set; }
        public IReadOnlyList<CommandName> AwailableCommands { get; private set; }
        public SortedDictionary<CommandName, CommandExecutorBase> AwailableExecutors { get; private set; }

        #endregion


        #region Mono

        private void Awake()
        {
            AwailableExecutors = new SortedDictionary<CommandName, CommandExecutorBase>();

            foreach (var commandExecutor in gameObject.GetComponentsInChildren<CommandExecutorBase>())
            {
                AwailableExecutors.Add(commandExecutor.CommandName, commandExecutor);
            }

            AwailableCommands = new List<CommandName>(AwailableExecutors.Keys);
        }

        #endregion

    }
}