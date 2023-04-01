using RTDef.Abstraction.Commands;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class MoveCommandExecutor : CommandExecutorBase
    {

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }

        public override void TryExecuteCommand(ICommand baseCommand)
        {
            var command = (IMoveCommand)baseCommand;

            Debug.Log($"Move to {command.Target}");
        }
    }
}