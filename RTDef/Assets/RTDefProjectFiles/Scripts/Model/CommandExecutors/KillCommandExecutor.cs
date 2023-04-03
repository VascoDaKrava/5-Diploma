using RTDef.Abstraction.Commands;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class KillCommandExecutor : CommandExecutorBase
    {

        public override void Stop()
        {
        }

        public override void TryExecuteCommand(ICommand _)
        {
            Debug.Log($"{this} recieve KILL");
        }
    }
}