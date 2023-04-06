using RTDef.Abstraction.Commands;
using UnityEngine;

namespace RTDef.Game.Commands
{
    public sealed class StopCommandExecutor : CommandExecutorBase
    {

        public override void Stop()
        {
            //Vector3.forward
        }

        public override void TryExecuteCommand(ICommand command)
        {
            var stopCommand = (IStopCommand)command;
            Debug.Log($"{this} recieve Stop {stopCommand.CommandToStop}");
        }
    }
}