using RTDef.Enum;
using System.Collections.Generic;


namespace RTDef.Abstraction.Commands
{
    public abstract class CommandHolderBase : SelectableObjectBase, ICommandHolder
    {

        #region Fields

        private CommandName _currentCommand;

        #endregion


        #region Properties

        public CommandName CurrentCommand
        {
            get => _currentCommand;
            set
            {
                if (value != _currentCommand && _currentCommand != CommandName.None)
                {
                    AwailableExecutors[_currentCommand].StopExecuteCommand();
                }

                _currentCommand = value;
            }
        }

        public IReadOnlyList<CommandName> AwailableCommands { get; private set; }
        public SortedDictionary<CommandName, CommandExecutorBase> AwailableExecutors { get; private set; }

        #endregion


        #region Mono

        private protected virtual void Awake()
        {
            AwailableExecutors = new SortedDictionary<CommandName, CommandExecutorBase>();

            foreach (var commandExecutor in gameObject.GetComponentsInChildren<CommandExecutorBase>())
            {
                AwailableExecutors.Add(commandExecutor.ExecutorCommandName, commandExecutor);
            }

            AwailableCommands = new List<CommandName>(AwailableExecutors.Keys);
        }

        #endregion

    }
}