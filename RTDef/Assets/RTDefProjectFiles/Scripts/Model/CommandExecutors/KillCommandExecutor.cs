using RTDef.Abstraction.Commands;
using RTDef.Enum;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class KillCommandExecutor : CommandExecutorBase
    {
        public override CommandName ExecutorCommandName => CommandName.Kill;

        public override void StopExecuteCommand()
        {
        }

        public override void TryExecuteCommand(ICommand _)
        {
            Debug.Log($"{this} recieve KILL");
        }
    }
}