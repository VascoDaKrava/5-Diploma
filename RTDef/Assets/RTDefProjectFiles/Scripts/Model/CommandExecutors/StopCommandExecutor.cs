using RTDef.Abstraction.Commands;
using RTDef.Enum;
using System;


namespace RTDef.Game.Commands
{
    public sealed class StopCommandExecutor : CommandExecutorBase
    {

        #region Properties

        public override CommandName ExecutorCommandName => CommandName.Stop;

        #endregion


        #region Methods

        public override void CommandFinish()
        {
            throw new MissingMethodException("CommandFinish in StopCommandExecutor!");
        }

        public override void StopExecuteCommand()
        {
            throw new MissingMethodException("StopExecuteCommand in StopCommandExecutor!");
        }

        public override void TryExecuteCommand(ICommand command)
        {
            var stopCommand = (IStopCommand)command;

            if (stopCommand.CommandToStop == CommandName.None)
            {
                return;
            }

            CommandHolder.AwailableExecutors[stopCommand.CommandToStop].StopExecuteCommand();
        }

        #endregion

    }
}