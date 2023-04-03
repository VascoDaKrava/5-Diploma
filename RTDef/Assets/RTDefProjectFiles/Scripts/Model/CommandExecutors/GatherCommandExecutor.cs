using RTDef.Abstraction.Commands;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class GatherCommandExecutor : CommandExecutorBase
    {

        public override void Stop()
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