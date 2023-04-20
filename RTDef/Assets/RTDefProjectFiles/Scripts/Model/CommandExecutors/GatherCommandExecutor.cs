using RTDef.Abstraction.Commands;
using RTDef.Enum;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class GatherCommandExecutor : CommandExecutorBase
    {
        public override CommandName ExecutorCommandName => CommandName.Gathering;

        public override void CommandFinish()
        {
            throw new System.NotImplementedException();
        }

        public override void StopExecuteCommand()
        {
            throw new System.NotImplementedException();
        }

        public override void TryExecuteCommand(ICommand baseCommand)
        {
            var command = (IGatheringCommand)baseCommand;

            Debug.Log($"Gather {command.GatheringTarget}");
        }
    }
}